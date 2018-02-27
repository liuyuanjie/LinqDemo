using System;
using System.IO;
using System.Reflection;
using LINQDemo.Properties;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Output(CreateDemo(args[0]));

            Console.ReadLine();
        }

        static ILinqDemo CreateDemo(string name)
        {
            var fileName = string.Format("Demo{0}", name);

            Console.WriteLine(File.ReadAllText(
                Directory.GetFiles(Settings.Default.Path, string.Format("{0}.cs", fileName), SearchOption.AllDirectories)[0]));

            Console.WriteLine("-----------------------------------{0} Output ---------------------------------", fileName);

            return Assembly.Load("LINQDemo").CreateInstance(string.Format("LINQDemo.{0}", fileName),
                    true, BindingFlags.Default, null, null, null, null) as ILinqDemo;
        }

        static void Output(ILinqDemo demo)
        {
            try
            {
                demo.Output();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
