
namespace Minesweeper
{
    public class Validation
    {

        // Validating User Input: Grid Size
        internal static (bool isValid, string message) ValidateGridSize(string gridInput)
        {
            if (int.TryParse(gridInput, out int gridSize))
            {
                if (gridSize <= 2)
                {
                    return (false, "Minimum size of grid is 3.");
                }
                else if (gridSize >= 11)
                {
                    return (false, "Maximum size of grid is 10.");
                }
                return (true, "success");
            }
            else
            {
                return (false, "Incorrect input. Please enter a number.");
            }
        }

        // Validating User Input: Mine Count
        internal static (bool isValid, string message) ValidateMineCount(string mineInput, int gridSize)
        {
            if (int.TryParse(mineInput, out int mineCount))
            {
                if (mineCount < 1)
                {
                    return (false, "There must be at least 1 mine.");
                }
                else if (mineCount > (0.35 * gridSize * gridSize))
                {
                    return (false, "Maximum number of mines are 35% of total squares.");
                }
                return (true, "success");
            }
            else
            {
                return (false, "Incorrect input. Please enter a number.");
            }
        }

        //Validating User Input : Cell e.g. A1
        internal static (bool isValid, string message) ValidateCell(string cell, int gridSize)
        {
            // Ensure the input has at least 2 characters: a letter and a number.
            if (cell.Length < 2 || !char.IsLetter(cell[0]) || !cell.Substring(1).All(char.IsDigit))
            {
                return (false, "Incorrect input. Please enter a letter followed by a number (e.g. A1, B10).");
            }

            // Convert the first character to uppercase to standardize it
            char rowChar = char.ToUpper(cell[0]);
            // Get the column number from the input
            int colNumber = int.Parse(cell.Substring(1));

            // Check if the row character is within the valid range
            if (rowChar < 'A' || rowChar >= 'A' + gridSize)
            {
                return (false, $"Row character out of range. Please enter a letter between A and {Convert.ToChar('A' + gridSize - 1)}.");
            }

            // Check if the column number is within the valid range
            if (colNumber < 1 || colNumber > gridSize)
            {
                return (false, $"Column number out of range. Please enter a number between 1 and {gridSize}.");
            }

            return (true, "success");
        }

    }
}
