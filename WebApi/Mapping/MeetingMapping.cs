using AutoMapper;
using DtoLayer.MeetingDto;
using EntityLayer.Concrete;

namespace WebApi.Mapping
{
    public class MeetingMapping:Profile
    {
        public MeetingMapping()
        {
            CreateMap<Meeting,ResultMeetingDto>().ReverseMap();
            CreateMap<Meeting,UpdateMeetingDto>().ReverseMap();
            CreateMap<Meeting,CreateMeetingDto>().ReverseMap();
        }
    }
}
