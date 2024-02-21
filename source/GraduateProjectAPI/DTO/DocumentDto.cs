
using Microsoft.AspNetCore.Http.HttpResults;

namespace GraduateProjectAPI.DTO
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string RegistrationNumber {  get; set; }
        public DateTime Date { get; set; }
        public string Created {  get; set; }
        public string PublicComment { get; set; }
        public string TypeDoc { get; set; }
        public string PrivateComment { get; set; }

    }
}
