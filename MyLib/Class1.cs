using System;

namespace MyLib
{
    public class Class1
    {
        public static void PrintMemoryVersion()
        {
            Console.WriteLine(typeof(System.Memory<>).AssemblyQualifiedName);
        }

        public static void TestDenseTensor()
        {
            var t = new Microsoft.ML.OnnxRuntime.Tensors.DenseTensor<float>(1);
            var buffy = t.Buffer;
        }
    }
}

