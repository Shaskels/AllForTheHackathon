namespace AllForTheHackathon.Employees
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {

            return $"{Id.ToString(),-3}- {Name.ToString()}";
        }
    }
}
