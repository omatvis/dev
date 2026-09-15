namespace IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>
            {
                new ("iPhone", "13 Pro", 999),
                new ("Samsung", "Galaxy S21", 799),
                new ("Google", "Pixel 6", 599)
            };

            IQueryable<Phone> queryablePhones = phones.AsQueryable();
            queryablePhones = queryablePhones.Where(phone => phone.Price > 700);

            if (!queryablePhones.Any())
            {
                Console.WriteLine("No phones found.");
            }
            else

                foreach (Phone phone in queryablePhones)
                {
                    Console.WriteLine($"Name: {phone.Name}, Model: {phone.Model}, Price: {phone.Price}");
                }
        }

        internal class Phone(string name = "Unknown", string model = "Unknown", decimal price = 0)
        {
            public string Name { get; } = name;
            public string Model { get; } = model;
            public decimal Price { get; } = price;
        }
    }
}
