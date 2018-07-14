using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace ConsoleApp5
{
    public class Program
    {
        private static List<Students> list = new List<Students>()
        {
            new Students("A001", "hung", "hung@gmail.com", "091235646"),
            new Students("A002", "hung", "hung@gmail.com", "091235646"),
            new Students("A003", "hung", "hung@gmail.com", "091235646"),
            new Students("A004", "hung", "hung@gmail.com", "091235646"),
            new Students("A005", "hung", "hung@gmail.com", "091235646")
        };
        private static void GenerateMenu()
        {
            while (true)
            {
                Console.WriteLine("---------Student Managent------------");
                Console.WriteLine("1. Add new student");
                Console.WriteLine("2. Display students");
                Console.WriteLine("3. Search student by name");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Please enter your choice: ");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudents();
                        break;
                    case 2:
                        DispllayStudents();
                        break;
                    case 3:
                        SearchByName();
                        break;
                    case 4:
                        Console.WriteLine("Thank you! Bye bye.");
                        break;
                }

                if (choice == 4)
                {
                    Environment.Exit(1);
                    break;
                }
            }
        }

        private static void AddStudents()
        {
            while (true)
            {
                Students students = new Students();
                
                Console.WriteLine("Please enter roll name: ");
                students.RollNumber = Console.ReadLine();
                
                Console.WriteLine("Please enter name: ");
                students.Name = Console.ReadLine();
                
                Console.WriteLine("Please enter email: ");
                students.Email = Console.ReadLine();
                
                Console.WriteLine("Please enter phone: ");
                students.Phone = Console.ReadLine();
                
                list.Add(students);

                Console.WriteLine("Wanna continue? (y/n)");
                string choice = Console.ReadLine();
                if (choice == "n")
                {
                    break;
                }
            }
        }
        
        private static void DispllayStudents()
        {
            Console.WriteLine(" ----------Student List-----------");
            Console.WriteLine("{0, -15}{1, -15}", "Name", "RollNumber");
            for (int i = 0; i < list.Count; i++)
            {
                
                Console.WriteLine("{0, -15}{1, -15}", list[i].Name, list[i].RollNumber);
            }
        }
        
        private static void SearchByName()
        {
            Console.WriteLine("Please enter search name: ");
            string name = Console.ReadLine();
            int count = 0;
            foreach (var students in list)
            {
                if (students.Name == name)
                {
                    Console.WriteLine("{0, -15}{1, -15}", students.Name, students.RollNumber);
                    count++;
                }
            }

            Console.WriteLine("Found" + " " + count +" "+ "student with name match" + " " + name + "");
        }
        
        
        static void Main()
        {
            GenerateMenu();
        } 
    }
}