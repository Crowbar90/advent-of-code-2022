using Day03;

var inputLines = File
    .ReadLines("Inputs/puzzleInput.txt")
    .ToArray();

var puzzle1Result = await inputLines.SolvePuzzle1();

Console.WriteLine($"Puzzle 1: {puzzle1Result}");

var puzzle2Result = await inputLines.SolvePuzzle2();

Console.WriteLine($"Puzzle 2: {puzzle2Result}");