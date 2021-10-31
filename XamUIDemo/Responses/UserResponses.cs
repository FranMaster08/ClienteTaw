using System;
using Newtonsoft.Json;

namespace XamUIDemo.Responses
{
    public class UserResponses
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Fecha")]
        public string Fecha { get; set; }

        [JsonProperty("Direccion")]
        public string Direccion { get; set; }

        [JsonProperty("Cuidad")]
        public string Cuidad { get; set; }

        [JsonProperty("Provincia")]
        public string Provincia { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
