# V3
(*V3*)

## Overview

### Available Operations

* [V3TokenRequest](#v3tokenrequest) - Request OAuth token.
* [V3ChallengeRequest](#v3challengerequest) - Submit challenge.
* [V3CompleteRequest](#v3completerequest) - Complete flow.
* [V3StartRequest](#v3startrequest) - Start flow.
* [V3UnifyRequest](#v3unifyrequest) - Initiate Possession Check
* [V3UnifyBindRequest](#v3unifybindrequest) - Bind Prove Key
* [V3UnifyStatusRequest](#v3unifystatusrequest) - Check Status of Unify Session
* [V3ValidateRequest](#v3validaterequest) - Validate phone number.
* [V3VerifyRequest](#v3verifyrequest) - Initiate verified users session.
* [V3VerifyStatusRequest](#v3verifystatusrequest) - Perform checks for verified users session.

## V3TokenRequest

Send this request to request the OAuth token.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi();

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ChallengeRequest

Send this request to submit challenge information. Either a DOB or last 4 of SSN needs to be submitted if neither was submitted to the /start endpoint (challenge fields submitted to this endpoint will overwrite the /start endpoint fields submitted). It will return a correlation ID, user information, and the next step to call in the flow. This capability is only available in Pre-Fill®, it's not available in Prove Identity®. You'll notice that when using Prove Identity®, if /validate is successful, it will then return `v3-complete` as one of the keys in the `Next` field map instead of `v3-challenge`.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3CompleteRequest

Send this request to verify the user and complete the flow. It will return a correlation ID, user information, and the next step to call in the flow. There is a validation check that requires at least first + last name or SSN passed in, else an HTTP 400 is returned. Additionally, specific to the Pre-Fill® or Prove Identity® with KYC use case, you need to pass in first name, last name, DOB and SSN (or address) to ensure you receive back the KYC elements and correct CIP values.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
            new V3CompleteAddressEntryRequest() {
                Address = "4861 Jay Junction",
                City = "Boston",
                ExtendedAddress = "Apt 78",
                PostalCode = "02208",
                Region = "MS",
            },
        },
        Dob = "1981-01",
        EmailAddresses = new List<string>() {
            "jdoe@example.com",
            "dsmith@example.com",
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3StartRequest

Send this request to start a Prove flow. It will return a correlation ID and an authToken for the client SDK.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

V3StartRequest req = new V3StartRequest() {
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
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

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

V3UnifyRequest req = new V3UnifyRequest() {
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    FinalTargetUrl = "https://www.example.com/landing-page",
    PhoneNumber = "2001004011",
    PossessionType = "mobile",
    SmsMessage = "#### is your verification code",
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
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

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
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

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ValidateRequest

Send this request to check the phone number entered/discovered earlier in the flow is validated. It will return a correlation ID and the next step.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3VerifyRequest

Send this request to initiate a Verified Users session. It will return a correlation ID, authToken for the client SDK, and the results of the possession and verify checks (usually pending from this API).

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

V3VerifyRequest req = new V3VerifyRequest() {
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3VerifyStatusRequest

Send this request to perform the necessary checks for a Verified Users session. It will return the results of the possession and verify checks, as well as the overall success.

### Example Usage

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new Proveapi(auth: "<YOUR_AUTH_HERE>");

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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |