using FluentAssertions;

namespace Day03.Tests;

public class SampleInputTests
{
    private readonly string[] _inputLines;
    
    public SampleInputTests() => _inputLines = File.ReadLines("Inputs/puzzleInput.txt").ToArray();

    [Fact]
    public async Task Test_Puzzle1() => (await _inputLines.SolvePuzzle1()).Should().Be(157);

    [Fact]
    public async Task Test_Puzzle2() => (await _inputLines.SolvePuzzle2()).Should().Be(70);
}