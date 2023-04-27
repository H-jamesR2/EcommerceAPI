# EcommerceAPI
Inspired by the shopify API as the ‘standard’ for API documentation.

-- CSCI 39537 (Intro to APIs) Final Project

## About
Three Tables:

Discounts ( DiscountId,
	DiscountName, DiscountDesc, DiscountPercent
)

Products ( ProductId,
	ProductName, ProductDesc, ProductPrice, DiscountId
)

Reviews( ReviewId,
	ReviewTitle, ReviewDesc, ReviewRating, ProductId
)

## How to Call API Endpoints
### 1. Discount API Endpoints:
#### GET: https://localhost:7002/api/Discount/
#### Sample Response Body:
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! DiscountS request was completed.",
    "discounts": [
        {
            "discountId": 1,
            "discountName": "appleDiscount",
            "discountDesc": "No Discount Description Available",
            "discountPercent": 0.25
        },
        {
            "discountId": 2,
            "discountName": "dellDiscount",
            "discountDesc": "High Bargain BlackFriday Sale!",
            "discountPercent": 0.4
        }
    ],
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### GET: https://localhost:7002/api/Discount/1
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! Discount request was completed.",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": {
        "discountId": 1,
        "discountName": "appleDiscount",
        "discountDesc": "No Discount Description Available",
        "discountPercent": 0.25
    },
    "product": null,
    "review": null
}

if failed:
{

    "statusCode": 404,
    "statusDescription": "Error! No DiscountS found matching given ID",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### POST: https://localhost:7002/api/Discount/
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! New Discount request completed.",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": {
        "discountId": 5,
        "discountName": "test99",
        "discountDesc": "testingDescription for discount",
        "discountPercent": 0.5
    },
    "product": null,
    "review": null
}
if fail:
{

    "statusCode": 400,
    "statusDescription": "Error! Incorrect Discount input",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### DELETE: https://localhost:7002/api/Discount/4
if success:
{

    "statusCode": 204,
    "statusDescription": "Content Successfully REMOVED at ID:4 with no response Body",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

if fail:
{

    "statusCode": 404,
    "statusDescription": "Error! No DiscountS found matching given ID",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

### 2. Product API Endpoints:

#### GET: https://localhost:7002/api/Product
#### Sample Response Body:
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! ProductS request was completed.",
    "discounts": null,
    "products": [
        {
            "productId": 1,
            "productName": "AppleComputer",
            "productDesc": "Computer from Apple Company",
            "productPrice": 800.25,
            "discount": null
        },
        {
            "productId": 2,
            "productName": "DellComputer",
            "productDesc": "Computer from Dell Company",
            "productPrice": 250.35,
            "discount": null
        }
    ],
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}
if failed (No ProductS):
{

    "statusCode": 200,
    "statusDescription": "Error! No ProductS found..",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
} 
if failed (No ProductS at givenID):
{

    "statusCode": 200,
    "statusDescription": "Error! No ProductS found matching given ID",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### GET: https://localhost:7002/api/Product/1
#### Sample Request Body:
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! Product request was completed.",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": {
        "productId": 1,
        "productName": "AppleComputer",
        "productDesc": "Computer from Apple Company",
        "productPrice": 800.25,
        "discount": null
    },
    "review": null
}
if failed:
{

    "statusCode": 404,
    "statusDescription": "Error! No ProductS found matching given ID",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### POST: https://localhost:7002/api/Product/
## Sample Input:
{

    "productId": 5,
    "productName": "AppleComputer",
    "productDesc": "Computer from TANGERINE Company",
    "productPrice": 800.25,
    "discount": null
}
#### Sample Request Body:
if successs
{

    "statusCode": 200,
    "statusDescription": "Success! New Product request completed.",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": {
        "productId": 5,
        "productName": "AppleComputer",
        "productDesc": "Computer from TANGERINE Company",
        "productPrice": 800.25,
        "discount": null
    },
    "review": null
}
if failed:
{

    "statusCode": 400,
    "statusDescription": "Error! Incorrect Product input",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### PUT: https://localhost:7002/api/Product/1
## Sample Input:
{

    "productId": 1,
    "productName": "AppleComputer",
    "productDesc": "Computer from MANGO Company",
    "productPrice": 800.25,
    "discount": null
}
#### Sample Request Body:
if success:
{

    "statusCode": 204,
    "statusDescription": "Content Successfully UPDATED at ID:1 with no response Body",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

#### DELETE: https://localhost:7002/api/Product/4
#### Sample Request Body:
if success:
{

    "statusCode": 204,
    "statusDescription": "Content Successfully REMOVED at ID:4 with no response Body",
    "discounts": null,
    "products": null,
    "reviews": null,
    "discount": null,
    "product": null,
    "review": null
}

....
### Review API Endpoints:
#### GET https://localhost:7002/api/Review/
if success:
{

    "statusCode": 200,
    "statusDescription": "Success! ReviewS request was completed.",
    "discounts": null,
    "products": null,
    "reviews": [
        {
            "reviewId": 1,
            "reviewTitle": "Apple Mac Review",
            "reviewDesc": "This Mac Computer has broken HDMI port; 3 Star and Need a refund!",
            "reviewRating": 3,
            "product": null
        },
        {
            "reviewId": 2,
            "reviewTitle": "Apple Mac Review",
            "reviewDesc": "This Mac Computer is pretty good for running Photoshop.",
            "reviewRating": 5,
            "product": null
        },
        {
            "reviewId": 3,
            "reviewTitle": "Dell Laptop Review",
            "reviewDesc": "This Computer is garbage and is overheating when I play Crisis >:(",
            "reviewRating": 1,
            "product": null
        }
    ],
    "discount": null,
    "product": null,
    "review": null
}

#### GET https://localhost:7002/api/Review/1
---> Param = /productID
...
#### PUT https://localhost:7002/api/Review/1
---> Param = /reviewID
#### POST https://localhost:7002/api/Review/

#### DELETE: https://localhost:7002/api/Review/1
---> Param = /reviewID
