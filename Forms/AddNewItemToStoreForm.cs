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
    public partial class AddNewItemToStoreForm : Form
    {
        private string StoreId;
        public AddNewItemToStoreForm(string id)
        {
            StoreId = id;
            InitializeComponent();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            var s = sender as TextBox;
            bool isNum = int.TryParse(s.Text, out var num);
            if(!isNum)
            {
                amountTextBox.Text = amountTextBox.Text.Substring(0, amountTextBox.TextLength - 1);
            }
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            var s = sender as TextBox;
            bool isNum = int.TryParse(s.Text, out var num);
            if (!isNum)
            {
                idTextBox.Text = idTextBox.Text.Substring(0, idTextBox.TextLength - 1);
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text.Length < 4)
                return;
            if(nameTextBox.Text.Length != 0 && idTextBox.Text.Length != 0 && amountTextBox.Text.Length != 0)
            {
                List<Item> items = new List<Item>();
                items.Add(new Item(idTextBox.Text, nameTextBox.Text, Int32.Parse(amountTextBox.Text), false));
                AddNewItem addNewItem = new AddNewItem(items, StoreId);
                if(addNewItem.Successful)
                {
                    successLabel.Text = "Элемент успешно добавлен";
                    Thread.Sleep(3000);
                    this.Close();
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Text == "Form1")
                            form.Show();
                    }
                }
                else
                {
                    successLabel.Text = "Элемент не был добавлен";
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach(Form form in Application.OpenForms)
            {
                if(form.Text == "StartStoresForm")
                {
                    form.Show();
                }
            }
        }
    }
}
