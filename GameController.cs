using System;

public class GameController
{
    private Deck deck;
    private Table table;
    private bool winOrLoss;

    public GameController()
    {
        deck = new Deck();
        table = new Table();
        winOrLoss = false;
    }

    public void startGame()
    {
        Console.WriteLine("=== ELEVENS GAME ===\n");
        deck.shuffle();
        table.initialize(deck);
    }

    public void displayStatus()
    {
        Console.WriteLine($"Remaining cards: {deck.remainingCards}");
        table.displayCards();
        checkEndState();
    }

    public void submitSelection(int[] positions)
    {
        if (!validate(positions))
        {
            Console.WriteLine("Invalid selection!");
            return;
        }

        table.remove(positions);
        table.refill(deck, deck.remainingCards);
        checkEndState();
    }

    public bool validate(int[] positions)
    {
        Card[] cards = table.getCards();
        
        for (int i = 0; i < positions.Length; i++)
        {
            if (cards[positions[i]] == null)
            {
                return false;
            }
        }

        if (positions.Length == 2)
        {
            int sum = cards[positions[0]].getValue() + cards[positions[1]].getValue();
            if (sum == 11)
            {
                Console.WriteLine($"Valid: {cards[positions[0]]} + {cards[positions[1]]} = 11");
                return true;
            }
            return false;
        }
        else if (positions.Length == 3)
        {
            bool hasJ = false, hasQ = false, hasK = false;
            for (int i = 0; i < 3; i++)
            {
                int val = cards[positions[i]].getValue();
                if (val == 11) hasJ = true;
                if (val == 12) hasQ = true;
                if (val == 13) hasK = true;
            }
            
            if (hasJ && hasQ && hasK)
            {
                Console.WriteLine("Valid: J-Q-K combination");
                return true;
            }
            return false;
        }

        return false;
    }

    public void checkEndState()
    {
        Card[] cards = table.getCards();
        int emptyCount = 0;
        
        for (int i = 0; i < 9; i++)
        {
            if (cards[i] == null) emptyCount++;
        }

        if (emptyCount == 9 && deck.remainingCards == 0)
        {
            winOrLoss = true;
            Console.WriteLine("\n=== YOU WIN! ===");
            return;
        }

        if (!hasValidMoves(cards))
        {
            winOrLoss = true;
            Console.WriteLine("\n=== YOU LOSE! No valid moves remaining. ===");
        }
    }

    private bool hasValidMoves(Card[] cards)
    {
        for (int i = 0; i < 9; i++)
        {
            if (cards[i] == null) continue;

            for (int j = i + 1; j < 9; j++)
            {
                if (cards[j] == null) continue;

                if (cards[i].getValue() + cards[j].getValue() == 11)
                {
                    return true;
                }
            }
        }

        bool hasJ = false, hasQ = false, hasK = false;
        for (int i = 0; i < 9; i++)
        {
            if (cards[i] != null)
            {
                int val = cards[i].getValue();
                if (val == 11) hasJ = true;
                if (val == 12) hasQ = true;
                if (val == 13) hasK = true;
            }
        }

        return hasJ && hasQ && hasK;
    }

    public bool isGameOver()
    {
        return winOrLoss;
    }
}
