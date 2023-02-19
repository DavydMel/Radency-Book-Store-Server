using FluentValidation;
using RadencyTask2.Models.Books;

namespace RadencyTask2.Models.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator() 
        {
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.Cover).NotEmpty();
            RuleFor(b => b.Content).NotEmpty();
            RuleFor(b => b.Author).NotEmpty().Length(1, 50);
            RuleFor(b => b.Genre).NotEmpty();
        }
    }
}