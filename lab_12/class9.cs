using System;
using System.Linq;

namespace lab_12
{
        public class Prossesstr
        {
            public static string RemoveStr(string str)  //удаление знаков препинания
            {
                char[] signs = {'/', ';', ',', '.', '?', ':'};
                for (int i = 0; i < str.Length; i++)
                {
                    if (signs.Contains(str[i]))
                    {
                        str = str.Remove(i, 1);
                    }
                }
                return str;
            }
            public static string AddStr(string str)  //Добавление подстроки
            {
                return str += "adddeedd";
            }
            public static string UpStr(string str) 
            {
                return str.ToUpper();
            }
            public static string RemovePr(string str)  //удаление
            {
                return str.Replace(" ", "");
            }
            public static string LowStr(string str)  
            {
                return str.ToLower();
            }

        }
        public class Game
        {
            public delegate void Action(string message);
            public event Action Attack;
            public event Action Heal;

            public string name;
            public int mana;
            public Game(string n, int m)
            {
                name = n;
                mana = m;
            }

            public void Healing(int point, Game obj)
            {
                if (obj.mana > 0)
                {
                    obj.mana += point;
                    this.mana -= point;
                    Heal?.Invoke($"{obj.name} healed!");
                }
                else
                {
                    Heal?.Invoke("Healing is imposible. Fighter is already dead.");
                }
            }

            public void ToAttack(int point, Game obj)
            {
                if (this.mana > 0)
                {
                    obj.mana -= point;
                    this.mana -= point;
                    if(obj.mana<= 0)
                    {
                        Attack?.Invoke($"Congrats! You just killed {obj.name}");
                    }
                    else
                    {
                        Attack?.Invoke($"{obj.name} attaked!");
                    }
                }
                else
                {
                    Attack?.Invoke("Not enough power to attak");
                }
            }
            public void Display()
            {
                Console.WriteLine($"{this.name}, mana level: {this.mana}");
            }
            public static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
}
