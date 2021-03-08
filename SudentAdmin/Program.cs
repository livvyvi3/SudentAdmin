using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SudentAdmin;

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

            try
            {

                Console.WriteLine("Please select option");
                Console.WriteLine("1: Insert student");
                Console.WriteLine("2: Delete student");
                Console.WriteLine("3: Update details");
                Console.WriteLine("4: Select all students");
                //Console.WriteLine("5: Select Specific student");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            result = StudentHelper.InsertStudent(conn);

                            break;
                        }
                    case "2":
                        {
                            result = StudentHelper.deleteStudent(conn);
                            break;
                        }
                    case "3":
                        {
                            result = StudentHelper.updateStudent(conn);
                            break;
                        }

                    case "4":
                        {
                            result = StudentHelper.getAllStudents(conn);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid option");
                            break;
                        }
                }


                if (result)
                    Console.WriteLine("Selected option Worked");
                else

                    Console.WriteLine("Selected option failed.");



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();


            Console.WriteLine("Data base Connection Closed.");

        }
    }
}
