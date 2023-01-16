using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace Day1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? path;
        public MainWindow()
        {
            InitializeComponent();
            this.red.IsChecked = true;
            this.ink.IsChecked = true;
            this.normalBrush.IsChecked = true;
            this.ellipse.IsChecked = true;
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            RadioButton? Color = sender as RadioButton;
            switch (Color?.Content.ToString())
            {
                case "Red":
                    this.Drawer.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Blue":
                    this.Drawer.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Green":
                    this.Drawer.DefaultDrawingAttributes.Color = Colors.Green;

                    break;
                case "Magenta":
                    this.Drawer.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
            }
        }
        private void ModeChange(object sender, RoutedEventArgs e)
        {
            RadioButton? Mode = sender as RadioButton;
            switch (Mode?.Content.ToString())
            {
                case "Ink":
                    this.Drawer.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    this.Drawer.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Erase":
                    this.Drawer.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "Erase By Strock":
                    this.Drawer.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void ShapeChange(object sender, RoutedEventArgs e)
        {
            RadioButton? Shape = sender as RadioButton;
            switch (Shape?.Content.ToString())
            {
                case "Ellipse":
                    this.Drawer.DefaultDrawingAttributes.StylusTip = (StylusTip)1;
                    break;
                case "Rectangle":
                    this.Drawer.DefaultDrawingAttributes.StylusTip = 0;
                    break;
            }
        }

        private void SizeChange(object sender, RoutedEventArgs e)
        {
            RadioButton? Size = sender as RadioButton;
            switch (Size?.Content.ToString())
            {
                case "Small":
                    this.Drawer.DefaultDrawingAttributes.Width = 1;
                    this.Drawer.DefaultDrawingAttributes.Height = 1;
                    break;
                case "Normal":
                    this.Drawer.DefaultDrawingAttributes.Width = 5;
                    this.Drawer.DefaultDrawingAttributes.Height = 5;
                    break;
                case "Large":
                    this.Drawer.DefaultDrawingAttributes.Width = 10;
                    this.Drawer.DefaultDrawingAttributes.Height = 10;
                    break;
            }

        }

        private void newBtn(object sender, RoutedEventArgs e)
        {
            if (this.Drawer.Strokes.Count > 0)
            {
                if (MessageBox.Show("Do You Want to Save ?", "Alert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.saveBtn(null, null);
                }
            }
            this.Drawer.Strokes.Clear();
        }
        private void saveBtn(object? sender, RoutedEventArgs? e)
        {
            var saveContext = new SaveFileDialog();
            saveContext.Filter = "CanvasFile|*.can| All|*.";
            if (path == null)
            {
                if (saveContext.ShowDialog() != false)
                {
                    path = saveContext.FileName;
                }
                else
                {
                    return;
                }
            }
            FileStream file = new(path, FileMode.OpenOrCreate);
            Drawer.Strokes.Save(file);
            file.Close();
        }
        private void loadBtn(object sender, RoutedEventArgs e)
        {
            var loadmenu = new OpenFileDialog();
            loadmenu.Filter = "CanvasFile|*.can|All|*.";
            if (loadmenu.ShowDialog() != false)
            {
                path = loadmenu.FileName;
                FileStream file = new(path, FileMode.Open);
                Drawer.Strokes = new StrokeCollection(file);
                file.Close();
            }
        }
        private void copyBtn(object sender, RoutedEventArgs e)
        {
            this.Drawer.CopySelection();
        }
        private void pasteBtn(object sender, RoutedEventArgs e)
        {
            this.Drawer.Paste();
        }
        private void cutBtn(object sender, RoutedEventArgs e)
        {
            this.Drawer.CutSelection();
        }


    }
}
