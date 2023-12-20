using Kurss.Domain;

namespace Kurs.API.DTO
{
    public class PersonalDataDTOMapper
    {
        public static PersonalDataDTO ToDto(PersonalData personalData)
        {
            var personalDataDTO = new PersonalDataDTO
            {
                Id = personalData.Id,
                Age = personalData.Age,
                DateOfBirth = personalData.DateOfBirth

            };
            return personalDataDTO;
        }

        public static PersonalData ToEntity(PersonalDataDTO personalDataDto)
        {
            var personalData = new PersonalData(personalDataDto.Age, personalDataDto.DateOfBirth)
            {
                Id = personalDataDto.Id
            };

            return personalData;
        }
    }
}
