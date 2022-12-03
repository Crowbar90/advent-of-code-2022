using System.IO.Compression;

namespace Day02;

public static class PuzzleSolver
{
    public static ValueTask<int> SolvePuzzle1(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .GetShapes()
            .GetResults()
            .CalculateScore());
    
    public static ValueTask<int> SolvePuzzle2(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .GetShapesAndResults()
            .GetShapeToPlay()
            .CalculateScore());

    private static IEnumerable<(Shape, Shape)> GetShapes(
        this IEnumerable<string> inputLines) =>
        inputLines.Select(l => (ShapeExtensions.FromChar(l[0]), ShapeExtensions.FromChar(l[2])));

    private static IEnumerable<(Shape, Result)> GetResults(
        this IEnumerable<(Shape, Shape)> shapes) =>
        shapes.Select(s => (s.Item2, ResultExtensions.CalculateResult(s.Item1, s.Item2)));

    private static IEnumerable<(Shape, Result)> GetShapesAndResults(
        this IEnumerable<string> inputLines) =>
        inputLines.Select(l => (ShapeExtensions.FromChar(l[0]), ResultExtensions.FromChar(l[2])));

    private static IEnumerable<(Shape, Result)> GetShapeToPlay(
        this IEnumerable<(Shape, Result)> shapes) =>
        shapes.Select(s => s.Item2 switch
        {
            Result.Win => ((Shape)(((int)s.Item1 + 1) % 3), s.Item2),
            Result.Draw => (s.Item1, s.Item2),
            Result.Loss => ((Shape)(((int)s.Item1 + 2) % 3), s.Item2),
            _ => throw new ArgumentOutOfRangeException()
        });

    private static int CalculateScore(
        this IEnumerable<(Shape, Result)> results)
    {
        return results.Aggregate(0,
            (acc, r) =>
                acc += r.Item1 switch
                {
                    Shape.Rock => 1,
                    Shape.Paper => 2,
                    Shape.Scissors => 3,
                    _ => throw new ArgumentOutOfRangeException()
                } + r.Item2 switch
                {
                    Result.Win => 6,
                    Result.Draw => 3,
                    Result.Loss => 0,
                    _ => throw new ArgumentOutOfRangeException()
                });
    }
}