using System.Reflection;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            // game init
            bool gameOn = true;
            int player = 1;
            string[,] field = { { "7", "8", "9" }, { "4", "5", "6" }, { "1", "2", "3" } };

            // game winpatterns
            string winpattern1 = "XXX";
            string winpattern2 = "OOO";

            // display the board first
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }

            // helper function
            static void WinningMessage(int player)
            {
                Console.WriteLine($"Player {player} Won! Press a key to exit");
                Console.ReadKey();
            }

            while (gameOn)
            {
                int played;
                bool validPlay = false;

                // message
                Console.Write($"Player {player}'s turn: ");
                string input = Console.ReadLine();

                // parsing
                int.TryParse(input, out played); // gives back 0 if failed
                //Console.WriteLine(played);

                // guard clause
                if (played < 1 || played > 9)
                {
                    Console.WriteLine("Call a number between 1-9!");
                    continue;
                }

                // guard clause 2
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == played.ToString())
                        {
                            validPlay = true;
                        }
                    }
                }

                if (!validPlay)
                {
                    Console.WriteLine("Call a number which is on the field!");
                    continue;
                }

                // display played move
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == played.ToString() && player == 1)
                        {
                            field[i, j] = "X";
                        }
                        if (field[i, j] == played.ToString() && player == 2)
                        {
                            field[i, j] = "O";
                        }
                        Console.Write(field[i, j] + " ");
                    }
                    Console.WriteLine();
                }


                // check for horizontal win
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    string winpattern = "";
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        winpattern += field[i, j];
                    }

                    if (winpattern == winpattern1)
                    {
                        gameOn = false;
                        WinningMessage(1);
                    }

                    if (winpattern == winpattern2)
                    {
                        gameOn = false;
                        WinningMessage(2);
                    }
                }

                // check for vertical win
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    string winpattern = "";
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        winpattern += field[j, i];
                    }
                    if (winpattern == winpattern1)
                    {
                        gameOn = false;
                        WinningMessage(1);
                    }

                    if (winpattern == winpattern2)
                    {
                        gameOn = false;
                        WinningMessage(2);
                    }
                }

                // check for left cross win
                string leftCrossWinner = "";
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {

                        if (i == j)
                        {
                            leftCrossWinner += field[i, j];
                        }
                    }
                    //Console.WriteLine(leftCrossWinner);

                    if (leftCrossWinner == winpattern1)
                    {
                        gameOn = false;
                        WinningMessage(1);
                    }

                    if (leftCrossWinner == winpattern2)
                    {
                        gameOn = false;
                        WinningMessage(2);
                    }
                }

                // check for rigth cross win
                string rightCrossWinners = "";
                for (int i = 0, j = field.GetLength(0) - 1; i < field.GetLength(0); i++, j--)
                {
                    rightCrossWinners += field[i, j];
                    //Console.WriteLine(rightCrossWinners);

                    if (rightCrossWinners == winpattern1)
                    {
                        gameOn = false;
                        WinningMessage(1);
                    }

                    if (rightCrossWinners == winpattern2)
                    {
                        gameOn = false;
                        WinningMessage(2);
                    }
                }


                // switch players
                if (player == 1)
                {
                    player = 2;
                }
                else player = 1;
            }
        }

    }
}