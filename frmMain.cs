using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnCryptDecrypt
{
    public partial class frmMain : Form
    {
        private Bitmap bmp = null;
        private Bitmap bmpcopy = null;
        public static string text1 = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtClearText.Text == "")
            {
                error.SetError(txtClearText, "Enter the text you want to encrypt");
            }
            else
            {
                error.Clear();
                string clearText = txtClearText.Text.Trim();
                string cipherText = CryptorEngine.Encrypt(clearText, true);
                txtDecryptedText.Visible = false;
                label3.Visible = false;
                txtCipherText.Text = cipherText;
                btnDecrypt.Enabled = true;
                text1 = cipherText;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = txtCipherText.Text.Trim();
            string decryptedText = CryptorEngine.Decrypt(cipherText, true);
            txtDecryptedText.Text = decryptedText;
            txtDecryptedText.Visible = true;
            label3.Visible = true;            
        }

        private void txtDecryptedText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClearText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Ashutosh\\Pictures\\Saved Pictures\artboard_2_1x.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void hide1_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;
            string text = txtCipherText.Text;
            int number = 1;
            MessageBox.Show(text);
            if(text.Equals(""))
            {
                MessageBox.Show("The text you want to hide can't be empty", "Warning");
            }
            else
            {
                bmp = EnCryptDecrypt.SteganographyHelper.embedText(text, bmp, number);
                MessageBox.Show("Your text was hidden in the image successfully!", "Done");
                txtClearText.Visible = false;
                txtCipherText.Visible = false;
                txtDecryptedText.Visible = false;
                btnDecrypt.Enabled = false;
                btnEncrypt.Enabled = false;
            }
        }

        private void Extract_Click(object sender, EventArgs e)
        {

        }
    }
}