using System.Runtime.ExceptionServices;

namespace PrimeFactorLib;

public static class PrimeFactorLib
{
    public static string PrimeFactors(int n)
    {
        List<int> numbers = [];
        try
        {
            if (n < 1 || n > 1000)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    "Value should be greater then 0 and less than 1001."
                );
            }

            while (n % 2 == 0)
            {
                n /= 2;
                numbers.Add(2);
            }

            int i = 3;
            while (i <= Math.Sqrt(n))
            {
                if (n % i == 0)
                {
                    numbers.Add(i);
                    n /= i;
                }
                else
                {
                    i += 2;
                }
            }
            if (n > 2)
            {
                numbers.Add(n);
            }

            numbers.Sort(CompareInt);

            string res = "";
            for (int j = 0; j < numbers.Count; j++)
            {
                res += numbers.ElementAt(j);
                if (j < numbers.Count - 1)
                    res += " x ";
            }
            return res;

            static int CompareInt(int x, int y)
            {
                int res = 0;
                if (x > y)
                {
                    res = -1;
                }
                else if (y > x)
                {
                    res = 1;
                }
                return res;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            ExceptionDispatchInfo.Capture(ex).Throw();
            return "";
        }
    }
}
