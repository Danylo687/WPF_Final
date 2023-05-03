using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final
{
    internal class MyColor
    {
        public string Name { get; set; }
        public Color Colir { get; set; }
        public int Index { get; set; }

        public MyColor() { Name = "Not set"; Colir = Color.FromArgb(0, 0, 0, 0); }
        public MyColor(string name, Color colir, int id) { 
            this.Name = name; this.Colir = colir; Index = id; }

    }
}
