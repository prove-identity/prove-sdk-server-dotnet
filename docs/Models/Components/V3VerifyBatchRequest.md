# V3VerifyBatchRequest


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `ClientRequestId`                                                               | *string*                                                                        | :heavy_minus_sign:                                                              | N/A                                                                             |
| `Items`                                                                         | List<[VerifyItem](../../Models/Components/VerifyItem.md)>                       | :heavy_check_mark:                                                              | Batch of verify requests to process. The array length cannot exceed 1000 items. |