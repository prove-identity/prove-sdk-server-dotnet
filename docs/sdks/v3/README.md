# V3
(*V3*)

## Overview

### Available Operations

* [V3TokenRequest](#v3tokenrequest) - Request OAuth Token
* [V3ChallengeRequest](#v3challengerequest) - Submit Challenge
* [V3CompleteRequest](#v3completerequest) - Complete Flow
* [V3StartRequest](#v3startrequest) - Start Flow
* [V3UnifyRequest](#v3unifyrequest) - Initiate Possession Check
* [V3UnifyBindRequest](#v3unifybindrequest) - Bind Prove Key
* [V3UnifyStatusRequest](#v3unifystatusrequest) - Check Status
* [V3ValidateRequest](#v3validaterequest) - Validate Phone Number
* [V3VerifyRequest](#v3verifyrequest) - Initiate Verified Users Session
* [V3VerifyStatusRequest](#v3verifystatusrequest) - Perform Checks for Verified Users Session

## V3TokenRequest

This endpoint allows you to request an OAuth token.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI();

V3TokenRequest req = new V3TokenRequest() {
    ClientId = "customer_id",
    ClientSecret = "secret",
    GrantType = "client_credentials",
};

var res = await sdk.V3.V3TokenRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [V3TokenRequest](../../Models/Components/V3TokenRequest.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[V3TokenRequestResponse](../../Models/Requests/V3TokenRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ChallengeRequest

This endpoint allows you to submit challenge information.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3ChallengeRequest req = new V3ChallengeRequest() {
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
    Dob = "1981-01",
    Ssn = "0596",
};

var res = await sdk.V3.V3ChallengeRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [V3ChallengeRequest](../../Models/Components/V3ChallengeRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[V3ChallengeRequestResponse](../../Models/Requests/V3ChallengeRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3CompleteRequest

This endpoint allows you to verify the user and complete the flow.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3CompleteRequest req = new V3CompleteRequest() {
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
    Individual = new V3CompleteIndividualRequest() {
        Addresses = new List<V3CompleteAddressEntryRequest>() {
            new V3CompleteAddressEntryRequest() {
                Address = "39 South Trail",
                City = "San Antonio",
                ExtendedAddress = "Apt 23",
                PostalCode = "78285",
                Region = "TX",
            },
        },
        Dob = "1981-01",
        EmailAddresses = new List<string>() {
            "jdoe@example.com",
        },
        FirstName = "Tod",
        LastName = "Weedall",
        Ssn = "265228370",
    },
};

var res = await sdk.V3.V3CompleteRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [V3CompleteRequest](../../Models/Components/V3CompleteRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[V3CompleteRequestResponse](../../Models/Requests/V3CompleteRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3StartRequest

This endpoint allows you to start the solution flow.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3StartRequest req = new V3StartRequest() {
    AllowOTPRetry = true,
    Dob = "1981-01",
    EmailAddress = "mpinsonm@dyndns.org",
    FinalTargetUrl = "https://www.example.com/landing-page",
    FlowType = "mobile",
    IpAddress = "10.0.0.1",
    PhoneNumber = "2001001695",
    SmsMessage = "#### is your temporary code to continue your application. Caution: for your security, don't share this code with anyone.",
    Ssn = "0596",
};

var res = await sdk.V3.V3StartRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [V3StartRequest](../../Models/Components/V3StartRequest.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[V3StartRequestResponse](../../Models/Requests/V3StartRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyRequest

This endpoint allows you to initiate the possession check.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3UnifyRequest req = new V3UnifyRequest() {
    AllowOTPRetry = true,
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    FinalTargetUrl = "https://www.example.com/landing-page",
    PhoneNumber = "2001004011",
    PossessionType = "mobile",
    Rebind = true,
    SmsMessage = "#### is your verification code.",
};

var res = await sdk.V3.V3UnifyRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [V3UnifyRequest](../../Models/Components/V3UnifyRequest.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[V3UnifyRequestResponse](../../Models/Requests/V3UnifyRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyBindRequest

This endpoint allows you to bind a Prove Key to a phone number of a Unify session and get the possession result.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3UnifyBindRequest req = new V3UnifyBindRequest() {
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
    PhoneNumber = "2001004011",
};

var res = await sdk.V3.V3UnifyBindRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [V3UnifyBindRequest](../../Models/Components/V3UnifyBindRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[V3UnifyBindRequestResponse](../../Models/Requests/V3UnifyBindRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyStatusRequest

This endpoint allows you to check the status of a Unify session and get the possession result.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3UnifyStatusRequest req = new V3UnifyStatusRequest() {
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
    PhoneNumber = "2001004011",
};

var res = await sdk.V3.V3UnifyStatusRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [V3UnifyStatusRequest](../../Models/Components/V3UnifyStatusRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[V3UnifyStatusRequestResponse](../../Models/Requests/V3UnifyStatusRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ValidateRequest

This endpoint allows you to check if the phone number entered/discovered earlier in the flow is validated.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3ValidateRequest req = new V3ValidateRequest() {
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
};

var res = await sdk.V3.V3ValidateRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [V3ValidateRequest](../../Models/Components/V3ValidateRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[V3ValidateRequestResponse](../../Models/Requests/V3ValidateRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3VerifyRequest

This endpoint allows you to initiate a Verified Users session.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3VerifyRequest req = new V3VerifyRequest() {
    AllowOTPRetry = true,
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    EmailAddress = "sbutrimovichb@who.int",
    FinalTargetUrl = "https://www.example.com/landing-page",
    FirstName = "Sheilakathryn",
    LastName = "Butrimovich",
    PhoneNumber = "2001004011",
    PossessionType = "mobile",
    SmsMessage = "#### is your temporary code to continue your application. Caution: for your security, don't share this code with anyone.",
};

var res = await sdk.V3.V3VerifyRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                     | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `request`                                                     | [V3VerifyRequest](../../Models/Components/V3VerifyRequest.md) | :heavy_check_mark:                                            | The request object to use for the request.                    |

### Response

**[V3VerifyRequestResponse](../../Models/Requests/V3VerifyRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3VerifyStatusRequest

This endpoint allows you to perform the necessary checks for a Verified Users session.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3VerifyStatusRequest req = new V3VerifyStatusRequest() {
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    CorrelationId = "713189b8-5555-4b08-83ba-75d08780aebd",
};

var res = await sdk.V3.V3VerifyStatusRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [V3VerifyStatusRequest](../../Models/Components/V3VerifyStatusRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[V3VerifyStatusRequestResponse](../../Models/Requests/V3VerifyStatusRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error        | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |