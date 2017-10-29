namespace Lab.AdvancedCSharp.Bashsoft.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private readonly IComparer<T> comparer;

        private T[] innerCollection;

        private int capacity;

        public SimpleSortedList() : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public SimpleSortedList(int capacity) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparer) : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.comparer = comparer;
            this.Capacity = capacity;
            this.innerCollection = new T[this.Capacity];
        }

        public int Size { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity cannot be negative!");
                }

                this.capacity = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < this.Size; index++)
            {
                yield return this.innerCollection[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool removed = false;
            int removedElementIndex = 0;
            for (int index = 0; index < this.Size; index++)
            {
                if (this.innerCollection[index].Equals(element))
                {
                    removedElementIndex = index;
                    removed = true;
                    break;
                }
            }

            if (removed)
            {
                this.Size--;
                for (int index = removedElementIndex; index < this.Size; index++)
                {
                    this.innerCollection[index] = this.innerCollection[index + 1];
                }

                this.innerCollection[this.Size] = default(T);
            }

            return removed;
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.innerCollection.Length == this.Size)
            {
                this.Resize();
            }

            this.innerCollection[this.Size] = element;
            this.Size++;
            this.QuickSort(this.innerCollection, 0, this.Size - 1, this.comparer);
        }

        public void AddAll(ICollection<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + elements.Count >= this.innerCollection.Length)
            {
                this.MultiResize(elements);
            }

            foreach (var element in elements)
            {
                this.innerCollection[this.Size] = element;
                this.Size++;
            }

            this.QuickSort(this.innerCollection, 0, this.Size - 1, this.comparer);
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            var builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            if (this.Size > 0)
            {
                builder.Remove(builder.Length - joiner.Length, joiner.Length);
            }

            return $"{builder}";
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Capacity * 2];
            Array.Copy(this.innerCollection, newCollection, this.Capacity);
            this.innerCollection = newCollection;
            this.Capacity = newCollection.Length;
        }

        private void MultiResize(ICollection<T> elements)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + elements.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Capacity);
            this.innerCollection = newCollection;
            this.Capacity = newCollection.Length;
        }

        private void QuickSort(T[] data, int firstIndex, int lastIndex, IComparer<T> comparer)
        {
            if (lastIndex - firstIndex > 0)
            {
                int pivotIndex = this.Partition(data, firstIndex, lastIndex, comparer);
                this.QuickSort(data, firstIndex, pivotIndex - 1, comparer);
                this.QuickSort(data, pivotIndex + 1, lastIndex, comparer);
            }
        }

        private int Partition(T[] data, int firstIndex, int lastIndex, IComparer<T> comparer)
        {
            T pivot = data[lastIndex];

            int pivotIndex = firstIndex;
            for (int dataIndex = firstIndex; dataIndex < lastIndex; dataIndex++)
            {
                if (comparer.Compare(data[dataIndex], pivot) <= 0)
                {
                    this.Swap(ref data[dataIndex], ref data[pivotIndex]);
                    pivotIndex++;
                }
            }

            this.Swap(ref data[pivotIndex], ref data[lastIndex]);
            return pivotIndex;
        }

        private void Swap(ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}
