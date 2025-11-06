//Class ElevensGame
//- deck: Deck
//- table: Card[9]
//+ ElevensGame()
//+ StartGame(): void shuffles deck and deals 9 cards
//+ DisplayTable(): void displays/deals 9 cards on the table
//+ SelectCards(selected: int[]): SelectionResult 
//      selects cards on the table and returns a result indicating success or error type
//      removes selected cards if returns success
//+ HasAvailableMoves(): bool checks if there are any valid moves left
//+ IsGameOver(): bool checks if the game is over (deck is empty and no moves left)
//+ HasUserWon(): bool checks if the user has won the game (deck is empty and no cards on the table)
//+ ResetGame(): void resets the game to initial state
//+ GetRemainingTableCount() : int (need to implement new RemainingCount:int in deck class)
//      returns remaining count of cards

//Enum SelectionResult
//+ Success
//+ InvalidCardCount
//+ TwoCardsSumNotEleven
//+ ThreeCardsNotJQK
//+ DuplicateSelection
//+ IndexOutOfRange
//+ NoCardsSelected