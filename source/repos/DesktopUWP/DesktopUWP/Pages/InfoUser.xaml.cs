using System;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace DesktopUWP.Pages
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class InfoUser : Page
    {
        public InfoUser()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageDialog md = new("Hello World!")
            //{
            //    Content = $"L'utente: {UserName.Text}, con ID: {userID.Text}"
            //};
            //await md.ShowAsync();

            //_ = new
            //InfoUserData()
            //{
            //    UserName = UserName.Text,
            //    UserID = userID.Text
            //};

            var users = await User.FindAllAsync();
            var user = users.FirstOrDefault();

            if (user != null)
            {
                string fullName = await user.GetPropertyAsync(KnownUserProperties.AccountName) as string;
                Debug.WriteLine(fullName);
            }
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
