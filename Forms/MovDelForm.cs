using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPTest3.Code;

namespace IPTest3
{
    public partial class MovDelForm : Form
    {
        private List<Item> Items = new List<Item>();
        private bool MovDel;
        private string Id;
        public MovDelForm(List<Item> items, bool movDel, string id)
        {
            Items = items;
            MovDel = movDel;
            Id = id;
            MovDelListBox = new ListBox();
            continueButton = new Button();
            cancelButton = new Button();
            successLabel = new Label();
            InitializeComponent();
            foreach (Item item in items)
            {
                MovDelListBox.Items.Add(item.Id + " " + item.Name + " " + item.Amount);
            }
        }

        private async void continueButton_Click(object sender, EventArgs e)
        {
            if (MovDel)
            {
                MovToStoresForm movToStoresPage = new MovToStoresForm(Id, Items);
                this.Close();
                movToStoresPage.Show();
            }
            else
            {
                DeleteFromStore deleteFromStore = new DeleteFromStore(Items, Id);
                if (deleteFromStore.Successful)
                {
                    successLabel.Text = "Элементы успешно удалены";
                    Thread.Sleep(3000);
                    this.Close();
                    foreach(Form form in Application.OpenForms)
                    {
                        if(form.Text == "Form1")
                            form.Show();
                    }
                }
                else
                {
                    successLabel.Text = "Элементы ";
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach(Form form in Application.OpenForms)
            {
                if(form.Text == "StoreItemsForm")
                {
                    form.Show();
                }
            }
        }


    }
}
