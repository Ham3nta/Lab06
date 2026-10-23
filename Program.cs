using System;

namespace LibraryApp
{
    internal class Program
    {
        const int Capacity = 100;

        static int[] ids = new int[Capacity];
        static string[] titles = new string[Capacity];
        static string[] authors = new string[Capacity];
        static int[] publishYears = new int[Capacity];
        static string[] genres = new string[Capacity];
        static int[] copies = new int[Capacity];
        static bool[] isIssued = new bool[Capacity];

        static int count = 0;
        static int nextId = 1;

        static void Main(string[] args)
        {
            ids[count] = nextId; titles[count] = "Кобзар"; authors[count] = "Шевченко"; publishYears[count] = 1840; genres[count] = "Поезія"; copies[count] = 5; isIssued[count] = false; count++; nextId++;
            ids[count] = nextId; titles[count] = "Тигролови"; authors[count] = "Багряний"; publishYears[count] = 1944; genres[count] = "Роман"; copies[count] = 2; isIssued[count] = true; count++; nextId++;

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1 - Додати книгу");
                Console.WriteLine("2 - Показати всі");
                Console.WriteLine("3 - Знайти за номером");
                Console.WriteLine("4 - Видалити за номером");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (count >= Capacity)
                    {
                        Console.WriteLine("Сховище заповнене!");
                    }
                    else
                    {
                        Console.Write("Назва: ");
                        titles[count] = Console.ReadLine();

                        Console.Write("Автор: ");
                        authors[count] = Console.ReadLine();

                        Console.Write("Рік: ");
                        int.TryParse(Console.ReadLine(), out publishYears[count]);

                        Console.Write("Жанр: ");
                        genres[count] = Console.ReadLine();

                        Console.Write("Кількість примірників: ");
                        int.TryParse(Console.ReadLine(), out copies[count]);

                        Console.Write("Видана? (true/false): ");
                        bool.TryParse(Console.ReadLine(), out isIssued[count]);

                        ids[count] = nextId;
                        count++;
                        nextId++;
                        Console.WriteLine("Книгу додано!");
                    }
                }
                else if (choice == "2")
                {
                    if (count == 0)
                    {
                        Console.WriteLine("Книг немає.");
                    }
                    else
                    {
                        Console.WriteLine("№   | Назва                | Автор           | Рік  | Жанр     | К-сть | Статус");
                        int totalCopies = 0;

                        for (int i = 0; i < count; i++)
                        {
                            string status = "Вільна";
                            if (isIssued[i] == true) status = "Видана";

                            Console.WriteLine($"{ids[i],3} | {titles[i],-20} | {authors[i],-15} | {publishYears[i],4} | {genres[i],-8} | {copies[i],5} | {status}");
                            totalCopies += copies[i];
                        }
                        Console.WriteLine($"Усього унікальних книг: {count}, всього примірників: {totalCopies}");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Номер для пошуку: ");
                    int.TryParse(Console.ReadLine(), out int searchId);

                    int index = -1;
                    for (int i = 0; i < count; i++)
                    {
                        if (ids[i] == searchId)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("Книгу не знайдено.");
                    }
                    else
                    {
                        Console.WriteLine($"Знайдено в позиції {index}: {titles[index]} ({authors[index]})");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Номер для видалення: ");
                    int.TryParse(Console.ReadLine(), out int deleteId);

                    int index = -1;
                    for (int i = 0; i < count; i++)
                    {
                        if (ids[i] == deleteId)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("Книгу не знайдено.");
                    }
                    else
                    {
                        for (int i = index; i < count - 1; i++)
                        {
                            ids[i] = ids[i + 1];
                            titles[i] = titles[i + 1];
                            authors[i] = authors[i + 1];
                            publishYears[i] = publishYears[i + 1];
                            genres[i] = genres[i + 1];
                            copies[i] = copies[i + 1];
                            isIssued[i] = isIssued[i + 1];
                        }
                        count--;

                        ids[count] = 0;
                        titles[count] = "";
                        authors[count] = "";
                        publishYears[count] = 0;
                        genres[count] = "";
                        copies[count] = 0;
                        isIssued[count] = false;

                        Console.WriteLine("Книгу видалено.");
                    }
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Немає такого пункту меню.");
                }
            }
        }
    }
}
