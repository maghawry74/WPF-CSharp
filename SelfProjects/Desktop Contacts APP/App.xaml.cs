using System;
using System.Windows;

namespace Desktop_Contacts_APP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string dataBaseName = "Contacts.db";
        public static string DBPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dataBaseName);
    }
}
