using Kurss.Domain;

namespace Kurs.API.DTO
{
    public class DocumentsDTO
    {
        public Guid Id { get; set; }

        public string DocName { get; set; } = String.Empty;
        public bool Visible { get; set; } = true;

        public List<PasportDTO> PasportsDTOS { get; set; } = new List<PasportDTO>();

        public List<SertificateDTO> SertificatesDTOS { get; set; } = new List<SertificateDTO>();
    }
}
