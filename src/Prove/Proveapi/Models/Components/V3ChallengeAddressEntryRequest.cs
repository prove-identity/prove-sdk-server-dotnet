//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Prove.Proveapi.Models.Components
{
    using Newtonsoft.Json;
    using Prove.Proveapi.Utils;
    
    public class V3ChallengeAddressEntryRequest
    {

        /// <summary>
        /// The street address of the individual.
        /// </summary>
        [JsonProperty("address")]
        public string? Address { get; set; }

        /// <summary>
        /// The city of the individual.
        /// </summary>
        [JsonProperty("city")]
        public string? City { get; set; }

        /// <summary>
        /// The apartment number or other extended address information.
        /// </summary>
        [JsonProperty("extendedAddress")]
        public string? ExtendedAddress { get; set; }

        /// <summary>
        /// The zip code of the individual. It can be either 5 digits (XXXXX) or ZIP+4 (XXXXX-XXXX).
        /// </summary>
        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// The state or locality of the individual.
        /// </summary>
        [JsonProperty("region")]
        public string? Region { get; set; }
    }
}