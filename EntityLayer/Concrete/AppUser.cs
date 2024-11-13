using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RepresentationCode { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public List<Meeting> CreatedMeetings { get; set; }
        public List<Meeting> UpdatedMeetings { get; set; }

    }
}
