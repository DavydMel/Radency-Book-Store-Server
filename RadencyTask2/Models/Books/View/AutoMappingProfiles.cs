using AutoMapper;

namespace RadencyTask2.Models.Books.View
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Book, BookView>()
                //.ForMember(dest => dest.Rating, act => act.MapFrom(
                //    src => src.Ratings.Average(r => r.Score)))
                .ForMember(dest => dest.ReviewsNumber, act => act.MapFrom(
                    src => src.Reviews.Count()));
        }
    }
}