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
    
    public class IDVDataInternal
    {

        [JsonProperty("dataSource1")]
        public DataSourceInternal? DataSource1 { get; set; }

        [JsonProperty("dataSource2")]
        public DataSourceInternal? DataSource2 { get; set; }

        [JsonProperty("multiCIPConfidence")]
        public string? MultiCIPConfidence { get; set; }
    }
}