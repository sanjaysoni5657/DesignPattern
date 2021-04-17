using System;
using System.Threading;

namespace Singleton
{
    public sealed class Singleton
    {
        private static int _count = 0;

        // Eagerly Initialization (CLR take care for Thread Safety)
        // private static readonly Singleton _instance = new Singleton();

        // Lazy Initialization (Lazy object are thread safe)
        // private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        private static Singleton _instance;
        private static readonly Object obj = new Object();

        private Singleton()
        {
            _count++;
            Console.WriteLine("Count value after instantiation {0}", _count);
        }

        public static Singleton getInstance()
        {
            Console.WriteLine("Called for Instance");
            // Double Check Locking
            /*if (_instance == null)
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }*/
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
            // in case of Lazy Initialization
            // return _instance.Value;
        }

        public void printMessage(string message)
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("{0} having Count {1} of Thread {2}", message, _count, thread.ManagedThreadId);
        }


        public override int GetHashCode()
        {
            // return base.GetHashCode();
            return _instance.GetHashCode();
        }
        /*public class DerivedSingleton : Singleton
        {

        }*/
    }
}