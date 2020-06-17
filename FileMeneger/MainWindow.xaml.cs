using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileMeneger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Загрузка файлов и папок -кнопка "перейти" 
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            listBox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach(DirectoryInfo crrDir in dirs)
            {
                listBox.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox.Items.Add(crrfile);
            }
        }
        // двойной щелчек по listBox
        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (System.IO.Path.GetExtension(System.IO.Path.Combine(textBox.Text, listBox.SelectedItem.ToString())) == "")
            {
                textBox.Text = System.IO.Path.Combine(textBox.Text, listBox.SelectedItem.ToString());
                listBox.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox.Text);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo crrDir in dirs)
                {
                    listBox.Items.Add(crrDir);
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo crrfile in files)
                {
                    listBox.Items.Add(crrfile);
                }
            }
            else { 
                Process.Start(System.IO.Path.Combine(textBox.Text, listBox.SelectedItem.ToString()));
            }
        }
        //Загрузка файлов и папок -кнопка "назад"
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text[textBox.Text.Length - 1] == '\\')
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                while(textBox.Text[textBox.Text.Length -1] != '\\')
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                }
            }else if (textBox.Text[textBox.Text.Length - 1] != '\\')
            {
                while (textBox.Text[textBox.Text.Length - 1] != '\\')
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                }
            }
           
            listBox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox.Items.Add(crrfile);
            }
        }
        //Загрузка файлов и папок -кнопка "вперед"
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox.Items.Add(crrfile);
            }
        }
    }
}
