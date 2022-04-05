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
    public partial class MovToStoresForm : Form
    {
        private List<Item> Items = new List<Item>();
        private string Id = "";
        public MovToStoresForm(string id, List<Item> items)
        {
            Id = id;
            Items = items;
            StoresListBox = new ListBox();
            StoresPage storesPage = new StoresPage(id);

            InitializeComponent();
            foreach (Store store in storesPage.stores)
            {

                StoresListBox.Items.Add(store.Id + " " + store.Name);
            }
        }

        private void StoresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ListBox;
            string destId = s.SelectedItem.ToString().Substring(0, 3);
            StoreMovings storeMovings = new StoreMovings(Items, Id, destId);
            if (storeMovings.Successful)
            {
                successLabel.Text = "Элементы успешно перемещены";
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
                successLabel.Text = "Элементы не были перемещены";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                
                if (form.Text == "MovDelForm")
                    form.Show();
            }
        }
    }
}
