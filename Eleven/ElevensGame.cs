using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ElevensGame
{
    private Deck deck;
    private Card?[] table;

    public ElevensGame()
    {
        deck = new Deck();
        table = new Card?[9];
    }

    public void StartGame()
    {
        deck.Shuffle();
        for (int i = 0; i < 9; i++)
        {
            table[i] = deck.TakeTopCard();
            table[i]!.FlipOver();
        }
    }

    public void DisplayTable()
    {
        for (int i = 0; i < 9; i++)
        {
            if (table[i] != null)
            {
                Console.Write($"[{i}]{table[i]!.Rank}{table[i]!.Suit} ");
            }
        }
    }

    public SelectionResult SelectCards(int[] selected)
    {
        // Validate Errors
        // No cards selected
        if (selected == null || selected.Length == 0)
            return SelectionResult.NoCardsSelected;

        // Cards selected <2 or >3
        if (selected.Length == 1 || selected.Length > 3)
            return SelectionResult.InvalidCardCount;

        // Duplicate selections
        if (selected.Distinct().Count() != selected.Length)
            return SelectionResult.DuplicateSelection;

        // Selected card index <0 or >8
        if (selected.Any(index => index < 0 || index >= 9))
            return SelectionResult.IndexOutOfRange;

        // Selected cards doesnt exist
        if (selected.Any(index => table[index] == null))
            return SelectionResult.IndexOutOfRange;

        // Check for valid combinations
        if (selected.Length == 2)
        {
            int sum = GetCardValue(table[selected[0]]) + GetCardValue(table[selected[1]]);
            if (sum != 11)
                return SelectionResult.TwoCardsSumNotEleven;
        }
        else if (selected.Length == 3)
        {
            if (!IsJQKCombination(selected))
                return SelectionResult.ThreeCardsNotJQK;
        }

        ReplaceCards(selected);

        return SelectionResult.Success;

    }
    
    private int GetCardValue(Card? card)
    {
        if (card == null)
            return 0;

        switch (card.Rank)
        {
            case Rank.Ace:
                return 1;
            case Rank.Two:
                return 2;
            case Rank.Three:
                return 3;
            case Rank.Four:
                return 4;
            case Rank.Five:
                return 5;
            case Rank.Six:
                return 6;
            case Rank.Seven:
                return 7;
            case Rank.Eight:
                return 8;
            case Rank.Nine:
                return 9;
            case Rank.Ten:
                return 10;
            case Rank.Jack:
            case Rank.Queen: 
            case Rank.King:
                return 0;
            default:
                return 0;
        }
    }

    private bool IsJQKCombination(int[] index)
    {
        var cards = index.Select(i => table[i]).ToArray();


        bool hasJack = cards.Any(card => card!.Rank == Rank.Jack);
        bool hasQueen = cards.Any(card => card!.Rank == Rank.Queen);
        bool hasKing = cards.Any(card => card!.Rank == Rank.King);
        return hasJack && hasQueen && hasKing;
    }
    
    private void ReplaceCards(int[] i)
    {
        foreach(int index in i)
        {
            if (deck.RemainingCount > 0)
            {
                // Still have cards in the deck: take a new card and flip it over
                table[index] = deck.TakeTopCard();
                table[index]!.FlipOver();
            }
            else
            {
                // Deck is empty: remove the card from the table (set to null)
                table[index] = null;
            }
        }
    }
    //+ HasAvailableMoves(): bool checks if there are any valid moves left
    //+ IsGameOver(): bool checks if the game is over (deck is empty and no moves left)
    //+ HasUserWon(): bool checks if the user has won the game (deck is empty and no cards on the table)
    //+ ResetGame(): void resets the game to initial state
    //+ GetRemainingTableCount() : int (need to implement new RemainingCount:int in deck class)
    //      returns remaining count of cards
}