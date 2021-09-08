using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class CupOfTea : HotDrink, ICup
    {
        string[] tea_previe = { "Черный", "Зеленый" };
        public string Volume { get; set; }
        public string LeafType { get; set; }
        public string Type { get; set; }
        public override int Milk { get; set; }
        public override int Sugar { get; set; }
        public CupOfTea()
        {
            LeafType = tea_previe[0];
            Volume = "0.2";
            Type = "Пластик";
            Milk = 3;
            Sugar = 3;

        }
        public override int AddMilk(int count)
        {
            Milk = count;
            return Milk;
        }
        public string AddLeafType(string count)
        {
            LeafType = count;
            return LeafType;
        }
        public string AddVolume(string count)
        {
            Volume = count;
            return Volume;
        }
        public string AddType(string count)
        {
            Type = count;
            return Type;
        }
        public override int AddSugar(int count)
        {
            Sugar = count;
            return Sugar;
        }

        public override bool Drink(int number)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine
                 (
                      $"Заказ №{number} успешно оформлен: \r\n" +
                      $"{LeafType} чай, обьемом в {Volume} мм\r\nКоличеством сахара и молока: {Sugar} гр., {Milk} мм\r\n" +
                      $"В {Type} стакане;\r\n"
                 );
                Console.ResetColor();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("В оформлении заказа произошла ошибка, попробуйте еще раз.\r\n" + e.Message);
                return false;
            }
        }
        public void Preview()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine
            (
                $"Вид чая: {tea_previe[0]} или {tea_previe[1]} <По умолчанию {tea_previe[0]}>;\r\n" +
                $"Сахар: 0...5 <По умолчанию 3>;\r\n" +
                $"Молоко: 0...10 <По умолчанию 3>;\r\n" +
                $"Тип стакана: Пластик или Стекло <По умолчанию Пластик>;\r\n" +
                $"Обьем: 0.2 или 0.3 <По умолчанию 0.2>;\r\n"
            );
            Console.ResetColor();
        }
        public string Relif()
        {
            return $"Повторить: {Convert.ToString(Type)} c кофе, обьемом {Convert.ToString(Volume)}, количеством сахара {Convert.ToString(Sugar)} и молока {Convert.ToString(Milk)}";
        }

        public string Wash()
        {
            return $"Вымыть {Convert.ToString(Type)} чашку c чаем";
        }
    }
}
