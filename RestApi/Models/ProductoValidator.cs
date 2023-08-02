using FluentValidation;

namespace RestApi.Models
{
    public class ProductoValidator: AbstractValidator<ProductoModel>
    {
        public ProductoValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Precio).GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
        }
    }
}
