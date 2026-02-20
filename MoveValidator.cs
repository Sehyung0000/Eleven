namespace Eleven;

public class MoveValidator
{
    public bool IsValidSelection(IReadOnlyList<Card> selected)
    {
        if (selected == null || (selected.Count != 2 && selected.Count != 3))
            return false;
        if (selected.Count == 2)
            return IsValidPair(selected[0], selected[1]);
        return IsValidTriple(selected);
    }

    public bool HasLegalMoves(IReadOnlyList<Card> tableCards)
    {
        if (tableCards == null || tableCards.Count < 2)
            return false;
        int n = tableCards.Count;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (IsValidPair(tableCards[i], tableCards[j]))
                    return true;
            }
        }

        if (n >= 3)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        var three = new[] { tableCards[i], tableCards[j], tableCards[k] };
                        if (IsValidTriple(three))
                            return true;
                    }
                }
            }
        }

        return false;
    }

    private static bool IsValidPair(Card a, Card b)
    {
        return a.ValueForEleven + b.ValueForEleven == 11;
    }

    private static bool IsValidTriple(IReadOnlyList<Card> three)
    {
        if (three == null || three.Count != 3)
            return false;
        bool hasJack = false, hasQueen = false, hasKing = false;
        foreach (Card c in three)
        {
            if (c.IsJack) hasJack = true;
            if (c.IsQueen) hasQueen = true;
            if (c.IsKing) hasKing = true;
        }
        return hasJack && hasQueen && hasKing;
    }
}
