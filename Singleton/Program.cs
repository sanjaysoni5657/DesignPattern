using System;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FirstInstance();
            SecondInstance();
            ThirdInstance();
            FourthInstance();*/

            Parallel.Invoke(() => FirstInstance(),
            () => SecondInstance(),
            () => ThirdInstance(),
            () => FourthInstance());

            /* Singleton.DerivedSingleton deriveInstance = new Singleton.DerivedSingleton();
            deriveInstance.printMessage("Derived Instance");*/
        }

        private static void FirstInstance()
        {
            Singleton s1 = Singleton.getInstance();
            s1.printMessage("First Instance");
        }
        private static void SecondInstance()
        {
            Singleton s2 = Singleton.getInstance();
            s2.printMessage("Second Instance");
        }
        private static void ThirdInstance()
        {
            Singleton s3 = Singleton.getInstance();
            s3.printMessage("Third Instance");
        }

        private static void FourthInstance()
        {
            Singleton s4 = Singleton.getInstance();
            s4.printMessage("Fourth Instance");
        }
    }
}
