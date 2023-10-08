using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using System.IO;
using System.Runtime.CompilerServices;


namespace assigment1_RX15MW
{
    public class Item
    {
        public int element;
        public int frequency;

        public Item()
        {
            element = 0;
            frequency = 0;
        }

        public Item(int elem, int freq)
        {
            element = elem;
            frequency = freq;
        }

        public override string ToString()
        {
            return "(" + element.ToString() + ", " + frequency.ToString() + ")";
        }

        public void Read()
        {
            Console.WriteLine("Element: ");
            element = int.Parse(Console.ReadLine());
            Console.WriteLine("Frequency: ");
            frequency = int.Parse(Console.ReadLine());


        }
    }
    public class Bag
    {
        private List<Item> seq = new();
        public class EmptyBag : Exception { } // When the bag is empty
        public class NonExistingElement : Exception { } // when the entered element is not the bag
        public class UnknownError : Exception { } // other errors

        public (bool, int) LogSearch(int element) // taken from OOP'22 lab, Map type - lab 5
        {
            bool exists = false;
            int lowerBound = 0;
            int upperBound = seq.Count - 1;
            int middlePoint = 0;

            while (!exists && lowerBound <= upperBound)
            {
                middlePoint = (lowerBound + upperBound) / 2;
                if (seq[middlePoint].element > element) { upperBound = middlePoint - 1; }
                else if (seq[middlePoint].element < element) { lowerBound = middlePoint + 1; }
                else { exists = true; }
            }
            if (!exists) middlePoint = lowerBound;

            return (exists, middlePoint);
        }
        public void InsertElement(int element) 
        {
            var result = LogSearch(element);

            if (!result.Item1)
            {
                Item it = new Item();
                it.element = element;
                it.frequency = 1;

                seq.Insert(result.Item2, it);
            }
            else if (result.Item1)
            {
                seq[result.Item2].frequency++;
            }
        }

        public void RemoveElement(int element)
        {
            if(seq.Count == 0)
            {
                throw new EmptyBag();
            }

            var result = LogSearch(element);
            if((result.Item1) && (seq[result.Item2].frequency == 1))
            {
                for (int i = result.Item2 + 1; i < seq.Count; i++)
                    seq[i - 1] = seq[i];
                seq.RemoveAt(result.Item2);
            }
            else if ((result.Item1) && (seq[result.Item2].frequency > 1)){
                seq[result.Item2].frequency--;
            }
            else throw new NonExistingElement();
        }

        public int GetFrequency(int element)
        {
            if (seq.Count == 0) throw new EmptyBag();

            var result = LogSearch(element);
            if(result.Item1)
            {
                return seq[result.Item2].frequency;
            }
            else
            {
                throw new NonExistingElement();
            }
        }

        public int GetLargest()
        {
            if(seq.Count != 0)
            {
                Item larg = seq[seq.Count - 1];
                return larg.element;
            }
            else
            {
                throw new EmptyBag();
            }
        }

        public bool IsEmpty()
        {
            return seq.Count == 0;
        }

        public int GetLength() { return seq.Count; }

        public void Write()
        {
            foreach(Item e in seq)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<Item> GetElements()
        {
            List<Item> list = new();
            for(int i=0; i<seq.Count; i++)
            {
                list.Add(seq[i]);
            }
            return list;
        }

        public bool IsInBag()
        {
            int element = new ();
            for(int i=0; i<seq.Count; i++)
            {
                if (element == seq[i].element)
                    return true;
            }
            return false;
        }
    }
}