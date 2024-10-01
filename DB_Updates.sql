/********************************************************
* This script creates the database named InsightCVGS
*********************************************************/

--DROP DATABASE IF EXISTS InsightCVGS;
CREATE DATABASE InsightCVGS;
USE InsightCVGS;


/********************************************************
* create tables
*********************************************************/
-- create the tables for the database

CREATE TABLE Account (
	AccountId  INT IDENTITY(1,1) PRIMARY KEY,
	EmailAddress VARCHAR (50) NOT NULL,
	UserPassword VARCHAR (100) NOT NULL,
	AccountType VARCHAR (10) NOT NULL,  /*ADMIN - MEMBER*/
	AccountBlocked BIT DEFAULT 0
);

CREATE TABLE LanguageTable (
	LanguageId  INT IDENTITY(1,1) PRIMARY KEY,     /*En - Fr*/
	LanguageName VARCHAR (30) NOT NULL,  /*English - French*/
);

CREATE TABLE Member (
	MemberId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR (20),
	LastName VARCHAR (25),
	DisplayName VARCHAR (15),
	Gender VARCHAR(20) DEFAULT NULL,
	DOB DATE DEFAULT NULL,
	RecievesEmails BIT DEFAULT 1,
	PhoneNumber VARCHAR (20) DEFAULT NULL,
	AccountId INT UNIQUE,
	FOREIGN KEY (AccountId) REFERENCES Account (AccountId),
);

CREATE TABLE AddressTable (
	AddressId INT IDENTITY(1,1) PRIMARY KEY,
	MemberId INT NOT NULL,
	StreetName VARCHAR (40) NOT NULL,
	StreetNumber VARCHAR (10) NOT NULL,
	Unit VARCHAR (10) DEFAULT NULL,
	PostalCode VARCHAR (12) DEFAULT NULL,
	City VARCHAR (30)  DEFAULT NULL,
	Province VARCHAR (25) DEFAULT NULL,
	Country VARCHAR (25) NOT NULL,
	IsShipping BIT DEFAULT 0,
	DelivaryInstructions VARCHAR (MAX) DEFAULT NULL,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId)
);

CREATE TABLE GameCategory (
	CategoryId  INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR (30) NOT NULL,
);

CREATE TABLE GamePlatform (
	PlatformId INT IDENTITY(1,1) PRIMARY KEY,
	PlatformName VARCHAR (30) NOT NULL,
);

CREATE TABLE ReviewStatus (
	StatusId INT IDENTITY(1,1) PRIMARY KEY,  /*A - P*/
	Statusname VARCHAR (15) NOT NULL,  /* Approved - Pending - Rejected */
);

CREATE TABLE EventType (
	EvTypeId  INT IDENTITY(1,1) PRIMARY KEY,
	EvTypeName VARCHAR (15) NOT NULL,  /*virtual - on-site*/
);

CREATE TABLE GameEvent (
	EventId INT IDENTITY(1,1) PRIMARY KEY,
	EventName VARCHAR (50) NOT NULL,
	Details VARCHAR (MAX) NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE DEFAULT NULL,
	StartTime TIME,
	EndTime TIME,
	EvTypeId INT NOT NULL,
	EventLink VARCHAR (100) DEFAULT NULL,
	IsDeleted BIT DEFAULT 0,
	AddressId INT DEFAULT NULL,
	FOREIGN KEY (EvTypeId) REFERENCES EventType (EvTypeId),
	FOREIGN KEY (AddressId) REFERENCES AddressTable (AddressId),
);


CREATE TABLE Employee (
	EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR (20),
	LastName VARCHAR (25),
	AccountId INT UNIQUE,
	FOREIGN KEY (AccountId) REFERENCES Account (AccountId),
);

CREATE TABLE Game (
	GameId INT IDENTITY(1,1) PRIMARY KEY,
	GameName VARCHAR (30) NOT NULL,
	Details VARCHAR (MAX) NOT NULL,
	Price FLOAT DEFAULT 0,
	PhysicalAvailable BIT DEFAULT 0,
	IsDeleted BIT DEFAULT 0,
);

CREATE TABLE Review (
	ReviewId INT IDENTITY (1,1) PRIMARY KEY,
	GameId INT,
	MemberId INT,
	StatusId INT NOT NULL,
	ReviewBody VARCHAR (MAX) NOT NULL,
	RejectReason VARCHAR (MAX) NULL,
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
	FOREIGN KEY (StatusId) REFERENCES ReviewStatus (StatusId),
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId)
);

CREATE TABLE OrderTable (
	OrderId INT IDENTITY (1,1) PRIMARY KEY,
	OrderDate DATE DEFAULT GETDATE(),
	OrderTime TIME DEFAULT CURRENT_TIMESTAMP,
	TotalPayment FLOAT,
	OrderFulfilled BIT DEFAULT 1,
	MemberId INT NOT NULL,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
);

CREATE TABLE OrderItem ( /* junction table */
	OrderId INT,
	GameId INT,
	IsShipped BIT DEFAULT 0,
	FOREIGN KEY (OrderId) REFERENCES OrderTable (OrderId),
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
);

CREATE TABLE MemberPlatformPref ( /* junction table */
    MemberId INT,
    PlatformId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (PlatformId) REFERENCES GamePlatform (PlatformId),
);
CREATE TABLE MemberGameCategoryPref ( /* junction table */
    MemberId INT,
    CategoryId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (CategoryId) REFERENCES GameCategory (CategoryId),
);
CREATE TABLE MemberLanguagePref ( /* junction table */
    MemberId INT,
    LanguageId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (LanguageId) REFERENCES LanguageTable (LanguageId),
);

CREATE TABLE GameDetailsCategory ( /* junction table */
	GameId INT,
	CategoryId INT,
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
	FOREIGN KEY (CategoryId) REFERENCES GameCategory (CategoryId),
);

CREATE TABLE GameDetailsPlatform ( /* junction table */
    GameId INT,
    PlatformId INT,
    FOREIGN KEY (GameId) REFERENCES Game (GameId),
    FOREIGN KEY (PlatformId) REFERENCES GamePlatform (PlatformId),
);

CREATE TABLE GameDetailsLanguage ( /* junction table */
	GameId INT,
	LanguageId INT,
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
	FOREIGN KEY (LanguageId) REFERENCES LanguageTable (LanguageId),
);

CREATE TABLE WishList ( /* junction table */
	MemberId INT,
	GameId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
);

CREATE TABLE MemberEventRegist ( /* junction table */
	MemberId INT,
	EventId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (EventId) REFERENCES GameEvent (EventId),
);

CREATE TABLE Friend ( /* junction table */
	MemberId INT,
	FriendId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (FriendId) REFERENCES Member (MemberId),
);
