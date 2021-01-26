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



        private void saveOldText()
        {
            string s;
            if (Text != "")    
                s = "Do you want to save changes in this file? " + Text + "?";
            else
                s = "Do you want to save text?";
            if (MessageBox.Show(s, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                saveToolStripMenuItem_Click(null, null);



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

      
        private void TextEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (area.Modified)
                saveOldText();
            Application.Exit();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (area.Modified)
            {
                saveOldText();
                area.Text = "";
                Text = "";
                area.Modified = false;

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (area.Modified)
                saveOldText();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                area.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                this.Text = openFileDialog1.FileName;
                area.Modified = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsDialog.FileName = "";
            if (saveAsDialog.ShowDialog() == DialogResult.OK)
            {
                area.SaveFile(saveAsDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveAsDialog.FileName;
                area.Modified = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text != "")
                area.SaveFile(this.Text, RichTextBoxStreamType.PlainText);
            else
                saveAsToolStripMenuItem_Click(null, null);
            area.Modified = false;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (area.Modified)
                saveOldText();
            Application.Exit();
        }

        private void lightMoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.FromArgb(20, 102, 184);
            area.ForeColor = Color.White;
        }

        private void darkMoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.Black;
            area.ForeColor = Color.GreenYellow;
        }

        private void blueMoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            area.BackColor = Color.FromArgb(0, 0, 64);
            area.ForeColor = Color.White;
        }
    }
    
}
