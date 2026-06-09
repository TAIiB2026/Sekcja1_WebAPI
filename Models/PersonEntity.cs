using System.Collections.ObjectModel;

namespace Models
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DayOfBirth { get; set; }
        public string? Phone {  get; set; }
        public string? Email { get; set; }
        public Collection<AddressEntity> Addresses { get; set; }
    }
}
