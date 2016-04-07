using System;
using ERP.Domain.Interfaces.Products.Sections;
using ERP.Services.PurchaseServices.Converters.Products.Sections;
using ERP.Services.PurchaseServices.Dtos.Sections;
using ERP.Services.PurchaseServices.Interfaces.Products.Sections;

namespace ERP.Services.PurchaseServices.Services.Products.Sections
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly SectionNewDtoConverterOrganizationEntity _converterSectionNewDto;
        private readonly SectionDtoConverterOrganizationEntity _converterSectionDto;
        private readonly SectionEditDtoConverterOrganizationEntity _converterSectionEditDto;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
            _converterSectionDto = new SectionDtoConverterOrganizationEntity();
            _converterSectionNewDto = new SectionNewDtoConverterOrganizationEntity();
            _converterSectionEditDto = new SectionEditDtoConverterOrganizationEntity();
        }

        public Guid Create(SectionNewDto newSection, Guid organizationId)
        {
            try
            {
                if (!IsValidNewSection(newSection)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newSection.OrganizationId = organizationId;
                var section = _converterSectionNewDto.Convert(newSection,null);

                _sectionRepository.Save(section);
                _sectionRepository.Execute();

                return section.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar seção:  {ex.Message} ");
            }
        }

      
        public SectionDto Get(Guid id)
        {
            try
            {
                var section = _sectionRepository.Get(id);
                var sectionDto = _converterSectionDto.Convert(section, null);

                return sectionDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter seção: {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var section = _sectionRepository.Get(id);
                _sectionRepository.Delete(section);
                _sectionRepository.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar seção: {ex.Message}");
            }

        }

        public void Update(SectionEditDto editSection)
        {
            if (IsValidSection(editSection)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

            var section = _converterSectionEditDto.Convert(editSection, null);
            _sectionRepository.Save(section);

        }

        private static bool IsValidNewSection(SectionNewDto newSupplier)
        {
            return !string.IsNullOrWhiteSpace(newSupplier.Description);
        }

        private static bool IsValidSection(SectionEditDto section)
        {
            return !string.IsNullOrWhiteSpace(section.Description);
        }
    }
}
