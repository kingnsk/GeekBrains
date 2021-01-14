// Decompiled with JetBrains decompiler
// Type: lesson7_1.Program
// Assembly: lesson7_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1705D62F-F4E5-4399-8923-692BF1BDE804
// Assembly location: C:\!Work\GeekBrains\lesson7\lesson7_1\bin\Debug\lesson7_1.exe

using System;

namespace lesson7_1
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Введите число [0-255]");
      byte num = Convert.ToByte(Console.ReadLine());
            if ((int)num % 2 == 0)
            {
                Console.WriteLine(string.Format("Число {0} четное", (object)num));
                Console.WriteLine("Внесены правки в проект!");
            }
            else
            {
                Console.WriteLine(string.Format("Число {0} нечетное", (object)num));
                Console.WriteLine("Внесены правки в проект!");
            }

        }
  }
}
