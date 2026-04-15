# VerificationType

The verification method based on the use case and authorization level. Current allowed values: "verifiedUser", "accountOpening", "humanAssurance", "prefill", "prefillForBiz", "identityResolution".

## Example Usage

```csharp
using Prove.Proveapi.Models.Components;

var value = VerificationType.HumanAssurance;
```


## Values

| Name                 | Value                |
| -------------------- | -------------------- |
| `HumanAssurance`     | humanAssurance       |
| `VerifiedUser`       | verifiedUser         |
| `AccountOpening`     | accountOpening       |
| `Prefill`            | prefill              |
| `PrefillForBiz`      | prefillForBiz        |
| `IdentityResolution` | identityResolution   |