using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EnCryptDecrypt
{
    public partial class frmMain : Form
    {
        public Bitmap bmp = null;
        public Bitmap bmpcopy = null;
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
                textBox1.Visible = false;
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
            textBox1.Visible = true;
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
            
        }

        private void hide1_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;
            bmpcopy = (Bitmap)bmp.Clone();
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
                if(bmp.Equals(bmpcopy))
                {
                    MessageBox.Show(" Success ");
                }
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
            bmp = (Bitmap)pictureBox1.Image;
            string cryptotext = null;
            if (bmp == bmpcopy)
            {
                MessageBox.Show(" Success ");
            }
            else
            {
                cryptotext = EnCryptDecrypt.SteganographyHelper.extractText(bmp);
                textBox1.Text = cryptotext;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open_dialog.FileName);
            }
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png Image|*.png|Bitmap Image|*.bmp";
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 0:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Png);
                        } break;
                    case 1:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Bmp);
                        } break;
                }
            }
        }
    }
}