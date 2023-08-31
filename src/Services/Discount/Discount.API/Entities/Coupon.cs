namespace Discount.API.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = "No Discount";     
        public string Description { get; set; } = "No Discount Desc";
        public int Amount { get; set; } = 0;
    }
}
