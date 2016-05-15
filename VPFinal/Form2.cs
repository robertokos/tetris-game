using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPFinal
{
    public partial class Form2 : Form
    {
        ErrorProvider errorProvider1;

        public string PlayerName { get; set; }

        public Form2()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Trim().Length < 2)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Invalid value!");
            }

            else
            {
                errorProvider1.SetError(tbName, null);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PlayerName = tbName.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
