using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string filePath { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileD.ShowDialog() == DialogResult.OK) {
                rtb_txt.SaveFile(saveFileD.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileD.ShowDialog() == DialogResult.OK) {
                rtb_txt.LoadFile(openFileD.FileName);
                filePath = openFileD.FileName; 
            }
             
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else {
                rtb_txt.SaveFile(filePath); 
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_txt.Clear();
            filePath = null; 
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();


            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rtb_txt.Text != "")
            {

                DialogResult closeSaveAction = MessageBox.Show("Do you want to save changes?", "save", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (closeSaveAction == DialogResult.OK)
                {
                    if (filePath == null)
                    {
                        saveAsToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }
                }
            }
            DialogResult closeConfirmation = MessageBox.Show("Are you want to close The Program??", "Terminate", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (closeConfirmation != DialogResult.OK)
            {
                e.Cancel = true; 
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontD.ShowDialog() == DialogResult.OK) {
                if (rtb_txt.SelectedText != "")
                {
                    rtb_txt.SelectionFont = fontD.Font;
                }
                else {
                    rtb_txt.Font = fontD.Font;

                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK) {
                if (rtb_txt.SelectedText != "")
                {
                    rtb_txt.SelectionColor = colorD.Color;
                }
                else {
                    rtb_txt.ForeColor = colorD.Color;
                }
            }
        }
    }
}
