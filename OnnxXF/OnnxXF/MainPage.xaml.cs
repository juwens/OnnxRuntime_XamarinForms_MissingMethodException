using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            MyLib.Class1.PrintMemoryVersion();
            MyLib.Class1.TestDenseTensor();

            System.Console.WriteLine("success");
        }
    }
}

