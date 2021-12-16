using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnnxXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            PrintLoadedTypes();
            PrintDenseTensorInfos();

            Debug.WriteLine("System.Memory        type from C#: " + typeof(System.Memory<>).AssemblyQualifiedName);

            MyLib.Class1.PrintMemoryVersion();
            MyLib.Class1.TestDenseTensor();

            System.Console.WriteLine("success");
        }

        private void PrintDenseTensorInfos()
        {
            var type = typeof(Microsoft.ML.OnnxRuntime.Tensors.DenseTensor<>);
            var bufferProp = type.GetProperty("Buffer");
            Debug.WriteLine("DenseTensor<>.Buffer type from C#: " + bufferProp.PropertyType.AssemblyQualifiedName);
        }

        private static void PrintLoadedTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in assemblies)
            {
                bool asmWasPrinted = false;
                foreach (var type in asm.DefinedTypes)
                {
                    if (type.FullName != "System.Memory`1") continue;

                    if (!asmWasPrinted)
                    {
                        asmWasPrinted = true;
                        Debug.WriteLine(asm.FullName);
                    }
                    Debug.WriteLine($"\t{type.AssemblyQualifiedName}");
                }
                if (asmWasPrinted) Debug.WriteLine("");
            }
        }
    }
}

