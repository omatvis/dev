using System.Collections.Generic;
using Xunit;
using EnumerationAndIterators;

public class SequenceOfEntitiesTests
{
    [Fact]
    public void Add_AddsEntityToCollection()
    {
        var seq = new SequenceOfEntities();
        var entity = new Entity(1, "Test");
        seq.Add(entity);

        Assert.Single(seq);
        Assert.Equal(entity, seq[0]);
    }

    [Fact]
    public void Indexer_GetSet_WorksCorrectly()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);
        seq[0] = entity2;

        Assert.Equal(entity2, seq[0]);
    }

    [Fact]
    public void Remove_RemovesEntity()
    {
        var seq = new SequenceOfEntities();
        var entity = new Entity(1, "Test");
        seq.Add(entity);

        bool removed = seq.Remove(entity);

        Assert.True(removed);
        Assert.Empty(seq);
    }

    [Fact]
    public void Contains_ReturnsTrueIfPresent()
    {
        var seq = new SequenceOfEntities();
        var entity = new Entity(1, "Test");
        seq.Add(entity);

        Assert.True(seq.Contains(entity));
    }

    [Fact]
    public void Clear_RemovesAllEntities()
    {
        var seq = new SequenceOfEntities();
        seq.Add(new Entity(1, "A"));
        seq.Add(new Entity(2, "B"));

        seq.Clear();

        Assert.Empty(seq);
    }

    [Fact]
    public void CopyTo_CopiesEntitiesToArray()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);
        seq.Add(entity2);

        var arr = new Entity[2];
        seq.CopyTo(arr, 0);

        Assert.Equal(entity1, arr[0]);
        Assert.Equal(entity2, arr[1]);
    }

    [Fact]
    public void IndexOf_ReturnsCorrectIndex()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);
        seq.Add(entity2);

        int idx = seq.IndexOf(entity2);

        Assert.Equal(1, idx);
    }

    [Fact]
    public void Insert_InsertsAtCorrectIndex()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);

        seq.Insert(0, entity2);

        Assert.Equal(entity2, seq[0]);
        Assert.Equal(entity1, seq[1]);
    }

    [Fact]
    public void RemoveAt_RemovesAtIndex()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);
        seq.Add(entity2);

        seq.RemoveAt(0);

        Assert.Single(seq);
        Assert.Equal(entity2, seq[0]);
    }

    [Fact]
    public void Enumerator_IteratesAllEntities()
    {
        var seq = new SequenceOfEntities();
        var entity1 = new Entity(1, "A");
        var entity2 = new Entity(2, "B");
        seq.Add(entity1);
        seq.Add(entity2);

        var list = new List<Entity>();
        foreach (var e in seq)
            list.Add(e);

        Assert.Equal(2, list.Count);
        Assert.Contains(entity1, list);
        Assert.Contains(entity2, list);
    }
}