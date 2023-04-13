namespace ECOLAB.IOT.ChatGPT.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Data_Collection_History
    {
        [AttrForCsvColumnLabel(Ignore =true)]
        public float Id { get; set; }

        public string? Device_Code { get; set; }

        public string? Device_Type { get; set; }

        public DateTime Gmt_Create { get; set; }

        [AttrForCsvColumnLabel(Ignore = true)]
        public string Data_Json { get; set; }

        public int MessageType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Device_Code, Device_Type, Gmt_Create, MessageType);
        }
    }
}
