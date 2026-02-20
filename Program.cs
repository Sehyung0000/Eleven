using System;
using Eleven;

class Program
{
    static void Main(string[] args)
    {
        GameController game = new GameController();
        game.StartGame();

        void PrintTable()
        {
            Console.WriteLine("\n=== Table ===");
            const int cols = 3;
            for (int row = 0; row < cols; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int i = row * cols + col;
                    int num = i + 1;
                    string cell = i < game.Table.Count()
                        ? $"{num}: {game.Table.GetCardAt(i)}"
                        : $"{num}: [Empty]";
                    Console.Write(cell.PadRight(14));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        while (game.State == GameState.Running)
        {
            PrintTable();
            game.CheckEndState();
            if (game.State != GameState.Running)
                break;

            Console.Write("Enter positions 1–9 (12 or 459, no spaces needed): ");
            string? raw = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(raw)) break;

            try
            {
                string digits = raw.Replace(" ", "").Replace(",", "");
                if (digits.Length == 0) continue;
                int[] indices = new int[digits.Length];
                for (int i = 0; i < digits.Length; i++)
                {
                    if (digits[i] < '1' || digits[i] > '9')
                        throw new FormatException();
                    indices[i] = digits[i] - '1';
                }

                if (!game.SubmitSelection(indices, out string message))
                    Console.WriteLine(message);
                if (game.State != GameState.Running)
                    PrintTable();
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
