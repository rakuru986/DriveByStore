using System;
using System.Text.Json.Serialization;

namespace Models.JwtAuth
{
    public sealed class RefreshToken
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
