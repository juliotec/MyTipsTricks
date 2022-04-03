using System;
using System.Diagnostics;
using System.Linq;
using static System.Console;
using System.Collections.Generic;
using MyListInt = System.Collections.Generic.List<int>;

namespace MyTipsTricks
{
    internal class Program
    {
        public static void Main()
        {
            //MyUsingStaticAndMore();
            //MyUsingDisposable();
            //MyDestructor();
            //MyStruct();
            //MyClassReturns();
            //MyStrings();
            //MyRefOutIn();
            //MyActionsPrint();
            //MyFirst();
            MyTuples();
            //MyForForeach();
            _ = ReadLine();
        }

        public static void MyUsingStaticAndMore()
        {
            var list = new MyListInt() { 1, 2, 3, 4};

            WriteLine(list[0]);
        }

        public static void MyUsingDisposable()
        {
           // using var i = new MyUsing();

            using (var i = new MyUsing())
            {
                WriteLine("Logic using");
            }
        }

        public static void MyDestructor()
        {
            _ = new Destructor();
        }

        public static void MyStruct()
        {
            _ = new Coordinate();
            _ = new Coordinate(1, 2);
        }

        public static void MyClassReturns()
        {
            WriteLine(new MyClassReturn1().Return());
            WriteLine(new MyClassReturn2().Return());
            WriteLine(new MyClassReturn3().Return());
            WriteLine(new MyClassReturn4().Return());
            WriteLine(MyClassReturn3.Number);
            WriteLine(MyClassReturn4.Number);
        }

        public static void MyStrings()
        {
            var i = 0;
            
            WriteLine($"Esto es una interpolacion del numero {i}");
            WriteLine(@"Los strings los podemos escribir
Con muchos parrafos
Los slash \ se muestran tal cual
Para escribir comillas se escribe dos veces "" """);
            WriteLine($@"
Interpolacion con @ En esta 
es lo mismo que @ solo que
podemos agregar la interpolacion

El numero es {i}

¿Y si quisiera agregar aqui las llaves
como texto?

Se hace con la misma logica doble llave
asi:
{{    }}

y las comillas igual "" ""
");
        }

        public static void MyRefOutIn()
        {
            int i;
            int j = 0;
            int z = 0;

            MyOutRefIn.ReturnOutRefIn(out i, ref j, in z);
            //MyOutRefIn.ReturnOutRefIn(out int i, ref j, in z);
        }

        public static void MyActionsPrint()
        {
            Action<int> action = (x) =>
            {
                WriteLine($"La Primera forma del action tiene el numero {x}");
            };

            static void action2(int x)
            {
                WriteLine($"La Segunda forma del action tiene el numero {x}");
            }

            MyActions.UseMyActions(action);
            MyActions.UseMyActions(action2);
        }

        public static void MyFirst()
        {
            var list = Enumerable.Range(0, 100).ToList();
            var list2 = new MyListInt();

            var i = list2.First();
            var j = list2.FirstOrDefault();
        }

        public static void MyTuples()
        {
            (double, int, MyListInt) t1 = (4.5, 3, new MyListInt() { 0, 1, 2 });

            WriteLine($" {t1.Item1}, {t1.Item2}, {t1.Item3[2]}");
        }

        public static void MyForForeach()
        {
            const int Size = 1000000;
            const int Iterations = 5000;
            var tests = 3;
            var data = new List<double>();
            var rng = new Random();

            for (int i = 0; i < Size; i++)
            {
                data.Add(rng.NextDouble());
            }

            var correctSum = data.Sum();
            Stopwatch sw;

            for (var t = 1; t <= tests; t++)
            {
                WriteLine($"Test {t}");
                sw = Stopwatch.StartNew();

                for (int i = 0; i < Iterations; i++)
                {
                    double sum = 0;

                    for (int j = 0; j < data.Count; j++)
                    {
                        sum += data[j];
                    }

                    if (Math.Abs(sum - correctSum) > 0.1)
                    {
                        WriteLine("Summation failed");

                        return;
                    }
                }

                sw.Stop();
                WriteLine("For loop: {0}", sw.Elapsed);
                sw = Stopwatch.StartNew();

                for (int i = 0; i < Iterations; i++)
                {
                    double sum = 0;

                    foreach (double d in data)
                    {
                        sum += d;
                    }

                    if (Math.Abs(sum - correctSum) > 0.1)
                    {
                        WriteLine("Summation failed");

                        return;
                    }
                }

                sw.Stop();
                WriteLine("Foreach loop: {0}", sw.Elapsed);
            }
        }
    }

    public class MyUsing : IDisposable
    {
        public void Dispose()
        {
            WriteLine("Termino el using");
            GC.SuppressFinalize(this);
        }
    }

    public class Destructor
    {
        public override string ToString() => GetType().Name;        
        
        ~Destructor() => WriteLine($"The {ToString()} finalizer is executing.");
        //NOTA: lost structs no tienen destructores
    }

    public struct Coordinate
    {
        public Coordinate(int x1, int y1)
        {
            X = x1;
            Y = y1;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public class MyClass //: Coordinate // Un struct no puede heredarse
    {

    }

    public interface IReturn
    {
        int Return();
    }

    public class MyClassReturn1 : IReturn
    {
        public virtual int Return()
        {
            return 0;
        }
    }

    public class MyClassReturn2 : MyClassReturn1
    {
        public override int Return()
        {
            return 1;
        }
    }

    public class MyClassReturn3 : MyClassReturn2
    {
        public static int Number = 1;

        public override int Return()
        {
            return 3;
        }
    }

    public class MyClassReturn4 : MyClassReturn3
    {
        new public static int Number = 1;

        public new int Return()
        {
            return 4;
        }
    }

    /*public class MyClassReturn5 : MyClassReturn4
    {
        public override int Return()
        {
            return 5;
        }
    }*/

    public class MyOutRefIn
    {
        public static void ReturnOutRefIn(out int i, ref int j, in int z)
        {
            i = 10;
            j = 10;
            //z = 10;
        }
    }

    public class MyActions
    {
        public static void UseMyActions(Action<int> action)
        {
            action(10);
        }
    }
}
