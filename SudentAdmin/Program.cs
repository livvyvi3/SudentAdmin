using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SudentAdmin;
using System.Threading;

namespace StudentAdmin
{
    class Program
    {
        private static string MyConn = @"Server=LAPTOP-CE3DN0MT\SQLEXPRESS;Database=StudentAdmin;Integrated Security = true;";

        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(MyConn);
            //SqlCommand command = new SqlCommand();
            bool result = false;



            //string option = Console.ReadLine();


            int userInput = displayMenu();

            try
            {

                while (userInput != 6)
                {



                    switch (userInput)
                    {
                        case 1:
                            {
                                result = StudentHelper.InsertStudent(conn);

                                break;
                            }
                        case 2:
                            {
                                result = StudentHelper.deleteStudent(conn);
                                break;
                            }
                        case 3:
                            {
                                result = StudentHelper.updateStudent(conn);
                                break;
                            }

                        case 4:
                            {
                                result = StudentHelper.getAllStudents(conn);
                                break;
                            }
                        case 5:
                            {
                                result = StudentHelper.getStudent(conn);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("The application will close shortly");
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }


                    if (result)
                    {
                        Console.WriteLine("Selected option Worked");
                    }
                    else
                    {
                        Console.WriteLine("Selected option failed.");
                    }

                    Console.WriteLine("\n");

                    userInput = displayMenu();
                }

                Console.WriteLine("Closing Application......");
                Thread.Sleep(2000);
                
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

           



        }

        static public int displayMenu()
        {
            Console.WriteLine("Please select option");
            Console.WriteLine("1: Insert student");
            Console.WriteLine("2: Delete student");
            Console.WriteLine("3: Update details");
            Console.WriteLine("4: Select all students");
            Console.WriteLine("5: Select Specific student");
            Console.WriteLine("6: Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }



}


