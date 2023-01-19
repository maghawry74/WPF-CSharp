using SQLite;

namespace Desktop_Contacts_APP.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public override string ToString()
        {
            return $"Name : {Name} Email : {Email} Phone : {Phone}";
        }

    }
}
