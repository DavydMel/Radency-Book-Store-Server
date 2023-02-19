using AutoMapper;

namespace RadencyTask2.Models.Books.View
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Book, BookShortView>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(
                    src => src.Ratings != null && src.Ratings.Count > 0 ?
                    (decimal?)src.Ratings.Average(r => r.Score) : (decimal?)null
                    ))
                .ForMember(dest => dest.ReviewsNumber, act => act.MapFrom(
                    src => src.Reviews.Count()));
            CreateMap<Book, BookDetailView>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(
                    src => src.Ratings != null && src.Ratings.Count > 0 ?
                    (decimal?)src.Ratings.Average(r => r.Score) : (decimal?)null
                    ));
        }
    }
}