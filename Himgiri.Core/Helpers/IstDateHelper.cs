using System;

namespace Himgiri.Core.Helpers;

// India Standard Time is a fixed UTC+5:30 offset with no daylight saving time, so a hardcoded
// offset is correct here and avoids any dependency on the host OS's timezone database.
public static class IstDateHelper
{
    private static readonly TimeSpan IstOffset = TimeSpan.FromHours(5.5);

    // Returns the UTC instants bounding the current calendar day in India (midnight IST today to
    // midnight IST tomorrow) — for comparing against UTC-stored timestamps like Order.CreatedAt
    // without the day boundary silently rolling over at 5:30 AM IST instead of local midnight.
    public static (DateTime StartUtc, DateTime EndUtc) GetTodayBoundariesUtc()
    {
        var todayIst = DateTime.UtcNow.Add(IstOffset).Date;
        var startUtc = todayIst.Subtract(IstOffset);
        return (startUtc, startUtc.AddDays(1));
    }

    // Converts a bare calendar date (e.g. from an admin's <input type="date"> date-range picker,
    // which carries no timezone info and is meant as an IST calendar day) into the UTC instant of
    // that day's IST midnight. Without this, DateTime.SpecifyKind(date, DateTimeKind.Utc) would
    // treat "15 March" as 15 March 00:00 UTC (= 15 March 5:30 AM IST) instead of what the admin
    // actually picked (15 March 00:00 IST = 14 March 18:30 UTC) — shifting the reported date
    // range by 5.5 hours at both ends.
    public static DateTime ToIstDayStartUtc(DateTime calendarDate)
    {
        return calendarDate.Date.Subtract(IstOffset);
    }
}
