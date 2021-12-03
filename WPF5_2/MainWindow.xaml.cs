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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF5_2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.EditingMode = InkCanvasEditingMode.InkAndGesture;
            MyInkCanvas.DefaultDrawingAttributes.Height = 2;
            MyInkCanvas.DefaultDrawingAttributes.Width = 2;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.EditingMode = InkCanvasEditingMode.InkAndGesture;
            MyInkCanvas.DefaultDrawingAttributes.Height = 2;
            MyInkCanvas.DefaultDrawingAttributes.Width = 5;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.EditingMode = InkCanvasEditingMode.InkAndGesture;
            MyInkCanvas.DefaultDrawingAttributes.Height = 10;
            MyInkCanvas.DefaultDrawingAttributes.Width = 10;
       
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.DefaultDrawingAttributes.Color = Colors.Red;
            SwitchEraser();


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            SwitchEraser();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
                SwitchEraser();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;

        }
        private void SwitchEraser()
        {
            if (MyInkCanvas.EditingMode == InkCanvasEditingMode.EraseByPoint) MyInkCanvas.EditingMode = InkCanvasEditingMode.InkAndGesture;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ink canvas(*.ink)|*.ink";
            if (openFileDialog.ShowDialog() == true)
            {
                using (var fs = new FileStream(openFileDialog.FileName,
                 FileMode.Open, FileAccess.Read))
                {
                    StrokeCollection strokes = new StrokeCollection(fs);
                    MyInkCanvas.Strokes = strokes;
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ink canvas(*.ink)|*.ink";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fs;
                if (!File.Exists(saveFileDialog.FileName)) fs = File.Create(saveFileDialog.FileName);
                else fs = new FileStream(saveFileDialog.FileName,
                  FileMode.Open, FileAccess.Read);
                
                using (fs)
                {
                  MyInkCanvas.Strokes.Save(fs);
                }

                
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.Strokes.Clear();
        }
    }
}
