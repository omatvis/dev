using System;

public class OracleConnection : DBConnection
{
    public OracleConnection(string connection)
        : base(connection) { }

    public OracleConnection(string connection, TimeSpan timeOut)
        : base(connection, timeOut) { }

    public override void Close()
    {
        System.Console.WriteLine("Oracle Connection Close().");
    }

    public override void Open()
    {
        System.Console.WriteLine("Oracle Connection Open().");
    }
}
