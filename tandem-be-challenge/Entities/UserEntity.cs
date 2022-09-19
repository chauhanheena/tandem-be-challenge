using Newtonsoft.Json;

namespace tandem_be_challenge.Entities
{
    /// <summary>
    /// Entity which will store in container.
    /// Partition key is EmailAddressId.
    /// </summary>
    public class UserEntity
    {
        [JsonProperty(PropertyName = "userId")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "firstName")]
        public string? FirstName { get; set; }

        [JsonProperty(PropertyName = "middleName")]
        public string? MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string? LastName { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string? EmailAddress { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? EmailAddressId { get; set; }
    }
}
