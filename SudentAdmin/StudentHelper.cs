using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudentAdmin
{
    public static class StudentHelper
    {


        public static bool InsertStudent(SqlConnection conn)
        {
            try
            {
                conn.Open();

                STUDENT mystudent = new STUDENT();

                Console.WriteLine("Enter student name");
                mystudent.student_name = Console.ReadLine();

                Console.WriteLine("Enter student specialization");
                mystudent.specialization = Console.ReadLine();

                Console.WriteLine("Enter qualification");
                mystudent.qualification = Console.ReadLine();

                Console.WriteLine("Enter number of courses");
                mystudent.courses = Convert.ToInt32(Console.ReadLine());


                // query to insert data into the table

                SqlCommand command = new SqlCommand($"INSERT INTO STUDENT VALUES ( '{mystudent.student_name}', '{mystudent.specialization}', '{mystudent.qualification}',{mystudent.courses})", conn);
                //command.CommandText = ;



                Console.WriteLine(command.CommandText);
                Console.WriteLine("Number of Rows Affected is: {0}", command.ExecuteNonQuery());

                conn.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                conn.Close();

                return false;
            }

        }

        public static bool deleteStudent(SqlConnection conn)
        {
            try
            {
                conn.Open();


                Console.WriteLine("Enter the student ID of the student you would like to delete: ");
                int studentId = Convert.ToInt16(Console.ReadLine());

                SqlCommand command = new SqlCommand($"delete from student where student_id = {studentId} ", conn);

                Console.WriteLine(command.CommandText);

                int executeResult = command.ExecuteNonQuery();


                if (executeResult > 0)
                {
                    Console.WriteLine($"Number of Rows Affected is: {executeResult}");
                }
                else
                {
                    Console.WriteLine($"No records deleted. Id {studentId} does not exists");
                }

                conn.Close();



                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                conn.Close();
                return false;
            }
        }

        public static bool updateStudent(SqlConnection conn)
        {
            try
            {
                conn.Open();


                Console.WriteLine("Enter the student ID of the student you would like to delete: ");
                int studentId = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter the new data" );
                var newValue = Console.ReadLine();

                //asks the user what they want to update about the student
                Console.WriteLine("Please select option of what you want to update about the student ");
                Console.WriteLine("1: Update student name");
                Console.WriteLine("2: Update specialization ");
                Console.WriteLine("3: Update qualification");
                Console.WriteLine("4: Update number of courses");
                

                string option = Console.ReadLine();
               // SqlCommand command;
                switch (option)
                {
                    case "1":
                        {
                            SqlCommand command = new SqlCommand($"UPDATE Student " +
                                $" SET student_name = {newValue} WHERE student_id = {studentId} ", conn);
                            Console.WriteLine(command.CommandText);
                            break;
                        }
                    case "2":
                        {
                            SqlCommand command = new SqlCommand($"UPDATE Student " +
                                $" SET specialization = {newValue} WHERE student_id = {studentId} ", conn);
                            Console.WriteLine(command.CommandText);
                            break;
                        }
                    case "3":
                        {
                            SqlCommand command = new SqlCommand($"UPDATE Student " +
                                $" SET qualification = {newValue} WHERE student_id = {studentId} ", conn);
                            Console.WriteLine(command.CommandText);
                            break;
                        }
                    case "4":
                        {
                            SqlCommand command = new SqlCommand($"UPDATE Student " +
                                $" SET courses = {newValue} WHERE student_id = {studentId} ", conn);
                            Console.WriteLine(command.CommandText);
                            break;
                        }


                }

                

            

                conn.Close();



                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                conn.Close();
                return false;
            }
        }

        public static bool getStudent(SqlConnection conn)
        {
            
            List<STUDENT> myStudents = new List<STUDENT>();


            try
            {

                conn.Open();
                Console.WriteLine("Enter the student ID of the student you would like to search: ");
                int student_Id = Convert.ToInt16(Console.ReadLine());

                SqlCommand command = new SqlCommand($"SELECT * FROM Student where student_id = {student_Id}"  , conn);
                               
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //populate myStudent object with every student found.
                        myStudents.Add(new STUDENT
                        {
                            student_id = Convert.ToInt32(reader["student_id"].ToString()),
                            student_name = reader["student_name"].ToString(),
                            specialization = reader["specialization"].ToString(),
                            qualification = reader["qualification"].ToString(),
                            courses = Convert.ToInt32(reader["courses"].ToString())
                        });




                    }
                }

                conn.Close();

                if (myStudents.Count > 0)
                {
                    Console.WriteLine($"{myStudents.Count} student found in the database");
                    PrintStudents(myStudents);
                }
                else
                {
                    Console.WriteLine($"No student found in the database");
                }

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                conn.Close();
                return false; ;
            }
        }
       public static bool getAllStudents(SqlConnection conn)
        {
            List<STUDENT> myStudents = new List<STUDENT>();

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Student ", conn);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //populate myStudent object with every student found.
                        myStudents.Add(new STUDENT
                        {
                            student_id = Convert.ToInt32(reader["student_id"].ToString()),
                            student_name = reader["student_name"].ToString(),
                            specialization = reader["specialization"].ToString(),
                            qualification = reader["qualification"].ToString(),
                            courses = Convert.ToInt32(reader["courses"].ToString())
                        });




                    }
                }

                conn.Close();

                if (myStudents.Count > 0)
                {
                    Console.WriteLine($"{myStudents.Count} students found in the database");
                    PrintStudents(myStudents);
                }
                else
                {
                    Console.WriteLine($"No students found in the database");
                }

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                return false;
            }



        }
     

        private static void PrintStudents(List<STUDENT> myStudents)
        {
            foreach (STUDENT student in myStudents)
            {
                Console.WriteLine($" {student.student_id}  {student.student_name} " +
                    $" {student.specialization}  {student.specialization}  {student.courses}" );


            }
        }
    }
}