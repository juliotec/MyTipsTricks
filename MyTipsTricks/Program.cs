using System;
using static System.Console;
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
            //MyDestructor();
            //MyClassReturns();
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
Los slash \ que en los
strings normales hacen
acciones aqui son ignorados
y se muestran tal cual

Y la pregunta ¿Si en el
string normal las comillas
las escribia asi con el \
ahora como las escribo?

La respuesta es que las escribes
dos veces "" "" asi");
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
}
