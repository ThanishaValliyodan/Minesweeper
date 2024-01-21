
Minesweeper Game in C#
======================

This is a simple console version of the classic game Minesweeper written in C# and targeted for the .NET 8 framework. The game creates a grid of cells, some of which contain mines. The goal is to clear the grid without detonating any mines.

Setup Instructions:
-------------------
1. Ensure you have Visual Studio or Visual Studio Code installed with the .NET 8 SDK. These tools provide the necessary environment to build and run C# applications.
2. Clone or download the source code from the repository to your local machine.
3. Open the solution file (.sln) in Visual Studio.
4. Use the 'Build' option from the top menu to compile the code.
5. Once the build is successful, run the application using the 'Start' button in Visual Studio.

How to Play:
------------
- When you start the application, you will be prompted to enter the size of the grid and the number of mines.
- The grid will be displayed with rows labeled A-J and columns labeled 1-10.
- Enter the coordinates of the cell you wish to reveal (e.g. A1) when prompted.
- If you reveal a mine, the game ends. Otherwise, the game will display the number of adjacent mines or zero if there are none.
- Continue revealing cells until all safe cells are uncovered to win the game.

Game Rules:
-----------
- Revealing a cell with a mine results in a game over.
- Revealed cells show the count of adjacent mines.
- The objective is to clear all non-mined cells.

Ending the Game:
----------------
- The game concludes when a mine is revealed or all safe cells are revealed.
- You will be given an option to play again or exit the game after it concludes.

Enjoy the Minesweeper game!
