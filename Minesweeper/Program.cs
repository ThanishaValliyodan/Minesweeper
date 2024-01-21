public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Minesweeper!");
        var game = new MinesweeperGame();
        game.StartGame();
    }
}

