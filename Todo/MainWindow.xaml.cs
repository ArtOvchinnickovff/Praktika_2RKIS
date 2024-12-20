﻿using System;
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


namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EmailTextBox.Text = "Введите почту";
            EmailTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            PasswordTextBox.Text = "Введите пароль";
            PasswordTextBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "Введите почту")
            {
                EmailTextBox.Text = "";
                EmailTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.Text = "Введите почту";
                EmailTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == "Введите пароль")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Введите пароль";
                PasswordTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(email) || email == "Введите почту" ||
                string.IsNullOrWhiteSpace(password) || password == "Введите пароль")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на валидность почты
            if (!email.IsValidEmail())
            {
                MessageBox.Show("Неверный формат электронной почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на валидность пароля
            if (!password.IsValidPassword())
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Если все проверки прошли успешно, продолжаем
            Main_empty main_Empty = new Main_empty();
            main_Empty.ShowDialog();
        }
    }
}
