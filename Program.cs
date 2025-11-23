using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[3, 3];
            InitializeBoard(board);

            string currentPlayer = "X";
            bool gameWon = false;
            int moves = 0;

            while (!gameWon && moves < 9)
            {
                PrintBoard(board);
                Console.WriteLine($"\nPlayer {currentPlayer}, enter your move (row and column 0–2):");

                Console.Write("Row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Column: ");
                int col = int.Parse(Console.ReadLine());

                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid move! Out of bounds.");
                    continue;
                }

                if (board[row, col] != " ")
                {
                    Console.WriteLine("That spot is already taken!");
                    continue;
                }

                board[row, col] = currentPlayer;
                moves++;

                if (CheckWin(board, currentPlayer))
                {
                    PrintBoard(board);
                    Console.WriteLine($"\nPlayer {currentPlayer} wins!");
                    gameWon = true;
                    break;
                }

                // Switch player
                currentPlayer = currentPlayer == "X" ? "O" : "X";
            }

            if (!gameWon)
            {
                PrintBoard(board);
                Console.WriteLine("\nIt's a draw!");
            }
        }

        static void InitializeBoard(string[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = " ";
        }

        static void PrintBoard(string[,] board)
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  -----");
            }
        }

        static bool CheckWin(string[,] board, string player)
        {
            // Rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
            }

            // Diagonals
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

            return false;
        }
    }
}
