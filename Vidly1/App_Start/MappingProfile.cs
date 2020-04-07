using AutoMapper;
using Vidly1.Dtos;
using Vidly1.Models;

namespace Vidly1.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Domain to Dto
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<Movie, MovieDto>();


			
			// Dto to Domain
			Mapper.CreateMap<CustomerDto, Customer>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			Mapper.CreateMap<MovieDto, Movie>()
				.ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}