using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Deck
{
    List<Card> cards = new List<Card>();

    //Deck Constructor
    public Deck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(rank, suit));
            }
        }
    }

    // Property to get the remaining count of cards in the deck
    public int RemainingCount
    {
        get { return cards.Count; }
    }

    //Implement a property to get Cards
    public List<Card> Cards
    {
        get { return cards; }
    }

    //Takes top card from deck (if deck is not empty, otherwise return null)
    public Card TakeTopCard()
    {
        if (cards.Count == 0)
        {
            return new Card(Rank.Ace, Suit.Spades); // Default card to avoid null
        }

        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }

    //Shuffle Method
    public void Shuffle()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    //Cut method
    public void Cut(int index)
    {
        if (index < 0 || index >= cards.Count)
        {
            return;
        }

        List<Card> top = cards.GetRange(0, index);
        List<Card> bottom = cards.GetRange(index, cards.Count - index);
        cards.Clear();
        cards.AddRange(bottom);
        cards.AddRange(top);
    }
}

