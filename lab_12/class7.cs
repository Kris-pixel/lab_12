using System;
using System.Collections.Generic;
using System.IO;

namespace lab_12
{
    public interface Iit<T>
    {
        void Add(T value);
        string Delete(T num);
        void Show();
    }

    class SetExeption: Exception
    {
        public SetExeption(string message):base(message)
            { }
    }

    public class CollectionType<T> : Iit<T>
        where T: IComparable
    {
        public List<T> items = new List<T>();
        public int amountItems;
        public CollectionType()
        {
        }
        public CollectionType(T[] a)
        {
            items.AddRange(a);
        }

        public void Add(T a)
        {
            if( a==null)
                throw new SetExeption ("null is imposible value");
            else {
                items.Add(a);
            }
        }

        public void Show()
        {
            foreach (T item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" ");
        }

        public string Delete(T num) //delete element
        {
            if (this.items.Remove(num))
            {
                return $"{num} удалено из множества";
            }
            else
            {
                return $"{num} не входит в множество";
            }

        }
        public static bool operator true(CollectionType<T> set)
        {
            return set.amountItems == 0;
        }

        public static bool operator false(CollectionType<T> set)
        {
            return set.amountItems != 0;
        }

        public void SaveInFile()
        {
            string path = @"D:\git_oop\lab_7\file.txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                foreach (T item in items)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
        }
        public void ReadFile()
        {
            string path = @"D:\git_oop\lab_7\file.txt";
            StreamReader sr = new StreamReader(path);
            Console.WriteLine("text from file");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
    }

}
       

