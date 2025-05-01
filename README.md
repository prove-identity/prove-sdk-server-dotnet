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


### [V3](docs/sdks/v3/README.md)

* [V3TokenRequest](docs/sdks/v3/README.md#v3tokenrequest) - Request OAuth token.
* [V3ChallengeRequest](docs/sdks/v3/README.md#v3challengerequest) - Submit challenge.
* [V3CompleteRequest](docs/sdks/v3/README.md#v3completerequest) - Complete flow.
* [V3StartRequest](docs/sdks/v3/README.md#v3startrequest) - Start flow.
* [V3UnifyRequest](docs/sdks/v3/README.md#v3unifyrequest) - Initiate Possession Check
* [V3UnifyBindRequest](docs/sdks/v3/README.md#v3unifybindrequest) - Bind Prove Key
* [V3UnifyStatusRequest](docs/sdks/v3/README.md#v3unifystatusrequest) - Check Status of Unify Session
* [V3ValidateRequest](docs/sdks/v3/README.md#v3validaterequest) - Validate phone number.
* [V3VerifyRequest](docs/sdks/v3/README.md#v3verifyrequest) - Initiate verified users session.
* [V3VerifyStatusRequest](docs/sdks/v3/README.md#v3verifystatusrequest) - Perform checks for verified users session.

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Error Handling [errors] -->
## Error Handling

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Prove.Proveapi.Models.Errors.APIException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `V3TokenRequestAsync` method throws the following exceptions:

| Error Type                                | Status Code | Content Type     |
| ----------------------------------------- | ----------- | ---------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400         | application/json |
| Prove.Proveapi.Models.Errors.Error401     | 401         | application/json |
| Prove.Proveapi.Models.Errors.Error        | 500         | application/json |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX    | \*/\*            |

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
catch (Exception ex)
{
    if (ex is Error400)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error401)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Prove.Proveapi.Models.Errors.APIException)
    {
        // Handle default exception
        throw;
    }
}
```
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

var sdk = new ProveAPI(server: "prod-eu");

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
