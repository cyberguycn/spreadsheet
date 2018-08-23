using System;
using System.Collections.Generic;
using System.Text;



namespace Spreadsheet_test
{
    class Program
    {


        static void Main(string[] args)
        {

            int w = 0, h = 0, x1 = 0, y1 = 0, x2 = 0, y2 = 0, x3 = 0, y3 = 0;

            Int16 v1 = 0;
            Int32 vTotal = 0;

            string str_cmd = Console.ReadLine().ToUpper().Trim();
            
            Int16 [,] sheet = new Int16 [0,0];

            while (str_cmd != "Q")
            {

                try
                {

                    str_cmd = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str_cmd.Trim(), " ");
                    string[] a_cmd_args = str_cmd.Split(' ');
                    string str_op = a_cmd_args[0]; 
                    
                    //Console.WriteLine(string.Join(" ",a_cmd_args).ToString());


                    if (str_op == "C") //command C x1 y1
                    {
                        if (a_cmd_args.Length != 3) {
                            throw new Exception("!! Invalid parameter, please type ? for more detail about the command for this program.");
                        }

                        w = Convert.ToInt32(a_cmd_args[1]);
                        h = Convert.ToInt32(a_cmd_args[2]);

                        if (w > 0 && h > 0)
                        {
                            sheet = new Int16[h, w];
                        }
                        else {
                            Console.WriteLine("Invalid parameter for create sheet, please type ? for help");
                        }

                        
                    } 
                    else if (str_op == "N") //command S x1 y1 v1
                    {

                        if (sheet.Length < 1) 
                        {
                                throw new Exception("!! Invalid operation, please create sheet first.");
                        }
                        else if (a_cmd_args.Length != 4)
                        {
                            throw new Exception("!! Invalid parameter, please type ? for more detail about the command for this program.");
                        }


                        x1 = Convert.ToInt32(a_cmd_args[1]) - 1;
                        y1 = Convert.ToInt32(a_cmd_args[2]) - 1;

                        if (x1 < 0 || y1 < 0) {
                            Console.WriteLine("Invalid parameter, please type ? for help"); 
                        }
                        else
                        {

                            v1 = Convert.ToInt16(a_cmd_args[3]);

                            if (v1.ToString().Length > 3)
                            {
                                Console.WriteLine("The length of assinged value cannot exceed 3 characters");
                            }
                            else
                            {
                                sheet[y1, x1] = v1;
                            }
                        }
                    }
                    else if (str_op == "S") //command S x1 y1 x2 y2 x3 y3
                    {

                        if (sheet.Length < 1)
                        {
                            throw new Exception("!! Invalid operation, please create sheet first.");
                        }
                        else if (a_cmd_args.Length != 7)
                        {
                            throw new Exception("!! Invalid parameter, please type ? for more detail about the command for this program.");
                        }


                        x1 = Convert.ToInt32(a_cmd_args[1]) - 1;
                        y1 = Convert.ToInt32(a_cmd_args[2]) - 1;

                        x2 = Convert.ToInt32(a_cmd_args[3]) - 1;
                        y2 = Convert.ToInt32(a_cmd_args[4]) - 1;

                        x3 = Convert.ToInt32(a_cmd_args[5]) - 1;
                        y3 = Convert.ToInt32(a_cmd_args[6]) - 1;

                        if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0 || x3 < 0 || y3 < 0)
                        {
                            Console.WriteLine("invalid parameter, please type ? for help");
                        }
                        else
                        {


                            vTotal = 0;

                            for (; x1 <= x2; x1++)
                            {
                                for (int row = y1; row <= y2; row++)
                                {
                                    vTotal += sheet[row, x1];
                                }
                            }

                            if (vTotal.ToString().Length > 3)
                            {
                                sheet[y3, x3] = Convert.ToInt16(vTotal.ToString().Substring(0, 3));

                                Console.WriteLine("the result " + vTotal.ToString() + " has been truncated to " + sheet[x3, y3]);
                            }
                            else
                            {
                                sheet[y3, x3] = Convert.ToInt16(vTotal);
                            }

                        }

                    }
                    else if (str_op == "?")
                    { //command for help

                        Console.WriteLine("C w h  -- Create a new spread sheet of width w and height h (i.e. the spreadsheet can hold w * h amount of cells). ");
                        Console.WriteLine("N x1 y1 v1  -- Insert a number in specified cell (x1,y1). ");
                        Console.WriteLine("S x1 y1 x2 y2 x3 y3  -- Perform sum on top of all cells from x1 y1 to x2 y2 and store the result in x3 y3 ");
                        Console.WriteLine("Q  -- Quit the program. ");
                    }
                    else
                    {

                        Console.WriteLine("!! Invalid command, please type ? for more detail about the command for this program.");
                    }


                    //output the sheet
                    if (w > 0 && h > 0)
                    {
                        string str_baseline = " ";

                        Console.WriteLine(str_baseline.PadLeft((w + 1) * 4 , '-'));
                        for (int row = 0; row < h; row++)
                        {
                            Console.Write("| ");
                            for (int col = 0; col < w; col++) {

                                Console.Write(sheet[row,col].ToString().PadLeft(3) + " ");

                            }

                            Console.WriteLine(" |");
                        }
                        Console.WriteLine(str_baseline.PadLeft((w + 1) * 4, '-'));
                    }

                }
                catch (Exception ex) {

                    //Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.Message);

                }finally{


                    str_cmd = Console.ReadLine().ToUpper();
                }
            }









        }
    }
}
