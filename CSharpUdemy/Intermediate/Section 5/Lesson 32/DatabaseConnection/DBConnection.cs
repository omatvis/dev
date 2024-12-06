using System;

public abstract class DBConnection
{
    public string Connection { get; set; }
    public TimeSpan TimeOut { get; set; }

    public DBConnection(string connection)
    {
        if (string.IsNullOrWhiteSpace(connection))
        {
            throw new ArgumentNullException(nameof(connection));
        }
        Connection = connection;
    }

    public DBConnection(string connection, TimeSpan timeOut)
        : this(connection)
    {
        TimeOut = timeOut;
    }

    public abstract void Close();
    public abstract void Open();
}
