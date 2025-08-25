# Identity
(*Identity*)

## Overview

### Available Operations

* [V3BatchGetIdentities](#v3batchgetidentities) - Batch Get Identities
* [V3EnrollIdentity](#v3enrollidentity) - Enroll Identity
* [V3BatchEnrollIdentities](#v3batchenrollidentities) - Batch Enroll Identities
* [V3DisenrollIdentity](#v3disenrollidentity) - Disenroll Identity
* [V3GetIdentity](#v3getidentity) - Get Identity
* [V3ActivateIdentity](#v3activateidentity) - Activate Identity
* [V3DeactivateIdentity](#v3deactivateidentity) - Deactivate Identity
* [V3GetIdentitiesByPhoneNumber](#v3getidentitiesbyphonenumber) - Get Identities By Phone Number

## V3BatchGetIdentities

Return a list of all identities you have enrolled in Identity Manager.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3BatchGetIdentities" method="get" path="/v3/identity/" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3BatchGetIdentitiesAsync();

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                    | Type                                                                                                                                                                                                                                                                                         | Required                                                                                                                                                                                                                                                                                     | Description                                                                                                                                                                                                                                                                                  |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `ClientRequestId`                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                     | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | A client-generated unique ID for a specific session. This can be used to identify specific requests. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field. |
| `Limit`                                                                                                                                                                                                                                                                                      | *long*                                                                                                                                                                                                                                                                                       | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | The maximum number of identities to return per call. Default value is 100.                                                                                                                                                                                                                   |
| `StartKey`                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                     | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | The pagination token for the GET /v3/identity API. Use this to retrieve the next page of results after a previous call to GET /v3/identity. This token is returned as lastKey in the GET /v3/identity API response - pass it in directly as startKey to get the next page of results.        |
| `ShowInactive`                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                       | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | Whether to show identities associated with the current client that are currently marked as inactive. Default value is false.                                                                                                                                                                 |

### Response

**[Models.Requests.V3BatchGetIdentitiesResponse](../../Models/Requests/V3BatchGetIdentitiesResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3EnrollIdentity

Enrolls a single customer for monitoring using their phone number and unique identifier.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3EnrollIdentity" method="post" path="/v3/identity/" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3EnrollIdentityRequest req = new V3EnrollIdentityRequest() {
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    DeviceId = "bf9ea15d-7dfa-4bb4-a64c-6c26b53472fc",
    PhoneNumber = "2001001695",
};

var res = await sdk.Identity.V3EnrollIdentityAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [V3EnrollIdentityRequest](../../Models/Components/V3EnrollIdentityRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[Models.Requests.V3EnrollIdentityResponse](../../Models/Requests/V3EnrollIdentityResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3BatchEnrollIdentities

Enrolls multiple customers in a single request for efficient bulk operations (up to 100).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3BatchEnrollIdentities" method="post" path="/v3/identity/batch" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3BatchEnrollIdentitiesRequest req = new V3BatchEnrollIdentitiesRequest() {
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    Items = new List<IdentityItem>() {
        new IdentityItem() {
            ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            DeviceId = "bf9ea15d-7dfa-4bb4-a64c-6c26b53472fc",
            PhoneNumber = "2001001695",
        },
        new IdentityItem() {
            ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            DeviceId = "bf9ea15d-7dfa-4bb4-a64c-6c26b53472fc",
            PhoneNumber = "2001001695",
        },
    },
};

var res = await sdk.Identity.V3BatchEnrollIdentitiesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [V3BatchEnrollIdentitiesRequest](../../Models/Components/V3BatchEnrollIdentitiesRequest.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[Models.Requests.V3BatchEnrollIdentitiesResponse](../../Models/Requests/V3BatchEnrollIdentitiesResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DisenrollIdentity

Disenrolls an identity from Identity Manager. If you wish to monitor in future, re-enrollment of that identity is required.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DisenrollIdentity" method="delete" path="/v3/identity/{identityId}" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3DisenrollIdentityAsync(identityId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                    | Type                                                                                                                                                                                                                                                                                         | Required                                                                                                                                                                                                                                                                                     | Description                                                                                                                                                                                                                                                                                  |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdentityId`                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                                                                                                           | A Prove-generated unique ID for a specific identity.                                                                                                                                                                                                                                         |
| `ClientRequestId`                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                     | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | A client-generated unique ID for a specific session. This can be used to identify specific requests. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field. |

### Response

**[Models.Requests.V3DisenrollIdentityResponse](../../Models/Requests/V3DisenrollIdentityResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3GetIdentity

Return details of an identity given the identity ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3GetIdentity" method="get" path="/v3/identity/{identityId}" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3GetIdentityAsync(identityId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                    | Type                                                                                                                                                                                                                                                                                         | Required                                                                                                                                                                                                                                                                                     | Description                                                                                                                                                                                                                                                                                  |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdentityId`                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                                                                                                           | A unique Prove-generated identifier for the enrolled identity.                                                                                                                                                                                                                               |
| `ClientRequestId`                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                     | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | A client-generated unique ID for a specific session. This can be used to identify specific requests. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field. |

### Response

**[Models.Requests.V3GetIdentityResponse](../../Models/Requests/V3GetIdentityResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ActivateIdentity

Sets an identity as active for monitoring.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3ActivateIdentity" method="post" path="/v3/identity/{identityId}/activate" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3ActivateIdentityAsync(
    identityId: "<id>",
    v3ActivateIdentityRequest: new Prove.Proveapi.Models.Components.V3ActivateIdentityRequest() {
        ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         | Example                                                                                             |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `IdentityId`                                                                                        | *string*                                                                                            | :heavy_check_mark:                                                                                  | A Prove-generated unique ID for a specific identity.                                                |                                                                                                     |
| `V3ActivateIdentityRequest`                                                                         | [Models.Components.V3ActivateIdentityRequest](../../Models/Components/V3ActivateIdentityRequest.md) | :heavy_minus_sign:                                                                                  | N/A                                                                                                 | {<br/>"clientRequestId": "71010d88-d0e7-4a24-9297-d1be6fefde81"<br/>}                               |

### Response

**[Models.Requests.V3ActivateIdentityResponse](../../Models/Requests/V3ActivateIdentityResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DeactivateIdentity

Stops webhook notifications without disenrolling the identity.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DeactivateIdentity" method="post" path="/v3/identity/{identityId}/deactivate" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3DeactivateIdentityAsync(
    identityId: "<id>",
    v3IdentityDeactivateRequest: new V3IdentityDeactivateRequest() {
        ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    }
);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `IdentityId`                                                                          | *string*                                                                              | :heavy_check_mark:                                                                    | A Prove-generated unique ID for a specific identity.                                  |                                                                                       |
| `V3IdentityDeactivateRequest`                                                         | [V3IdentityDeactivateRequest](../../Models/Components/V3IdentityDeactivateRequest.md) | :heavy_minus_sign:                                                                    | N/A                                                                                   | {<br/>"clientRequestId": "71010d88-d0e7-4a24-9297-d1be6fefde81"<br/>}                 |

### Response

**[Models.Requests.V3DeactivateIdentityResponse](../../Models/Requests/V3DeactivateIdentityResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3GetIdentitiesByPhoneNumber

Return list of all identities you have enrolled that are associated with this phone number.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3GetIdentitiesByPhoneNumber" method="get" path="/v3/identity/{mobileNumber}/lookup" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Identity.V3GetIdentitiesByPhoneNumberAsync(mobileNumber: "<value>");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                    | Type                                                                                                                                                                                                                                                                                         | Required                                                                                                                                                                                                                                                                                     | Description                                                                                                                                                                                                                                                                                  |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `MobileNumber`                                                                                                                                                                                                                                                                               | *string*                                                                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                                                                                                           | The phone number to find identities for. US phone numbers can be passed in with or without a leading +1. Acceptable characters are: alphanumeric with symbols '+'.                                                                                                                           |
| `ClientRequestId`                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                     | :heavy_minus_sign:                                                                                                                                                                                                                                                                           | A client-generated unique ID for a specific session. This can be used to identify specific requests. The format of this ID is defined by the client - Prove recommends using a GUID, but any format can be accepted. Do not include Personally Identifiable Information (PII) in this field. |

### Response

**[Models.Requests.V3GetIdentitiesByPhoneNumberResponse](../../Models/Requests/V3GetIdentitiesByPhoneNumberResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |