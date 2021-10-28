using Newtonsoft.Json;

namespace TestFrameworkHomeTask.Service.TestRail.Entities
{
    public class AddResultEntity
    {
        [JsonProperty("status_id")]
        public int StatusId { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("elapsed")]
        public string Elapsed { get; set; }

        [JsonProperty("defects")]
        public string Defects { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("assignedto_id ")]
        public int AssignedToId { get; set; }

    }
}
