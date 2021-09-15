using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCanteen
{
    class Program
    {
        // Итоговая цена
        static int totalSum = 0;

        // Меню и цены
        static int[] choosedDishes = { -1, -1, -1, -1 };
        static string[] firstDishes = { "Куриный суп", "Суп 'Харчо'", "Борщ", "Щи", "Картофельный суп", "Отмена" };
        static int[] firstPrices = { 100, 125, 75, 115, 150 };
        static string[] secondDishes = { "Запеканка", "Лагман с курицей", "Слоёная картошка", "Жаркое из свинины с картошкой", "Гречка с курицей", "Отмена" };
        static int[] secondPrices = { 25, 75, 50, 80, 60};
        static string[] drink = { "Апельсиновый сок", "Яблочный сок", "Персиковый сок", "Мультифруктовый сок", "Чай", "Отмена" };
        static int[] drinkPrices = { 45, 50, 55, 60, 20};
        static string[] desert = { "Кремовый торт", "Банановое тирамису", "Шоколадный пудинг", "Классический чизкейк", "Мороженое", "Отмена" };
        static int[] desertPrices = { 215, 175, 150, 195, 50};

        static void Main(string[] args)
        {
            string[] Menu = { "Первое", "Второе", "Напитки", "Десерт", "Касса"};

            bool isExit = false;

            while (!isExit)
            {
                Console.Clear();
                DrawChoosed(30, 0);
                int choosedMenu = Select(30, 5, Menu, true);

                Console.Clear();
                switch(choosedMenu)
                {
                    case 0:
                        choosedDishes[choosedMenu] = Select(30, 5, firstDishes, false);
                        if (choosedDishes[choosedMenu] == firstDishes.Length - 1)
                            choosedDishes[choosedMenu] = -1;
                        break;
                    case 1:
                        choosedDishes[choosedMenu] = Select(30, 5, secondDishes, false);
                        if (choosedDishes[choosedMenu] == secondDishes.Length - 1)
                            choosedDishes[choosedMenu] = -1;
                        break;
                    case 2:
                        choosedDishes[choosedMenu] = Select(30, 5, drink, false);
                        if (choosedDishes[choosedMenu] == drink.Length - 1)
                            choosedDishes[choosedMenu] = -1;
                        break;
                    case 3:
                        choosedDishes[choosedMenu] = Select(30, 5, desert, false);
                        if (choosedDishes[choosedMenu] == desert.Length - 1)
                            choosedDishes[choosedMenu] = -1;
                        break;
                    case 4:
                        isExit = true;
                        break;
                }
            }

            DrawChoosed(0, 0);
            Console.WriteLine();
            Console.WriteLine("Вы выбрали блюда на сумму " + totalSum + " рублей.");
            Console.ReadLine();
        }

        // Прорисовываем то, что выбрали
        static void DrawChoosed(int x, int y)
        {
            totalSum = 0;

            string result = "{ ";
            for(int i = 0; i < choosedDishes.Length; i++)
            {
                if(choosedDishes[i] > -1)
                    switch (i)
                    {
                        case 0:
                            result += firstDishes[choosedDishes[i]] + " - " + firstPrices[choosedDishes[i]] + "р. | ";
                            totalSum += firstPrices[choosedDishes[i]];
                            break;
                        case 1:
                            result += secondDishes[choosedDishes[i]] + " - " + secondPrices[choosedDishes[i]] + "р. | ";
                            totalSum += secondPrices[choosedDishes[i]];
                            break;
                        case 2:
                            result += drink[choosedDishes[i]] + " - " + drinkPrices[choosedDishes[i]] + "р. | ";
                            totalSum += drinkPrices[choosedDishes[i]];
                            break;
                        case 3:
                            result += desert[choosedDishes[i]] + " - " + desertPrices[choosedDishes[i]] + "р.";
                            totalSum += desertPrices[choosedDishes[i]];
                            break;
                    }
            }
            result += " }";
            Console.SetCursorPosition(x, y);
            Console.Write(result);
        }

        // Условие выбора
        static int Select(int x, int y, string[] mas, bool isHorizontal)
        {
            int active = 0;

            while (true)
            {
                // Защита от выхода за рамки
                if (active < 0)
                    active = mas.Length - 1;
                if (active > mas.Length - 1)
                    active = 0;

                DrawMenu(x, y, mas, active, isHorizontal);

                ConsoleKeyInfo info = Console.ReadKey(true);

                // Проверяем нажатую кнопку
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(!isHorizontal) active--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (!isHorizontal) active++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (isHorizontal) active--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (isHorizontal) active++;
                        break;
                    case ConsoleKey.Enter:
                        return active;
                    default:
                        break;
                }
            }
        }

        // Отрисовка меню выбора
        static void DrawMenu(int x, int y, string[] mas, int active, bool isHorizontal)
        {
            int length = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            if (isHorizontal)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (i == active)
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(x + length, y);
                    length += mas[i].Length + 1;

                    Console.Write(mas[i]);
                }
            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (i == active)
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(x, y + i);

                    Console.Write(mas[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
