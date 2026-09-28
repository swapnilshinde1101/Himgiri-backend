using System;
using Himgiri.Core.Helpers;
using Xunit;

namespace Himgiri.Tests.Unit;

/// <summary>
/// Regression coverage for the dashboard's "Revenue Today" timezone bug: Order.CreatedAt is
/// stored in UTC, but "today" must mean the current calendar day in India (fixed UTC+5:30, no
/// DST). Using DateTime.UtcNow.Date directly rolls the day boundary over at 5:30 AM IST instead
/// of local midnight, so for the first 5.5 hours of every IST day the metric silently shows the
/// previous day's total. Tested as a pure function since GetDashboardStatsAsync's SumAsync(decimal)
/// call can't run against this test suite's SQLite provider (SQLite can't translate SUM over a
/// decimal column) — the boundary math is exactly the part that was actually wrong.
/// </summary>
public class IstDateHelperTests
{
    [Fact]
    public void GetTodayBoundariesUtc_StartIsExactlyMidnightIst()
    {
        var (startUtc, _) = IstDateHelper.GetTodayBoundariesUtc();

        var startAsIst = startUtc.Add(TimeSpan.FromHours(5.5));
        Assert.Equal(TimeSpan.Zero, startAsIst.TimeOfDay);
    }

    [Fact]
    public void GetTodayBoundariesUtc_EndIsExactlyOneDayAfterStart()
    {
        var (startUtc, endUtc) = IstDateHelper.GetTodayBoundariesUtc();

        Assert.Equal(startUtc.AddDays(1), endUtc);
    }

    [Fact]
    public void GetTodayBoundariesUtc_CurrentInstantFallsWithinTheBoundaries()
    {
        var (startUtc, endUtc) = IstDateHelper.GetTodayBoundariesUtc();

        var nowUtc = DateTime.UtcNow;
        Assert.True(nowUtc >= startUtc && nowUtc < endUtc);
    }

    [Fact]
    public void GetTodayBoundariesUtc_StartIsAlways1830UtcThePreviousDay_NotUtcMidnight()
    {
        // The whole point of the fix: since IST midnight is always exactly 5.5 hours ahead of
        // UTC, the boundary this method returns is always 18:30:00 UTC on the previous calendar
        // day — never 00:00:00 UTC (which is what the old, buggy DateTime.UtcNow.Date logic used).
        var (startUtc, _) = IstDateHelper.GetTodayBoundariesUtc();

        Assert.Equal(18, startUtc.Hour);
        Assert.Equal(30, startUtc.Minute);
    }

    [Fact]
    public void ToIstDayStartUtc_ConvertsCalendarDateToPreviousDay1830Utc()
    {
        // A bare "15 March" date from an admin's date-range picker means 15 March 00:00 IST,
        // which is 14 March 18:30 UTC — not 15 March 00:00 UTC (what naive SpecifyKind gave).
        var calendarDate = new DateTime(2026, 3, 15);

        var startUtc = IstDateHelper.ToIstDayStartUtc(calendarDate);

        Assert.Equal(new DateTime(2026, 3, 14, 18, 30, 0), startUtc);
    }

    [Fact]
    public void ToIstDayStartUtc_IgnoresAnyTimeComponentOnTheInputDate()
    {
        // Only the calendar date matters — any time-of-day on the input (e.g. from a DateTime
        // that wasn't a clean midnight) must not leak into the result.
        var calendarDateWithTime = new DateTime(2026, 3, 15, 14, 45, 30);

        var startUtc = IstDateHelper.ToIstDayStartUtc(calendarDateWithTime);

        Assert.Equal(new DateTime(2026, 3, 14, 18, 30, 0), startUtc);
    }

    [Fact]
    public void ToIstDayStartUtc_ExclusiveEndBound_CoversTheFullEndDate()
    {
        // The correct pattern for an inclusive "through end date" filter is
        // CreatedAt < ToIstDayStartUtc(endDate.AddDays(1)) — verify that instant is exactly
        // 24 hours after the end date's own IST midnight, i.e. the full day is covered.
        var endDate = new DateTime(2026, 3, 15);

        var endDateStartUtc = IstDateHelper.ToIstDayStartUtc(endDate);
        var exclusiveUpperBoundUtc = IstDateHelper.ToIstDayStartUtc(endDate.AddDays(1));

        Assert.Equal(endDateStartUtc.AddDays(1), exclusiveUpperBoundUtc);
    }
}
