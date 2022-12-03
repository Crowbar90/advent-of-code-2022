namespace Day01;

public static class PuzzleSolver
{
    public static ValueTask<int> SolvePuzzle1(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .GetCaloriesTotals()
            .Max());
    
    public static ValueTask<int> SolvePuzzle2(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .GetCaloriesTotals()
            .OrderByDescending(c => c)
            .Take(3)
            .Sum());

    private static IEnumerable<int> GetCaloriesTotals(
        this IEnumerable<string> inputLines)
    {
        var acc = 0;
        foreach (var line in inputLines)
            switch (line)
            {
                case "":
                    yield return acc;
                    acc = 0;
                    break;
                default:
                    acc += int.Parse(line);
                    break;
            }
        yield return acc;
    }
}