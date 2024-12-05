using System.Collections;
internal partial class Program
{
    /// <summary>
    /// A Stack is a data structure for storing a list of elements in a LIFO (last in, first out) fashion.
    /// </summary>
    public class Stack    
    {
        private readonly ArrayList _stack = [];
        /// <summary>
        ///  stores the given object on top of the stack.
        ///  We should not store null references in the stack.
        ///  So if null is passed to this method, you should throw an InvalidOperationException.
        /// </summary>
        /// <param name="obj"></param>
        public void Push(object obj) { 
            if (obj is null) {
                throw new InvalidOperationException($"{nameof(obj)} cannot be null in Push().");
            }
            _stack.Add(obj);
        }

        /// <summary>
        ///  removes the object on top of the stack and returns it.
        ///  Make sure to take into account the scenario that we call the Pop() method on an empty stack.
        ///  In this case, this method should throw an InvalidOperationException.
        /// </summary>
        /// <returns></returns>
        public object Pop()
        {
            if (_stack.Count == 0) {
                throw new InvalidOperationException("Cannot pop element from empty stacj in Pop().");
            }
            var element = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);
            return element!;
        }

        /// <summary>
        /// removes all objects from the stack.
        /// </summary>
        public void Clear() { 
            _stack.Clear();
        }
    }
}
