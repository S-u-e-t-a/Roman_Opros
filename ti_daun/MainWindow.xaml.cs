using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ti_daun
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random rnd;
        private bool canCloseWindow;


        public MainWindow()
        {
            InitializeComponent();
            rnd = new Random();
            canCloseWindow = false;
        }


        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            var top = rnd.Next(0, Convert.ToInt32(Height - 50));
            var left = rnd.Next(0, Convert.ToInt32(Width - but.Width));
            but.Margin = new Thickness(left, top, 0, 0);
            Trace.WriteLine($"{top},{left},{Height},{Width}");
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            YesButton.Visibility = Visibility.Hidden;
            NoButton.Visibility = Visibility.Hidden;
            Label.Content = "Я знал))))";
            canCloseWindow = true;
        }


        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (!canCloseWindow)
            {
                e.Cancel = true;
            }
        }
    }
}