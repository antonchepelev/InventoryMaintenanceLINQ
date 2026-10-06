namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        // Anton Chepelev
        public frmNewItem()
        {
            InitializeComponent();
        }

        private InventoryItem item = null!;

        // Anton Chepelev
        public InventoryItem GetNewItem()
        {
            this.ShowDialog();
            return item;
        }

        // Anton Chepelev
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                item = new(
                    Convert.ToInt32(txtItemNo.Text),
                    txtDescription.Text,
                    Convert.ToDecimal(txtPrice.Text)
                );
                this.Close();
            }
        }

        // Anton Chepelev
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsInt32(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsPresent(txtDescription.Text, "Description");
            errorMessage += Validator.IsPresent(txtPrice.Text, "Price");
            errorMessage += Validator.IsDecimal(txtPrice.Text, "Price");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        // Anton Chepelev
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}