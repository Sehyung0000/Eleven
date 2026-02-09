using System;

class Program
{
    static void Main(string[] args)
    {
        GameController game = new GameController();
        game.startGame();

        while (!game.isGameOver())
        {
            game.displayStatus();
            
            Console.Write("Enter positions (e.g., 0 1 or 2 4 5): ");
            string input = Console.ReadLine();
            
            try
            {
                string[] parts = input.Split(' ');
                int[] positions = new int[parts.Length];
                
                for (int i = 0; i < parts.Length; i++)
                {
                    positions[i] = int.Parse(parts[i]);
                }

                game.submitSelection(positions);
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}