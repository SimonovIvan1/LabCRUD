using System.ComponentModel.DataAnnotations.Schema;

namespace LabCRUD.Domain.Entity
{
    public class Bakery
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string House { get; set; }

        public override string ToString()
        {
            return $"Name = {Name} | Number = {Number}";
        }
    }
}