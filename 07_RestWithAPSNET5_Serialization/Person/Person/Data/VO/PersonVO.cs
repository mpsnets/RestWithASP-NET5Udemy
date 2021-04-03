using System.Text.Json.Serialization;

namespace Person.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("nameFirst")]
        public string FirstName { get; set; }

        [JsonPropertyName("nameLast")]
        public string LasttName { get; set; }

        [JsonIgnore]
        public string Address { get; set; }

        [JsonPropertyName("sex")]
        public string Gender { get; set; }
    }
}
