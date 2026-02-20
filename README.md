# Eleven (Elevens card game)

Console card game where you remove pairs that sum to 11 or J-Q-K triples from a 3×3 table.

## Revision / changes

- Refactored to match the project UML (GameController, Deck, Table, MoveValidator, Card).
- GameController owns orchestration (StartGame, RefillTableToNine, SubmitSelection, CheckEndState); Table only has AddCard, RemoveCards, GetCardAt, etc., and does not depend on Deck.
- Validation logic moved into MoveValidator (IsValidSelection, HasLegalMoves).
- Display logic (3×3 layout, remaining count) moved from controller into Program.
- Card uses readonly fields for ValueForEleven and IsJack/IsQueen/IsKing set in the constructor.
- Deck.Count is a fixed readonly value (52); deck emptiness is exposed via IsEmpty().
- Table.Cards is assigned in the constructor to satisfy readonly rules; Table uses a List for visible cards with MaxCards = 9.
- Positions are 1–9 (3×3 grid); input is digit-only, no spaces required (ex: `12` or `459`); spaces and commas are stripped.
- No input prompt after game over; final table is shown again when the game ends (Win/Lose).

## Debugging with AI

- Used the assistant to fix a build error (CS0236) when a readonly field was initialized from another field in a field initializer; the fix was to assign it in the constructor.
- Asked for clarification on C# readonly semantics (when to use readonly fields vs get-only properties, and how to expose deck size vs “remaining” state).
