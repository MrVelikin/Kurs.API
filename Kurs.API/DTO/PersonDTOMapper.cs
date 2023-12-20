using Kurss.Domain;
using System.Xml.Linq;

namespace Kurs.API.DTO
{
    public static class PersonDTOMapper

    {
        public static PersonDTO ToDto(Person person)
        {
            var personDto = new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email
            };

            foreach (var Document in person.Documents)
            {
                personDto.DocumentsDTOS.Add(DocumentsDTOMapper.ToDto(Document));
            }

            return personDto;
        }

        public static Person ToEntity(PersonDTO personDto)
        {
            var person = new Person( personDto.Name, personDto.Email)
            {
                Id = personDto.Id,
            };

            return person;
        }

        public static List<PersonDTO> ToDto(List<Person> persons)
        {
            var personDTOS = new List<PersonDTO>();
            foreach (var person in persons)
            {
                personDTOS.Add(ToDto(person));
            }

            return personDTOS;
        }
    }
}
