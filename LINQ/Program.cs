using System.Linq;
using System.Collections.Generic;
using static LINQ.Program;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Runtime.InteropServices;

namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            var phoneBook = new List<Contact>();

           
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            Console.WriteLine("Введите число для отображения списка контактов");
            Console.WriteLine("Можно ввести только цифры: 1, 2, 3, 4: первые три - отображение списка контактов по странице \n4 - отсортированный список всех товарищей");

            while (true)
            { 
                var key = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (key)
                {
                    case '1':
                        {
                            var page1 = phoneBook.Take(2);
                            foreach(var p1 in page1 )
                                Console.WriteLine(p1.Name + " " + p1.LastName + " " + p1.PhoneNumber + " " + p1.Email);
                            break;
                        
                        }
                    case '2':
                        {
                            var page2 = phoneBook.Skip(2).Take(2);
                            foreach (var p2 in page2)
                                Console.WriteLine(p2.Name + " " + p2.LastName + " " + p2.PhoneNumber + " " + p2.Email);
                            break;

                        }
                    case '3':
                        {
                            var page3 = phoneBook.Skip(4);
                            foreach (var p3 in page3)
                                Console.WriteLine(p3.Name + " " + p3.LastName + " " + p3.PhoneNumber + " " + p3.Email);
                            break;
                        }
                    case '4':
                        { 
                            var sort = phoneBook.OrderBy(p => p.Name).ThenBy(p => p.LastName);
                            foreach (var s in sort)
                                Console.WriteLine(s.Name + " " + s.LastName + " " + s.PhoneNumber + " " + s.Email);
                            break;

                        }


                    default:
                        Console.WriteLine("Введено неверное значение: можно только 1, 2, 3 или 4");
                        break;
                }


            }


        }

    }



    }

    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }



