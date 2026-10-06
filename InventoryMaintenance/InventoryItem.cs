namespace InventoryMaintenance
{
    public class InventoryItem
    {
        // Anton Chepelev
        public InventoryItem() { }

        // Anton Chepelev
        public InventoryItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        public int ItemNo { get; set; }
        public string Description { get; set; } = "";
        public decimal Price { get; set; }

        // Anton Chepelev
        public string GetDisplayText() => $"{ItemNo}    {Description} ({Price:c})";
    }
}
