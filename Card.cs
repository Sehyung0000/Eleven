using System;

public class Card
{
    private int value;
    private string suit;

    public static string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

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
