using IPTest3.Code;

namespace IPTest3
{
    public partial class StartStoresForm : Form
    {
        
        public StartStoresForm()
        {
            StoresListFormObj = new ListBox();
            StoresPage storesPage = new StoresPage();
            
            InitializeComponent();
            foreach (Store store in storesPage.stores)
            {

                StoresListFormObj.Items.Add(store.Id + " " + store.Name);
            }

        }

        private void StoresListFormObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ListBox;
            string id = s.SelectedItem.ToString().Substring(0,3);
            this.Hide();
            StoreItemsForm storeItemsForm = new StoreItemsForm(id);
            storeItemsForm.Show();
        }

        private void movingsHistoryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MovingsHistoryForm movingsHistoryForm = new MovingsHistoryForm();
            movingsHistoryForm.Show();
        }
    }
}