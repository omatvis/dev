using System;

public class DBCommand
{
    DBConnection _dbConnection;
    string _instruction;

    public DBCommand(DBConnection dbConnection, string instruction)
    {
        if (dbConnection is null)
        {
            throw new ArgumentNullException(nameof(dbConnection));
        }

        if (string.IsNullOrWhiteSpace(instruction))
        {
            throw new ArgumentException("Cannot be empty or null", nameof(instruction));
        }
        _instruction = instruction;
        _dbConnection = dbConnection;
    }

    public void Execute()
    {
        _dbConnection.Open();
        System.Console.WriteLine($"Execute T-SQL instructions: {_instruction}");
        _dbConnection.Close();
    }
}
