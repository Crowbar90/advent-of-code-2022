namespace Day02;

public enum Shape
{
    Rock,
    Paper,
    Scissors
}

public static class ShapeExtensions
{
    public static Shape FromChar(char c) =>
        c switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    
    
}