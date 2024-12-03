using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace StackOverflowPost;

public class Post(string title, string description)
{
    private int _votes = 0;
    private readonly string _title = title;
    private readonly string _description = description;
    public string Title
    {
        get { return _title; }
    }
    public string Description
    {
        get { return _description; }
    }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public int Votes
    {
        get { return _votes; }
    }

    public void UpVote()
    {
        ++_votes;
    }

    public void DownVote()
    {
        --_votes;
    }
}
