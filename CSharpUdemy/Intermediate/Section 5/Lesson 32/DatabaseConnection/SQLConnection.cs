using System;

public class SQLConnection : DBConnection
{
    public SQLConnection(string connection)
        : base(connection) { }

    public SQLConnection(string connection, TimeSpan timeOut)
        : base(connection, timeOut) { }

    public override void Close()
    {
        System.Console.WriteLine("SQL Connection Close().");
    }

    public override void Open()
    {
        System.Console.WriteLine("SQL Connection Open().");
    }
}
