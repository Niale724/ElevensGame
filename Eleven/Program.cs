using System;
using System.Linq;

var game = new ElevensGame();
game.StartGame();

Console.WriteLine("   Elevens Solitaire   ");
Console.WriteLine("=======================");

while (true)
{
    Console.WriteLine("Current Table:");
    game.DisplayTable();
    Console.WriteLine();
    Console.WriteLine($"Remaining cards in deck: {game.RemainingDeckCount}");
    Console.WriteLine($"Cards on table: {game.GetRemainingTableCount()}");
    Console.WriteLine("Enter 'R' to reset the game or 'Q' to quit.");

    if (game.IsGameOver())
    {
        if (game.HasUserWon())
            Console.WriteLine("Congratulations! You have won the game!");
        else
            Console.WriteLine("Game over! No more moves available.");
        break;
    }

    Console.WriteLine("Please select cards to remove (enter indices, separated by spaces)");
    string input = Console.ReadLine()?.Trim() ?? "";

    if (input.ToUpper() == "Q")
    {
        Console.WriteLine("Quitting the game...");
        break;
    }

    else if (input.ToUpper() == "R")
    {
        Console.WriteLine("Resetting the game...");
        Console.WriteLine("Game has been reset!");
        game.ResetGame();
        continue;
    }

    try
    {
        var selected = input.Split(' ')
                          .Where(s => !string.IsNullOrWhiteSpace(s))
                          .Select(int.Parse)
                          .ToArray();

        var result = game.SelectCards(selected);

        if (result == SelectionResult.Success)
        {
            Console.WriteLine("Card removed successfully!");
        }
        else
        {
            Console.WriteLine($"Error: {GetErrorMessage(result)}");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter valid numbers!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
}

string GetErrorMessage(SelectionResult result)
{
    return result switch
    {
        SelectionResult.NoCardsSelected => "No cards selected",
        SelectionResult.InvalidCardCount => "Please select 2 or 3 cards",
        SelectionResult.DuplicateSelection => "Duplicate cards selected",
        SelectionResult.IndexOutOfRange => "Card index out of range",
        SelectionResult.TwoCardsSumNotEleven => "The sum of two cards must be 11",
        SelectionResult.ThreeCardsNotJQK => "Three cards must be one each of J, Q, and K",
        _ => "Unknown error"
    };
}


