//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Prove.Proveapi.Models.Requests
{
    using Newtonsoft.Json;
    using Prove.Proveapi.Models.Components;
    using Prove.Proveapi.Utils;
    
    public class V3DisenrollIdentityResponse
    {

        [JsonProperty("-")]
        public HTTPMetadata HttpMeta { get; set; } = default!;

        /// <summary>
        /// V3DisenrollIdentityResponse
        /// </summary>
        public Models.Components.V3DisenrollIdentityResponse? V3DisenrollIdentityResponseValue { get; set; }
    }
}