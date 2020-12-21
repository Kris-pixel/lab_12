using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lab_12
{
    public class Reflection
    {
/*a.выводит всё содержимое класса в текстовый файл(принимаетв качестве
 параметра имя класса);*/
        public static string AllInfo(object klass)
        {

            Type type = klass.GetType();
            var all = type.GetMembers();
            string path = @"D:\git_oop\lab_12\file.txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine("All objects in class:");
            foreach (var info in all)
            {
                sw.WriteLine($"{info.DeclaringType} {info.MemberType} {info.Name}");
            }
            sw.WriteLine();
            sw.Close();
            return "file with class info is updated.";
        }
/* b.извлекает все общедоступные публичные методы класса
(принимает в качестве параметра имя класса);*/
        public static string AllMethod(object klass)
        {
            Type type = klass.GetType();
            var all = type.GetMethods();
            string path = @"D:\git_oop\lab_12\file.txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine("All methods in class:");
            foreach (var info in all)
            {
                sw.WriteLine("Name:" + info.Name + "  Return Type:" + info.ReturnType);
            }
            sw.WriteLine();
            sw.Close();
            return "file with class info is updated.";
        }
/* c.получает информацию о полях и свойствах класса;*/
        public static string FieldInfo(object klass)
        {
            Type type = klass.GetType();
            var fields = type.GetFields();
            var prop = type.GetProperties();
            string path = @"D:\git_oop\lab_12\file.txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine("All fields in class:");
            foreach (var info in fields)
            {
                sw.WriteLine("Name:" + info.Name + "  Type:" + info.FieldType);
            }
            sw.WriteLine("All properties in class:");
            foreach (var info in prop)
            {
                sw.WriteLine("Name:" + info.Name + "  Type:" + info.PropertyType);
            }
            sw.WriteLine();
            sw.Close();
            return "file with class info is updated.";
        }
        /*d.получает все реализованные классом интерфейсы;*/
        public static string InterfaceInfo(object klass)
        {
            Type type = klass.GetType();
            var i = type.GetInterfaces();
            string path = @"D:\git_oop\lab_12\file.txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine("All interfaces in class:");
            foreach (var info in i)
            {
                sw.WriteLine("Name:" + info.FullName + "  Base Type:" + info.BaseType);
            }
            sw.WriteLine();
            sw.Close();
            return "file with class info is updated.";
        }
        /*e.выводит по имени класса имена методов, которые
         cодержат заданный(пользователем) тип параметра(имя классапередается
        в качестве аргумента);*/
        public static void TheMetod(object klass, object ch)
        {
            Type type = klass.GetType();
            Type parType = ch.GetType();
            var methods = type.GetMethods();
            int count = 0;
            Console.WriteLine($"List og method that contains {parType} as parametr");
            foreach (var info in methods)
            {
                foreach (var item in info.GetParameters())
                    if (item.ParameterType.FullName == Convert.ToString(parType))
                    {
                        Console.WriteLine("Name: " + info.Name);
                        count++;
                    }                    
            }
            if(count==0)
            {
                Console.WriteLine("Class doesn't contain such methods");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
                Product pr = new Product();
                pr.cost = 126;
                pr.id = 12341324;
                Console.WriteLine(pr.ToString());
                Console.WriteLine(pr.cost + ", " + pr.id + "\n");

                Technics tech = new Technics();
                tech.brand = "unlnown";
                tech.model = "unknown";
                Console.WriteLine(tech.ToString());
                tech.Info();

                Scaner sc = new Scaner(58, "Epson", "MX508");
                sc.CostOnSale();
                Console.WriteLine(sc.ToString());
                sc.Info();
                Technics sc2 = new Scaner(58, "Canon", "ML230");    // ссылка
                Console.WriteLine(sc2.ToString());
                Console.WriteLine(sc2.GetType());
                sc2.Info();

                //Computer comp = new Computer(); //не удалось создать экземпляр абстрактного класса
                Tablet tablet = new Tablet(112, "Lenivo", "90210");
                tablet.Info();
                Console.WriteLine(tablet.Dosmth());
                Console.WriteLine(tablet.ToString());
                tablet.CostOnSale();
                Isale tab = new Tablet(112, "Lenivo", "90210");
                Console.WriteLine(tab.ToString());
                tab.CostOnSale();
                Console.WriteLine();

                tech.IsAs();
                tablet.IsAs();

                Printer pri = new Printer(45, "Samslug", "PK320");
                Computer comp = new Tablet(12, "dadade", "gfd");
                Isale isa = new Printer(0, "sg", "54");

                Object[] arr = { pr, tech, sc, comp, tablet, pri, isa };
                pri.IAmPrinting(arr);
                foreach (object a in arr)
                    pri.IAmPrinting(a);
                try
                {
                    int[] a = new int[] { 1, 41, 2, 6, 8, 4, 23, 57 };
                    CollectionType<int> set1 = new CollectionType<int>(a);
                    set1.Show();
                    double[] s = new double[] { 2.5767, 6.4576, 3 / 870, 8, 37.0000656, 1, 5 };
                    CollectionType<double> set2 = new CollectionType<double>(s);
                    set2.Show();
                    string[] stri = new string[] { "fire", "on", "the", "streeeets" };
                    CollectionType<string> set3 = new CollectionType<string>(stri);
                    set3.Show();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сообщение ошибки:{ex.Message}\nМестонахождение:{ex.StackTrace}");
                }
                finally
                {
                    Console.WriteLine("scan session finished");
                }
                Game mika = new Game("Mika", 280);
                mika.Heal += Game.DisplayMessage;
                mika.Attack += Game.DisplayMessage;
                Game levi = new Game("Levi", 360);
                levi.Heal += Game.DisplayMessage;
                levi.Attack += Game.DisplayMessage;
                Game armin = new Game("Armin", 67);
                armin.Heal += Game.DisplayMessage;
                armin.Attack += Game.DisplayMessage;
                string select;
                string act = null;
                do
                {
                    Console.WriteLine("Choose fighter: 1.Mika, 2.Levi, 3.Armin, 0.quit");
                    select = Console.ReadLine();
                    if (select == "1") Console.WriteLine("Mika");
                    if (select == "2") Console.WriteLine("Levi");
                    if (select == "3") Console.WriteLine("Armin");
                    if (select != "0")
                    {
                        Console.WriteLine("Choose action: 1.Attack, 2.Heal, 0.quit");
                        act = Console.ReadLine();
                    }
                    switch (select)
                    {
                        case "1":
                            if (act == "1") mika.ToAttack(100, levi);
                            if (act == "2") mika.Healing(50, armin);
                            mika.Display();
                            levi.Display();
                            armin.Display();
                            break;
                        case "2":
                            if (act == "1") levi.ToAttack(100, mika);
                            if (act == "2") levi.Healing(50, armin);
                            mika.Display();
                            levi.Display();
                            armin.Display();
                            break;
                        case "3":
                            if (act == "1") armin.ToAttack(20, levi);
                            if (act == "2") armin.Healing(10, mika);
                            mika.Display();
                            levi.Display();
                            armin.Display();
                            break;
                        case "0":
                            mika.Display();
                            levi.Display();
                            armin.Display();
                            break;

                    }
                } while (select != "0");

                string str = Console.ReadLine();
                Func<string, string> prosses = Prossesstr.RemoveStr;
                str = prosses(str);
                Console.WriteLine(str);
                prosses = Prossesstr.UpStr;
                str = prosses(str);
                Console.WriteLine(str);
                prosses = Prossesstr.LowStr;
                str = prosses(str);
                Console.WriteLine(str);
                prosses = Prossesstr.AddStr;
                str = prosses(str);
                Console.WriteLine(str);
                prosses = Prossesstr.RemovePr;
                str = prosses(str);
                Console.WriteLine(str);

            /*вооооооооооттт*/
            Console.WriteLine(Reflection.AllInfo(pri));
            Console.WriteLine(Reflection.AllInfo(sc));
            Console.WriteLine(Reflection.AllInfo(mika)); 
            
            Console.WriteLine(Reflection.AllMethod(pri));
            Console.WriteLine(Reflection.AllMethod(sc));
            Console.WriteLine(Reflection.AllMethod(mika));

            Console.WriteLine(Reflection.FieldInfo(pri));
            Console.WriteLine(Reflection.FieldInfo(sc));
            Console.WriteLine(Reflection.FieldInfo(mika));

            Console.WriteLine(Reflection.InterfaceInfo(pri));
            Console.WriteLine(Reflection.InterfaceInfo(sc));
            Console.WriteLine(Reflection.InterfaceInfo(mika));

            Reflection.TheMetod(pri, 4);
            Reflection.TheMetod(pri, "vnfkj");
            Reflection.TheMetod(tech, pri);
        }
    }
}
