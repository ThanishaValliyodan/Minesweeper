using Minesweeper;
public class MinesweeperGame
{
    internal int gridSize;
    internal int mineCount;
    private char[,]? board;
    private bool[,]? mines;
    private bool gameWon = false;

    public void StartGame()
    {
        //set up the grid size and number of mines from user input
        gridSize = GetValidInput("Enter the size of the grid (e.g., 4 for a 4x4 grid): ", Validation.ValidateGridSize);
        mineCount = GetValidInput("Enter the number of mines to place on the grid (maximum is 35% of the total squares): ", input => Validation.ValidateMineCount(input, gridSize));
        InitializeBoard();
        PlayGame();
    }

    //Initialize the board with value '_'
    private void InitializeBoard()
    {
        board = new char[gridSize, gridSize];
        mines = new bool[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                board[i, j] = '_';
            }
        }
        PlaceMines();
    }

    //Get input from user and validate the input
    private int GetValidInput(string prompt, Func<string, (bool, string)> validationMethod)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            var (isValid, validationMessage) = validationMethod(input);
            if (isValid)
            {
                return Convert.ToInt32(input);
            }
            Console.WriteLine(validationMessage);
        }
    }

    //Randomly place the mines in the grid
    private void PlaceMines()
    {
        Random rand = new Random();
        for (int i = 0; i < mineCount; i++)
        {
            int row, col;
            do
            {
                row = rand.Next(gridSize);
                col = rand.Next(gridSize);
            } while (mines[row, col]);
            mines[row, col] = true;
        }
    }

    public void PlayGame()
    {
        gameWon = false; //To reinitialize for replay

        // Execute until the game is won or the player hits a mine
        while (!gameWon)
        {
            PrintBoard();
            Console.WriteLine("Select a square to reveal (e.g. A1): ");
            string cell = Console.ReadLine().ToUpper();

            var (isValid, validationMessage) = Validation.ValidateCell(cell, gridSize);

            if (isValid)
            {

                int row = cell[0] - 'A'; // Converts the first character to a zero-based row index.
                int col = int.Parse(cell.Substring(1)) - 1; // Converts the rest of the string as the column index.

                if (mines[row, col])
                {
                    Console.WriteLine("Oh no, you detonated a mine! Game over.");
                    break;
                }
                else
                {
                    RevealCell(row, col);
                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("Congratulations, you have won the game!");
                        gameWon = true;
                    }
                }
            }
            else
            {
                Console.WriteLine(validationMessage);
            }
        }

        // Check if the user wants to play again
        if (PromptForPlayAgain())
        {
            Console.Clear();
            StartGame();
        }
    }

    //To reveal the cell
    private void RevealCell(int row, int col)
    {
        int adjacentMines = CountAdjacentMines(row, col);
        // Update the board with the number of adjacent mines or ZERO if no adjacent mines
        board[row, col] = adjacentMines > 0 ? char.Parse(adjacentMines.ToString()) : '0';
    }

    //To print the game board in a grid format.
    private void PrintBoard()
    {
        // Print column headers with correct spacing
        Console.Write("   "); // Leading spaces for row labels and to align the column headers when grid size is 2 digit (e.g 10x10 grid)
        for (int i = 1; i <= gridSize; i++)
        {
            // Adjust spacing based on the number of digits in the column number
            Console.Write(i.ToString().PadRight(2) + " ");
        }
        Console.WriteLine();

        // Print rows with row labels
        for (int row = 0; row < gridSize; row++)
        {
            // Print the row label
            Console.Write((char)('A' + row) + " ");
            for (int col = 0; col < gridSize; col++)
            {
                // Print the board content with a space
                Console.Write(board[row, col] + "  "); // Two spaces for alignment with two-digit column (10x10 grid)
            }
            Console.WriteLine();
        }
    }


    //Calculates how many mines are adjacent to a given cell in the grid
    private int CountAdjacentMines(int row, int col)
    {
        int count = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int newRow = row + i;
                int newCol = col + j;
                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    if (mines[newRow, newCol])
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    //Checks if all cells that do not contain mines have been revealed
    private bool CheckWin()
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                if (board[row, col] == '_' && !mines[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    //Prompt to check whether user wants to play again
    private bool PromptForPlayAgain()
    {
        Console.WriteLine("Do you want to play again? (Y/N): ");
        char response = Console.ReadKey().KeyChar;
        Console.WriteLine(); // To move to the next line after the user input
        return response == 'Y' || response == 'y';
    }

}