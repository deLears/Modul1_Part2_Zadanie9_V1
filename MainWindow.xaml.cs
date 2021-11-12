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
using Microsoft.Win32;
using System.IO;
using System.Resources;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
    {
        InitializeComponent();
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            ThemeSwitch.ItemsSource = styles;
            ThemeSwitch.SelectedItem = 0;
            ThemeSwitch.SelectionChanged += ThemeSwitch_SelectionChanged;
    }

        private void ThemeSwitch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int themeindex = ThemeSwitch.SelectedIndex;
            Uri uri = new Uri("WhiteTheme.xaml", UriKind.Relative);
            if (themeindex == 1)
            {
                uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        

        private void FontName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string fontname = ((sender as ComboBox).SelectedItem as TextBlock).Text;

        if (Texting != null)
        {
            if (Texting != null)
            {
                Texting.FontFamily = new FontFamily(fontname);
            }
        }
    }

        private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double fontsize = 14;
            fontsize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (Texting != null)
            { Texting.FontSize = fontsize; };
        }

        private void FontBold_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Texting.FontWeight = FontWeights.Bold;

    }

    private void FontItalic_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Texting.FontStyle = FontStyles.Italic;
    }

    private void FontUnderline_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Texting.TextDecorations = TextDecorations.Underline;
    }

    private void FontRed_Checked(object sender, RoutedEventArgs e)
    {
        RadioButton radioButton = new RadioButton();
        Texting.Foreground = Brushes.Red;
    }

    private void FontBlack_Checked(object sender, RoutedEventArgs e)
    {
        RadioButton radioButton = new RadioButton();
        Texting.Foreground = Brushes.Black;
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        if (openFileDialog.ShowDialog() == true)
        {
          Texting.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Текстовые файлы (*.txt)";
        if (saveFileDialog.ShowDialog() == true)
        {
            File.WriteAllText(saveFileDialog.FileName, Texting.Text);
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        Application.Current.Shutdown();
        //https://stackoverflow.com/questions/1286692/wpf-standard-commands-wheres-exit
        //Unfortunately, there is no predefined ApplicationCommands.Exit. Adding one to WPF was suggested on Microsoft Connect in 2008
    }

    private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        if (openFileDialog.ShowDialog() == true)
        {
            Texting.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
    
    private void SaveExecuted(object sender, CanExecuteRoutedEventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Текстовые файлы (*.txt)";
        if (saveFileDialog.ShowDialog() == true)
        {
            File.WriteAllText(saveFileDialog.FileName, Texting.Text);
        }
    }
        

        
    }
}
