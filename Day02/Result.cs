using System.Diagnostics;

namespace Day02;

public enum Result
{
    Win,
    Draw,
    Loss
}

public static class ResultExtensions
{
    public static Result FromChar(char c) =>
        c switch
        {
            'X' => Result.Loss,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    
    public static Result CalculateResult(Shape opponent, Shape selected) =>
        (opponent, selected) switch
        {
            _ when (int)selected == (int)opponent => Result.Draw,
            _ when (int)selected == ((int)opponent + 1) % 3 => Result.Win,
            _ => Result.Loss,
        };
}