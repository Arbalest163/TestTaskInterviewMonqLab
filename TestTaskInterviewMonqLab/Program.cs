using System;
using System.Collections.Generic;

namespace TestTaskInterviewMonqLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        /*
        Задача 1.
        Напишите программу, которая выводит на экран числа от 1 до 100.
        При этом вместо чисел, кратных трем, программа должна выводить слово Fizz, а вместо чисел, кратных пяти — слово Buzz.
        Если число кратно одновременно 3 и 5, то программа должна выводить слово FizzBuzz.
        */
        static void Task1()
        {
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        /*
        Задача 2.
        Имеется древовидная структура групп пользователей произвольной вложенности подгрупп.
        Пользователь может входить в несколько групп одновременно.
        Требуется получить список всех пользователей во всех группах в виде IEnumerable<User> users методом рекурсии.
        */
        static void Task2()
        {
            var rootGroups = CreateGroups();

            var users = AllUserGroup(rootGroups);// Решение.

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        static IEnumerable<User> AllUserGroup(IEnumerable<Group> groups)
        {
            foreach (var group in groups)
            {
                if (group.Children.Count > 0)
                {
                    foreach (var user in AllUserGroup(group.Children))
                    {
                        yield return user;
                    }
                }
                foreach (var user in group.Users)
                {
                    yield return user;
                }
            }
        }
        /// Метод формирования списка групп пользователей.
        /// Метод не требует реализации.
        static IEnumerable<Group> CreateGroups()
        {
            var groups = new List<Group>()
    {
        new Group("Группа1")
        {
            Users = new List<User>
            {
                new User("User1"),
                new User("User2")
            }
        },
        new Group("Группа2")
        {
            Children = new List<Group>()
            {
                new Group("Группа3")
                {
                    Users = new List<User>
                    {
                        new User("User5"),
                        new User("User6")
                    }
                },
                new Group("Группа4")
                {
                    Children = new List<Group>()
                    {
                        new Group("Группа5")
                        {
                            Users = new List<User>
                            {
                                new User("User9"),
                                new User("User10")
                            }
                        },
                        new Group("Группа6")
                        {
                            Children = new List<Group>()
                            {
                                new Group("Группа7")
                                {
                                    Users = new List<User>
                                    {
                                        new User("User13"),
                                        new User("User14")
                                    }
                                },
                                new Group("Группа8")
                                {
                                    Children = new List<Group>()
                                    {
                                        new Group("Группа9")
                                        {
                                            Users = new List<User>
                                            {
                                                new User("User15"),
                                                new User("User16")
                                            }
                                        },
                                        new Group("Группа10")
                                        {

                                            Users = new List<User>
                                            {
                                                new User("User17"),
                                                new User("User18")
                                            }
                                        }
                                    },
                                    Users = new List<User>
                                    {
                                        new User("User19"),
                                        new User("User20")
                                    }
                                }
                            },
                            Users = new List<User>
                            {
                                new User("User11"),
                                new User("User12")
                            }
                        }
                    },
                    Users = new List<User>
                    {
                        new User("User7"),
                        new User("User8")
                    }
                }
            },
            Users = new List<User>
            {
                new User("User3"),
                new User("User4")
            }
        }
    };
            // groups.Add();
            return groups;
        }

        /// Модель группы пользователей.
        class Group
        {
            public string Name { get; set; }
            public ICollection<Group> Children { get; set; } = new List<Group>();
            public ICollection<User> Users { get; set; } = new List<User>();

            public Group(string name)
            {
                Name = name;
            }
        }

        /// Модель пользователя.
        class User
        {
            public string Name { get; set; }

            public User(string name)
            {
                Name = name;
            }
        }
    }
}
