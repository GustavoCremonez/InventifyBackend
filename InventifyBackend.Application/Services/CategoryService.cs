using AutoMapper;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Categories;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGeneralRepository generalRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<Guid>> Add(CategoryCreateResource categoryResource, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryResource);

                category.ValidateCategory();

                await _generalRepository.Add(category, cancellationToken);

                return ResponseDto<Guid>.Success(category.Id);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering category: " + e.Message);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering category.");
            }
        }

        public async Task<ResponseDto<CategoryDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.Get(id, cancellationToken);

                if (category == null)
                {
                    return ResponseDto<CategoryDto>.Failure(400, "There is no category with this id.");
                }

                var categoryDto = _mapper.Map<CategoryDto>(category);

                return ResponseDto<CategoryDto>.Success(categoryDto);
            }
            catch
            {
                return ResponseDto<CategoryDto>.Failure(500, "Error while getting category.");
            }
        }
        
        public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetAll(cancellationToken);
                var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return ResponseDto<IEnumerable<CategoryDto>>.Success(categoryDto);
            }
            catch
            {
                return ResponseDto<IEnumerable<CategoryDto>>.Failure(500, "Error while getting categories.");
            }
        }

        public async Task<ResponseDto<CategoryDto>> Update(CategoryUpdateResource? categoryResource, CancellationToken cancellationToken)
        {
            try
            {
                if (categoryResource == null)
                {
                    return ResponseDto<CategoryDto>.Failure(400, "The category information must contain a value.");
                }

                Category? category = await _categoryRepository.Get(categoryResource.id, cancellationToken);

                if (category == null)
                {
                    return ResponseDto<CategoryDto>.Failure(400, "There is no category with this id.");
                }

                category.UpdateCategory(categoryResource.name, categoryResource.description);

                await _generalRepository.SaveAsync();

                CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);

                return ResponseDto<CategoryDto>.Success(categoryDto);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<CategoryDto>.Failure(500, "Error while updating category: " + e.Message);
            }
            catch
            {
                return ResponseDto<CategoryDto>.Failure(500, "Error while updating category.");
            }
        }

        public async Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(id, cancellationToken);
            try
            {
                if (category == null)
                {
                    return ResponseDto<Guid>.Failure(400, "There is no category with this id.");
                }

                await _generalRepository.Delete(category);

                return ResponseDto<Guid>.Success(id);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when deleting category.");
            }
        }
    }
}
