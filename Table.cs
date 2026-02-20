using System;

namespace Eleven;

public class Table
{

    private readonly List<Card> _visibleCards = new();

    public readonly int MaxCards = 9;
    public readonly IReadOnlyList<Card> Cards;

    public Table()
    {
        Cards = _visibleCards;
    }

    public int Count() => _visibleCards.Count;

    public bool IsEmpty() => _visibleCards.Count == 0;

    public void AddCard(Card card)
    {
        if (_visibleCards.Count >= MaxCards)
            throw new InvalidOperationException($"Table cannot hold more than {MaxCards} cards.");
        _visibleCards.Add(card);
    }

    public Card GetCardAt(int index) => _visibleCards[index];

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
    {
        var result = new List<Card>();
        foreach (int i in indices)
        {
            if (i >= 0 && i < _visibleCards.Count)
                result.Add(_visibleCards[i]);
        }
        return result;
    }

    public void RemoveCards(IEnumerable<Card> cards)
    {
        var set = new HashSet<Card>(cards);
        _visibleCards.RemoveAll(c => set.Contains(c));
    }
}
