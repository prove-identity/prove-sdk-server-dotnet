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
    using Prove.Proveapi.Models.Components;
    using Prove.Proveapi.Utils;
    using System.Collections.Generic;
    
    /// <summary>
    /// Response body for the V3 Batch Enroll Identities API.
    /// </summary>
    public class V3BatchEnrollIdentitiesResponse
    {

        [JsonProperty("results")]
        public List<PostBatchResultItem>? Results { get; set; }
    }
}