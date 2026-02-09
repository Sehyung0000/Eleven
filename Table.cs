using System;

public class Table
{
    private Card[] cardsOnTable;

    public Table()
    {
        cardsOnTable = new Card[9];
        for (int i = 0; i < 9; i++)
        {
            cardsOnTable[i] = null;
        }
    }

    public void initialize(Deck deck)
    {
        for (int i = 0; i < 9; i++)
        {
            cardsOnTable[i] = deck.deal();
        }
    }

    public void displayCards()
    {
        Console.WriteLine("\n=== Table ===");
        for (int i = 0; i < 9; i++)
        {
            Console.Write($"{i}: ");
            if (cardsOnTable[i] != null)
            {
                Console.Write(cardsOnTable[i]);
            }
            else
            {
                Console.Write("[Empty]");
            }
            
            if (i < 8)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("\n");
    }

    public Card[] getCards()
    {
        return cardsOnTable;
    }

    public void remove(int[] positions)
    {
        foreach (int pos in positions)
        {
            cardsOnTable[pos] = null;
        }
    }

    public void refill(Deck deck, int remainingCards)
    {
        if (remainingCards <= 0) return;
        
        for (int i = 0; i < 9; i++)
        {
            if (cardsOnTable[i] == null && remainingCards > 0)
            {
                cardsOnTable[i] = deck.deal();
                remainingCards--;
            }
        }
    }
}
