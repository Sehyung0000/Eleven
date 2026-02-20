using System;

namespace Eleven;

public enum Suit
{
    Clubs, Diamonds, Hearts, Spades
}

public class Card
{
    public readonly int Rank;
    public readonly Suit Suit;
    public readonly int ValueForEleven;
    public readonly bool IsJack;
    public readonly bool IsQueen;
    public readonly bool IsKing;

    public Card(Suit suit, int rank)
    {
        Suit = suit;
        Rank = rank;
        ValueForEleven = rank >= 1 && rank <= 10 ? rank : 0;
        IsJack = rank == 11;
        IsQueen = rank == 12;
        IsKing = rank == 13;
    }

    public override string ToString()
    {
        string rankStr = Rank switch
        {
            1 => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
            _ => Rank.ToString()
        };
        string suitStr = Suit switch
        {
            Suit.Clubs => "♣",
            Suit.Diamonds => "♦",
            Suit.Hearts => "♥",
            Suit.Spades => "♠",
            _ => Suit.ToString()
        };
        return $"({rankStr}, {suitStr})";
    }
}
