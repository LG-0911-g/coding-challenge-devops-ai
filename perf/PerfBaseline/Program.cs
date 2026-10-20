
using System.Diagnostics;
using CodingChallenge.Api.Data;
using CodingChallenge.Api.Managers;
using Microsoft.EntityFrameworkCore;

const int boardId = 1;

var dbPath = Path.GetFullPath(
    "src/CodingChallenge.Api/codingchallenge.db");

if (!File.Exists(dbPath))
{
    throw new FileNotFoundException(
        "Database not found", dbPath);
}

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={dbPath};Mode=ReadOnly")
    .Options;

Console.WriteLine("=== Performance Baseline ===");
Console.WriteLine($"Board ID: {boardId}");
Console.WriteLine();

for (int i = 1; i <= 3; i++)
{
    await using var context = new AppDbContext(options);
    var manager = new ComponentManager(context);

    var stopwatch = Stopwatch.StartNew();

    var components =
        await manager.GetByBoardIdAsync(boardId);

    stopwatch.Stop();

    Console.WriteLine(
        $"Run {i}: {stopwatch.ElapsedMilliseconds} ms | " +
        $"{components.Count} components");

     
}
