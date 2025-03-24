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
using System.Windows.Shapes;

namespace PavlenkoFrolova.TechnoService.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }
        
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            //login:user/manager
            //password:123

            if (string.IsNullOrEmpty(LoginTb.Text)||
                string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Все поля обязательны для заполнения!"
                    ,"Предупреждение",MessageBoxButton.OK,MessageBoxImage.Warning);
            }


            App.emloyeeAccount = App.Ent.EmloyeeAccount
                .FirstOrDefault(ea => ea.Login == LoginTb.Text 
                && ea.Password == PasswordPb.Password);
            if (App.emloyeeAccount != null)
            {
                MessageBox.Show("Пользователь успешно авторизовался."
                   , "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден! Проверьте правильность введённых данных."
                    ,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
