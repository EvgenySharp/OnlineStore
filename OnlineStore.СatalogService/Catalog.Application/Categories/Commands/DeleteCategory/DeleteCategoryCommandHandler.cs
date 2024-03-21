using Catalog.Application.Exceptions.Categories;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var foundCategory = await _categoryRepository.FindByIdAsync(request.Id, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var categoryDeleteResult = await _categoryRepository.DeleteAsync(foundCategory, cancellationToken);

            if (!categoryDeleteResult.Succeeded)
            {
                throw new CategoryDeleteException();
            }

            return Unit.Value;
        }
    }
}