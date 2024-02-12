using Catalog.Application.Exceptions.Categories;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRequestDto = request.UptadeCategoryRequestDto;
            var foundCategory = await _categoryRepository.FindByIdAsync(categoryRequestDto.Id, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var categoryChangeResult = await _categoryRepository.ChangeTitleAsync(foundCategory, categoryRequestDto.NewTiitle, cancellationToken);

            if (!categoryChangeResult.Succeeded)
            {
                throw new CategoryUpdateException();
            }

            return Unit.Value;
        }
    }
}