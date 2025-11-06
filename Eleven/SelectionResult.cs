using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum SelectionResult
{
    Success,
    InvalidCardCount,
    TwoCardsSumNotEleven,
    ThreeCardsNotJQK,
    DuplicateSelection,
    IndexOutOfRange,
    NoCardsSelected
}