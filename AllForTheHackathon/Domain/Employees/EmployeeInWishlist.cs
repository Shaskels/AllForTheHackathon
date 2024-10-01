namespace AllForTheHackathon.Domain.Employees
{
    public class EmployeeInWishlist
    {
        public int Id { get; set; }
        public int EmployeeId {  get; set; }
        public Employee? Employee { get; set; }
        public int WishlistId { get; set; }
        public Wishlist? Wishlist { get; set; }
        public int PositionInList { get; set; }
    }
}
