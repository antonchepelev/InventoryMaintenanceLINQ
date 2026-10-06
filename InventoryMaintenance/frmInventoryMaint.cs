using System.Linq;
namespace InventoryMaintenance
{
    public partial class frmInventoryMaint : Form
    {
        // Anton Chepelev
        public frmInventoryMaint()
        {
            InitializeComponent();
        }

        private List<InventoryItem> items = null!;

        // Anton Chepelev
        private void frmInventoryMaint_Load(object sender, EventArgs e)
        {
            items = InventoryDB.GetItems();
            LoadComboBox();
            FillItemListBox();
        }

        // Anton Chepelev
        private void LoadComboBox()
        {
            cboFilterBy.DataSource = new string[] {
                "All", "Under $10", "$10 to $50", "Over $50"
            };
        }

        // Anton Chepelev
        private void FillItemListBox()
        {
            lstItems.Items.Clear();

            string filter = cboFilterBy.SelectedValue?.ToString() ?? "";
            IEnumerable<InventoryItem> filteredItems = items;

       
            switch (filter)
            {
                case "Under $10":
                    filteredItems = items.Where(item => item.Price < 10);
                    break;
                case "$10 to $50":
                    filteredItems = items.Where(item => item.Price >= 10 && item.Price <= 50);
                    break;
                case "Over $50":
                    filteredItems = items.Where(item => item.Price > 50);
                    break;
                default:
                    filteredItems = items;
                    break;
            }

        
            foreach (var i in filteredItems.OrderBy(i => i.Description))
                lstItems.Items.Add(i.GetDisplayText());

        }

        // Anton Chepelev
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new();
            InventoryItem item = newItemForm.GetNewItem();
            if (item != null)
            {
                items.Add(item);
                InventoryDB.SaveItems(items);
                FillItemListBox();
            }
        }

        // Anton Chepelev
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstItems.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No item selected");
            }
            else
            {
                InventoryItem selectedToDelete = items.First(item => item.GetDisplayText() == lstItems.Items[index].ToString());

                string message = $"Are you sure you want to delete {selectedToDelete.GetDisplayText()}?";
                DialogResult result =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    items.Remove(selectedToDelete);
                    InventoryDB.SaveItems(items);
                    FillItemListBox();
                }
            }
        }

        // Anton Chepelev
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Anton Chepelev
        private void cboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillItemListBox();
        }

        // Anton Chepelev
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}