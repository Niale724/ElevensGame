using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    private Rank rank;
    private Suit suit;
    private bool isFaceUp = false;

    public Card(Rank rank, Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public Rank Rank
    {
        get { return rank; }
    }

    public Suit Suit
    {
        get { return suit; }
    }

    public void FlipOver()
    {
        isFaceUp = !isFaceUp;
    }
}
