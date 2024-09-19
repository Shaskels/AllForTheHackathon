namespace AllForTheHackathon.Employees
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

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
