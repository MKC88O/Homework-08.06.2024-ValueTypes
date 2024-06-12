namespace Homework_08._06._2024_ValueTypes
{
    struct Shop
    {
        public string name;
        public string adres;
        public string kassirName;
        public int kassaNumber;
    };
    struct Product
    {
        public string name;
        public double price;
        public double quantity;
        public double discount;
    };
    struct Check
    {
        public Shop shop;
        public List<Product> products;
        public int productsQuantity;
        public int checkCount;
        public Check()
        {
            shop = new();
            products = new();
            productsQuantity = 0;
            checkCount++;
        }
        public void AddProducts(string name, double quantity, double price, double discount)
        {
            Product product = new()
            {
                name = name,
                quantity = quantity,
                price = price,
                discount = discount,
            };
            products.Add(product);
            productsQuantity++;
        }
        public void PrintCheck()
        {
            Product product;
            Shop shop;
            shop.name = "ТАВРІЯ В";
            shop.kassirName = "Іван Іваненко";
            shop.adres = "вул. Мельницька, 1, м. Одеса";
            shop.kassaNumber = 3;
            double gotivka = 4100;
            double total = 0;
            Console.WriteLine("+++++++++++++++" + shop.name + "+++++++++++++++");
            Console.WriteLine("-----------Ласкаво просимо!-----------");
            Console.WriteLine("\tКасір: " + shop.kassirName);
            Console.WriteLine("      Час: " + DateTime.Now);
            Console.WriteLine("  Адреса: " + shop.adres);
            Console.WriteLine("*****************ЧЕК******************");
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < productsQuantity; i++)
            {
                product = products[i];
                double totalPrice = product.quantity * product.price * (1 - product.discount / 100);
                Console.Write("{0, -23}", product.quantity + " X");
                Console.WriteLine("{0, 15}", product.price + "грн");

                Console.Write("{0, -23}", product.name);
                Console.WriteLine("{0, 15}", totalPrice + "грн");

                Console.Write("{0, -23}", "Знижка: ");
                Console.WriteLine("{0, 15}", product.discount + "%");
                Console.WriteLine();
                total += totalPrice;
            }

            Console.WriteLine("#Каса : " + shop.kassaNumber);
            Console.WriteLine("#Чек № : " + checkCount);
            Console.Write("{0, -23}", "ДО СПЛАТИ: ");
            Console.WriteLine("{0, 15}", total + "грн");
            Console.Write("{0, -23}", "ПДВ А = 20% ");
            Console.WriteLine("{0, 15}", Math.Round((total * 0.2),2) + "грн");
            Console.WriteLine("--------------------------------------");
            Console.Write("{0, -23}", "ГОТІВКА: ");
            Console.WriteLine("{0, 15}", gotivka + "грн");
            Console.Write("{0, -23}", "РЕШТА: ");
            Console.WriteLine("{0, 17}", gotivka - total + "грн\n\n");

            char[] elemsQR = { '▖', '▗', '▘', '▙', '▚', '▛', '▜', '▝', '▞', '▟', '▫', '▪' };
            //char[] elemsQR = { '▖', '▗', '▘', '▚', '▝', '▞', '▫', '▪' };
            char[,] QR = new char[5, 8];
            Random random = new();

            for (int i = 0; i < QR.GetLength(0); i++)
            {
                Console.Write("\t       ");
                for (int j = 0; j < QR.GetLength(1); j++)
                {
                    int randomIndex = random.Next(elemsQR.Length);

                    QR[i, j] = elemsQR[randomIndex];
                    QR[0, 0] = '⬜';
                    QR[0, 7] = '⬜';
                    QR[4, 0] = '⬜';
                    QR[2, 4] = '⬜';
                    Console.Write(QR[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("---------Дякуємо за покупку!----------");
            Console.WriteLine("-------------Заходьте ще!-------------");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t    ФІСКАЛЬНИЙ ЧЕК");
        }
    };
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Check check = new();
            check.AddProducts("Мівіна", 200, 10, 10);
            check.AddProducts("Пиво 0.5л", 50, 40, 0);
            check.AddProducts("Хліб", 1, 25, 0);
            check.AddProducts("Nescafe GOLD", 1, 250, 20);
            check.AddProducts("Пакет вел. ТАВРІЯ В", 1, 1.5, 0);
            check.PrintCheck();
        }
    }
}
