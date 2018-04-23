using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Browsing;

namespace RepCustomXRRichText {
    public partial class RichTextEditorForm : Form {
        public RichTextEditorForm() {
            InitializeComponent();
        }

        private void RichTextEditorForm_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
            richTextBox1.DragOver += new DragEventHandler(richTextBox1_DragOver);
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
        }

        void richTextBox1_DragEnter(object sender, DragEventArgs e) {
            if(e.Data.GetData(typeof(DataInfo[])) != null)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        void richTextBox1_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetData(typeof(DataInfo[])) != null)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        void richTextBox1_DragDrop(object sender, DragEventArgs e) {
            DataInfo droppedData = ((DataInfo[])(e.Data.GetData(typeof(DataInfo[]))))[0];

            richTextBox1.SelectedText = "[" + droppedData.Member + "]";
        }

    }
}