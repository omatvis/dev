using System;

internal class Program
{
    private static void Main(string[] args)
    {
        DBCommand dbCommandForSQL = new DBCommand(
            new SQLConnection("SQL Connection"),
            "UPDATE SOME DB Table"
        );
        dbCommandForSQL.Execute();
        DBCommand dbCommandForOracle = new DBCommand(
            new OracleConnection("SQL Connection"),
            "UPDATE SOME DB Table"
        );
        dbCommandForOracle.Execute();
    }
}
