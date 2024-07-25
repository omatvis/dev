namespace Indexers;

public class Sentence
{
    string[] words = "The quick brow fox".Split();

    public string this [int index] // indexer
    {
        get { return words[index]; }
        set { words[index] = value; }
    }
}
