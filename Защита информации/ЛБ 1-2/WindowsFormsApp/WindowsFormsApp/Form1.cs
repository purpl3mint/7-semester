using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        Encryption test = new Encryption();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word = richTextBox1.Text;
            string key = richTextBox2.Text;
            Encryption encryption = new Encryption(word, key);

            if (radioButton1.Checked)
            {  
                richTextBox3.Text = encryption.Encrypt();
            }
            else
            {
                richTextBox3.Text = encryption.EncryptTwo();
            }
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = richTextBox3.Text;
            string key = richTextBox2.Text;
            Encryption unEncryption = new Encryption(text, key);
            
            if (radioButton1.Checked)
            {
                richTextBox1.Text = unEncryption.Decrypt();
            }
            else
            {
                richTextBox1.Text = unEncryption.DecryptTwo();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = get_name_file();
            byte[] bt = File.ReadAllBytes(fileName);
            string key = richTextBox2.Text;
            Encryption fileEncryption = new Encryption(bt, key);

            if (radioButton1.Checked)
            {
                byte[] writeFile = fileEncryption.fileEncrypt();
                write_to_file(fileName, writeFile);
            }else
            {
                byte[] writeFile = fileEncryption.fileEncryptTwo();
                write_to_file(fileName, writeFile);
            }

        }

        private string get_name_file()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            var fileContent = string.Empty;

            openFile.InitialDirectory = "./";
            openFile.Filter = "All files (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                return openFile.FileName;
            }
            return null;
        }

        private void write_to_file(string fileName, byte[] bt)
        {
            FileStream write = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            
            write.Write(bt, 0, bt.Length);
            
            write.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                string fileName = get_name_file();
                byte[] bt = File.ReadAllBytes(fileName);
                string key = richTextBox2.Text;
            
                Encryption fileUnEncryption = new Encryption(bt, key);
            if (radioButton1.Checked)
            {

                byte[] writeFile = fileUnEncryption.fileDecrypt();

                write_to_file(fileName, writeFile);
            } else
            {
                byte[] writeFile = fileUnEncryption.fileDecryptTwo();

                write_to_file(fileName, writeFile);
            } 
        }
    }
}
