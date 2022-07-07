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
    /// <summary>
    /// Interaktionslogik für DecryptorPage.xaml
    /// </summary>
    public partial class DecryptorPage : Page
    {
        public DecryptorPage()
        {
            InitializeComponent();
        }

        private void Bttn_SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select your File!";
            ofd.Filter = "Text Files | *.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                char[] splittedText = File.ReadAllText(ofd.FileName).ToUpper().ToCharArray();
                string decryptedText = string.Empty;

                for (int i = 0; i < splittedText.Length; i++)
                {
                    int ascii = splittedText[i];

                    if (ascii == '\r')
                    {
                        decryptedText += Environment.NewLine;
                        continue;
                    }

                    if (ascii == '\n')
                        continue;

                    if (ascii > 31 && ascii < 65 || ascii > 90 && ascii < 97 || ascii > 122 && ascii < 127)
                        decryptedText += splittedText[i].ToString();

                    for (int j = 0; j < Models.AlphabetModel.Alphabet.Length; j++)
                        {
                            if (splittedText[i].ToString() == Models.AlphabetModel.Alphabet[j])
                            {
                                char res = (char)(65 + j);
                                decryptedText += res;
                            }
                    }
                }

                Tb_Text.Text = decryptedText;
            }
        }
    }
}
