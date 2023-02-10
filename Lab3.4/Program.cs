using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

// CODED BY KATHLEEN FORGIARINI DA SILVA
// DATE: 2023-01-26
// Lab 3.4

namespace lab3_4
{
    //Creating struct for Person
    struct Person
    {
        public string fname;
        public string lname;
        public sbyte age;
    }
    //Creating struct for Student
    struct Student
    {
        public Person pData; //object of Person struct
        public uint sId;
        public string cName;
        public string cAdr;
        public string cCity;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st1;
            st1.pData.fname = "Kathleen";
            st1.pData.lname = "Forgiarini da Silva";
            st1.pData.age = 23;
            st1.sId = 1234567;
            st1.cName = "LaSalle";
            st1.cCity = "Montreal";
            st1.cAdr = "2000 Ste. Chaterine";

            // creating the array of struct
            const int maxStudents = 5;
            Student[] arrStudents = new Student[maxStudents];
            arrStudents[0] = st1;
            int qtdStudents = 1;

            // creating the list of struct
            List<Student> listStudents = new List<Student>();
            Student stdItems = new Student();

            char option;
            char quit = 'n';

            // Inicializing the operation
            do
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1) Add nem student to array");
                Console.WriteLine("2) Add nem student to list");
                Console.WriteLine("3) Display students of the array");
                Console.WriteLine("4) Display students of the list");
                Console.WriteLine("5) Add all the information of the array to the list");
                Console.WriteLine("6) Clear the list");
                Console.WriteLine("7) Exit application\n");
                option = Convert.ToChar(Console.ReadLine()); //Convert string to char

                switch (option)
                {
                    case '1':
                        {
                            if (qtdStudents < maxStudents)
                            {
                                //student information
                                Console.WriteLine("Enter student's first name: ");
                                arrStudents[qtdStudents].pData.fname = Console.ReadLine();
                                Console.WriteLine("Enter student's last name: ");
                                arrStudents[qtdStudents].pData.lname = Console.ReadLine();


                            age: //label for goto

                                // If the age entered is not supported by SByte
                                try
                                {
                                    Console.WriteLine("Enter student's age: ");
                                    arrStudents[qtdStudents].pData.age = Convert.ToSByte(Console.ReadLine());
                                    if (arrStudents[qtdStudents].pData.age < 18 || arrStudents[qtdStudents].pData.age > 65)
                                    {
                                        Console.WriteLine("Please enter a value between 18 and 65");
                                        goto age; //if the age is not between 18 and 65, go back to ask again
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                    goto age;
                                }

                            id: // label for goto

                                // If the ID entered is not supported by Int32
                                try
                                {
                                    Console.WriteLine("Enter student's ID: ");
                                    arrStudents[qtdStudents].sId = Convert.ToUInt32(Console.ReadLine());
                                    if (arrStudents[qtdStudents].sId.ToString().Length > 7)
                                    {
                                        Console.WriteLine("Enter a number less than 7 digits");
                                        goto id;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                    goto id;
                                }

                                Console.WriteLine("Enter college's name: ");
                                arrStudents[qtdStudents].cName = Console.ReadLine();
                                Console.WriteLine("Enter the city: ");
                                arrStudents[qtdStudents].cCity = Console.ReadLine();
                                Console.WriteLine("Enter the address: ");
                                arrStudents[qtdStudents].cAdr = Console.ReadLine();

                                //increment number of std registered
                                qtdStudents++;
                                Console.WriteLine("\nStudent was successfully registered!\n");
                            }
                            else
                            {
                                Console.WriteLine("\nSorry, number of students exceeded.");
                            }
                        }
                        break;

                    case '2':
                        {
                            //student information
                            Console.WriteLine("Enter student's first name: ");
                            stdItems.pData.fname = Console.ReadLine();
                            Console.WriteLine("Enter student's last name: ");
                            stdItems.pData.lname = Console.ReadLine();

                        age: //label for goto

                            // If the age entered is not supported by SByte
                            try
                            {
                                Console.WriteLine("Enter student's age: ");
                                stdItems.pData.age = Convert.ToSByte(Console.ReadLine());
                                if (stdItems.pData.age < 18 || stdItems.pData.age > 65)
                                {
                                    Console.WriteLine("Please enter a value between 18 and 65");
                                    goto age; //if the age is not between 18 and 65, go back to ask again
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                goto age;
                            }

                        id: // label for goto

                            // If the ID entered is not supported by Int32
                            try
                            {
                                Console.WriteLine("Enter student's ID: ");
                                stdItems.sId = Convert.ToUInt32(Console.ReadLine());
                                if (stdItems.sId.ToString().Length > 7)
                                {
                                    Console.WriteLine("Enter a number less than 7 digits");
                                    goto id;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                goto id;
                            }

                            Console.WriteLine("Enter college's name: ");
                            stdItems.cName = Console.ReadLine();
                            Console.WriteLine("Enter the city: ");
                            stdItems.cCity = Console.ReadLine();
                            Console.WriteLine("Enter the address: ");
                            stdItems.cAdr = Console.ReadLine();

                            try
                            {
                                listStudents.Add(stdItems);
                                Console.WriteLine("\nStudent was successfully registered!\n");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                            }
                            break;
                        }

                    case '3':
                        {
                            //Display the informations of the students
                            if (qtdStudents > 0)
                            {
                                for (int i = 0; i < arrStudents.Length; i++)
                                {
                                    if (arrStudents[i].pData.age > 0)
                                    {

                                    Console.WriteLine($"\nStudent {i + 1}: First Name: {arrStudents[i].pData.fname,-15} Last Name: {arrStudents[i].pData.lname,-15} Age: {arrStudents[i].pData.age,10} ID: {arrStudents[i].sId,10}");
                                    Console.WriteLine($"College info.: College Name: {arrStudents[i].cName,-15} City: {arrStudents[i].cCity,-15} Address: {arrStudents[i].cAdr,-15}");
                                    Console.WriteLine("--------------------------------------------------------------------");
                                    }

                                }
                            }
                            else // If there is no student registered
                            {
                                Console.WriteLine("There is nothing to display!\n");
                            }
                        }
                        break;

                    case '4':
                        {
                            if (listStudents.Count == 0) // If there is no student registered
                            {
                                Console.WriteLine("There is nothing to display!\n");
                            }
                            else
                            {
                                for (int i = 0; i < listStudents.Count; i++)
                                {
                                    if (listStudents[i].pData.age > 0)
                                    {
                                        Console.WriteLine("\nStudent {0}: First Name: {1,10} Last Name: {2,10}", i + 1, listStudents[i].pData.fname, listStudents[i].pData.lname);
                                        Console.WriteLine("Age: {0,8} ID: {1,8}", listStudents[i].pData.age, listStudents[i].sId);
                                        Console.WriteLine("College info.: College Name: {0,10} City: {1,10} Address: {2,10}", listStudents[i].cName, listStudents[i].cCity, listStudents[i].cAdr);
                                        Console.WriteLine("=====================================================================");
                                    }
                                }
                            }
                            break;
                        }

                    case '5':
                        try
                        {
                            listStudents.AddRange(arrStudents);
                            Console.WriteLine("\nStudents of the array inserted to the list.");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nOh no! An exception occurred.\n - Details: " + e.Message);
                        }
                        break;

                    case '6':
                        try
                        {
                            listStudents.Clear();
                            Console.WriteLine("\nStudents of the list were removed.");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nOh no! An exception occurred.\n - Details: " + e.Message);
                        }

                        break;
                    case '7':
                        {
                            Console.WriteLine("Are you sure you want to quit? (Y/N) ");
                            quit = Convert.ToChar(Console.ReadLine().ToLower());
                            if (quit == 'y')
                            {
                                Console.WriteLine("Bye bye!");
                                Console.ReadKey();
                            }
                        }
                        break;
                    default: { } break;
                }//end switch
            } while (option != '7' || quit != 'y');
        }//end Main()
    }
}