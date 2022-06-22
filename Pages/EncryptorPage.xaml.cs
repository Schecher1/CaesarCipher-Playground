using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaesarCipher_Playground.Pages
{
    public partial class EncryptorPage : Page
    {
        public EncryptorPage()
        {
            InitializeComponent();
        }

        private void Bttn_SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Please Save your File!";
            sfd.Filter = "Text Files | *.txt";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                char[] splittedText = Tb_Text.Text.ToUpper().ToCharArray();
                string encryptedText = String.Empty;

                for (int i = 0; i < splittedText.Length; i++)
                {
                    int ascii = splittedText[i];

                    if (ascii == '\r')
                    {
                        encryptedText += Environment.NewLine;
                        continue;
                    }

                    if (ascii == '\n')
                        continue;

                    int res = ascii - 65;

                    if (res <= -1 || res > 26)
                        encryptedText += splittedText[i];
                    else
                        encryptedText += Models.AlphabetModel.Alphabet[res];
                }
                File.WriteAllText(sfd.FileName, encryptedText);
            }
        }
    }
}
