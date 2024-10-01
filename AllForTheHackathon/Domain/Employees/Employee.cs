namespace AllForTheHackathon.Domain.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public int IdInList { get; set; }
        public string Name { get; set; }
        public Wishlist? Wishlist { get; set; }
        public Employee(int idInList, string name)
        {
            IdInList = idInList;
            Name = name;
        }

        public override string ToString()
        {
            return $"{IdInList.ToString(),-3}- {Name.ToString()}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Employee);
        }

        public bool Equals(Employee other)
        {
            if (other != null && IdInList == other.IdInList && Name == other.Name)
                return true;
            return false;
        }
    }
}
