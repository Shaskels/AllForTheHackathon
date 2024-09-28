namespace AllForTheHackathon.Domain.Employees
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Employee);
        }

        public bool Equals(Employee other)
        {
            if (other != null && Id == other.Id && Name == other.Name)
                return true;
            return false;
        }
    }
}
