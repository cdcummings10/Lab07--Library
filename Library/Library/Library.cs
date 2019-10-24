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
        /// <summary>
        /// Adds an item to Library. Resizes storage array if number of items is larger than index.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (storage.Length == currentIndex)
            {
                Array.Resize(ref storage, storage.Length * 2);
            }
            storage[currentIndex] = item;
            currentIndex++;
        }
        /// <summary>
        /// Removes an item from the Library based on an index given. Creates a new storage with a new length.
        /// </summary>
        /// <param name="index">Takes in an index position as an int.</param>
        /// <returns>Returns the removed item.</returns>
        public T Remove(int index)
        {
            if (index > storage.Length)
            {
                return default;
            }
            T chosenItem = default;
            bool picked = false;
            T[] newStorage = new T[storage.Length - 1];
            int counter = 0;
            while (counter <= newStorage.Length)
            {
                if (picked && counter < newStorage.Length)
                {
                    newStorage[counter] = storage[counter + 1];
                    counter++;
                }
                else if (index == counter && !picked)
                {
                    picked = true;
                    chosenItem = storage[counter];
                    if(counter == newStorage.Length)
                    {
                        break;
                    }
                }
                else
                {
                    if (counter == newStorage.Length)
                    {
                        break;
                    }
                    newStorage[counter] = storage[counter];
                    counter++;
                }
            }
            currentIndex = newStorage.Length;
            storage = newStorage;
            return chosenItem;
        }
        /// <summary>
        /// Returns the current index.
        /// </summary>
        /// <returns></returns>
        public int ItemCount()
        {
            return currentIndex;
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
