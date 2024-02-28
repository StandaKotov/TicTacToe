namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int position;
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            bool gameWon = false;

            while (!gameWon)
            {
                DrawBoard();
                position = GetPosition();
                if (IsValidMove())
                {
                    MakeMove();
                    gameWon = CheckWin();
                    if (!gameWon)
                        SwitchPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }

                if (!gameWon && IsBoardFull())
                {
                    Console.WriteLine("It's a draw! Nobody wins.");
                    break;
                }
            }

            DrawBoard();
            if (gameWon)
                Console.WriteLine($"Player {currentPlayer} wins!");
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
        }

        static int GetPosition()
        {
            int pos = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9):");
                if (int.TryParse(Console.ReadLine(), out pos))
                {
                    if (pos >= 1 && pos <= 9 && board[pos - 1] != 'X' && board[pos - 1] != 'O')
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please enter a number between 1 and 9 that is not already taken.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 9.");
                }
            }

            return pos;
        }

        static bool IsValidMove()
        {
            return position >= 1 && position <= 9 && board[position - 1] != 'X' && board[position - 1] != 'O';
        }

        static void MakeMove()
        {
            board[position - 1] = currentPlayer;
        }

        static bool CheckWin()
        {
            return (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
                   (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
                   (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
                   (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
                   (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
                   (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
                   (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                   (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
        }

        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        static bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
