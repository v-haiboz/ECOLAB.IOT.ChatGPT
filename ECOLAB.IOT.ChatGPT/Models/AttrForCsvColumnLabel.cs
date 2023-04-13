namespace ECOLAB.IOT.ChatGPT.Models
{
    public class AttrForCsvColumnLabel : Attribute
    {
        public string Title { get; set; } = string.Empty;
        public bool Ignore { get; set; } = false;
    }
}
