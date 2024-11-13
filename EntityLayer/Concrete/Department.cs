namespace EntityLayer.Concrete
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Statu { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Meeting> Meetings { get; set; }
    }
}
