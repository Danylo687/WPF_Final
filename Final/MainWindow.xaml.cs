using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Id { get; set; } = 0;
        ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();

        public MainWindow()
        {
            InitializeComponent();

            slAlpha.Value = 255;
            slRed.Value = 255;
            slGreen.Value = 255;
            slBlue.Value = 255;

            ColorList.ItemsSource = colors;
        }

        public string ConvertSliderValue(double value) // ConvertSliderValue To String
        {
            return Convert.ToString(Convert.ToInt32(value));    
        }
        public byte CSV(Slider slName) // ConvertSliderValue To Int
        {
            return Convert.ToByte(slName.Value);    
        }

        public Color GetColor()
        {
            byte alpha = 255, red = 0, green = 0, blue = 0;

            if (cbAlpha.IsChecked == true) alpha = CSV(slAlpha);
            if (cbRed.IsChecked == true) red = CSV(slRed);
            if (cbGreen.IsChecked == true) green = CSV(slGreen);
            if (cbBlue.IsChecked == true) blue = CSV(slBlue);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public void ChoseColor()
        {
            Color currentColor = GetColor();
            SolidColorBrush currentBrush = new SolidColorBrush(currentColor);

            rc1.Fill = currentBrush;
        }
        public string ConvertColor()
        {
            Color color = GetColor();
            string hexColor = "#" + color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return hexColor;
        }
        public string ConvertColor(Color color)
        {
            string hexColor = "#" + color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return hexColor;
        }
        public void IsContainColor()
        {
            Color currentColor = GetColor();
            for(int i = 0; i < colors.Count; i++)
            {
                if (colors[i].Name == ConvertColor(currentColor))
                {
                    btnAdd.IsEnabled = false;
                    return;
                }
            }
            btnAdd.IsEnabled = true;
        }
        public void ListBoxRestart()
        {
            ObservableCollection<MyColor> colorsCopy = new ObservableCollection<MyColor>();
            foreach(MyColor color in colors)
            {
                colorsCopy.Add(color);
            }
            colors.Clear();
            colors = colorsCopy;
            ColorList.ItemsSource = colors;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbAlpha.Text = ConvertSliderValue(slAlpha.Value);
            tbRed.Text = ConvertSliderValue(slRed.Value);
            tbGreen.Text = ConvertSliderValue(slGreen.Value);
            tbBlue.Text = ConvertSliderValue(slBlue.Value);

            ChoseColor();
            IsContainColor();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (cbAlpha.IsChecked == false) slAlpha.IsEnabled = false;
            else slAlpha.IsEnabled = true;
            if (cbRed.IsChecked == false) slRed.IsEnabled = false;
            else slRed.IsEnabled = true;
            if (cbGreen.IsChecked == false) slGreen.IsEnabled = false;
            else slGreen.IsEnabled = true;
            if (cbBlue.IsChecked == false) slBlue.IsEnabled = false;
            else slBlue.IsEnabled = true;

            ChoseColor();
            IsContainColor();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MyColor newColor = new MyColor(ConvertColor(), GetColor(), Id);
            colors.Add(newColor);
            IsContainColor();
        }

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            colors.Remove(colors[currentButton.TabIndex]);

            int size = colors.Count - 1;
            for (int i = 0; i <= size; i++)
            {
                colors[i].Index = i;
            }
            Id--;

            ListBoxRestart();
            IsContainColor();
        }
    }
}
