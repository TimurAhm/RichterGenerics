using System;
using System.Collections.Generic;

namespace RichterGenerics
{
    internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue>
    { }

    internal class Program
    {
        static void Main(string[] args)
        {
            Object o = null;


            //Dictionary<,> - открытый тип с двумя параметрами типа
            Type t = typeof(Dictionary<,>);
            // Попытка создания экземпляра этого типа (неудачная)
            o = CreateInstance(t);
            Console.WriteLine();

            // DictionaryStringKey<> - открытый тип с одним параметром типа
            t = typeof(DictionaryStringKey<>);
            // Попытка создания экземпляра этого типа (неудачная)
            o = CreateInstance(t);
            Console.WriteLine();

            // DictionaryStringKey<Guid> - это закрытый тип
            t = typeof(DictionaryStringKey<Guid>);
            // Попытка создания экземпляра этого типа (удачная)
            o = CreateInstance(t);
            Console.WriteLine("Object type = " + o.GetType());
        }

        private static Object CreateInstance(Type t)
        {
            Object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Console.WriteLine($"Created instance of {0}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return o;
        }
    }
}