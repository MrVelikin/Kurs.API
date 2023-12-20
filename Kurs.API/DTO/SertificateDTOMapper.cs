using Kurss.Domain;

namespace Kurs.API.DTO
{
    public class SertificateDTOMapper : DocumentsDTOMapper
    {
        public static SertificateDTO ToDto(Sertificate sertificate)
        {
            var sertificateDTO = new SertificateDTO
            {
                SertName = sertificate.SertName,
                Photo = sertificate.Photo

            };
            return sertificateDTO;
        }

        public static Sertificate ToEntity(SertificateDTO sertificateDto)
        {
            var sertificate = new Sertificate(sertificateDto.SertName, sertificateDto.Photo, sertificateDto.DocName, sertificateDto.Visible);

            return sertificate;
        }

        public static List<SertificateDTO> ToDto(List<Sertificate> sertificates)
        {
            var sertificateDto = new List<SertificateDTO>();
            foreach (var sertificate in sertificates)
            {
                sertificateDto.Add(ToDto(sertificate));
            }

            return sertificateDto;
        }
    }
}
