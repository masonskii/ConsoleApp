using System;

namespace ConsoleApp2
{
    class CupOfCoffe : HotDrink, ICup
    {
        private string[] CoffePreviewBeenType = { "Арабика", "Робуста" };
        //private int[] CoffeAddSugarPreview = { 0, 1, 2, 3, 4, 5 };
        //private int[] CoffeAddMilkPreview = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public string Volume { get; set; }
        public string BeenType { get; set; }
        public string Type { get; set; }
        public override int Milk { get; set; }
        public override int Sugar { get; set; }
        public CupOfCoffe()
        {
            BeenType = CoffePreviewBeenType[0];
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

        public override int AddSugar(int count)
        {
            Sugar = count;
            return Sugar;
        }
        public string AddBeenType(string count)
        {
            BeenType = count;
            return BeenType;
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
        public override bool Drink(int number)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine
                 (
                      $"Заказ №{number} успешно оформлен: \r\n" +
                      $"Кофе с зернами {BeenType}, обьемом в {Volume}мм\r\nКоличеством сахара и молока: {Sugar} гр., {Milk} мм\r\n" +
                      $"В {Type} стакане;\r\n"
                 );
                Console.ResetColor();
                return true;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("В оформлении заказа произошла ошибка, попробуйте еще раз.\r\n" + e.Message);
                Console.ResetColor();
                return false;
            }
        }

        public void Preview()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine
            (
                $"Тип зерен: {CoffePreviewBeenType[0]} или {CoffePreviewBeenType[1]} <По умолчанию {CoffePreviewBeenType[0]}>;\r\n"+
                $"Сахар: 0...5 <По умолчанию 3>;\r\n" +
                $"Молоко: 0...10 <По умолчанию 3>;\r\n" +
                $"Тип стакана: Пластик или Стекло <По умолчанию Пластик>;\r\n" +
                $"Обьем: 0.2 или 0.3 <По умолчанию 0.2>;\r\n"
            );
            Console.ResetColor();
            /*Console.WriteLine
            (
                $"Сахар: "
            );
            foreach (var e in CoffeAddSugarPreview)
            {
                Console.Write
                (
                    $"{e}, "
                );
            }
            Console.Write
            (
                $"{SugarPreview()}"
            );
            Console.WriteLine
            (
                $"Молоко: "
            );
            foreach (var e in CoffeAddMilkPreview)
            {
                Console.Write
                (
                    $"{e}, "
                );
            }
            Console.Write
            (
                $"{SugarPreview()}"
            );*/

        }
        public string Relif()
        {
            return $"Повторить: {Convert.ToString(Type)} c кофе, обьемом {Convert.ToString(Volume)}, количеством сахара {Convert.ToString(Sugar)} и молока {Convert.ToString(Milk)}";
        }

        public string Wash()
        {
            return $"Вымыть {Convert.ToString(Type)} чашку с кофе";
        }
    }
}
