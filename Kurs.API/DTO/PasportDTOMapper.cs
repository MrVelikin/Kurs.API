using Kurs.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class PasportDTOMapper : DocumentsDTOMapper
    {
        public static PasportDTO ToDto(Pasport pasport)
        {
            var pasportDto = new PasportDTO
            {
                WhoGave = pasport.WhoGave,
                EndDate = pasport.EndDate,
                Number = pasport.Number
            };
            return pasportDto;
        }

        public static Pasport ToEntity(PasportDTO pasportDto)
        {
            var pasport = new Pasport(pasportDto.WhoGave, pasportDto.EndDate, pasportDto.Number, pasportDto.WhoGave, pasportDto.Visible);

            return pasport;
        }


        public static List<PasportDTO> ToDto(List<Pasport> paspors)
        {
            var pasportDto = new List<PasportDTO>();
            foreach (var pasport in paspors)
            {
                pasportDto.Add(ToDto(pasport));
            }

            return pasportDto;
        }
    }
}
