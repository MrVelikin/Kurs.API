using Kurss.Domain;

namespace Kurs.API.DTO
{
    public class DocumentsDTOMapper
    {
        public static DocumentsDTO ToDto(Documents document)
        {
            var documentDto = new DocumentsDTO
            {
                Id = document.Id,
                DocName = document.DocName,
                Visible = document.Visible
            };
            return documentDto;
        }

        public static Documents ToEntity(DocumentsDTO documentDto)
        {
            var Document = new Documents(documentDto.DocName, documentDto.Visible)
            {
                Id = documentDto.Id,
            };
            return Document;
        }

        public static List<DocumentsDTO> ToDto(List<Documents> documents)
        {
            var documentDto = new List<DocumentsDTO>();
            foreach (var document in documents)
            {
                documentDto.Add(ToDto(document));
            }

            return documentDto;
        }
    }
}
