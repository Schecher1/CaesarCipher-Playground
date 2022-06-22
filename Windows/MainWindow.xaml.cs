using System.Windows;

namespace CaesarCipher_Playground
{
    public partial class MainWindow : Window
    {
        public MainWindow()
            => InitializeComponent();

        private void Bttn_Encrypt_Click(object sender, RoutedEventArgs e)
            => Frame_PageMirror.Content = new Pages.EncryptorPage();

        private void Bttn_Decrypt_Click(object sender, RoutedEventArgs e)
            => Frame_PageMirror.Content = new Pages.DecryptorPage();

        private void Bttn_CaesarCipherKey_Click(object sender, RoutedEventArgs e)
        {
            Windows.CaesarCipherKeyWindow cckw = new Windows.CaesarCipherKeyWindow();
            cckw.ShowDialog();
        }
    }
}
