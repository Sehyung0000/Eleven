

public class Deck
{
  private List<Card> cards = new List<Card>();

  public Deck()
  {
    for {int i = 0; i < Card.Suits.Length; i++)
    {
      for (int j = 0; j < Card.Values.Length; j++)
      {
        cards.Add(new Card(Card.Suits[i], Card.Values[j]));
      }
    }
  }

  public void shuffle()
  {
    Random random = new Random();
    cards = cards.OrderBy(card => random.Next()).ToList();
  }
  }
}