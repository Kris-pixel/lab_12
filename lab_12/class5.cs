using System;
using System.Buffers;
// var 5
namespace lab_12
{
    interface Isale
    {
        void CostOnSale();
    }

    public class Product
    {
        public int id;
        public int cost;

        public override string ToString()
        {
            return "PRODUCT_TYPE "+base.ToString();
        }        
    }

    public class Technics:Product
    {
        public string brand;
        public string model;
        public int amount;

        public virtual void Info()
        {
            Console.WriteLine($"ID:{id}");
            Console.WriteLine($"Brand:{brand}");
            Console.WriteLine($"Model:{model}");
            Console.WriteLine($"Cost:{cost}");
            Console.WriteLine($"Quantity in stock:{amount}");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "TECHNICS_TYPE "+base.ToString();
        }

        public void IsAs()
        {
            if (this is Tablet)
            {
                Console.WriteLine("Это планшет, успокойтесь.");
            }
            else
            {
                Console.WriteLine("Это не планшет, сейчас исправим");
                var tmp = this;
                tmp = this as Tablet;
                Console.WriteLine("Теперь это точно планшет");
            }
        }
    }

    public class Printer:Technics, Isale
    {
        public void CostOnSale()
        {
            int coSale;
            coSale = cost - (60 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }

        public override void Info()
        {
            Console.Write($"ID:{id}; ");
            Console.Write($"Brand:{brand}; ");
            Console.Write($"Model:{model}; ");
            Console.Write($"Cost:{cost}; ");
            Console.Write($"Quantity in stock:{amount};"+"\n");
        }

        new public string ToString()        //new нужен, чтобы скрыть определение этой функции, данное в базовом классе
        {
            return "PRINTER_TYPE "+base.ToString();
        }

        public Printer(int c, string b, string m)   //конструкторы не наследуюься
        {
            amount++;
            cost = c;
            brand = b;
            model = m;
            Random rnd = new Random();
            id = rnd.Next();

        }

        public virtual void IAmPrinting(Object elem)
        {
            Console.WriteLine(elem.GetType());
            Console.WriteLine(elem.ToString());
        }
    }

    sealed public class Scaner:Technics, Isale //бесплодный
    {
        public void CostOnSale()
        {
            int coSale;
            coSale = cost - (25 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }

        new public string ToString()
        {
            return "SCANER_TYPE_SEALED "+base.ToString();
        }

        public Scaner(int c, string b, string m)
        {
            amount++;
            cost = c;
            brand = b;
            model = m;
            Random rnd = new Random();
            id = rnd.Next();

        }
    }

    public abstract class Computer:Technics
    {
        public abstract string Dosmth();   //virtual помечается метод вбазовом классе, который можно будет переопределить в потомке. Здесь не надо т к абстрактые обязательно переопределять
        public abstract void CostOnSale();

        new public string ToString()
        {
            return "COMPUTER_TYPE_ABSTRACT "+base.ToString();
        }
    }

    public class Tablet:Computer, Isale    //абстрактный так как наследник Компьютера
    {
        public override string Dosmth()
        {
            return "Hello I'm useless piece of code";
        }

        new public string ToString()
        {
            return "TABLET_TYPE "+base.ToString();
        }

        public Tablet(int c, string b, string m)
        {
            amount++;
            cost = c;
            brand = b;
            model = m;
            Random rnd = new Random();
            id = rnd.Next();
        }

         void Isale.CostOnSale()    
        {
            int coSale;
            coSale = cost - (40 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }
        public override void CostOnSale()    
        {
            int coSale;
            coSale = cost - (38 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }
    }
}


