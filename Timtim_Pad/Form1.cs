using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timtim_Pad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New
            richTextBox1.Clear();
            this.Text = "Untitled";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "open";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save
            SaveFileDialog op = new SaveFileDialog();
            op.Title = "Save";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit

            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                //Modify this code..
                MessageBox.Show("Konnichiwa", "Wise Choice", MessageBoxButtons.OK);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Undo
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Redo
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Paste
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cut
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Select All
            richTextBox1.SelectAll();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Date Time
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Font
            FontDialog op = new FontDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = op.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Color
            ColorDialog op = new ColorDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = op.Color;
        }


        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //About
            MessageBox.Show("Timtim Pad is a simple text editor made by Timtim", "About", MessageBoxButtons.OK);
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            //Status Bar
            int line = richTextBox1.Lines.Count();
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            toolStripStatusLabel1.Text = "Line: " + line.ToString() + " Column: " + column.ToString();
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form Closing
            if (richTextBox1.Text != "")
            {
                string message = "Do you want to save changes?";
                string title = "Save Changes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog op = new SaveFileDialog();
                    op.Title = "Save";
                    op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
                    if (op.ShowDialog() == DialogResult.OK)
                        richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = op.FileName;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
