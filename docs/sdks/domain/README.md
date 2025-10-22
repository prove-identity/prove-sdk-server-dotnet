# Domain
(*Domain*)

## Overview

### Available Operations

* [V3DomainConfirmLinkRequest](#v3domainconfirmlinkrequest) - Confirm a domain link request
* [V3DomainIDRequest](#v3domainidrequest) - Get Domain Details
* [V3DomainLinkRequest](#v3domainlinkrequest) - Request a domain link
* [V3DomainLinkedRequest](#v3domainlinkedrequest) - Get the list of domains that are linked to this domain.
* [V3DomainUnlinkRequest](#v3domainunlinkrequest) - Remove a domain link or request

## V3DomainConfirmLinkRequest

Confirms a given domain link request by validating the PCID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainConfirmLinkRequest" method="post" path="/v3/domain/confirm-link" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3DomainConfirmLinkRequest req = new V3DomainConfirmLinkRequest() {
    Pcid = "pcid",
};

var res = await sdk.Domain.V3DomainConfirmLinkRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [V3DomainConfirmLinkRequest](../../Models/Components/V3DomainConfirmLinkRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[V3DomainConfirmLinkRequestResponse](../../Models/Requests/V3DomainConfirmLinkRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainIDRequest

Returns the domain details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainIDRequest" method="get" path="/v3/domain/id" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Domain.V3DomainIDRequestAsync();

// handle response
```

### Response

**[V3DomainIDRequestResponse](../../Models/Requests/V3DomainIDRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainLinkRequest

Create a request to connect the requested domain to the domain the request is made from.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainLinkRequest" method="post" path="/v3/domain/link" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3DomainLinkRequest req = new V3DomainLinkRequest() {
    Pcid = "pcid",
};

var res = await sdk.Domain.V3DomainLinkRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [V3DomainLinkRequest](../../Models/Components/V3DomainLinkRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[V3DomainLinkRequestResponse](../../Models/Requests/V3DomainLinkRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainLinkedRequest

Returns the accepted and pending links for this domain.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainLinkedRequest" method="get" path="/v3/domain/linked" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

var res = await sdk.Domain.V3DomainLinkedRequestAsync();

// handle response
```

### Response

**[V3DomainLinkedRequestResponse](../../Models/Requests/V3DomainLinkedRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3DomainUnlinkRequest

Remove a domain link or request between the requested domain and the domain the request is made from.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3DomainUnlinkRequest" method="post" path="/v3/domain/unlink" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3DomainUnlinkRequest req = new V3DomainUnlinkRequest() {
    PcidFrom = "pcidFrom",
    PcidTo = "pcidTo",
};

var res = await sdk.Domain.V3DomainUnlinkRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [V3DomainUnlinkRequest](../../Models/Components/V3DomainUnlinkRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[V3DomainUnlinkRequestResponse](../../Models/Requests/V3DomainUnlinkRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |