namespace GraduateProjectAPI.DTO
{
    public class DocumentResult
    {
        public int KeyDoc { get; set; }
        public int? KeyNote { get; set; }
        public string DocNumber { get; set; }
        public DateTime? DocCreated { get; set; }
        public DateTime? DocDate { get; set; }
        public int? KeyAuthor { get; set; }
        public string Author { get; set; }
        public int? Restrictions { get; set; }
        public int? Flags { get; set; }
        public short? DocState { get; set; }
        public int CheckedOut { get; set; }
        public string Comment { get; set; }
        public int Embedded { get; set; }
        public int Signed { get; set; }
        public int? KeyPrivacy { get; set; }
        public string Privacy { get; set; }
        public int NotRead { get; set; }
        public string DocNote { get; set; }
        public int? KeyForm { get; set; }
        public int Supervised { get; set; }
        public string UserComment { get; set; }
    }
}
