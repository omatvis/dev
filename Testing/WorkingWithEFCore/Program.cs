namespace Packt.Shared;

partial class Program
{
    private static void Main(string[] args)
    {
        /*         QueryingCategories();
                FilteredIncludes();
                QueryingProducts();
                QueryingWithLike();
                GetRandomProduct();
        var (affected, productId) = AddProduct(
            categoryId: 6,
            productName: "Bob's Burgers",
            price: 500M
        );
        if (affected == 1)
        {
            WriteLine($"Add product successful with ID : {productId}.");
            ListProducts(productIdsToHighlight: [productId]);
        }

        (int affected, int productId) = IncreaseProductPrice(
            productNameStartsWith: "Bob",
            amount: 20M
        );
        if (affected == 1)
        {
            WriteLine($"Increase price success for ID : {productId}.");
        }
        ListProducts(productIdsToHighlight: new[] { productId }); */

        WriteLine("About to delete all products whose name starts with Bob.");
        Write("Press Enter to continue or any other key to exit: ");
        if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
        {
            int deleted = DeleteProducts(productNameStartsWith: "Bob");
            WriteLine($"{deleted} product(s) were deleted.");
        }
        else
        {
            WriteLine("Delete was canceled.");
        }
    }
}
