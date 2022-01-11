using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskStudentMenu
{
    [Serializable]
    class GenericStore<T> : IEnumerable<T>
    {
        T[] data = new T[0];


        public void Add(T item)
        {
            Array.Resize(ref data, data.Length + 1);

            data[data.Length - 1] = item;
        }
        public T this[int index]
        {
            get
            {
                //if (index >=data.Length || index<0)
                //    return default(T);

                if (index < 0 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return data[index];
            }
        }
        public void RemoveAt(int index)
        {
            //[1,2,3,4,5]
            //[1,2,4,5,5]
            if (index >= data.Length || index < 0)
                return;
            for (int i = 0; i < data.Length - 1; i++)
            {
                data[index] = data[index + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
