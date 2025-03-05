using AutoMapper;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Categories;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Helper;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Application.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IMapper _mapper;

        public CategorieService(IGeneralRepository generalRepository, ICategorieRepository categorieRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _categorieRepository = categorieRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<Guid>> Add(CategorieCreateResource categorieResource, CancellationToken cancellationToken)
        {
            try
            {
                Categorie categorie = _mapper.Map<Categorie>(categorieResource);

                categorie.ValidateCategorie();

                await _generalRepository.Add(categorie, cancellationToken);

                return ResponseDto<Guid>.Success(categorie.Id);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering categorie: " + e.Message);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering categorie.");
            }
        }

        public async Task<ResponseDto<CategorieDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Categorie? categorie = await _categorieRepository.Get(id, cancellationToken);

                if (categorie == null)
                {
                    return ResponseDto<CategorieDto>.Failure(400, "There is no categorie with this id.");
                }

                CategorieDto categorieDto = _mapper.Map<CategorieDto>(categorie);

                return ResponseDto<CategorieDto>.Success(categorieDto);
            }
            catch
            {
                return ResponseDto<CategorieDto>.Failure(500, "Error while getting categorie.");
            }
        }

        public async Task<ResponseDto<CategorieDto>> Update(CategorieUpdateResource categorieResource, CancellationToken cancellationToken)
        {
            try
            {
                if (categorieResource == null)
                {
                    return ResponseDto<CategorieDto>.Failure(400, "The categorie information must contain a value.");
                }

                Categorie? categorie = await _categorieRepository.Get(categorieResource.id, cancellationToken);

                if (categorie == null)
                {
                    return ResponseDto<CategorieDto>.Failure(400, "There is no categorie with this id.");
                }

                categorie.UpdateCategorie(categorieResource.name, categorieResource.description);

                await _generalRepository.SaveAsync();

                CategorieDto categorieDto = _mapper.Map<CategorieDto>(categorie);

                return ResponseDto<CategorieDto>.Success(categorieDto);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<CategorieDto>.Failure(500, "Error while updating categorie: " + e.Message);
            }
            catch
            {
                return ResponseDto<CategorieDto>.Failure(500, "Error while updating categorie.");
            }
        }

        public async Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Categorie? categorie = await _categorieRepository.Get(id, cancellationToken);

                if (categorie == null)
                {
                    return ResponseDto<Guid>.Failure(400, "There is no categorie with this id.");
                }

                await _generalRepository.Delete(categorie);

                return ResponseDto<Guid>.Success(id);
            }
            catch
            {
                return ResponseDto<Guid>.Failure(500, "Error when deleting categorie.");
            }
        }
    }
}
