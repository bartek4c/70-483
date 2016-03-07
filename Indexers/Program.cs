using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            //example 1
            DataRow row = new DataRow();
            row.Load();
            Console.WriteLine("Column 0: {0}", row[1].Data);
            row[1].Data = 12;

            //example 2
            Board board = new Board();

            board["A", 4] = new Player("White King");
            board["H", 4] = new Player("Black King");

            Console.WriteLine("A4 = {0}", board["A", 4]);
            Console.WriteLine("H4 = {0}", board["H4"]);

            //example 3
            IntList intList = new IntList(3);
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);

            foreach (int number in intList)
            {
                Console.WriteLine(number);
            }

            //example 4
            TestIterator testi = new TestIterator();
            testi.Consumer();

            Console.ReadLine();
        }
    }

    #region example 1
    class DataValue
    {
        public DataValue(string name, object data)
        {
            Name = name;
            Data = data;
        }

        public object Data { get; set; }
        public string Name { get; set; }
    }

    class DataRow
    {
        List<DataValue> _row;
        public DataRow()
        {
            _row = new List<DataValue>();
        }

        public void Load()
        {
            _row.Add(new DataValue("Id", 123));
            _row.Add(new DataValue("Name", "Fred"));
            _row.Add(new DataValue("Salary", 2300.23M));
        }

        ///indexer
        public DataValue this[int column]
        {
            get { return _row[column - 1]; }
            set { _row[column - 1] = value; }
        }
    }
    #endregion

    #region example 2
    public class Player
    {
        string _name;
        public Player(string name)
        {
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
    }

    public class Board
    {
        Player[,] board = new Player[8, 8];
        
        int RowToIndex(string row)
        {
            ///Explicit conversion char to integer using UTF-8 encoding and unicode characters where A = &#65; 
            ///=> 'A' will be converted into 65, 'B' will be converted into 66, and so on
            ///=> http://www.utf8-chartable.de/unicode-utf8-table.pl?unicodeinhtml=dec
            
            string temp = row.ToUpper();
            //using temp[0] to always get the letter value, even for H4 => H
            return((int) temp[0] - (int) 'A');
        }

        int PositionToColumn(string pos)
        {
            ///Using pos[1] to always get the numeric value, even for H4 => 4 which is the converted into int as above
            ///=> pos[1] for '4' => 52 '4' => 52
            ///=> '0' => 48 '0' => 48
            ///so => 52 - 48 - 1 = 3 (For "H4")

            return (pos[1] - '0' - 1);
        }

        public Player this[string row, int column]
        {
            get
            {
                return (board[RowToIndex(row), column - 1]);
            }
            set
            {
                board[RowToIndex(row), column - 1] = value;
            }
        }

        public Player this[string position]
        {
            get
            {
                return (board[RowToIndex(position), PositionToColumn(position)]);
            }
            set
            {
                board[RowToIndex(position), PositionToColumn(position)] = value;
            }
        }
    }
    #endregion 

    #region example 3
    /// <summary>
    /// Custom enumerator for IntList class
    /// </summary>
    public class IntListEnumerator : IEnumerator
    {
        IntList _intList;
        int _index;
        public IntListEnumerator(IntList intList)
        {
            _intList = intList;
            Reset();
        }

        public object Current
        {
            get { return (_intList[_index]); }
        }

        public bool MoveNext()
        {
            _index++;
            return _index < _intList.Count;
        }

        public void Reset()
        {
            _index = -1;
        }
    }

    /// <summary>
    /// IntList class which implement IEnumerable interface
    /// </summary>
    public class IntList : IEnumerable
    {
        int _count = 0;
        int[] _values;
        public IntList(int capacity)
        {
            _values = new int[capacity];
        }
        public void Add(int value)
        {
            _values[_count] = value;
            _count++;
        }
        
        // indexer !!!
        public int this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }
        
        public int Count { get { return _count; } }
        public IEnumerator GetEnumerator()
        {
            return new IntListEnumerator(this);
        }
    }
    #endregion

    #region example 4
    public class TestIterator
    {
        public void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }

        public IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }
    #endregion
}
