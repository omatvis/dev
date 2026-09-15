namespace IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Owner> owners = new List<Owner>
            {
                new Owner("Oleg")   { Phones = { new Phone("iPhone","13 Pro",999) } },
                new Owner("Vlad")   { Phones = { new Phone("Samsung","S22",799) } },
                new Owner("Dmitry") { Phones = { new Phone("Google","Pixel 6",599) } },
            };

            IQueryable<Owner> queryableOwners = owners.AsQueryable();
            queryableOwners = queryableOwners.Where(owner => owner.Phones.Any(phone => phone.Price > 800));

            if (!queryableOwners.Any())
            {
                Console.WriteLine("No owners found.");
            }
            else

                foreach (Owner owner in queryableOwners)
                {
                    Console.WriteLine($"Owner: {owner.OwnerName}");
                    foreach (Phone phone in owner.Phones)
                    {
                        Console.WriteLine($"  Name: {phone.Name}, Model: {phone.Model}, Price: {phone.Price}");
                    }
                }
        }

        internal class Phone(string name = "Unknown", string model = "Unknown", decimal price = 0, string ownerName = "Unknown")
        {
            public int PhoneId { get; set; }
            public string Name { get; } = name;
            public string Model { get; } = model;
            public decimal Price { get; } = price;

            public string OwnerName { get; set; } = ownerName;

            public virtual Owner Owner { get; set; } = null!;

        }

        internal class Owner(string name = "Unknown", string email = "Unknown")
        {
            public string OwnerName { get; } = name;
            public string Email { get; } = email;

            public virtual ICollection<Phone> Phones { get; } = new List<Phone>();
        }
    }
}
