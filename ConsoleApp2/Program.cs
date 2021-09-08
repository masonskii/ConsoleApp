namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var NewOrder = new Orders();
            //TODO: Реализовать метод END подсчитывающий всю стоимость заказа в отдельных свойствах. Мб добавить массивы/листы для хранения всех обьектов чай/кофе для подсчета.
        }
    }
    struct CountOrders
    {
        public string itemname;
        public int unitCount;
        public double unitCost;
        public double TotalCost(out double totalCost)
        {

            totalCost = unitCost;
            return totalCost;
        }
    }
}