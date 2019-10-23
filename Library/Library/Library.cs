using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Library<T>: IEnumerable<T>
    {
        //Creation of book storage for library
        private T[] storage = new T[5];
        private int currentIndex = 0;

        public void Add(T item)
        {
            if (storage.Length == currentIndex)
            {
                Array.Resize(ref storage, storage.Length * 2);
            }
            storage[currentIndex] = item;
            currentIndex++;
        }

        public T Remove(int index)
        {
            T chosenItem = default;
            bool picked = false;
            T[] newStorage = new T[storage.Length - 1];
            for (int i = 0; i < newStorage.Length; i++)
            {
                if (index == i)
                {
                    picked = true;
                    newStorage[i] = storage[i + 1];
                    chosenItem = storage[i];
                }
                else if (picked)
                {
                    newStorage[i] = storage[i + 1];
                }
                else
                {
                    newStorage[i] = storage[i];
                }
            }
            currentIndex = newStorage.Length;
            storage = newStorage;
            return chosenItem;
        }

        //Allows foreach
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                yield return storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
