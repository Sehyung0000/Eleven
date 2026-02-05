using System;

public class Card
{
    private int value;
    private string suit;

    public static string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

    public static int[] Values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    
    public Card (string suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public int getValue()
    {
        return value;
    }

    public override string ToString()
    {
        return $"{value} of {suit}";
    }
}
