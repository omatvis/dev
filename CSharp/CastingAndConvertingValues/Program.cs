namespace CastingAndConvertingValues;

using System.Text;
using System.Text.Unicode;
using static System.Convert;

class Program
{
    static void Main(string[] args)
    {
        double c = 9.8;
        int d = (int)c;
        Console.WriteLine($"double c = {c}. Casting double to int drop decimal part d = {d}");

        // Should be  an error when casting basing types to complex: object, string etc.
        // Cannot convert type 'double' to 'string'
        /*         string e;
                e = (string)c;
         */

        // Convert
        Console.WriteLine(
            $"c is {c} and convert ToInt32 result is {ToInt32(c)}. Converting rounds result."
        );

        // Convert csv text to base64 and backwards
        string csvText = """
          No Users with conflicting SC QS + MC QS roles,Yes,0
          No Users with conflicting Senior QS + Assistant QS roles at the same time,Yes,0
          1. Subcontract Order(s),Yes,4885
              1.1 Unused Order Status(es),Yes (all statuses are currently in use),NULL
              1.2 Uncommitted Orders,Yes,39
              1.3 Cancelled Orders,Yes,186
              1.4 Completed Orders,Yes,431
              1.5 Order Shared,Yes,1336
              1.6 Active Orders Without Valuations,Yes,6
          2. Payment Valuation Offsets,Yes,18384
              2.1 Default Offsets presence,Yes,1
              2.2 Offsets amendment,Yes,1526
          3. Submitted Application,Yes,1659
              3.1 Superseded Application,Yes,129
              3.2 Breakdown Application,Yes,146
              3.3 Lump Sum Application,Yes,2086
          4. Payment Notice(s) Issued,Yes,1538
              4.1 Unused Payment Status(es),Yes (all statuses are currently in use),0
              4.1.1 Payment Notice(s) Certificate(s) Paid,Yes,518
              4.1.2 Payment Notice(s) Certificate(s) Unpaid,Yes,5
              4.2 Lump Sum Payment Notice(s),Yes,2583
              4.2 Breakdown Payment Notice(s),Yes,201
              4.3 Payment - Costing Distribution,Yes,3137
              4.4 Payment Contra Charge,Yes,30
              4.5 Payment - Multi VAT Distribution,Yes,2701
              4.6 Payment - Insurance scheme(s),Yes,81
              4.7 Payment - CIS,Yes,1077
              4.8.1 Payment - PDF,Yes,NULL
              4.8.2 Payment - Attachments,Yes,2326
              4.9 Payment - Certificate Deletion,Yes,461
          5. Payless - Notice(s) Issued,Yes,913
              5.1 Payless - Unused Status(es),Yes (all statuses are currently in use),0
              4.1.1 Payless Notice(s) Certificate(s) Paid,Yes,295
              4.1.2 Payless Notice(s) Certificate(s) Unpaid,Yes,3
              5.2.1 Payless - Lump Sum Notice(s),Yes,1839
              5.2.2 Payless - Breakdown Notice(s),Yes,89
              5.3 Payless - Costing Distribution,Yes,1772
              5.4 Payless Contra Charge,Yes,24
              5.5 Payless - Multi VAT Distribution,Yes,1438
              5.6 Payless - Insurance scheme(s),Yes,62
              5.7 Payless - CIS,Yes,610
              5.8.1 Payless - PDF,Yes,NULL
              5.8.2 Payless - Attachments,Yes,1597
              5.9 Payless - Certificate Deletion,Yes,124
          6. Notices: Take On Balance,Yes,99
          7. SQS Approval: At least 2 different Users with exclusively Senior OR Assistant roles,Yes,NULL
              7.2 Payment - SQS Approval Usage,Yes,365
              7.1 Payless - SQS Approval Usage,Yes,186
          8. Contract Workflow Approval roles,Yes,4
          9. Contract Workflow Setup,Yes,136
              9.1 Notification Workflow (Payment),Yes,10
              9.2 Step By Step Workflow (Payment),Yes,59
              9.1 Notification Workflow (Payless),Yes,2
              9.2 Step By Step Workflow (Payless),Yes,6
          10. Auto issue is configured,Yes,3883
              10.1 Payment - Auto issue usage,Yes,149
              10.2 Payless - Auto issue usage,Yes,118
          SC Tenant,SC Controller Multi MC (1005),1
          SC Payless Availability,Yes,520
          SC Payment Availability,Yes,1031
          SC Application Availability,Yes,730
          SC Issued Payless Availability,Yes,366
          SC Issued Payment Availability,Yes,770
""";
       
        string base64 = ToBase64String(Encoding.Unicode.GetBytes(csvText));
        Console.WriteLine(base64);
        Console.WriteLine(Encoding.Unicode.GetString(FromBase64String(base64))); 
    }
}
