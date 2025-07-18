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
    
    /// <summary>
    /// Represents a single identity that you wish to enroll.
    /// </summary>
    public class IdentityItem
    {

        /// <summary>
        /// A client-generated unique ID for a specific customer. This ID links calls related to the same customer, across different requests or sessions. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field.
        /// </summary>
        [JsonProperty("clientCustomerId")]
        public string? ClientCustomerId { get; set; }

        /// <summary>
        /// A string that is the unique identifier for the Prove Key on the device. Only applicable if you are leveraging Prove Unify.
        /// </summary>
        [JsonProperty("deviceId")]
        public string? DeviceId { get; set; }

        /// <summary>
        /// The number of the consumer being enrolled. US phone numbers can be passed in with or without a leading +1. Acceptable characters are: alphanumeric with symbols &apos;+&apos;.
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; } = default!;
    }
}