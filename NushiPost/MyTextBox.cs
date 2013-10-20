using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NushiPost
{
    class MyTextBox : TextBox 
    {
        public MyTextBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(MyTextBox_KeyDown);
        }

        private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control == true)
            {
                this.SelectAll();
                e.SuppressKeyPress = true;
            }
        }     
    }
}
