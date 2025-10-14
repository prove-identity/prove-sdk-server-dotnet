# prove-sdk-server-dotnet
.NET Server SDK for Prove APIs - Customer Access

<!-- Start Summary [summary] -->
## Summary

Prove APIs: This specification describes the Prove API.

OpenAPI Spec - generated.
<!-- End Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [prove-sdk-server-dotnet](#prove-sdk-server-dotnet)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Authentication](#authentication)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Prove.Proveapi
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Prove/Proveapi/Prove.Proveapi.csproj
```
<!-- End SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

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
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name   | Type   | Scheme       |
| ------ | ------ | ------------ |
| `Auth` | oauth2 | OAuth2 token |

To authenticate with the API the `Auth` parameter must be set when initializing the SDK client instance. For example:
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

V3TokenRequest req = new V3TokenRequest() {
    ClientId = "customer_id",
    ClientSecret = "secret",
    GrantType = "client_credentials",
};

var res = await sdk.V3.V3TokenRequestAsync(req);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Domain](docs/sdks/domain/README.md)

* [V3DomainConfirmLinkRequest](docs/sdks/domain/README.md#v3domainconfirmlinkrequest) - Confirm a domain link request
* [V3DomainIDRequest](docs/sdks/domain/README.md#v3domainidrequest) - Get Domain Details
* [V3DomainLinkRequest](docs/sdks/domain/README.md#v3domainlinkrequest) - Request a domain link
* [V3DomainLinkedRequest](docs/sdks/domain/README.md#v3domainlinkedrequest) - Get the list of domains that are linked to this domain.
* [V3DomainUnlinkRequest](docs/sdks/domain/README.md#v3domainunlinkrequest) - Remove a domain link or request

### [Identity](docs/sdks/identity/README.md)

* [V3BatchGetIdentities](docs/sdks/identity/README.md#v3batchgetidentities) - Batch Get Identities
* [V3EnrollIdentity](docs/sdks/identity/README.md#v3enrollidentity) - Enroll Identity
* [V3BatchEnrollIdentities](docs/sdks/identity/README.md#v3batchenrollidentities) - Batch Enroll Identities
* [V3DisenrollIdentity](docs/sdks/identity/README.md#v3disenrollidentity) - Disenroll Identity
* [V3GetIdentity](docs/sdks/identity/README.md#v3getidentity) - Get Identity
* [V3ActivateIdentity](docs/sdks/identity/README.md#v3activateidentity) - Activate Identity
* [V3CrossDomainIdentity](docs/sdks/identity/README.md#v3crossdomainidentity) - Cross Domain Identity
* [V3DeactivateIdentity](docs/sdks/identity/README.md#v3deactivateidentity) - Deactivate Identity
* [V3GetIdentitiesByPhoneNumber](docs/sdks/identity/README.md#v3getidentitiesbyphonenumber) - Get Identities By Phone Number

### [V3](docs/sdks/v3/README.md)

* [V3TokenRequest](docs/sdks/v3/README.md#v3tokenrequest) - Request OAuth Token
* [V3ChallengeRequest](docs/sdks/v3/README.md#v3challengerequest) - Submit Challenge
* [V3CompleteRequest](docs/sdks/v3/README.md#v3completerequest) - Complete Flow
* [V3StartRequest](docs/sdks/v3/README.md#v3startrequest) - Start Flow
* [V3UnifyRequest](docs/sdks/v3/README.md#v3unifyrequest) - Initiate Possession Check
* [V3UnifyBindRequest](docs/sdks/v3/README.md#v3unifybindrequest) - Bind Prove Key
* [V3UnifyStatusRequest](docs/sdks/v3/README.md#v3unifystatusrequest) - Check Status
* [V3ValidateRequest](docs/sdks/v3/README.md#v3validaterequest) - Validate Phone Number
* [V3VerifyRequest](docs/sdks/v3/README.md#v3verifyrequest) - Initiate Verified Users Session
* [V3VerifyBatchRequest](docs/sdks/v3/README.md#v3verifybatchrequest) - Batch Verify Users

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`ProveAPIError`](./src/Prove/Proveapi/Models/Errors/ProveAPIError.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `Request`     | *HttpRequestMessage*  | HTTP request object   |
| `Response`    | *HttpResponseMessage* | HTTP response object  |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using Prove.Proveapi.Models.Errors;

var sdk = new ProveAPI();

try
{
    V3TokenRequest req = new V3TokenRequest() {
        ClientId = "customer_id",
        ClientSecret = "secret",
        GrantType = "client_credentials",
    };

    var res = await sdk.V3.V3TokenRequestAsync(req);

    // handle response
}
catch (ProveAPIError ex)  // all SDK exceptions inherit from ProveAPIError
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpRequestMessage request = ex.Request;
    HttpResponseMessage response = ex.Response;
    var statusCode = (int)response.StatusCode;
    var responseBody = ex.Body;

    if (ex is Error) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        ErrorPayload payload = ex.Payload;
        long Code = payload.Code;
        string Message = payload.Message;
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exceptions:**
* [`ProveAPIError`](./src/Prove/Proveapi/Models/Errors/ProveAPIError.cs): The base class for HTTP error responses.
  * [`Error`](./src/Prove/Proveapi/Models/Errors/Error.cs): Bad Request. The server cannot process the request due to a client error.
  * [`Error401`](./src/Prove/Proveapi/Models/Errors/Error401.cs): Unauthorized. Authentication is required and has failed or has not been provided. Status code `401`.
  * [`Error403`](./src/Prove/Proveapi/Models/Errors/Error403.cs): Forbidden. The server understood the request but refuses to authorize it. Status code `403`. *

<details><summary>Less common exceptions (2)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`ProveAPIError`](./src/Prove/Proveapi/Models/Errors/ProveAPIError.cs):
  * [`ResponseValidationError`](./src/Prove/Proveapi/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Name

You can override the default server globally by passing a server name to the `server: string` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the names associated with the available servers:

| Name      | Server                                  | Description        |
| --------- | --------------------------------------- | ------------------ |
| `uat-us`  | `https://platform.uat.proveapis.com`    | UAT for US Region  |
| `prod-us` | `https://platform.proveapis.com`        | Prod for US Region |
| `uat-eu`  | `https://platform.uat.eu.proveapis.com` | UAT for EU Region  |
| `prod-eu` | `https://platform.eu.proveapis.com`     | Prod for EU Region |

#### Example

```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(server: SDKConfig.Server.ProdEu);

V3TokenRequest req = new V3TokenRequest() {
    ClientId = "customer_id",
    ClientSecret = "secret",
    GrantType = "client_credentials",
};

var res = await sdk.V3.V3TokenRequestAsync(req);

// handle response
```

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(serverUrl: "https://platform.uat.proveapis.com");

V3TokenRequest req = new V3TokenRequest() {
    ClientId = "customer_id",
    ClientSecret = "secret",
    GrantType = "client_credentials",
};

var res = await sdk.V3.V3TokenRequestAsync(req);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->
