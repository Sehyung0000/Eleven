using System;

namespace Eleven;

public class Deck
{
    private List<Card> _cards = new();

    public readonly int Count = 52;

    public Deck()
    {
        foreach (Suit suit in Enum.GetValues<Suit>())
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    public bool IsEmpty() => _cards.Count == 0;

    public void Shuffle()
    {
        Random random = new Random();
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Card DealCard()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("Deck is empty.");
        int last = _cards.Count - 1;
        Card card = _cards[last];
        _cards.RemoveAt(last);
        return card;
    }
}
