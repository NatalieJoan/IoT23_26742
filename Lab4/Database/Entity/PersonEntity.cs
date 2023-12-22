namespace Lab4.Database.Entities
{
    public class PersonEntity
    {
        internal object people;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity address{ get; set; }
        public int AddressId{ get; set; }
    }
}