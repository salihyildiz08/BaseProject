﻿namespace DtoLayer.MeetingDto
{
    public class CreateMeetingDto
    {
        public string Title { get; set; }
        public string VisitedCompany { get; set; }
        public string Description { get; set; }
        public string CompanyDemands { get; set; }
        public string IsCollection { get; set; }
        public decimal CollectionTotal { get; set; }
        public string CollectionType { get; set; }
        public string Currency { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserID { get; set; }
        public int DepartmentId { get; set; }
    }

}
