namespace ELAKIL.Business.Entities
{
    public class UserCartItem
    {
        public int UserID { get; set; }
        public int? MealId { get; set; }
        public Meal Meal { get; set; }
        public int ID { get; set; }
        public int Quantity { get; set; }
    }
}