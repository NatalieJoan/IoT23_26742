namespace Lab4.Database.Entities
{
    public class AddressEntity
    {
        internal object address;
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public int ZipCode { get; set; }
        public List<PersonEntity> people {get; set;}
    }
}