using CoreApiProject.Api.Dtos.ProductDtos;
using FluentValidation;

namespace CoreApiProject.Api.ValidationRules.ProductValidators;
public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty()
            .WithMessage("Ürün Adı Boş Geçilemez!")
            .MinimumLength(2)
            .WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır!")
            .MaximumLength(100)
            .WithMessage("Ürün Adı En Fazla 100 Karakter Olmalıdır!");

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Ürün Fiyatı Negatif veya Boş Değer Olamaz!")
            .LessThanOrEqualTo(1000)
            .WithMessage("Ürün Fiyatı 1000 ₺'yi Aşamaz!");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Ürün Açıklaması Boş Geçilemez!");
    }
}