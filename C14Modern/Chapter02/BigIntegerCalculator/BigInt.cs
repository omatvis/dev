using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BigIntegerCalculator
{
    public class BigInt
    {
        private string _strNumber;
        private List<int> _binaryNumber;
        public string StrNumber { get => _strNumber; }
        public int this[int index]
        {
            get {
                if (index < 0 || index > _binaryNumber.Count - 1) throw new IndexOutOfRangeException("Index is out of range.");
                return _binaryNumber[_binaryNumber.Count - index - 1];
            } 
        }

        public override string ToString()
        {
            string result = "";
            if (_binaryNumber is null || _binaryNumber.Count == 0) return "0";
            for (int i = _binaryNumber.Count - 1; i > -1; i--)
            {
                result += Convert.ToString(_binaryNumber[i]);
            }
            return result;
        }

        public BigInt(string strNumber)
        {
            _strNumber = strNumber;
            _binaryNumber = new();
        }

        public void Parse()
        {
            if (string.IsNullOrEmpty(_strNumber))
            {
                throw new ArgumentException("Number string cannot be null or empty.");
            }

            foreach (char c in _strNumber)
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException($"Invalid character '{c}' in number string.");
                }
            }

            bool isConverted = Int32.TryParse(_strNumber, out int result);
            if (isConverted == false) 
                throw new InvalidOperationException($"Failed to convert '{_strNumber}' to an integer.");

            if (result == 0)
            {
                _binaryNumber.Add(0);
                return;
            }

            while (result > 0)
            {
                _binaryNumber.Add(result & 1);
                result = result >> 1;
            }
        }
    }


}
