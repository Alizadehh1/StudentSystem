using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TaskStudentMenu
{
    [Serializable]
    class Program
    {
        static string fileName = @"Lists.dat";

        [Obsolete]
        static void Main(string[] args)
        {
            int count = 1;
            int index;
            bool cancel = true;
            bool cancel1 = true;
            bool cancel2 = true;
            List<Student> ls = LoadFromFile(fileName);
            while (cancel1!=false)
            {
                salam:
                Console.Clear();
                PrintMenu1();
                Console.Write("Select Menu: ");
                int selectedmenu1 = Convert.ToInt32(Console.ReadLine());
                switch (selectedmenu1)
                {
                    case 1:
                        {
                            while (cancel != false)
                            {
                                salam1:
                                Console.Clear();
                                PrintMenu2();
                                Console.Write("Select Menu: ");
                                int selectedmenu = Convert.ToInt32(Console.ReadLine());

                                switch (selectedmenu)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Student s = new Student();

                                            Console.Write("Name: ");
                                            s.Name = Console.ReadLine();

                                            Console.Write("Surname: ");
                                            s.SurName = Console.ReadLine();

                                            Console.Write("Gender (For Male-1, For Female-2): ");
                                            s.Gender = (Gender)Convert.ToInt32(Console.ReadLine());

                                            Console.Write("Age: ");
                                            s.Age = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("School: ");
                                            s.School = Console.ReadLine();

                                            Console.Write("Grade: ");
                                            s.Grade = Console.ReadLine();


                                            ls.Add(s);
                                            while (cancel2!=false)
                                            {
                                                
                                                Console.WriteLine("1)Save and back to Main Menu");
                                                Console.WriteLine("2)Back to Main Menu");
                                                Console.Write("Select Menu: ");
                                                int selectedmenu2 = Convert.ToInt32(Console.ReadLine());

                                                switch (selectedmenu2)
                                                {
                                                    case 1:
                                                        {
                                                            SaveToFile(ls, fileName);
                                                            goto salam1;
                                                        }
                                                    case 2:
                                                        {
                                                            goto salam1;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                            


                                            break;
                                        }
                                     case 2:
                                        {
                                            Console.Clear();
                                            goto salam;
                                        }
                                    default:
                                        break;
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            while (cancel1!=false)
                            {
                                count = 1;
                                Console.Clear();
                                PrintMenu3();
                                Console.Write("Select Menu: ");
                                int selectedmenu2 = Convert.ToInt32(Console.ReadLine());
                                switch (selectedmenu2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of Students");
                                            
                                            foreach (var item in ls)
                                            {
                                                Console.WriteLine(item);
                                            }
                                            Console.Write("If you want back to the menu enter any key!");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of Students");
                                            
                                            foreach (var item in ls)
                                            {
                                                Console.Write($"[{count}]");
                                                Console.WriteLine(item);
                                                count++;
                                            }
                                            Console.Write("Remove by index:");
                                            index = Convert.ToInt32(Console.ReadLine());
                                            ls.RemoveAt(index-1);
                                            Console.Write("If you want back to the menu enter any key!");
                                            Console.ReadKey();

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            SaveToFile(ls, fileName);
                                            cancel1 = false;
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            cancel1 = false;
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            goto salam;
                                        }
                                    default:
                                        break;
                                }
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            SaveToFile(ls, fileName);
                            cancel1 = false;
                            break;
                        }
                    default:
                        break;
                }
                    
                }
            }
                
        static void PrintMenu1()
        {
            Console.WriteLine("1)Student's Menu");
            Console.WriteLine("2)Teacher's Menu");
            Console.WriteLine("3)Save and Exit");  
        }
        static void PrintMenu2()
        {
            Console.WriteLine("1)Registration for Students");
            Console.WriteLine("2)Back to Main Menu");
        }
        static void PrintMenu3()
        {
            Console.WriteLine("1)List of Students");
            Console.WriteLine("2)Remove any Student by index");
            Console.WriteLine("3)Save and Exit");
            Console.WriteLine("4)Exit Menu");
            Console.WriteLine("5)Back to Main Menu");
        }
        [Obsolete]
        static void SaveToFile(List<Student> ls,string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, ls);
            }
        }
        [Obsolete]
        static List<Student> LoadFromFile(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    return (List<Student>)bf.Deserialize(fs);

                }
            }
            catch (Exception)
            {

                return new List<Student>();
            }
        }      
    }
}
