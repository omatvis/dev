using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

public class BankAccount
{
    public string? AccountName; // Instance member. It could be null.
    public decimal Balance; // Instance member. Defaults to zero.
    public static decimal InterestRate; // Shared member. Defaults to zero.
}
