using System;
using System.Collections.Generic;

//Week One Assignment: Tic Tac Toe
//By Jacob Deschamps
namespace Tic_Tac_Toe{
    public class Program{
        public static void drawBoard(List <string> board){
            string border = "-+-+-";
            Console.WriteLine("\n");
            for (int i = 0; i < 7; i += 3){
                Console.WriteLine($"{board[i]}|{board[i+1]}|{board[i+2]}");
                if (i < 6){
                    Console.WriteLine(border);
                }
            }
            Console.WriteLine("\n");
            return;
        }

        public static bool checkWin(List<string> board, List<short> checks){
            int count = checks.Count;
            for (int i = 0; i < count; i+=3){
                if (board[checks[i]] == board[checks[i+1]] && board[checks[i]] == board[checks[i+2]]){
                    drawBoard(board);
                    Console.WriteLine($"Game Over! {board[checks[i]]} wins!");
                    return false;
                }
            }
            return true;
        }


        public static bool checkDraw(List<string> board){
            for (int i = 0; i < 9; i++){
                if (board[i] == (i+1).ToString()){
                    return true;
                }
            }
            drawBoard(board);
            Console.WriteLine("Draw! Out of Moves!");
            return false;
        }


        public static void Main(string[] argv){
            bool Xturn;
            bool isPlaying;
            bool isRunning = true;
            bool hasAnswered;
            string currentPlayer;
            short choice;
            string query;
            List<short> checks = new List<short>();
            while (isRunning){
                isPlaying = true;
                Xturn = true;
                for (short i = 0; i < 9; i++){
                    checks.Add(i);
                }
                for (short i = 0; i < 3; i++){
                    checks.Add(i);
                    checks.Add((short)(i + 3));
                    checks.Add((short)(i + 6));
                }
                for (short i = 0; i < 9; i+=4){
                    checks.Add(i);
                }
                for (short i = 2; i < 8; i+=2){
                    checks.Add(i);
                }
                List<string> board = new List<string>();
                for (int i = 1; i < 10; i++){
                    board.Add(i.ToString());
                }

                while (isPlaying){
                    if (Xturn){
                        currentPlayer = "X";
                    }
                    else{
                        currentPlayer = "O";
                    }
                    
                    drawBoard(board);
                    Console.WriteLine($"{currentPlayer} turn! Select a cell: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                    choice--;
                    if (choice >= 0 && choice < 9){
                        if (board[choice] != "X" && board[choice] != "O"){
                            board[choice] = currentPlayer;
                            if (Xturn){
                                Xturn = false;
                            }
                            else{
                                Xturn = true;
                            }
                        }
                        else{
                            Console.WriteLine("Cell already Occupied, Try again.");
                        }
                    }
                    else{
                        Console.WriteLine("Output not Valid, Try again.");
                    }
                    isPlaying = checkWin(board, checks);
                    if (isPlaying){
                        isPlaying = checkDraw(board);
                    }
                }

                hasAnswered = false;
                while (!hasAnswered){
                    Console.WriteLine("Do you want to play again? [Y/N]");
                    query = Console.ReadLine().ToUpper();
                    if (query != "Y" && query != "N"){
                        Console.WriteLine("Please Select a Valid Option.");
                    }
                    else{
                        if (query == "Y"){
                            isRunning = true;
                        }
                        else if (query == "N"){
                            isRunning = false;
                        }
                        hasAnswered = true;
                    }
                }
            }
        }
    }
}
