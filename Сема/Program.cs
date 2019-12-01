using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Сема
{
    class Program
    {
        static string write_read_Path = @"Data.json";
        static int avaliable = 0;
        private static string data;
        private static string[] numbers;
        static List<Lines> lines = new List<Lines>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            try
            {
                data = File.ReadAllText(write_read_Path);
                lines = JsonConvert.DeserializeObject<List<Lines>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Создать его?\n1) Да\n2) Нет");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    File.Create(write_read_Path).Close();
                }
                else
                {
                    Console.WriteLine("Внимание! Данные не будут сохранены!");
                }
            }
            Menu_level_0();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static void Menu_level_0()
        {
            if (avaliable == 1)
            {
                Write();
                avaliable = 0;
            }
            Console.WriteLine("Программа для инвентаризации оборудования технологических линий.");
            Console.WriteLine("На данный момент количество линий равно " + lines.Count);
            if (lines.Count == 0)
            {
                Console.WriteLine("Выберите действие:\n1) Добавить линию");
                Menu_level_1(Convert.ToInt32(Console.ReadLine()));
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    Console.WriteLine(Convert.ToString(i) + ") " + lines[i].Name);
                }
                Console.WriteLine("Выберите действие:\n1) Добавить линию\n2) Редактировать линию\n3) Удалить линию\n4) Показать информацию");
                Menu_level_1(Convert.ToInt32(Console.ReadLine()));
            }
        }

        static void Menu_level_1(int key)
        {
            Console.Clear();
            switch (key)
            {
                case 1:
                    Console.Write("Введите название линии: ");
                    lines.Add(new Lines(Console.ReadLine()));
                    Console.WriteLine("Хотите добавить оборудование?\n1) Да\n2) Нет");
                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        Menu_level_2(1, lines.Count - 1);
                    }
                    else
                    {
                        avaliable = 1;
                        Console.Clear();
                        Menu_level_0();
                    }
                    break;
                case 2:
                    int a;
                    Console.Write("Выберите нужную линию: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a > (lines.Count - 1))
                    {
                        Console.WriteLine("Такой линии не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        Console.WriteLine("Введите новое имя линии:");
                        lines[a].Update(Console.ReadLine());
                    }
                    break;
                case 3:
                    int b;
                    Console.Write("Выберите нужную линию: ");
                    b = Convert.ToInt32(Console.ReadLine());
                    if (b > (lines.Count - 1))
                    {
                        Console.WriteLine("Такой линии не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        lines.RemoveAt(b);
                        avaliable = 1;
                        Console.Clear();
                        Menu_level_0();
                    }
                    break;
                case 4:
                    int c;
                    Console.Write("Выберите нужную линию: ");
                    c = Convert.ToInt32(Console.ReadLine());
                    if (c > (lines.Count - 1))
                    {
                        Console.WriteLine("Такой линии не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        Console.WriteLine(lines[c].ToString());
                        Console.WriteLine("Выберите действие:\n1) Добавить оборудование\n2) Редактировать оборудование\n3) Удалить оборудование");
                        Console.WriteLine("4) Показать информацию об оборудовании\n5) Назад");
                        int vibr = Convert.ToInt32(Console.ReadLine());
                        if (vibr == 5)
                        {
                            Console.Clear();
                            Menu_level_0();
                        }
                        else
                        {
                            Menu_level_2(vibr, c);
                        }
                    }
                    break;
            }
        }

        static void Menu_level_2(int k, int num)
        {
            Console.Clear();
            switch (k)
            {
                case 1:
                    string name, number, status, specification;
                    Console.Write("Введите название оборудования: ");
                    name = Console.ReadLine();
                    Console.Write("Введите инвентарный номер: ");
                    number = Console.ReadLine();
                    Console.Write("Введите описание оборудования: ");
                    specification = Console.ReadLine();
                    Console.Write("Введите статус оборудования: ");
                    status = Console.ReadLine();
                    lines[num].EquimpentAdd(new Equimpent(name, number, status, specification));
                    avaliable = 1;
                    Console.Clear();
                    Menu_level_0();
                    break;
                case 2:
                    int a;
                    Console.Write("Выберите нужное оборудование: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a > (lines[num].Count() - 1))
                    {
                        Console.WriteLine("Такого оборудования не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        Console.WriteLine("Введите новые изменения в формате имя|номер|статус|описание.Если в секция не требует изменения то нужно поставить -:");
                        lines[num].equimpents[a].Update(Console.ReadLine());
                    }
                    break;
                case 3:
                    int b;
                    Console.Write("Выберите нужное оборудование: ");
                    b = Convert.ToInt32(Console.ReadLine());
                    if (b > (lines[num].Count() - 1))
                    {
                        Console.WriteLine("Такого оборудования не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        lines[num].EquimpentDelete(b);
                        avaliable = 1;
                        Console.Clear();
                        Menu_level_0();
                    }
                    break;
                case 4:
                    int c;
                    Console.Write("Выберите нужное оборудование: ");
                    c = Convert.ToInt32(Console.ReadLine());
                    if (c > (lines[num].Count() - 1))
                    {
                        Console.WriteLine("Такого оборудования не существует");
                        Menu_level_0();
                    }
                    else
                    {
                        Console.WriteLine(lines[c].ToString());
                        Console.WriteLine("Выберите действие:\n1) Назад");
                        if (Convert.ToInt32(Console.ReadLine()) == 1)
                        {
                            Console.Clear();
                            Menu_level_0();
                        }
                        else
                        {
                        }
                    }
                    break;
            }
        }

        static void Write()
        {
            string serialized = JsonConvert.SerializeObject(lines);
            File.WriteAllText(write_read_Path, serialized);
        }
    }
}
