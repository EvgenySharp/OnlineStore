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
            var foundCategory = await _categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var categoryUpdateResult = await _categoryRepository.UpdateAsync(foundCategory, request.JsonPatchCategoryDto, cancellationToken);

            if (!categoryUpdateResult.Succeeded)
            {
                throw new CategoryUpdateException();
            }

            return Unit.Value;
        }
    }
}