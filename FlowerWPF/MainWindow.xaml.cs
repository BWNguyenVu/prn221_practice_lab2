using System;
using System.Windows;
using System.Threading.Tasks;
using Services;
using BusinessObject;

namespace FlowerWPF
{
    public partial class MainWindow : Window
    {
        private readonly IAccountService _accountService;

        public MainWindow() 
        {
            InitializeComponent();
            _accountService = new UserService();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                 Account account = await _accountService.GetAccountByUsernameAndPasswordAsync(username, password);

                if (account != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Proceed to the next window or application state
                    // For example, you might want to navigate to a dashboard window
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Exit the application
        }
    }
}
