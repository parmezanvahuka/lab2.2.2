using System;
using System.Collections.Generic;

namespace lab2var8
{
    public class Sotrudnik
    {
        public string FnSn;
        public string Grafik;
        public double Payment;

        public Sotrudnik(string FnSn, string Grafik, double Payment)
        {
            this.FnSn = FnSn;
            this.Grafik = Grafik;
            this.Payment = Payment;
        }

        public void Pokaz()
        {
            Console.WriteLine("Фамилия Имя: " + FnSn + " | График: " + Grafik + " | Оплата/час: " + Payment + " руб.");
        }
    }

    public class HRDTB
    {
        private List<Sotrudnik> list = new List<Sotrudnik>();

        public void AddSotrudnika(Sotrudnik str)
        {
            list.Add(str);
        }

        public void PrintAll()
        {
            Console.WriteLine("\n Список сотрудников ");
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Pokaz();
            }
        }

        public void SortByPriceDescending() // пузырим
        {
            for (int i = 0; i < list.Count - 1; i++) // сортим
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j].Payment < list[j + 1].Payment) // i j<j+1 => свап j,j+1
                    {
                        Sotrudnik temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    } 

    class Vybor
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HRDTB db = new HRDTB();

            db.AddSotrudnika(new Sotrudnik("Матвеев Сергей", "11 график", 35));
            db.AddSotrudnika(new Sotrudnik("Перевозчиков Егор", "10 график", 35));
            db.AddSotrudnika(new Sotrudnik("Скрыпников Анатолий", "11 график", 50));
            db.AddSotrudnika(new Sotrudnik("Елтышев Святослав", "10 график", 30));

            while (true)
            {
                Console.WriteLine("\nЧто имеем");
                db.PrintAll();

                Console.WriteLine("\nВыбор:");
                Console.WriteLine("1 - Добавить еще одного сотрудника?");
                Console.WriteLine("2 - Отсортировать?");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("\nВВодные данные");

                    Console.Write("Введите ФИ: ");
                    string FnSn = Console.ReadLine();

                    Console.Write("Введите график: ");
                    string grafik = Console.ReadLine();

                    Console.Write("Введите оплату за один час (руб.): ");
                    double price = double.Parse(Console.ReadLine());

                    db.AddSotrudnika(new Sotrudnik(FnSn, grafik, price));
                    Console.WriteLine("Done...");
                }
                else if (choice == "2")
                {
                    db.SortByPriceDescending();

                    Console.WriteLine("\n=== РЕЗУЛЬТАТ ПОСЛЕ СОРТИРОВКИ ===");
                    db.PrintAll();

                    break;
                }
                else
                {
                    Console.WriteLine("...Всего две цифры бро,попробуй еще раз");
                }
            }

            Console.WriteLine("\nСпасибо за внимание!!!!!!");
            Console.ReadKey();
        }
    }
}
