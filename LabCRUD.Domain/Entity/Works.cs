namespace LabCRUD.Domain.Entity
{
    public class Works
    {
        public int Id { get; set; }
        public string Actions { get; set; }
        public string Worker { get; set; }
        public int BakeryId { get; set; }
        public override string ToString()
        {
            return $"Actions = {Actions} | Worker = {Worker}";
        }
    }
}

