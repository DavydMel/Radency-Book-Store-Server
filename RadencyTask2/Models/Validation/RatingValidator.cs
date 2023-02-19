using FluentValidation;
using RadencyTask2.Models.Books;

namespace RadencyTask2.Models.Validation
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator() 
        {
            RuleFor(b => b.Score).InclusiveBetween(1, 5);
        }
    }
}