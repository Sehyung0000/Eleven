using System;

namespace Eleven;

public enum GameState { NotStarted, Running, Won, Lost }

public class GameController
{
    private Deck _deck;
    private Table _table;
    private MoveValidator _validator;

    public GameState State { get; private set; } = GameState.NotStarted;
    public Deck Deck => _deck;
    public Table Table => _table;

    public GameController(Deck? deck = null, Table? table = null, MoveValidator? validator = null)
    {
        _deck = deck ?? new Deck();
        _table = table ?? new Table();
        _validator = validator ?? new MoveValidator();
    }

    public void StartGame()
    {
        Console.WriteLine("=== ELEVENS GAME ===\n");
        State = GameState.Running;
        _deck.Shuffle();
        RefillTableToNine();
    }

    public void RefillTableToNine()
    {
        while (_table.Count() < _table.MaxCards && !_deck.IsEmpty())
        {
            _table.AddCard(_deck.DealCard());
        }
    }

    public bool SubmitSelection(IReadOnlyList<int> indices, out string message)
    {
        message = "";
        if (State != GameState.Running)
        {
            message = "Game is not in progress.";
            return false;
        }

        var selected = _table.GetCardsByIndices(indices);
        if (selected.Count != indices.Count)
        {
            message = "Invalid indices.";
            return false;
        }

        if (!_validator.IsValidSelection(selected))
        {
            message = "Invalid selection.";
            return false;
        }

        _table.RemoveCards(selected);
        RefillTableToNine();
        CheckEndState();
        return true;
    }

    public void CheckEndState()
    {
        if (CheckWin())
        {
            State = GameState.Won;
            Console.WriteLine("\n=== YOU WIN ===");
            return;
        }
        if (CheckLose())
        {
            State = GameState.Lost;
            Console.WriteLine("\n=== YOU LOSE ===");
        }
    }

    public bool CheckWin() => _table.IsEmpty() && _deck.IsEmpty();

    public bool CheckLose() => !_validator.HasLegalMoves(_table.Cards);
}
