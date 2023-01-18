using System.Collections.Generic;
using System.Windows;

namespace StudentsDisplay
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string image { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();
            students = new List<Student>()
            {
                new Student() { id = 1,name="Assem",age=3,image="./imgs/assem.png"},
                new Student() { id = 2,name="Alaa",age=24,image="./imgs/alaa.png"},
                new Student() { id = 3,name="Ahmed",age=27,image="./imgs/Ahmed.png"},
                new Student() { id = 4,name="Amr",age=25,image="./imgs/Amr.png"},
                new Student() { id = 5,name="Eslam",age=23,image="./imgs/Eslam.png"},
                new Student() { id = 6,name="Kareem",age=23,image="./imgs/Kareem.png"},
                new Student() { id = 7,name="Mahmoud",age=25,image="./imgs/Mahmoud ali.png"},
                new Student() { id = 8,name="Mostafa",age=25,image="./imgs/Mostafa.png"},
                new Student() { id = 9,name="Mohamed",age=25,image="./imgs/Okba.png"},
                new Student() { id = 10,name="Maghawry",age=25,image="./imgs/maghawry.png"},
            };
            studentsList.ItemsSource = students;
            studentsList.SelectedIndex = 0;
        }
    }
}
