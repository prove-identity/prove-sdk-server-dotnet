# Domain
(*Domain*)

## Overview

### Available Operations

* [V3DomainID](#v3domainid) - Get Domain Details
* [V3DomainConfirmLink](#v3domainconfirmlink) - # Confirm a given domain link request.
* [V3DomainLinked](#v3domainlinked) - Get the list of domains that are linked to this domain.
* [V3DomainUnlink](#v3domainunlink) - # Remove a domain link or request.

## V3DomainID

Returns the domain details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainID" method="post" path="/v3/domain/id" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

string? req = null;

var res = await sdk.Domain.V3DomainIDAsync(req);

// handle response
```

### Parameters

| Parameter                                  | Type                                       | Required                                   | Description                                |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| `request`                                  | *string*                                   | :heavy_check_mark:                         | The request object to use for the request. |

### Response

**[Models.Requests.V3DomainIDResponse](../../Models/Requests/V3DomainIDResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainConfirmLink

# Confirm a given domain link request.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainConfirmLink" method="post" path="/v3/domain/link" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3DomainConfirmLinkRequest req = new V3DomainConfirmLinkRequest() {
    Pcid = "pcid",
};

var res = await sdk.Domain.V3DomainConfirmLinkAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [V3DomainConfirmLinkRequest](../../Models/Components/V3DomainConfirmLinkRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[Models.Requests.V3DomainConfirmLinkResponse](../../Models/Requests/V3DomainConfirmLinkResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainLinked

Returns the accepted and pending links for this domain.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainLinked" method="get" path="/v3/domain/linked" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Domain.V3DomainLinkedAsync();

// handle response
```

### Response

**[Models.Requests.V3DomainLinkedResponse](../../Models/Requests/V3DomainLinkedResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainUnlink

# Remove a domain link or request.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainUnlink" method="post" path="/v3/domain/unlink" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3DomainUnlinkRequest req = new V3DomainUnlinkRequest() {
    PcidFrom = "pcidFrom",
    PcidTo = "pcidTo",
};

var res = await sdk.Domain.V3DomainUnlinkAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [V3DomainUnlinkRequest](../../Models/Components/V3DomainUnlinkRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[Models.Requests.V3DomainUnlinkResponse](../../Models/Requests/V3DomainUnlinkResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |