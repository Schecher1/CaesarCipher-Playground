using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace CaesarCipher_Playground.Windows
{
    public partial class CaesarCipherKeyWindow : Window
    {
        public CaesarCipherKeyWindow()
        {
            InitializeComponent();
        }

        private void Tb_Letter_TextChanged(object sender, TextChangedEventArgs e)
        {
            MakeTheLetterUpperCase(sender);
            RemoveIllegalCharacters(sender);
        }

        private void Bttn_LoadKey_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Select your Key File!";
            ofd.Filter = "CaesarCipherKey Files | *.cckey";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadKey(ofd.FileName);
        }
        private void Bttn_SaveKey_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Please Save your Key File!";
            sfd.Filter = "CaesarCipherKey Files | *.cckey";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                SaveKey(sfd.FileName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();

            for (int i = 0; i < letterBoxes.Length; i++)
                letterBoxes[i].Text = Models.AlphabetModel.Alphabet[i];
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();

            for (int i = 0; i < letterBoxes.Length; i++)
                Models.AlphabetModel.Alphabet[i] = letterBoxes[i].Text;
        }

        private void Bttn_Normal_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();
            int counter = 0;

            for (int i = 65; i <= 90; i++)
            {
                letterBoxes[counter].Text = ((char)i).ToString();
                counter++;
            }
        }
        private void Bttn_Twisted_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();
            int counter = 0;

            for (int i = 90; i >= 65; i--)
            {
                letterBoxes[counter].Text = ((char)i).ToString();
                counter++;
            }
        }
        private void Bttn_Random_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();
            List<char> usedChars = new List<char>();
            bool getAllChars = false;
            int arrayCounter = 0;
            int errorCounter = 0;

            Bttn_Normal_Click(sender, e);

            Random r = new Random();

            while (!getAllChars)
            {
                errorCounter++;
                bool charAlreadyUsed = false;

                char randomChar = (char) r.Next(65, 91);

                foreach (char letter in usedChars)
                    if (letter == randomChar)
                        charAlreadyUsed = true;

                if (letterBoxes[arrayCounter].Text != randomChar.ToString() && !charAlreadyUsed)
                {
                    letterBoxes[arrayCounter].Text = randomChar.ToString();
                    usedChars.Add(randomChar);
                    arrayCounter++;
                }

                if (arrayCounter == letterBoxes.Length)
                    getAllChars = true;

                //Is the cut, if the while loop gets an endless run.
                //(have no idea why, sometimes it works and sometimes not).
                if (errorCounter == 5000)
                {
                    Bttn_Clear_Click(sender, e);
                    break;
                }
            }
        }
        private void Bttn_Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] letterBoxes = GetAllTextboxes();

            for (int i = 0; i < letterBoxes.Length; i++)
                letterBoxes[i].Text = "";
        }

        private void LoadKey(string path)
        {
            TextBox[] letterBoxes = GetAllTextboxes();
            string[] key = File.ReadAllLines(path);

            for (int i = 0; i < letterBoxes.Length; i++)
                letterBoxes[i].Text = key[i];
                
            MessageBox.Show("was successfully loaded!");
        }
        private void SaveKey(string path)
        {
            TextBox[] letterBoxes = GetAllTextboxes();
            List<string> key = new List<string>();

            for (int i = 0; i < letterBoxes.Length; i++)
                key.Add(letterBoxes[i].Text);

            File.WriteAllLines(path, key);

            MessageBox.Show("was successfully saved!");
        }

        private void RemoveIllegalCharacters(object sender)
        {
            bool isIllegal = true;

            for (int i = 65; i <= 90; i++)
                if (((TextBox)sender).Text == ((char)i).ToString())
                    isIllegal = false;

            if (isIllegal)
                ((TextBox)sender).Text = "";
        }
        private void MakeTheLetterUpperCase(object sender)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        //private void CheckForLetterRepeats(object sender)
        //{
        //    TextBox[] letterBoxes = GetAllTextboxes();

        //    foreach (var letterBox in letterBoxes)
        //        if (letterBox == null)
        //            return;

        //    foreach (var letterBox in letterBoxes)
        //    {
        //        if (letterBox.Text == ((TextBox)sender).Text && letterBox != sender)
        //            ((TextBox)sender).Text = "";
        //    }
        //}

        private TextBox[] GetAllTextboxes()
        {
                TextBox[] letterBoxes =
                {
                    Tb_Letter_A,
                    Tb_Letter_B,
                    Tb_Letter_C,
                    Tb_Letter_D,
                    Tb_Letter_E,
                    Tb_Letter_F,
                    Tb_Letter_G,
                    Tb_Letter_H,
                    Tb_Letter_I,
                    Tb_Letter_J,
                    Tb_Letter_K,
                    Tb_Letter_L,
                    Tb_Letter_M,
                    Tb_Letter_N,
                    Tb_Letter_O,
                    Tb_Letter_P,
                    Tb_Letter_Q,
                    Tb_Letter_R,
                    Tb_Letter_S,
                    Tb_Letter_T,
                    Tb_Letter_U,
                    Tb_Letter_V,
                    Tb_Letter_W,
                    Tb_Letter_X,
                    Tb_Letter_Y,
                    Tb_Letter_Z
                };

            return letterBoxes;
        }


    }
}
