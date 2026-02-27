# Auth

## Overview

### Available Operations

* [AuthContinueRequest](#authcontinuerequest) - AuthContinue /v1/server/auth/continue
* [AuthFinishRequest](#authfinishrequest) - AuthFinish /v1/server/auth/finish
* [AuthStartRequest](#authstartrequest) - AuthStart /v1/server/auth/start

## AuthContinueRequest

If the initial Prove Auth authenticators fail, the Force Bind authenticator can be used which permits using another
authentication method to verify a mobile number (like Prove Instant Link™). Once the mobile number is verified, send
this AuthContinue request.

Production URL: https://oapi.prove-auth.proveapis.com/v1/server/auth/continue

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AuthContinueRequest" method="post" path="/v1/server/auth/continue" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

AuthContinueRequest req = new AuthContinueRequest() {
    AuthId = "713189b8-5555-4b08-83ba-75d08780aebd",
    RequestId = "eba12f3a-5555-47bc-b85d-21c0cbc4b973",
    Subjects = new AuthContinueRequestSubjects() {
        Mobile = new AuthContinueRequestSubjectMobile() {
            Claim = new AuthContinueRequestSubjectMobileClaim() {
                MobileNumber = "12065550100",
            },
        },
    },
};

var res = await sdk.Auth.AuthContinueRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [AuthContinueRequest](../../Models/Components/AuthContinueRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[AuthContinueRequestResponse](../../Models/Requests/AuthContinueRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## AuthFinishRequest

To complete the auth flow and get the authentication result, send this AuthFinish request.

Production URL: https://oapi.prove-auth.proveapis.com/v1/server/auth/finish

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AuthFinishRequest" method="post" path="/v1/server/auth/finish" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

AuthFinishRequest req = new AuthFinishRequest() {
    AuthId = "eba12f3a-5555-47bc-b85d-21c0cbc4b973",
};

var res = await sdk.Auth.AuthFinishRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [AuthFinishRequest](../../Models/Components/AuthFinishRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[AuthFinishRequestResponse](../../Models/Requests/AuthFinishRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |

## AuthStartRequest

To start an auth flow, send this AuthStart request to control how Prove Auth will authenticate the end users and
their devices. The expected authenticators should be included in the body parameters. There are many supported
scenarios to use Prove Auth so each of the request types are explained in the "Server Integration Guide".

Production URL: https://oapi.prove-auth.proveapis.com/v1/server/auth/start

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AuthStartRequest" method="post" path="/v1/server/auth/start" -->
```csharp
using Prove.Proveapi;
using Prove.Proveapi.Models.Components;
using System.Collections.Generic;

var sdk = new ProveAPI(auth: "<YOUR_AUTH_HERE>");

AuthStartRequest req = new AuthStartRequest() {
    CallbackUrl = "https://example.com/webhook",
    Delivery = new AuthStartRequestDelivery() {
        Push = new AuthStartRequestDeliveryPush() {
            Notification = new AuthStartRequestDeliveryPushNotification() {
                Body = "Do you want to allow login from this device?",
                ConfirmBtn = "Confirm",
                DenyBtn = "Deny",
                OriginatingDevice = "iPhone12",
                OriginatingIp = "198.51.100.10",
                Title = "Confirm Login",
            },
        },
        Scan = new AuthStartRequestDeliveryScan() {
            Notification = new AuthStartRequestDeliveryScanNotification() {
                Body = "Please confirm you are trying to sign in...",
                ConfirmBtn = "Confirm",
                DenyBtn = "Deny",
                OriginatingDevice = "Google Chrome on Windows",
                OriginatingIp = "198.51.100.10",
                Title = "Confirm Sign In",
            },
        },
    },
    RequestId = "eba12f3a-5555-47bc-b85d-21c0cbc4b973",
    Subjects = new AuthStartRequestSubjects() {
        Card = new AuthStartRequestSubjectCard() {
            Authenticators = new AuthStartRequestSubjectCardAuthenticators() {
                AirKey = new AuthStartRequestSubjectCardAuthenticatorAirKey() {
                    Claim = new AuthStartRequestSubjectCardAuthenticatorAirKeyClaim() {
                        Puids = new List<string>() {
                            "puids",
                            "puids",
                        },
                    },
                    TestMode = "testMode",
                },
            },
        },
        Device = new AuthStartRequestSubjectDevice() {
            Authenticators = new AuthStartRequestSubjectDeviceAuthenticators() {
                Passive = new AuthStartRequestSubjectDeviceAuthenticatorPassive() {
                    AllowPasscodeFallback = true,
                    UserVerificationLevel = "userVerificationLevel",
                },
            },
            Claim = new AuthStartRequestSubjectDeviceClaim() {
                DeviceId = "deviceId",
            },
        },
        Mobile = new AuthStartRequestSubjectMobile() {
            Authenticators = new AuthStartRequestSubjectMobileAuthenticators() {
                Instant = new AuthStartRequestSubjectMobileAuthenticatorInstant() {
                    Consent = new AuthStartRequestInstantAuthConsent() {
                        CollectedTimestamp = "2022-02-17T00:00:00Z",
                        Description = "Customer Application Name",
                        Status = "optedIn",
                        TransactionId = "eba12f3a-5555-47bc-b85d-21c0cbc4b973",
                    },
                    TestMode = "testMode",
                },
                Instantlink = new AuthStartRequestSubjectMobileAuthenticatorInstantLink() {
                    AllowMobileNumberRePrompt = true,
                    FinalTargetUrl = "https://example.com/finishpage",
                    MessageText = "Please click the link to authenticate your mobile number: ####",
                    SourceIp = "123...",
                    SubscriptionCustomerId = "123",
                    TestMode = "testMode",
                },
                Otp = new AuthStartRequestSubjectMobileAuthenticatorOTP() {
                    AllowMobileNumberRePrompt = true,
                    AllowOtpRetry = true,
                    MessageText = "Your pin is: ####",
                    TestMode = "testMode",
                },
                Passive = new AuthStartRequestSubjectMobileAuthenticatorPassive() {
                    CacheResult = true,
                    LocalDomain = true,
                    MaxAge = 7776000,
                    TestMode = "testMode",
                },
                Universal = new AuthStartRequestSubjectMobileAuthenticatorUniversal() {
                    FinalTargetUrl = "https://example.com/finishpage",
                    TestMode = "testMode",
                },
            },
            Claim = new AuthStartRequestSubjectMobileClaim() {
                MobileNumber = "12065550100",
            },
        },
        User = new AuthStartRequestSubjectUser() {
            Authenticators = new AuthStartRequestSubjectUserAuthenticators() {
                Docv = new Docv() {},
                Passive = new AuthStartRequestSubjectUserAuthenticatorPassive() {
                    UserVerificationLevel = "userVerificationLevel",
                },
                Ppb = new Ppb() {},
                Present = new Present() {},
            },
            Claim = new AuthStartRequestSubjectUserClaim() {
                Provided = true,
                UserId = "eba12f3a-5555-47bc-b85d-21c0cbc4b973",
            },
        },
    },
};

var res = await sdk.Auth.AuthStartRequestAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [AuthStartRequest](../../Models/Components/AuthStartRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[AuthStartRequestResponse](../../Models/Requests/AuthStartRequestResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Prove.Proveapi.Models.Errors.Error400     | 400                                       | application/json                          |
| Prove.Proveapi.Models.Errors.Error        | 500                                       | application/json                          |
| Prove.Proveapi.Models.Errors.APIException | 4XX, 5XX                                  | \*/\*                                     |