namespace Day03;

public static class PuzzleSolver
{
    public static ValueTask<int> SolvePuzzle1(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .ParseInputLines1()
            .Sum(GetPriority));
    
    public static ValueTask<int> SolvePuzzle2(
        this IEnumerable<string> inputLines) =>
        ValueTask.FromResult(inputLines
            .ParseInputLines2()
            .Sum(GetPriority));

    private static IEnumerable<char> ParseInputLines1(this IEnumerable<string> inputLines) =>
        inputLines.Select(line =>
            line.GetSplitPoint()
                .SplitInHalf()
                .GetCommonItem());

    private static IEnumerable<char> ParseInputLines2(this IEnumerable<string> inputLines) =>
        inputLines.ChunkByGroup()
            .Select(chunk => chunk.GetBadgeItem());

    private static (IEnumerable<char> inputString, int splitPoint) GetSplitPoint(this string inputString) =>
        (inputString, inputString.Length / 2);

    private static (IEnumerable<char> left, IEnumerable<char> right) SplitInHalf(
        this (IEnumerable<char> inputString, int splitPoint) inputStringSplit) =>
        (inputStringSplit.inputString.Take(inputStringSplit.splitPoint),
            inputStringSplit.inputString.TakeLast(inputStringSplit.splitPoint));

    private static char GetCommonItem(this (IEnumerable<char> left, IEnumerable<char> right) splitString) =>
        splitString.left.First(c => splitString.right.Contains(c));

    private static int GetPriority(this char item) =>
        item switch
        {
            >= 'a' and <= 'z' => item - 'a' + 1,
            >= 'A' and <= 'Z' => item - 'A' + 27,
            _ => throw new ArgumentOutOfRangeException(nameof(item), item, null)
        };

    private static IEnumerable<string[]> ChunkByGroup(this IEnumerable<string> inputStrings) =>
        inputStrings.Chunk(3);

    private static char GetBadgeItem(this string[] groupStrings) =>
        groupStrings.First()
            .First(c =>
                groupStrings
                    .Skip(1)
                    .All(s => s.Contains(c)));
}