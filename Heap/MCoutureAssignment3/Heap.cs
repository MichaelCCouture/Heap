using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCoutureAssignment3
{
    public class Heap<T> where T: class, IComparable
    {
        T[] items;
        const int MAXSIZE = 100;
        int root;
        int maximumSize;
        int sizeCounter = 0;
        public Heap(int MaxN)
        {
            if(MaxN > MAXSIZE || MaxN <= 0)
            {
                //Exception on size about max size, or 0 and below
                throw new ArgumentOutOfRangeException("Invalid Array Size");
            }
            else 
            {
                items = new T[MaxN];
                maximumSize = MaxN;
            }
        }

        public bool IsEmpty()
        {
            if(sizeCounter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Entries()
        {
            return sizeCounter;
        }

        public void Insert(T new_item)
        {
            if((sizeCounter +1) > maximumSize)
            {
                throw new ArgumentOutOfRangeException("Array is too large");
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    //Insert new item into first available slot
                    if(items[i] == null)
                    {
                        items[i] = new_item;
                        sizeCounter++;
                        ReSortArray();
                        return;
                    }
                }             
            }
        }
        
        public T GetMin()
        {
            if (IsEmpty())
            {
                return null;
            }
            else
            {
                //Set temp to value you wish to return and remove it from the array
                T temp;
                temp = items[root];
                items[root] = null;

                ReSortArray();

                sizeCounter--;
                return temp;
            }
        }

        public void ReSortArray()
        {
            root = -1;
            for (int i = 0; i < maximumSize; i++)
            {
                if (root == -1 && items[i] != null)
                {
                    root = i;
                }
                //This will set the value of root as the lowest number in the array
                if(items[i] != null && items[root] != null)
                {
                    if (items[i].CompareTo(items[root]) != 1)
                    {
                        root = i;
                    }
                }
            }
        }

    }
}
