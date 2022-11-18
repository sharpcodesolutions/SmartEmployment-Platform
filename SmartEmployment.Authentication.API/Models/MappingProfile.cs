using AutoMapper;
using SmartEmployment.DataAccess.Model;

namespace SmartEmployment.Authentication.API.Models
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserForRegistrationDto, User>()
				.ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
		}
	}
}
