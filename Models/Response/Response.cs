using System.Text.Json;
using System.Text.Json.Serialization;

namespace LDKProject.Models.Response
{
    public class Response
    {
        public bool Success { get; set; }
        public object Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // Kalo NULL, pagination ga dimunculkan
        public Pagination? Pagination { get; set; }

        public string Message { get; set; }
        public string Status { get; set; }
        public int Code { get; set; }
        public override string ToString() // untuk ubah key json jadi string
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
