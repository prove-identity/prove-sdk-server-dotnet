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
    using Prove.Proveapi.Utils;
    
    public class V3GetIdentitiesByPhoneNumberRequest
    {

        /// <summary>
        /// The phone number to find identities for. US phone numbers can be passed in with or without a leading +1. Acceptable characters are: alphanumeric with symbols &apos;+&apos;.
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=mobileNumber")]
        public string MobileNumber { get; set; } = default!;

        /// <summary>
        /// A client-generated unique ID for a specific session. This can be used to identify specific requests. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=clientRequestId")]
        public string? ClientRequestId { get; set; }
    }
}