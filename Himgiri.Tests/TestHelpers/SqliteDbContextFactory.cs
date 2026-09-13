using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Himgiri.Infrastructure.Data;

namespace Himgiri.Tests.TestHelpers;

/// <summary>
/// Builds a real (Sqlite) HimgiriDbContext for tests that need actual EF Core
/// behavior — optimistic concurrency checks and ExecuteUpdateAsync — that the
/// InMemory provider cannot faithfully emulate.
/// </summary>
public static class SqliteDbContextFactory
{
    public static SqliteConnection CreateOpenConnection()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        // These tests seed Orders/Items directly without also seeding their State/Category
        // parent rows (irrelevant to what's under test), which Sqlite's FK enforcement
        // would otherwise reject. Real Postgres FK behavior isn't what these tests cover.
        using var pragma = connection.CreateCommand();
        pragma.CommandText = "PRAGMA foreign_keys = OFF;";
        pragma.ExecuteNonQuery();

        return connection;
    }

    public static HimgiriDbContext CreateContext(SqliteConnection connection)
    {
        var options = new DbContextOptionsBuilder<HimgiriDbContext>()
            .UseSqlite(connection)
            .Options;
        return new HimgiriDbContext(options);
    }
}
