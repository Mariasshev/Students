using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
        class Person
        {
            private string name;
            private string surname;
            private int age;
            private int phone;
            
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }

            public int Phone
            {
                get { return phone; }
                set { phone = value; }
            }
            public int Age 
            {
                get { return age;} 
                set { age = value;}
            }

            public Person() : this(null, null, 0, 0){ }

            public Person(string name, string surname, int age, int phone)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
                this.phone = phone;
            }

            public void Print()
            {
                Console.WriteLine($"Student {this.Name} {this.Surname}");
                Console.WriteLine($"Age: {this.Age}");
                Console.WriteLine($"Phone: {this.Phone}");
            }


        }

        class Student: Person
        {
            private double average;
            private int number_of_group;

            public double Average
            {
                get { return average; }
                set { average = value; }
            }

            public int Number_Of_Group
            {
                get { return number_of_group;}
                set { number_of_group = value;}
            }

            public Student() :this(0.0, 0, null, null, 0, 0){}

            public Student(double average, int number_of_group, string name, string surname, int age, int phone): base(name, surname, age, phone)
            {
                this.average = average;
                this.Number_Of_Group = number_of_group;
            }

            new public void Print(){
                base.Print();
                Console.WriteLine($"Average: {Average}");
                Console.WriteLine($"Number of group: {Number_Of_Group}");
            }


        }

        class Academy_Group
        {
            Student[] students;
            private int count;

            public Academy_Group(){
                this.count = 0;
                students = new Student[5];
            }

            public Academy_Group(Student student):this()
            {
                this.count=0;
                Add(student);
            }

            public void Add(Student student)
            {
                if(count < students.Length)
                {
                    students[count] = student;
                    count++;
                }
                else
                {
                    Console.WriteLine("No place for new Student!");
                }
            }

            public void Remove(string surname)
            {
                int newIndex = 0;
                int myInd = 0;
                bool check = false;
                for (int i = 0; i < this.count; i++)
                {
                    if (students[i].Surname == surname)
                    {
                        check = true;
                        newIndex = i + 1;
                        students[i] = students[newIndex];
                        myInd = i+1;
                        newIndex++;
                    }
                    if(newIndex > 0)
                    {
                        students[myInd] = students[newIndex];
                        myInd++;
                        newIndex++;
                    }
                }
                if (!check)
                {
                    Console.WriteLine($"There is no student with surname {surname}");
                }
                else { Console.WriteLine("Student is deleted successfully!"); }
            }

            public void Edit(string surname)
            {
                bool check = false;
                int findIndex = 0;
                for (int i = 0; i < this.count; i++)
                {
                    if (students[i].Surname == surname)
                    {
                        check = true;
                        findIndex = i;
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine($"There is no student with surname {surname}");
                }
                else { 
                    Console.WriteLine("What do you want to edit?\n[1] - name [2] - surname [3] - age [4] - phone");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter new name: ");
                            students[findIndex].Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter new surname: ");
                            students[findIndex].Surname = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter new age: ");
                            students[findIndex].Age = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter new phone: ");
                            students[findIndex].Phone = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Incorrect choice!");
                            break;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Group");
                for(int i = 0; i < this.count;i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].Name} {students[i].Surname}");
                }
                Console.WriteLine("----------");
            }

            public void Save()
            {
                Console.WriteLine("Data saved successfully!");
            }
            public void Load()
            {
                Console.WriteLine("Data from file: ");
                Print();
            }

            public void Search()
            {
                Console.WriteLine("Choose a category\n[1] - name [2] - surname [3] - age [4] - phone");
                int choice = int.Parse(Console.ReadLine());
                bool check = false;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name to find: ");
                        string name = Console.ReadLine();
                        for (int i = 0; i < this.count; i++)
                        {
                            if (students[i].Name == name)
                            {
                                check= true;
                                Console.WriteLine("student found!");
                                students[i].Print();
                                break;
                            }
                        }
                        if (!check) { Console.WriteLine("Error!"); }
                        break;
                    case 2:
                        Console.WriteLine("Enter surname to find: ");
                        string surname = Console.ReadLine();
                        for (int i = 0; i < this.count; i++)
                        {
                            if (students[i].Surname == surname)
                            {
                                check = true;
                                Console.WriteLine("student found!");
                                students[i].Print();
                                break;
                            }
                        }
                        if (!check) { Console.WriteLine("Error!"); }
                        break;
                    case 3:
                        Console.WriteLine("Enter age to find: ");
                        int age = int.Parse(Console.ReadLine());
                        for (int i = 0; i < this.count; i++)
                        {
                            if (students[i].Age == age)
                            {
                                check = true;
                                Console.WriteLine("student found!");
                                students[i].Print();
                                break;
                            }
                        }
                        if (!check) { Console.WriteLine("Error!"); }
                        break;
                    case 4:
                        Console.WriteLine("Enter phone to find: ");
                        int phone = int.Parse(Console.ReadLine());
                        for (int i = 0; i < this.count; i++)
                        {
                            if (students[i].Phone == phone)
                            {
                                check = true;
                                Console.WriteLine("student found!");
                                students[i].Print();
                                break;
                            }
                        }
                        if (!check) { Console.WriteLine("Error!"); }
                        break;
                    default:
                        Console.WriteLine("Incorrect choice!");
                        break;
                }
            }
        }

    class MainClass
    {
        public static void Main()
        {
            Student student1 = new Student(11, 221, "Oleg", "Red", 19, 123456789);
            Student student2 = new Student(11, 221, "Maria", "Vivien", 18, 123456789);
            Academy_Group group221 = new Academy_Group(student1);
            group221.Add(student2);
            student1.Print();
            group221.Print();

            group221.Edit("Red");
            group221.Print();

            group221.Save();
            group221.Load();
        }
        
    }
}
