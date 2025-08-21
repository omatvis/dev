using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationAndIterators
{
    public class SequenceOfEntities : IEnumerable<Entity>, ICollection<Entity>, IList<Entity>
    {
        private readonly List<Entity> _entities = new();

        public Entity this[int index]
        {
            get => _entities[index];
            set => _entities[index] = value;
        }

        public int Count => _entities.Count;

        public bool IsReadOnly => false;

        public void Add(Entity item)
        {
            _entities.Add(item);
        }

        public void Clear()
        {
            _entities.Clear();
        }

        public bool Contains(Entity item)
        {
            return _entities.Contains(item);
        }

        public void CopyTo(Entity[] array, int arrayIndex)
        {
            _entities.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        public int IndexOf(Entity item)
        {
            return _entities.IndexOf(item);
        }

        public void Insert(int index, Entity item)
        {
            _entities.Insert(index, item);
        }

        public bool Remove(Entity item)
        {
            return _entities.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _entities.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class EntityCursor : IEnumerator<Entity>
    {
        private readonly IList<Entity> _entities;
        private int _position = -1;

        public EntityCursor(IList<Entity> entities)
        {
            _entities = entities;
        }

        public Entity Current => _position >= 0 && _position < _entities.Count ? _entities[_position] : throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_position < _entities.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
            // No resources to dispose
        }
    }

    public class Entity (int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;

    }

}
