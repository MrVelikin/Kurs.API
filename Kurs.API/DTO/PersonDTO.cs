using Kurss.Domain;

namespace Kurs.API.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public PersonalDataDTO? PersonalDataDTO { get; set; } = null;
        public List<DocumentsDTO> DocumentsDTOS { get; set; } = new List<DocumentsDTO>();
        public List<PasportDTO> PasportsDTOS { get; set; } = new List<PasportDTO>();
        public List<SertificateDTO> SertificatesDTOS { get; set; } = new List<SertificateDTO>();
    }
}
