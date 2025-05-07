using System;

namespace WorkingWithEFCore;
partial class Program
{
    static void Main(string[] args)
    {
        //using NorthwindDb db = new ();
        //WriteLine($"Provider: {db.Database.ProviderName}");
        //ConfigureConsole();
        //LazyLoadingWithNoTracking();
        //QueryingCategories();
        //FilteredIncludes();
        //QueryingProducts();
        //GettingOneProduct();
        //QueryingWithLike();
        //GetRandomProduct();

        #region AddProduct
        (int affected, int productId) = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);
        if (affected == 1)
        {
            WriteLine($"Add product successful with ID: {productId}.");
        }
        ListProducts(productIdsToHighlight: [productId]);
        #endregion

        #region IncreaseProductPrice
        (affected, productId) = IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M);
        if (affected == 1)
        {
            WriteLine($"Increase price success for ID: {productId}.");
        }
        ListProducts(productIdsToHighlight: new[] { productId });
        #endregion

        #region DeleteProducts
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
        #endregion

        #region Update set of products and delete set of products at once
        AddProduct(categoryId: 6, productName: "Bob's Burgers 1", price: 500M, stock: 72);
        AddProduct(categoryId: 6, productName: "Bob's Burgers 2", price: 500M, stock: 72);
        AddProduct(categoryId: 6, productName: "Bob's Burgers 3", price: 500M, stock: 72);

        var resultUpdateBetter = IncreaseProductPricesBetter(productNameStartsWith: "Bob", amount: 20M);
        if (resultUpdateBetter.affected > 0)
        {
            WriteLine("Increase product price successful.");
        }
        ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);

        WriteLine("About to delete all products whose name starts with Bob.");
        Write("Press Enter to continue or any other key to exit: ");
        if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
        {
            int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");
            WriteLine($"{deleted} product(s) were deleted.");
        }
        else
        {
            WriteLine("Delete was canceled.");
        }
        #endregion
    }
}