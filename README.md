# MicroServices_PracticeProject
This is practice project
Simple store billing system backend code

#Service 1. Search 
It will search tax Invoice of the store, which calls other three api to retrive information:
```yaml
{
    "taxInvoice": {
        "cityName": "US",
        "branchName": "street1"
    },
    "details": [
        {
            "srNo": 1,
            "manufacturingCountry": "USD",
            "invoiceDate": "2022-07-02T14:25:15.7306029+05:30",
            "items": [
                {
                    "id": 1,
                    "qrCodeNum": 1,
                    "description": "MS PRoduct 1",
                    "qty": 10,
                    "value": 5
                },
                {
                    "id": 2,
                    "qrCodeNum": 2,
                    "description": "Car doors",
                    "qty": 3,
                    "value": 5
                },
                {
                    "id": 3,
                    "qrCodeNum": 2,
                    "description": "Car doors",
                    "qty": 8,
                    "value": 50
                }
            ]
        }
    ]
}
```
#Service 2. Tax Invoice
It fecthes the information based on Details of Invoice No and date with Product information
```yaml
{
    "invoiceNo": 2,
    "cityName": "US",
    "branchName": "street2"
}
```


#Service 3. Details
It calls Product API to fetch product values, additionally associates products details based on below parameters
```yaml
[
    {
        "srNo": 3,
        "invoiceNo": 3,
        "manufacturingCountry": "EUR",
        "invoiceDate": "2022-07-02T14:25:15.7834959+05:30",
        "items": [
            {
                "id": 7,
                "qrCodeNum": 1,
                "qty": 10,
                "value": 5
            },
            {
                "id": 8,
                "qrCodeNum": 3,
                "qty": 5,
                "value": 5
            },
            {
                "id": 9,
                "qrCodeNum": 2,
                "qty": 8,
                "value": 50
            }
        ]
    }
]
```

#Service 4. Product 
It has parameters as below:
```yaml
{
    "qrCodeNum": 3,
    "description": "fruit",
    "categoryNum": "33333333",
    "productValue": 500
}
```


Product API has unit tests project.
Postman collection is also included.
