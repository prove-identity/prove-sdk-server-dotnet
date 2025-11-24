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
* [V3VerifyBatchRequest](#v3verifybatchrequest) - Batch Verify Users

## V3TokenRequest

This endpoint allows you to request an OAuth token.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3TokenRequest" method="post" path="/token" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ChallengeRequest

This endpoint allows you to submit challenge information.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3ChallengeRequest" method="post" path="/v3/challenge" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3CompleteRequest

This endpoint allows you to verify the user and complete the flow.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3CompleteRequest" method="post" path="/v3/complete" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3StartRequest

This endpoint allows you to start the solution flow.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3StartRequest" method="post" path="/v3/start" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyRequest

This endpoint allows you to initiate the possession check.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3UnifyRequest" method="post" path="/v3/unify" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3UnifyRequest req = new V3UnifyRequest() {
    AllowOTPRetry = true,
    CheckReputation = true,
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientHumanId = "7bfbb91d-9df8-4ec0-99a6-de05ecc23a9e",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    DeviceId = "bf9ea15d-7dfa-4bb4-a64c-6c26b53472fc",
    EmailAddress = "sbutrimovichb@who.int",
    FinalTargetUrl = "https://www.example.com/landing-page",
    IpAddress = "192.168.0.1",
    PhoneNumber = "2001004011",
    PossessionType = "mobile",
    ProveId = "a07b94ce-218c-461f-beda-d92480e40f61",
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyBindRequest

This endpoint allows you to bind a Prove Key to a phone number of a Unify session and get the possession result.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3UnifyBindRequest" method="post" path="/v3/unify-bind" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3UnifyStatusRequest

This endpoint allows you to check the status of a Unify session and get the possession result.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3UnifyStatusRequest" method="post" path="/v3/unify-status" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3ValidateRequest

This endpoint allows you to check if the phone number entered/discovered earlier in the flow is validated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3ValidateRequest" method="post" path="/v3/validate" -->
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
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## V3VerifyRequest

This endpoint allows you to initiate a Verified Users session.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3VerifyRequest" method="post" path="/v3/verify" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3VerifyRequest req = new V3VerifyRequest() {
    AddOnFeature = new List<string>() {
        "ageEstimation",
    },
    BusinessName = "businessName",
    ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
    ClientHumanId = "aad25769-23bb-458c-80db-50296a82c91b",
    ClientRequestId = "71010d88-d0e7-4a24-9297-d1be6fefde81",
    DateOfBirth = "dateOfBirth",
    EmailAddress = "ecoldman1h@storify.com",
    FirstName = "Elena",
    IpAddress = "192.168.1.1",
    LastName = "Coldman",
    NationalId = "nationalId",
    PhoneNumber = "2001004053",
    ProveId = "proveId",
    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0",
    VerificationType = VerificationType.VerifiedUser,
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

## V3VerifyBatchRequest

This endpoint allows you to batch verify and enroll users.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="V3VerifyBatchRequest" method="post" path="/v3/verify/batch" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3VerifyBatchRequest req = new V3VerifyBatchRequest() {
    ClientRequestId = "clientRequestId",
    Items = new List<VerifyItem>() {
        new VerifyItem() {
            ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            ClientHumanId = "clientHumanId",
            EmailAddress = "ecoldman1h@storify.com",
            FirstName = "Elena",
            IpAddress = "192.168.1.1",
            LastName = "Coldman",
            PhoneNumber = "2001004053",
            ProveId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0",
            VerificationType = "verificationType",
        },
        new VerifyItem() {
            ClientCustomerId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            ClientHumanId = "clientHumanId",
            EmailAddress = "ecoldman1h@storify.com",
            FirstName = "Elena",
            IpAddress = "192.168.1.1",
            LastName = "Coldman",
            PhoneNumber = "2001004053",
            ProveId = "e0f78bc2-f748-4eda-9d29-d756844507fc",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0",
            VerificationType = "verificationType",
        },
    },
};

var res = await sdk.V3.V3VerifyBatchRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [V3VerifyBatchRequest](../../Models/Components/V3VerifyBatchRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[V3VerifyBatchRequestResponse](../../Models/Requests/V3VerifyBatchRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error401     | 401                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error403     | 403                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |