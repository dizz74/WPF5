using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//family
        {
            if (textBox != null)
                textBox.FontFamily = new FontFamily(((sender as ComboBox).SelectedItem as TextBlock).Text);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//size
        {
            if (textBox != null)
                textBox.FontSize = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
                textBox.FontWeight = FontWeights.Bold;
            else textBox.FontWeight = FontWeights.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Italic)
                textBox.FontStyle = FontStyles.Normal;
            else textBox.FontStyle = FontStyles.Italic;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (textBox.TextDecorations == null || textBox.TextDecorations.Count == 0)
                textBox.TextDecorations = TextDecorations.Underline;
            else textBox.TextDecorations = null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текст (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текст (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
