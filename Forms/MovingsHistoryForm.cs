using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPTest3.Code;

namespace IPTest3
{
    public partial class MovingsHistoryForm : Form
    {
        public MovingsHistoryForm()
        {
            MovingsHistory movingsHistory = new MovingsHistory();
            List<Movement> movements = movingsHistory.movements;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach(Form form in Application.OpenForms)
            {
                if(form.Name == "StartNodesForm")
                {
                    form.Show();
                }
            }
        }
    }
}
