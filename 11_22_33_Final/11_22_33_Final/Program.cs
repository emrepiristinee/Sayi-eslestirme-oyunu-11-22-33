using System;
using System.Threading;


namespace _11_22_33
{
    class Program
    {
        static int option;
        static void Main(string[] args)
        {
            int r_how_much1 = 0, r_how_much2 = 0, r_how_much3 = 0, r_number1 = 0, r_number2 = 0, r_number3 = 0, r_number_row = 0, r_place1 = 0, r_place2 = 0, r_place3 = 0, r_place_index = 0, b = 1, cursorx = 1, cursory = 1, temp_number = 0, delete_count = 0;
            ConsoleKeyInfo cki;
            string nameOfDefaultPlayer1 = "Serhat Acımaz", nameOfDefaultPlayer2 = "ipek Nur Dere", nameOfDefaultPlayer3 = "Mehmet Kurt", nameOfPlayer = "Player";
            int print_scoreOfPlayer = 0, scoreOfPlayer = 0, scoreOfPlayer1 = 70, scoreOfPlayer2 = 50, scoreOfPlayer3 = 40, limit_of_movement = 9;
            bool if_delete_11_22_33 = true, press_esc = true, limit_decreased = true, chech_game_over = true;



            for (int a = 0; a < 4;)
            {
                if (a == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t-MENU-\n1-GAME RULES\n2-GAMEPLAY\n3-HIGH SCORE TABLE\n4-EXIT");
                    do
                    {
                        b = 1;
                        try
                        {
                            Console.Write("Please choose an option:");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option <= 0 || option > 4)
                            {
                                Console.WriteLine("Please enter a valid value");
                                b = 2;
                            }
                        }
                        catch (FormatException) //catches if wrong value is entered for menu
                        {

                            Console.WriteLine("\nPlease enter a valid value");
                            b = 2;
                        }

                    } while (b == 2);

                    Console.Clear();
                }

                if (option == 1)
                {
                    Console.WriteLine(@"1. The game is played on a 3x30 board.

2. In the beginning, the board is randomly filled with 30 random numbers which are 1, 2 and 3.

3. The arrow keys are used to move the cursor and WASD keys are used to move the number under the cursor.

4. WASD keys can move only the single numbers (the left and right side of the number should be empty).
W : Moves the number one square up. 
S : Moves the number one square down. 
A : Moves the number to the left as much as it can go.
D : Moves the number to the right as much as it can go.

5. If two identical numbers come together on the same line (by player moves or randomly), 
-Matching numbers are deleted from the board.
-The player's score increases by 10 points. 
-New two random numbers are generated and randomly placed on the board.

-PLEASE PRESS A KEY TO RETURN TO THE MENU
 ");
                    Console.ReadKey();
                    Console.Clear();
                    a = 0;
                }
                if (option == 2)
                {
                    int[] row1 = new int[30];
                    int[] row2 = new int[30];
                    int[] row3 = new int[30];

                    Random R_H1 = new Random(); //How many numbers in row 1?
                    r_how_much1 = R_H1.Next(8, 13); //At least 8 and maximum 12 numbers should be placed on the 1st row

                    Random R_H2 = new Random(); //How many numbers in row 1?
                    r_how_much2 = R_H2.Next(8, 12);

                    r_how_much3 = 30 - (r_how_much1 + r_how_much2); //put the remaining numbers on the last line

                    Random R_Number = new Random(); //Generates random numbers from 1 to 3.
                    Random R_Place = new Random();  //It will place numbers between 0 and 29 indices


                    Console.WriteLine("+------------------------------+");
                    Console.WriteLine("|\t\t\t       |\n|\t\t\t       |\n|\t\t\t       |");
                    Console.WriteLine("+------------------------------+");


                    for (int i = 1; i <= r_how_much1; i++) //It returns as many numbers as it will write on the 1st row
                    {
                        r_number1 = R_Number.Next(1, 4); //Generates random numbers from 1 to 3.
                        r_place1 = R_Place.Next(0, 30); //It will place numbers between 0 and 29 indices
                        if (row1[r_place1] == 0) //if this index is empty
                        {
                            Console.SetCursorPosition(r_place1 + 1, 1);
                            Console.Write(r_number1);
                            row1[r_place1] = r_number1; //assigns that number to the array
                        }
                        else
                        {
                            i -= 1;
                        }

                        //it deletes 11, 22, 33
                        if (r_place1 != 29 && row1[r_place1] == row1[r_place1 + 1]) //checks the number to the right
                        {
                            Console.SetCursorPosition(r_place1 + 1, 1);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place1 + 2, 1);
                            Console.WriteLine(" ");
                            row1[r_place1] = 0;
                            row1[r_place1 + 1] = 0;
                            i -= 2; //loop 2 decreases because 2 numbers are deleted
                            scoreOfPlayer += 10; //gives points for adjacent numbers
                        }
                        else if (r_place1 != 0 && row1[r_place1] == row1[r_place1 - 1]) //checks the number to the left
                        {
                            Console.SetCursorPosition(r_place1, 1);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place1 + 1, 1);
                            Console.WriteLine(" ");
                            row1[r_place1] = 0;
                            row1[r_place1 - 1] = 0;
                            i -= 2; //loop 2 decreases because 2 numbers are deleted
                            scoreOfPlayer += 10;
                        }
                    }


                    for (int i = 1; i <= r_how_much2; i++)
                    {
                        r_number2 = R_Number.Next(1, 4);
                        r_place2 = R_Place.Next(0, 30);
                        if (row2[r_place2] == 0)
                        {
                            Console.SetCursorPosition(r_place2 + 1, 2);
                            Console.Write(r_number2);
                            row2[r_place2] = r_number2;
                        }
                        else
                        {
                            i -= 1;
                        }

                        //it deletes 11, 22, 33
                        if (r_place2 != 29 && row2[r_place2] == row2[r_place2 + 1])
                        {
                            Console.SetCursorPosition(r_place2 + 1, 2);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place2 + 2, 2);
                            Console.WriteLine(" ");
                            row2[r_place2] = 0;
                            row2[r_place2 + 1] = 0;
                            i -= 2;
                            scoreOfPlayer += 10;
                        }
                        else if (r_place2 != 0 && row2[r_place2] == row2[r_place2 - 1])
                        {
                            Console.SetCursorPosition(r_place2, 2);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place2 + 1, 2);
                            Console.WriteLine(" ");
                            row2[r_place2] = 0;
                            row2[r_place2 - 1] = 0;
                            i -= 2;
                            scoreOfPlayer += 10;
                        }
                    }


                    for (int i = 1; i <= r_how_much3; i++)
                    {
                        r_number3 = R_Number.Next(1, 4);
                        r_place3 = R_Place.Next(0, 30);
                        if (row3[r_place3] == 0)
                        {
                            Console.SetCursorPosition(r_place3 + 1, 3);
                            Console.Write(r_number3);
                            row3[r_place3] = r_number3;
                        }
                        else
                        {
                            i -= 1;
                        }

                        //it deletes 11, 22, 33
                        if (r_place3 != 29 && row3[r_place3] == row3[r_place3 + 1])
                        {
                            Console.SetCursorPosition(r_place3 + 1, 3);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place3 + 2, 3);
                            Console.WriteLine(" ");
                            row3[r_place3] = 0;
                            row3[r_place3 + 1] = 0;
                            i -= 2;
                            scoreOfPlayer += 10;
                        }
                        else if (r_place3 != 0 && row3[r_place3] == row3[r_place3 - 1])
                        {
                            Console.SetCursorPosition(r_place3, 3);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(r_place3 + 1, 3);
                            Console.WriteLine(" ");
                            row3[r_place3] = 0;
                            row3[r_place3 - 1] = 0;
                            i -= 2;
                            scoreOfPlayer += 10;
                        }
                    }

                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("Score = " + scoreOfPlayer);



                    while (press_esc)
                    {
                        while (limit_of_movement != 0) //controls the movement limit
                        {
                            if (Console.KeyAvailable) // true: there is a key in keyboard buffer
                            {
                                cki = Console.ReadKey(true); // true: do not write character 

                                if (cki.Key == ConsoleKey.RightArrow && cursorx < 30) // key and boundary control
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    cursorx++;
                                    limit_of_movement--; //movement limit decreases by 1
                                    limit_decreased = false; //a control to print the new movement limit to the screen
                                }
                                if (cki.Key == ConsoleKey.LeftArrow && cursorx > 1)
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    cursorx--;
                                    limit_of_movement--;
                                    limit_decreased = false;
                                }
                                if (cki.Key == ConsoleKey.UpArrow && cursory > 1)
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    cursory--;
                                    limit_of_movement--;
                                    limit_decreased = false;
                                }
                                if (cki.Key == ConsoleKey.DownArrow && cursory < 3)
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    cursory++;
                                    limit_of_movement--;
                                    limit_decreased = false;
                                }

                                if (cki.KeyChar == 87 || cki.KeyChar == 119) //if press w and W
                                {
                                    if (cursory != 1) //cannot go up from the 1st row
                                    {
                                        if (cursory == 2 && row2[cursorx - 1] != 0 && row1[cursorx - 1] == 0) //if there is a number at the cursor position and the up digit is blank
                                        {
                                            temp_number = row2[cursorx - 1];
                                            row2[cursorx - 1] = 0;
                                            row1[cursorx - 1] = temp_number;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.WriteLine(" ");
                                            cursory--;
                                            limit_of_movement--; //movement limit decreases by 1
                                            limit_decreased = false; //a control to print the new movement limit to the screen
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.Write(temp_number);
                                        }
                                        else if (cursory == 3 && row3[cursorx - 1] != 0 && row2[cursorx - 1] == 0) //if there is a number at the cursor position and the up digit is blank
                                        {
                                            temp_number = row3[cursorx - 1];
                                            row3[cursorx - 1] = 0;
                                            row2[cursorx - 1] = temp_number;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.WriteLine(" ");
                                            cursory--;
                                            limit_of_movement--;
                                            limit_decreased = false;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.Write(temp_number);
                                        }
                                        Console.SetCursorPosition(50, 5);
                                        Console.WriteLine("Pressed Key: " + cki.KeyChar);
                                    }
                                }

                                if (cki.KeyChar == 83 || cki.KeyChar == 115) //if press s and S
                                {
                                    if (cursory != 3) //cannot go down from the 3rd row
                                    {
                                        if (cursory == 1 && row1[cursorx - 1] != 0 && row2[cursorx - 1] == 0) //if there is a number at the cursor position and the down digit is blank
                                        {
                                            temp_number = row1[cursorx - 1];
                                            row1[cursorx - 1] = 0;
                                            row2[cursorx - 1] = temp_number;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.WriteLine(" ");
                                            cursory++;
                                            limit_of_movement--;
                                            limit_decreased = false;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.Write(temp_number);
                                        }
                                        else if (cursory == 2 && row2[cursorx - 1] != 0 && row3[cursorx - 1] == 0) //if there is a number at the cursor position and the down digit is blank
                                        {
                                            temp_number = row2[cursorx - 1];
                                            row2[cursorx - 1] = 0;
                                            row3[cursorx - 1] = temp_number;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.WriteLine(" ");
                                            cursory++;
                                            limit_of_movement--;
                                            limit_decreased = false;
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.Write(temp_number);
                                        }
                                        Console.SetCursorPosition(50, 5);
                                        Console.WriteLine("Pressed Key: " + cki.KeyChar);
                                    }
                                }

                                if (cki.KeyChar == 65 || cki.KeyChar == 97) //if press a and A
                                {
                                    if (cursorx != 1) //cannot go left from the 1st index
                                    {
                                        for (int i = cursorx; i >= 2; i--) //moves from the cursor to the left
                                        {
                                            if (cursory == 1 && row1[cursorx - 1] != 0 && row1[cursorx - 2] == 0) //if there is a number at the cursor position and the left digit is blank
                                            {
                                                if (row1[i - 2] != 0) //If the index on the left is full, go inside and print the index you are in.
                                                {
                                                    temp_number = row1[cursorx - 1];
                                                    row1[cursorx - 1] = 0;
                                                    row1[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 2 && row1[i - 2] == 0) //for the 0. index
                                                {
                                                    temp_number = row1[cursorx - 1];
                                                    row1[cursorx - 1] = 0;
                                                    row1[i - 2] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i - 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }

                                            else if (cursory == 2 && row2[cursorx - 1] != 0 && row2[cursorx - 2] == 0) //if there is a number at the cursor position and the left digit is blank
                                            {
                                                if (row2[i - 2] != 0)
                                                {
                                                    temp_number = row2[cursorx - 1];
                                                    row2[cursorx - 1] = 0;
                                                    row2[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 2 && row2[i - 2] == 0)
                                                {
                                                    temp_number = row2[cursorx - 1];
                                                    row2[cursorx - 1] = 0;
                                                    row2[i - 2] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i - 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }

                                            else if (cursory == 3 && row3[cursorx - 1] != 0 && row3[cursorx - 2] == 0) //if there is a number at the cursor position and the left digit is blank
                                            {
                                                if (row3[i - 2] != 0)
                                                {
                                                    temp_number = row3[cursorx - 1];
                                                    row3[cursorx - 1] = 0;
                                                    row3[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 2 && row3[i - 2] == 0)
                                                {
                                                    temp_number = row3[cursorx - 1];
                                                    row3[cursorx - 1] = 0;
                                                    row3[i - 2] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i - 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }
                                        }
                                        Console.SetCursorPosition(50, 5);
                                        Console.WriteLine("Pressed Key: " + cki.KeyChar);
                                    }
                                }

                                if (cki.KeyChar == 68 || cki.KeyChar == 100) //if press d and D
                                {
                                    if (cursorx != 30) //cannot go right from the 30. index
                                    {
                                        for (int i = cursorx; i <= 29; i++)
                                        {
                                            if (cursory == 1 && row1[cursorx - 1] != 0 && row1[cursorx] == 0) //if there is a number at the cursor position and the right digit is blank
                                            {
                                                if (row1[i] != 0) //If the index on the right is full, go inside and print the index you are in.
                                                {
                                                    temp_number = row1[cursorx - 1];
                                                    row1[cursorx - 1] = 0;
                                                    row1[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 29 && row1[i] == 0) //for the 0.index
                                                {
                                                    temp_number = row1[cursorx - 1];
                                                    row1[cursorx - 1] = 0;
                                                    row1[i] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i + 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }
                                            else if (cursory == 2 && row2[cursorx - 1] != 0 && row2[cursorx] == 0) //if there is a number at the cursor position and the right digit is blank
                                            {
                                                if (row2[i] != 0)
                                                {
                                                    temp_number = row2[cursorx - 1];
                                                    row2[cursorx - 1] = 0;
                                                    row2[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 29 && row2[i] == 0)
                                                {
                                                    temp_number = row2[cursorx - 1];
                                                    row2[cursorx - 1] = 0;
                                                    row2[i] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i + 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }
                                            else if (cursory == 3 && row3[cursorx - 1] != 0 && row3[cursorx] == 0) //if there is a number at the cursor position and the right digit is blank
                                            {
                                                if (row3[i] != 0)
                                                {
                                                    temp_number = row3[cursorx - 1];
                                                    row3[cursorx - 1] = 0;
                                                    row3[i - 1] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i, cursory);
                                                    Console.Write(temp_number);
                                                }
                                                else if (i == 29 && row3[i] == 0)
                                                {
                                                    temp_number = row3[cursorx - 1];
                                                    row3[cursorx - 1] = 0;
                                                    row3[i] = temp_number;
                                                    Console.SetCursorPosition(cursorx, cursory);
                                                    Console.WriteLine(" ");
                                                    limit_of_movement--;
                                                    limit_decreased = false;
                                                    Console.SetCursorPosition(i + 1, cursory);
                                                    Console.Write(temp_number);
                                                }
                                            }
                                            Console.SetCursorPosition(50, 5);
                                            Console.WriteLine("Pressed Key: " + cki.KeyChar);
                                        }
                                    }
                                }
                                if (cki.Key == ConsoleKey.Escape)
                                {
                                    print_scoreOfPlayer = scoreOfPlayer;
                                    scoreOfPlayer = 0;
                                    press_esc = false;
                                    break;
                                }
                            }
                            break;

                            if (press_esc == false)
                            {
                                break;
                            }
                        }

                        Console.SetCursorPosition(cursorx, cursory); //cursor stays where it is

                        for (int i = 0; i < row1.Length; i++)
                        {
                            //it deletes 11, 22, 33
                            if (i != 29 && row1[i] == row1[i + 1] && row1[i] != 0) //checks the number to the right
                            {
                                Console.SetCursorPosition(i + 1, 1);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 2, 1);
                                Console.WriteLine(" ");
                                row1[i] = 0;
                                row1[i + 1] = 0;
                                if_delete_11_22_33 = false; //it will generate new number if deleted
                                scoreOfPlayer += 10;
                                delete_count++; //to find out how many 11,22,33 you deleted
                                limit_of_movement = 9; //limit of movement is reset
                            }
                            else if (i != 0 && row1[i] == row1[i - 1] && row1[i] != 0) //checks the number to the left
                            {
                                Console.SetCursorPosition(i, 1);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 1, 1);
                                Console.WriteLine(" ");
                                row1[i] = 0;
                                row1[i - 1] = 0;
                                if_delete_11_22_33 = false;
                                scoreOfPlayer += 10;
                                delete_count++;
                                limit_of_movement = 9;
                            }

                            //it deletes 11, 22, 33
                            if (i != 29 && row2[i] == row2[i + 1] && row2[i] != 0) //row2
                            {
                                Console.SetCursorPosition(i + 1, 2);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 2, 2);
                                Console.WriteLine(" ");
                                row2[i] = 0;
                                row2[i + 1] = 0;
                                if_delete_11_22_33 = false;
                                scoreOfPlayer += 10;
                                delete_count++;
                                limit_of_movement = 9;
                            }
                            else if (i != 0 && row2[i] == row2[i - 1] && row2[i] != 0) //row2
                            {
                                Console.SetCursorPosition(i, 2);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 1, 2);
                                Console.WriteLine(" ");
                                row2[i] = 0;
                                row2[i - 1] = 0;
                                if_delete_11_22_33 = false;
                                scoreOfPlayer += 10;
                                delete_count++;
                                limit_of_movement = 9;
                            }

                            //it deletes 11, 22, 33
                            if (i != 29 && row3[i] == row3[i + 1] && row3[i] != 0) //row3
                            {
                                Console.SetCursorPosition(i + 1, 3);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 2, 3);
                                Console.WriteLine(" ");
                                row3[i] = 0;
                                row3[i + 1] = 0;
                                if_delete_11_22_33 = false;
                                scoreOfPlayer += 10;
                                delete_count++;
                                limit_of_movement = 9;
                            }
                            else if (i != 0 && row3[i] == row3[i - 1] && row3[i] != 0) //row3
                            {
                                Console.SetCursorPosition(i, 3);
                                Console.WriteLine(" ");
                                Console.SetCursorPosition(i + 1, 3);
                                Console.WriteLine(" ");
                                row3[i] = 0;
                                row3[i - 1] = 0;
                                if_delete_11_22_33 = false;
                                scoreOfPlayer += 10;
                                delete_count++;
                                limit_of_movement = 9;
                            }
                        }

                        if (if_delete_11_22_33 == false) //if numbers match and delete
                        {
                            for (int i = 0; i < delete_count * 2; i++) //return 2 times the number of deleted couples
                            {
                                r_number_row = R_Number.Next(1, 4); //for random row
                                r_place_index = R_Place.Next(0, 30); //for random index
                                r_number3 = R_Number.Next(1, 4); //for random number

                                switch (r_number_row)
                                {
                                    case 1:
                                        if (row1[r_place_index] == 0)
                                        {
                                            Console.SetCursorPosition(r_place_index + 1, 1);
                                            Console.Write(r_number3);
                                            row1[r_place_index] = r_number3;
                                        }
                                        else
                                        {
                                            i -= 1;
                                        }
                                        break;

                                    case 2:
                                        if (row2[r_place_index] == 0)
                                        {
                                            Console.SetCursorPosition(r_place_index + 1, 2);
                                            Console.Write(r_number3);
                                            row2[r_place_index] = r_number3;
                                        }
                                        else
                                        {
                                            i -= 1;
                                        }
                                        break;

                                    case 3:
                                        if (row3[r_place_index] == 0)
                                        {
                                            Console.SetCursorPosition(r_place_index + 1, 3);
                                            Console.Write(r_number3);
                                            row3[r_place_index] = r_number3;
                                        }
                                        else
                                        {
                                            i -= 1;
                                        }
                                        break;
                                }
                            }
                        }
                        if (if_delete_11_22_33 == false) //if deleted, write the current score on the screen
                        {
                            Console.SetCursorPosition(50, 0);
                            Console.WriteLine("Score = " + scoreOfPlayer);
                        }

                        if_delete_11_22_33 = true;
                        delete_count = 0;

                        if (limit_decreased == false) //if the limit has decreased, write the current limit on the screen
                        {
                            Console.SetCursorPosition(50, 2);
                            Console.WriteLine("Number of Moves Left: " + limit_of_movement);
                        }

                        limit_decreased = true;

                        if (limit_of_movement == 0)
                        {
                            chech_game_over = false;
                        }

                        if (chech_game_over == false)
                        {
                            Console.SetCursorPosition(50, 10);
                            press_esc = false;
                            print_scoreOfPlayer = scoreOfPlayer;
                            Console.WriteLine("Number of Moves Left: " + limit_of_movement + " GAME OVER");
                            Thread.Sleep(5000); //Waits 5 seconds before popping into menu
                        }

                    }
                    cursorx = 1; cursory = 1; //the cursor is reset
                    limit_of_movement = 9; //menüye dönüldüğünde tuş limitini sıfırlar
                    chech_game_over = true; //menüye dönüldüğünde game over kontrolü sıfırlar
                    press_esc = true; ////menüye dönüldüğünde menüye dönme isteğini sıfırlar
                    a = 0;
                }

                if (option == 3)
                {
                    if (print_scoreOfPlayer >= 40 && print_scoreOfPlayer < 50)
                    {
                        Console.WriteLine(nameOfDefaultPlayer1 + " = " + scoreOfPlayer1);
                        Console.WriteLine(nameOfDefaultPlayer2 + " = " + scoreOfPlayer2);
                        Console.WriteLine(nameOfPlayer + " = " + print_scoreOfPlayer);
                    }
                    else if (print_scoreOfPlayer >= 50 && print_scoreOfPlayer < 70)
                    {
                        Console.WriteLine(nameOfDefaultPlayer1 + " = " + scoreOfPlayer1);
                        Console.WriteLine(nameOfPlayer + " = " + print_scoreOfPlayer);
                        Console.WriteLine(nameOfDefaultPlayer2 + " = " + scoreOfPlayer2);
                    }
                    else if (print_scoreOfPlayer >= 70)
                    {
                        Console.WriteLine(nameOfPlayer + " = " + print_scoreOfPlayer);
                        Console.WriteLine(nameOfDefaultPlayer1 + " = " + scoreOfPlayer1);
                        Console.WriteLine(nameOfDefaultPlayer2 + " = " + scoreOfPlayer2);
                    }
                    else
                    {
                        Console.WriteLine(nameOfDefaultPlayer1 + " = " + scoreOfPlayer1);
                        Console.WriteLine(nameOfDefaultPlayer2 + " = " + scoreOfPlayer2);
                        Console.WriteLine(nameOfDefaultPlayer3 + " = " + scoreOfPlayer3);
                        Console.WriteLine(nameOfPlayer + " = " + print_scoreOfPlayer);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    a = 0;
                }

                if (option == 4)
                {
                    Console.WriteLine(@"Are you sure you want to exit game ?
             (Y)/(N)");
                    string inputOfExit = Console.ReadLine();
                    inputOfExit = inputOfExit.ToUpper();
                    if (inputOfExit == "Y")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        a = 0;
                        Console.Clear();

                    }
                }

            }
        }
    }
}
