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
    /// Response body for the V3 Activate Identity API.
    /// </summary>
    public class V3ActivateIdentityResponse
    {

        /// <summary>
        /// If true, the activate operation was successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; } = default!;
    }
}