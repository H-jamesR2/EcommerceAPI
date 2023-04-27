DROP DATABASE IF EXISTS EcommerceDatabase;
CREATE DATABASE EcommerceDatabase;
USE EcommerceDatabase;

DROP TABLE IF EXISTS Discounts;
CREATE TABLE Discounts(
	DiscountId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY ( DiscountId ),
    DiscountName VARCHAR(100) NOT NULL,
    DiscountDesc VARCHAR(15000) 
		DEFAULT 'No Discount Description Available',
    DiscountPercent DECIMAL(5, 2) NOT NULL
);

/*
If no productDiscountId, else Update Product DiscountID reference;
*/
DROP TABLE IF EXISTS Products;
CREATE TABLE Products(
	ProductId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY ( ProductId ),
	ProductName VARCHAR(100) NOT NULL,
    ProductDesc TEXT NOT NULL,
    ProductPrice DECIMAL(9, 2) NOT NULL,
    DiscountId INT DEFAULT '0',
    CONSTRAINT FK_ProdDiscount
		FOREIGN KEY (DiscountId)
        REFERENCES Discounts( DiscountId )
        ON DELETE SET NULL
        ON UPDATE SET NULL
);

DROP TABLE IF EXISTS Reviews;
CREATE TABLE Reviews(
	ReviewId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY ( ReviewId ),
    ReviewTitle VARCHAR(100) NOT NULL,
    ReviewDesc TEXT NOT NULL,
    ReviewRating INT DEFAULT '3',
    ProductId INT,
    CONSTRAINT FK_reviewedProduct
		FOREIGN KEY ( ProductId )
        REFERENCES Products ( ProductId )
);

INSERT INTO Discounts (
	DiscountName, DiscountPercent
) VALUES ("appleDiscount", 0.25);

INSERT INTO Discounts (
	DiscountName, DiscountDesc, DiscountPercent
) VALUES ("dellDiscount", "High Bargain BlackFriday Sale!",0.40);

INSERT INTO Products (
	ProductName, ProductDesc, ProductPrice, DiscountId
) VALUES ("AppleComputer", 
	"Computer from Apple Company",
	800.25,
    1);

INSERT INTO Products (
	ProductName, ProductDesc, ProductPrice, DiscountId
) VALUES ("DellComputer", 
	"Computer from Dell Company",
	250.35,
    2);
    
INSERT INTO Reviews(
	ReviewTitle, ReviewDesc, ReviewRating, ProductId
) VALUES ("Apple Mac Review",
	"This Mac Computer has broken HDMI port; 3 Star and Need a refund!",
    3,
	1);
    
INSERT INTO Reviews(
	ReviewTitle, ReviewDesc, ReviewRating, ProductId
) VALUES ("Apple Mac Review",
	"This Mac Computer is pretty good for running Photoshop.",
    5,
	1);
    
INSERT INTO Reviews(
	ReviewTitle, ReviewDesc, ReviewRating, ProductId
) VALUES ("Dell Laptop Review",
	"This Computer is garbage and is overheating when I play Crisis >:(",
    1,
	2);
