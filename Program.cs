using System.Linq;
using System.Text;

Main.Order start = new();
start.Menu();

public class Basket
{
    public static List<Cake> Cakes = new();

}

public class RezultValuesCake
{
    public string Name { get; set; }
    public Double Price { get; set; }
}
public class Cake
{
    public string BodyCake { get; set; }
    public string SizeCake { get; set; }
    public string[] TastyCake { get; set; }
    public int CountCake { get; set; }
    public string[] GlazePrice { get; set; }
    public string[] DecorCake { get; set; }
    public Double TotalPrice { get; set; }
}


public class Library
{
    public static Dictionary<Double, string> BodyCake = new Dictionary<Double, string>()
    {
        { 100, "Круг"},
        { 400, "Сердце"},
        { 300, "Квадрат"}
    };
    public static Dictionary<Double, string> SizeCake = new()
    {
        { 1200, "Большая"},
        { 900, "Средняя"},
        { 700, "Маленькая"}
    };
    public static Dictionary<Double, string> TastyCake = new Dictionary<Double, string>()
    {
        { 500, "Шоколадные"},
        { 900, "Фруктовые"},
        { 700, "Йогуртовые"}
    };
    public static Dictionary<Double, string> DecorCake = new Dictionary<Double, string>()
    {
        { 200, "Печать съедобных картинок"},
        { 50, "Сахарные украшения"},
        { 150, "Вафельные украшения"}
    };
    public static Dictionary<Double, string> GlazePrice = new Dictionary<Double, string>()
    {
        { 0, "Прозрачными"},
        { 100, "Блестящими"},
        { 150, "Матовыми"}
    };
}

internal class Main
{
    public class Order
    {
        public void Menu()
        {
            while (true)
            {

                Console.Clear();
                if (Basket.Cakes.Count > 0)
                {
                    Console.WriteLine($"Итоговая сумма - {Basket.Cakes.Sum(x => x.CountCake * x.TotalPrice)}");
                }
                Console.WriteLine("Кондитерская - Выбирите действия");
                Console.WriteLine("1.Создать торт");
                if (Basket.Cakes.Count > 0)
                {
                    Console.WriteLine("2.Корзина");
                    Console.WriteLine("3.Создать заказ");
                }
                Console.WriteLine("Введите команду");
                Console.WriteLine("-------------");
                int comand = 0;
                bool status = int.TryParse(Console.ReadLine(), out comand );
                if (!status) continue;
                switch (comand)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        ShowBasket();
                        break;
                    case 3:
                        CreateOrderTxt();
                        return;
                    default:
                        Console.WriteLine("Неправльный ввод команды");
                        Menu();
                        break;
                }
            }
        }
        public void Create()
        {
            string _bodyCake = string.Empty, _size = string.Empty;
            List<string> _glazePrice = new(), _decor = new(), _tasty = new();
            int _count = 1;
            double _price = 0;
            List<int> blockComand = new();
            while (true)
            {
                Console.Clear();
                if (_price > 0)
                {
                    Console.WriteLine($"Итоговая сумма - {_price * _count}");
                }
                Console.WriteLine("Для выхода из создание нажмите Escape");
                if (string.IsNullOrEmpty(_bodyCake))
                {
                    Console.WriteLine("1.Форма");
                }
                if(string.IsNullOrEmpty(_size))
                {
                    Console.WriteLine("2.Размер ");
                }
                Console.WriteLine("3.Количество");
                Console.WriteLine("4.Глазурь");
                Console.WriteLine("5.Декор");
                Console.WriteLine("6.Вкусовая добавка");
                Console.WriteLine("7.Создать торт");
                Console.WriteLine("-------------");
                ConsoleKeyInfo keyValue = Console.ReadKey();
                if (keyValue.Key == ConsoleKey.Escape)
                {
                    Menu();
                    return;
                }
                int chapter = int.Parse(keyValue.KeyChar.ToString());
                if (chapter.Equals(7))
                {
                    break;
                }
                Library _library = new();
                if (blockComand.Any(c => c.Equals(chapter))) { continue; }
                int number;
                int position = 1;
                bool step;
                switch (chapter)
                {
                    case 1:
                        Console.WriteLine("Какую форму использовать?");
                        position = 1;
                        foreach (var item in Library.BodyCake)
                        {
                            Console.WriteLine($"{position}.{item.Key} цена - {item.Value} ");
                            position++;
                        }
                        Console.WriteLine($"{position}.Создать новый пункт");
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(Library.BodyCake.Count + 1)) 
                            { 
                                CreateParam(Library.BodyCake); 
                            }
                            else
                            {
                                _bodyCake = Library.BodyCake.ElementAt(currectIndex(Library.BodyCake, number)).Value;
                                _price += Library.BodyCake.ElementAt(currectIndex(Library.BodyCake, number)).Key;
                                blockComand.Add(1);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Какой размер?");
                        position = 1;
                        foreach (var item in Library.SizeCake)
                        {
                            Console.WriteLine($"{position}.{item.Key} цена - {item.Value} ");
                            position++;
                        }
                        Console.WriteLine($"{position}.Создать новый пункт");
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(Library.SizeCake.Count + 1))
                            {
                                CreateParam(Library.SizeCake);
                            }
                            else
                            {
                                _size = Library.SizeCake.ElementAt(currectIndex(Library.SizeCake, number)).Value;
                                _price += Library.SizeCake.ElementAt(currectIndex(Library.SizeCake, number)).Key;
                                blockComand.Add(2);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Сколько тортов в заказе?");
                        position = 1;
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(0))
                            {
                                _count = 1;
                                break;
                            }
                            _count = number;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Укажите глазурь?");
                        position = 1;
                        foreach (var item in Library.GlazePrice)
                        {
                            Console.WriteLine($"{position}.{item.Key} цена - {item.Value} ");
                            position++;
                        }
                        Console.WriteLine($"{position}.Создать новый пункт");
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(Library.GlazePrice.Count + 1))
                            {
                                CreateParam(Library.GlazePrice);
                            }
                            else
                            {
                                _glazePrice.Add(Library.GlazePrice.ElementAt(currectIndex(Library.GlazePrice, number)).Value);
                                _price += Library.GlazePrice.ElementAt(currectIndex(Library.GlazePrice, number)).Key;
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Укажите декор?");
                        position = 1;
                        foreach (var item in Library.DecorCake)
                        {
                            Console.WriteLine($"{position}.{item.Key} цена - {item.Value} ");
                            position++;
                        }
                        Console.WriteLine($"{position}.Создать новый пункт");
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(Library.DecorCake.Count + 1))
                            {
                                CreateParam(Library.DecorCake);
                            }
                            else
                            {
                                _decor.Add(Library.DecorCake.ElementAt(currectIndex(Library.DecorCake, number)).Value);
                                _price += Library.DecorCake.ElementAt(currectIndex(Library.DecorCake, number)).Key;
                            }
                           
                        }
                        break;
                    case 6:
                        Console.WriteLine("Укажите вкусовую добавку?");
                        position = 1;
                        foreach (var item in Library.DecorCake)
                        {
                            Console.WriteLine($"{position}.{item.Key} цена - {item.Value} ");
                            position++;
                        }
                        Console.WriteLine($"{position}.Создать новый пункт");
                        step = int.TryParse(Console.ReadLine(), out number);
                        if (step)
                        {
                            if (number.Equals(Library.TastyCake.Count + 1))
                            {
                                CreateParam(Library.TastyCake);
                            }
                            else
                            {
                                _tasty.Add(Library.TastyCake.ElementAt(currectIndex(Library.TastyCake, number)).Value);
                                _price += Library.TastyCake.ElementAt(currectIndex(Library.TastyCake, number)).Key;
                            }

                        }
                        break;
                }
            }
            Cake createCake = new()
            {
                BodyCake = _bodyCake,
                CountCake = _count,
                DecorCake = _decor.ToArray(),
                GlazePrice = _glazePrice.ToArray(),
                TastyCake = _tasty.ToArray(),
                SizeCake = _size,
                TotalPrice = _price
            };
            Basket.Cakes.Add(createCake);
            Menu();
        }
        private void CreateParam(Dictionary<double, string> keyValues)
        {

            Console.WriteLine("Укажите новое название");
            string name = Console.ReadLine();
            Console.WriteLine("Укажите цену");
            int price = int.Parse(Console.ReadLine());
            keyValues.Add(price, name);
        }
        private int currectIndex(Dictionary<double,string> keyValues, int number)
        {
            int index = number - 1;
            if (keyValues.Count < index)
            {
                return keyValues.Count -1;
            }
            return index;
        }
        private string BasketTxt()
        {
            StringBuilder rez = new StringBuilder();
            int position = 1;
            rez.Append($"Заказ от <{DateTime.Now}>");

            foreach (var item in Basket.Cakes)
            {
                rez.Append("\n"+($"Торт - {position}"));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "форма", item.BodyCake)));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "размер", item.SizeCake)));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "вкус", string.Join(",", item.TastyCake))));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "количество", item.CountCake)));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "глазурь", string.Join(",", item.GlazePrice))));
                rez.Append("\n"+(String.Format("{0}{1} - {2}", "  ", "декор", string.Join(",", item.DecorCake))));
                rez.Append("\n" +(String.Format("{0}{1} - {2}", "  ", "Стоимость", item.TotalPrice)));
                position++;

            }
            rez.Append("\n" + (String.Format("Сумма заказа - {0}", Basket.Cakes.Sum(x => x.CountCake* x.TotalPrice))));
            return rez.ToString();
        }
        public void ShowBasket()
        {
            Console.WriteLine(BasketTxt());
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Menu();
                }
            }
        }
        private void CreateOrderTxt()
        {
            string myfile = Path.GetTempPath()+ "file.txt";
            try
            {
                if(File.Exists(myfile))
                {
                    File.Delete(myfile);
                }
                File.AppendAllText(myfile, BasketTxt(), Encoding.UTF8);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                Console.WriteLine($"Файл создан по пути {myfile}");
            }
            string readText = File.ReadAllText(myfile);
            Console.WriteLine(readText);
            Console.ReadLine();
        }
    }
}

