using System;

public class Deck
{
  private Card[] cards;
  public int remainingCards;

  public Deck()
  {
    cards = new Card[52];
    remainingCards = 52;

    int index = 0;
    for (int i = 0; i < Card.Suits.Length; i++)
    {
      for (int j = 0; j < Card.Values.Length; j++)
      {
        cards[index] = new Card(Card.Suits[i], Card.Values[j]);
        index++;
      }
    }
  }

  public void shuffle()
  {
    Random random = new Random();
    for (int i = cards.Length - 1; i > 0; i--)
    {
      int j = random.Next(0, i + 1);
      Card temp = cards[i];
      cards[i] = cards[j];
      cards[j] = temp;
    }
    remainingCards = 52;
  }

  public Card deal()
  {
    remainingCards--;
    return cards[52 - remainingCards - 1];
  }
}