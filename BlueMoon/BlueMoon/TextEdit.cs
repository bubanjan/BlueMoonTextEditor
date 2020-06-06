using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMoon
{
    public partial class TextEdit : Form
    {
        public TextEdit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "";
          
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            saveAsDialog.FileName = "Document.txt";
            if (saveAsDialog.ShowDialog() == DialogResult.OK)
            {
                area.SaveFile(saveAsDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveAsDialog.FileName; // file name in windows frame
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (area.Modified)
                saveOldText();
            Application.Exit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.Text.Length > 0) // controll file name length
                area.SaveFile(this.Text, RichTextBoxStreamType.PlainText);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                area.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                this.Text = openFileDialog1.FileName; // filename in window frame
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveOldText()
        {
            string s;
            if (Text != "")    // Finns filnamn i fönsterramen?
                s = "Do you want to save changes in this file? " + Text + "?";
            else
                s = "Do you want to save text?";
            if (MessageBox.Show(s, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SaveButton_Click(null, null);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("click red x");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.FromArgb(0, 0, 64);
            area.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.FromArgb(20 ,102 ,184);
            area.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.Black;
            area.ForeColor = Color.GreenYellow;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (area.Modified)
            {
                saveOldText();
                area.Clear();

            }

        }

        private void TextEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Text == "" && area.Modified)
            {
                if (MessageBox.Show("Do you want to save this text?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveAsDialog.FileName = "Document.txt";
                    if (saveAsDialog.ShowDialog() == DialogResult.OK)
                    {
                        area.SaveFile(saveAsDialog.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = saveAsDialog.FileName; // file name in windows frame
                    }

                }
                else
                {
                    Application.Exit();
                }
                    

            }
           
            else if (this.Text != "" && area.Modified == true)
            {
                saveOldText();
                area.Clear();

            }
            else if (this.Text == "")
            {
                Application.Exit();
            }

        }
    }
    
}
