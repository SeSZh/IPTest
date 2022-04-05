using IPTest3.Code;
using System.Text.RegularExpressions;

namespace IPTest3
{
    public partial class StoreItemsForm : Form
    {
        private bool IsToMove = false;
        private bool IsToDelete = false;
        private List<Item> Items = new List<Item>();
        public string StoreId = "";
        public StoreItemsForm(string id)
        {
            
            StoreId = id;
            ItemsPage itemsPage = new(id);
            StoreItemsListBox = new ListBox();
            addNewItemButton = new Button();
            movingButton = new Button();
            deleteButton = new Button();
            TableLayoutPanel tab = new TableLayoutPanel();
            tab.ColumnCount = 3;
            tab.RowCount = 1;
            tab.Width = 2000000;
            Label label = new Label();
            Items = new List<Item>(itemsPage.items);
            InitializeComponent();
            timeTextBox.Text = DateTime.Now.ToString();
            foreach (Item item in Items)
            {


                StoreItemsListBox.Items.Add(item.Id + " " + item.Name + " " + item.Amount);
            }
            
        }

        private void StoreItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ListBox;

            StoreItemsListBox.SelectedItems.Add(s.SelectedItem);
            string id = s.SelectedItem.ToString().Substring(0, 4);
            int index = Items.FindIndex(item => item.Id == id);
            Items[index].IsSelected = !Items[index].IsSelected;


        }
        private void StoreItemsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var s = sender as ListBox;
        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>(Items.FindAll(item => item.IsSelected == true));
            this.Hide();
            MovDelForm movDelForm = new MovDelForm(items, true, StoreId);
            movDelForm.Show();

        }

        private void addNewItemButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            AddNewItemToStoreForm addNewItemToStoreForm = new AddNewItemToStoreForm(StoreId);
            addNewItemToStoreForm.Show();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>(Items.FindAll(item => item.IsSelected == true));
            this.Hide();
            MovDelForm movDelForm = new MovDelForm(items, false, StoreId);
            movDelForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == "Form1")
                    form.Show();
            }
        }

        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void getBalanceButton_Click(object sender, EventArgs e)
        {
            string time = timeTextBox.Text;
            if (time.Length == 18)
                time = time.Insert(11, "0");
            try
            {
                DateTime now = DateTime.ParseExact(time, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                GetNewItemsByTime(now);
                movingButton.Enabled = false;
                deleteButton.Enabled = false;
                addNewItemButton.Enabled = false;

            }
            catch
            {
                return;
            }
            
        }
        private void GetNewItemsByTime(DateTime time)
        {
            StoreItemsListBox.Items.Clear();
            ItemsPage itemsPage = new ItemsPage(StoreId, time, Items);
            Items = itemsPage.items;
            foreach (Item item in Items)
            {
                StoreItemsListBox.Items.Add(item.Id + " " + item.Name + " " + item.Amount);
            }

        }
    }
}
