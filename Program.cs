using System;
using System.Collections.Generic;

namespace YetGen
{
    class Program
    {
        class Student
        {
            public string Names { get; set; }
            public int Balance { get; set; }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Student Ahmet = new Student { Names = "Ahmet", Balance = 30 };
            Student Ayse = new Student { Names = "Ayse", Balance = 40 };

            students.Add(Ahmet);
            students.Add(Ayse);
            Console.WriteLine("Yeni bir kayıt mı eklemek istiyorsunuz? \n Evet için e, Hayır için h ye basınız.");
            string choice = Console.ReadLine();

            if (choice == "e")
            {
                AddMember(students);
                Menu(students);
            }

            if (choice == "h")
            {
                Menu(students);
            }
            Console.ReadLine();
        }

        static void Menu(List<Student> students)
        {
            Console.WriteLine("Kullanıcı Adınızı Giriniz:");
            string user = Console.ReadLine();

            Student onlineStudent = students.Find(student => student.Names == user);

            if (onlineStudent != null)
            {
                Console.WriteLine($"\n{onlineStudent.Names} Hoşgeldin! Hesabında {onlineStudent.Balance} TL var.");
            }
            else
            {
                Console.WriteLine("Gecerli bir ad giriniz");
            }
            while (true)
            {
                Console.WriteLine("Yapmak istediğin işlemi seç:\n");
                Console.WriteLine("Para Yatırmak için '+' tuşuna bas.");
                Console.WriteLine("Para Çekmek için '-' tuşuna bas.");
                Console.WriteLine("Çıkış Yapmak için 'q' tuşuna bas.");

                string process = Console.ReadLine();
                if (process == "+")
                {
                    increaseBalance(onlineStudent, students);
                }
                else if (process == "-")
                {
                    decreaseBalance(onlineStudent, students);
                }
                else if (process == "q")
                {
                    Console.WriteLine("Çıkış yapılıyor..");
                    return;
                }
            }
        }

        static void AddMember(List<Student> students)
        {
            Console.WriteLine("İsminizi Giriniz.");
            string name = Console.ReadLine();
            Student newStudent = new Student
            {
                Names = name,
                Balance = 0
            };
            students.Add(newStudent);
            Console.WriteLine($"Merhaba {name}, kaydın başarıyla gerçekleştirildi.");

        }
        static void increaseBalance(Student onlineStudent, List<Student> students)
        {
            Console.WriteLine("Ne kadar yatırmak istiyorsun?");

            int amount = int.Parse(Console.ReadLine());
            onlineStudent.Balance += amount;
            Console.WriteLine($"Güncel bakiyen : {onlineStudent.Balance}");
            Console.WriteLine("İşlemi sonlandırmak veya devam etmek için aşağıdan bir seçenek seç.\n");
        }

        static void decreaseBalance(Student onlineStudent, List<Student> students)
        {
            Console.WriteLine("Ne kadar para çekmek istiyorsun?");

            int amount = int.Parse(Console.ReadLine());
            onlineStudent.Balance -= amount;
            Console.WriteLine($"Güncel bakiyen : {onlineStudent.Balance}");
            Console.WriteLine("İşlemi sonlandırmak veya devam etmek için aşağıdan bir seçenek seç.\n");
        }


    }
}
