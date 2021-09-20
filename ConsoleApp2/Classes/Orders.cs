using System;

namespace ConsoleApp2
{
    class Orders
    {
        private int _number = 0;
        public int Number
        {
            get => _number;
            set => _number = value;
        }
        public bool IsCoffeOrTea { get; set; }
        public Orders()
        {
            CupOfCoffe cupOfCoffe = new CupOfCoffe();
            Random r = new Random();
            CupOfTea cupOfTea = new CupOfTea();
            Console.WriteLine("Мы внимательно записываем!");;
            if (!Order(cupOfCoffe, cupOfTea, r)) End();
        }
        private void End()
        {
            var allCost = new CostOrders();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Общая стоимость заказа составляет = {allCost.TotalCost()}.99 руб.");
            Console.ResetColor();
        }
        private bool isWash()
        {
            try
            {
                Console.Write("Вымыть чашку? Да <1> или Нет <2>: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int wash = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (wash)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        return isWash();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return isWash();
            }
        }
        private bool Order(CupOfCoffe obj1, CupOfTea obj2, Random obj3)
        {
            Number = obj3.Next(1, 10000);
            if (isCoffeOrTea())
            {
                if (!CoffeOrder(obj1, Number))
                {
                    if (isWash())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(obj1.Wash());
                        Console.ResetColor();
                    }
                    return false;
                }
                return true;
            }
            else
            {
                if (!TeaOrder(obj2, Number))
                {
                    if (isWash())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(obj2.Wash());
                        Console.ResetColor();
                    }
                    return false;
                }
                else
                    return true;
            }

        }
        private bool CoffeOrder(CupOfCoffe obj, int Number)
        {
            obj.Preview();
            if (isDefault())
            {
                if (obj.Drink(Number))
                {
                    if (isReload())
                    {
                        CupOfCoffe coffe = new CupOfCoffe();
                        Random r = new Random();
                        CupOfTea tea = new CupOfTea();
                        return Order(coffe, tea, r);
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                if (CoffeOrderNotDefault(ref obj))
                {
                    if (obj.Drink(Number))
                    {
                        if (isReload())
                        {
                            CupOfCoffe coffe = new CupOfCoffe();
                            Random r = new Random();
                            CupOfTea tea = new CupOfTea(); 
 
                            return Order(coffe, tea, r);
                        }
                        else return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool CoffeOrderNotDefault(ref CupOfCoffe obj)
        {
            try
            {
                obj.AddBeenType(GrainSelection());
                obj.AddSugar(ChoosingAmountSugar());
                obj.AddMilk(ChoosingAmountMilk());
                obj.AddType(TypeSelection());
                obj.AddVolume(VolumeSelection());
                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
        }
        private string GrainSelection()
        {
            if (IsCoffeOrTea)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Выберите тип зерна: Арабика <1> или Робуста <2>; ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    var BeenType = Convert.ToInt32(Console.ReadLine());
                    switch (BeenType)
                    {
                        case 1:
                            return "Арабика";
                        case 2:
                            return "Робуста";
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine
                            (
                                "Не найден выбранный вариант, повторите попытку;"
                            );
                            Console.ResetColor();
                            return GrainSelection();
                    }
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    return GrainSelection();
                }
            }
            else
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Выберите тип чая: Черный <1> или Зеленый <2>; ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    var LeafType = Convert.ToInt32(Console.ReadLine());
                    switch (LeafType)
                    {
                        case 1:
                            return "Черный";
                        case 2:
                            return "Зеленый";
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine
                            (
                                "Не найден выбранный вариант, повторите попытку;"
                            );
                            Console.ResetColor();
                            return GrainSelection();
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    return GrainSelection();
                }
            }
        }
        private int ChoosingAmountSugar()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Напиши количество добавляемого сахара: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int ValueSugar = Convert.ToInt32(Console.ReadLine());
                if (ValueSugar >= 0 && ValueSugar <= 5)
                    return ValueSugar;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine
                    (
                        "Не найден выбранный вариант, повторите попытку;"
                    );
                    Console.ResetColor();
                    return ChoosingAmountSugar();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return ChoosingAmountSugar();
            }
        }
        private int ChoosingAmountMilk()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Напиши количество добавляемого молока: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int ValueMilk = Convert.ToInt32(Console.ReadLine());
                if (ValueMilk >= 0 && ValueMilk <= 10)
                    return ValueMilk;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine
                    (
                        "Не найден выбранный вариант, повторите попытку;"
                    );
                    Console.ResetColor();
                    return ChoosingAmountMilk();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return ChoosingAmountMilk();
            }

        }
        private string TypeSelection()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Выберите чашку: Пластик <1> или Стекло <2>; ");
                Console.ForegroundColor = ConsoleColor.Red;
                var TypeCup = Convert.ToInt32(Console.ReadLine());
                switch (TypeCup)
                {
                    case 1:
                        return "Пластик";
                    case 2:
                        return "Стекло";
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        Console.ResetColor();
                        return TypeSelection();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return TypeSelection();
            }
        }
        private string VolumeSelection()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Выберите обьем: 0.2 <1> или 0.3 <2>; ");
                Console.ForegroundColor = ConsoleColor.Red;
                var TypeCup = Convert.ToInt32(Console.ReadLine());
                switch (TypeCup)
                {
                    case 1:
                        return "0.2";
                    case 2:
                        return "0.3";
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        Console.ResetColor();
                        return VolumeSelection();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return VolumeSelection();
            }
        }
        private bool TeaOrder(CupOfTea obj, int Number)
        {
            obj.Preview();
            if (isDefault())
            {
                if (obj.Drink(Number))
                {
                    if (isReload())
                    {
                        CupOfCoffe coffe = new CupOfCoffe();
                        Random r = new Random();
                        CupOfTea tea = new CupOfTea();
                        return Order(coffe, tea, r);
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                if (TeaOrderNotDefault(ref obj))
                {
                    if (obj.Drink(Number))
                    {
                        if (isReload())
                        {
                            CupOfCoffe coffe = new CupOfCoffe();
                            Random r = new Random();
                            CupOfTea tea = new CupOfTea();
                            return Order(coffe, tea, r);
                        }
                        else return false;
                    }
                    else return false;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool TeaOrderNotDefault(ref CupOfTea obj)
        {
            try
            {
                obj.AddLeafType(GrainSelection());
                obj.AddSugar(ChoosingAmountSugar());
                obj.AddMilk(ChoosingAmountMilk());
                obj.AddType(TypeSelection());
                obj.AddVolume(VolumeSelection());
                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
        }
        private bool isCoffeOrTea()
        {
            try
            {
                Console.Write("Выберите напиток: кофе <1> или чай <2> :");
                Console.ForegroundColor = ConsoleColor.Red;
                int CoffeOrTea = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (CoffeOrTea)
                {
                    case 1:
                        IsCoffeOrTea = true;
                        return true;
                    case 2:
                        IsCoffeOrTea = false;
                        return false;
                    default:
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        return isCoffeOrTea();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return isCoffeOrTea();
            }
        }
        private bool isDefault()
        {
            try
            {
                Console.Write("Оставить все по умолчанию и запустить? Да <1> или Нет <2>: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int defaultSettings = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (defaultSettings)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        return isDefault();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return isDefault();
            }
        }
        private bool isReload()
        {
            try
            {
                Console.Write("Повторить заказ? Да <1> или Нет <2>: ");
                Console.ForegroundColor = ConsoleColor.Red;
                int reload = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                switch (reload)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine
                        (
                            "Не найден выбранный вариант, повторите попытку;"
                        );
                        Console.ResetColor();
                        return isReload();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return isReload();
            }
        }
    }

}
