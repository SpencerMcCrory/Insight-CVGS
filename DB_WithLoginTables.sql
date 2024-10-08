/********************************************************
* This script creates the database named InsightCVGS
*********************************************************/

--DROP DATABASE IF EXISTS InsightUpdateCVGS2;
--CREATE DATABASE InsightUpdateCVGS2;
--USE InsightUpdateCVGS2;


/********************************************************
* create tables
*********************************************************/
-- create the tables for the database

CREATE TABLE AspNetUsers (
    Id                   VARCHAR (36)     NOT NULL,
    UserName             NVARCHAR (256)     NULL,
    NormalizedUserName   NVARCHAR (256)     NULL,
    Email                NVARCHAR (256)     NULL,
    NormalizedEmail      NVARCHAR (256)     NULL,
    EmailConfirmed       BIT                NOT NULL,
    PasswordHash         NVARCHAR (MAX)     NULL,
    SecurityStamp        NVARCHAR (MAX)     NULL,
    ConcurrencyStamp     NVARCHAR (MAX)     NULL,
    PhoneNumber          NVARCHAR (MAX)     NULL,
    PhoneNumberConfirmed BIT                NOT NULL,
    TwoFactorEnabled     BIT                NOT NULL,
    LockoutEnd           DATETIMEOFFSET (7) NULL,
    LockoutEnabled       BIT                NOT NULL,
    AccessFailedCount    INT                NOT NULL,
    CONSTRAINT PK_AspNetUsers PRIMARY KEY CLUSTERED (Id ASC)
);

CREATE UNIQUE NONCLUSTERED INDEX UserNameIndex
    ON AspNetUsers(NormalizedUserName ASC) WHERE (NormalizedUserName IS NOT NULL);

CREATE TABLE AspNetRoles (
    Id               NVARCHAR (450) NOT NULL,
    Name             NVARCHAR (256) NULL,
    NormalizedName   NVARCHAR (256) NULL,
    ConcurrencyStamp NVARCHAR (MAX) NULL,
    CONSTRAINT PK_AspNetRoles PRIMARY KEY CLUSTERED (Id ASC)
);

CREATE TABLE AspNetUserRoles (
    UserId VARCHAR (36) NOT NULL,
    RoleId NVARCHAR (450) NOT NULL,
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY CLUSTERED (UserId ASC, RoleId ASC),
    CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE,
    CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserLogins (
    LoginProvider       NVARCHAR (128) NOT NULL,
    ProviderKey         NVARCHAR (128) NOT NULL,
    ProviderDisplayName NVARCHAR (MAX) NULL,
    UserId              VARCHAR (36) NOT NULL,
    CONSTRAINT PK_AspNetUserLogins PRIMARY KEY CLUSTERED (LoginProvider ASC, ProviderKey ASC),
    CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES .AspNetUsers (Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserClaims (
    Id         INT            IDENTITY (1, 1) NOT NULL,
    UserId     VARCHAR (36) NOT NULL,
    ClaimType  NVARCHAR (MAX) NULL,
    ClaimValue NVARCHAR (MAX) NULL,
    CONSTRAINT PK_AspNetUserClaims PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

CREATE TABLE AspNetRoleClaims (
    Id         INT            IDENTITY (1, 1) NOT NULL,
    RoleId     NVARCHAR (450) NOT NULL,
    ClaimType  NVARCHAR (MAX) NULL,
    ClaimValue NVARCHAR (MAX) NULL,
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserTokens (
    UserId        VARCHAR (36) NOT NULL,
    LoginProvider NVARCHAR (128) NOT NULL,
    Name          NVARCHAR (128) NOT NULL,
    Value         NVARCHAR (MAX) NULL,
    CONSTRAINT PK_AspNetUserTokens PRIMARY KEY CLUSTERED (UserId ASC, LoginProvider ASC, Name ASC),
    CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

/*
CREATE TABLE Account (
	AccountId  INT IDENTITY(1,1) PRIMARY KEY,
	EmailAddress VARCHAR (50) NOT NULL,
	UserPassword VARCHAR (100) NOT NULL,
	AccountType VARCHAR (10) NOT NULL,  /*ADMIN - MEMBER*/
	AccountBlocked BIT DEFAULT 0
);
*/

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
	AccountId VARCHAR (36) UNIQUE NOT NULL,
	FOREIGN KEY (AccountId) REFERENCES AspNetUsers (Id),
);

CREATE TABLE AddressTable (
	AddressId INT IDENTITY(1,1) PRIMARY KEY,
	MemberId INT DEFAULT NULL, /*---------updated-----*/
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
	AccountId VARCHAR (36) UNIQUE NOT NULL,
	FOREIGN KEY (AccountId) REFERENCES AspNetUsers (Id),
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
	id INT IDENTITY (1,1) PRIMARY KEY,
	OrderId INT,
	GameId INT,
	IsShipped BIT DEFAULT 0,
	FOREIGN KEY (OrderId) REFERENCES OrderTable (OrderId),
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
);

CREATE TABLE MemberPlatformPref ( /* junction table */
    id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
    PlatformId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (PlatformId) REFERENCES GamePlatform (PlatformId),
);
CREATE TABLE MemberGameCategoryPref ( /* junction table */
    id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
    CategoryId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (CategoryId) REFERENCES GameCategory (CategoryId),
);
CREATE TABLE MemberLanguagePref ( /* junction table */
    id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
    LanguageId INT,
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
    FOREIGN KEY (LanguageId) REFERENCES LanguageTable (LanguageId),
);

CREATE TABLE GameDetailsCategory ( /* junction table */
	id INT IDENTITY (1,1) PRIMARY KEY,
	GameId INT,
	CategoryId INT,
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
	FOREIGN KEY (CategoryId) REFERENCES GameCategory (CategoryId),
);

CREATE TABLE GameDetailsPlatform ( /* junction table */
    id INT IDENTITY (1,1) PRIMARY KEY,
	GameId INT,
    PlatformId INT,
    FOREIGN KEY (GameId) REFERENCES Game (GameId),
    FOREIGN KEY (PlatformId) REFERENCES GamePlatform (PlatformId),
);

CREATE TABLE GameDetailsLanguage ( /* junction table */
	id INT IDENTITY (1,1) PRIMARY KEY,
	GameId INT,
	LanguageId INT,
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
	FOREIGN KEY (LanguageId) REFERENCES LanguageTable (LanguageId),
);

CREATE TABLE WishList ( /* junction table */
	id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
	GameId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (GameId) REFERENCES Game (GameId),
);

CREATE TABLE MemberEventRegist ( /* junction table */
	id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
	EventId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (EventId) REFERENCES GameEvent (EventId),
);

CREATE TABLE Friend ( /* junction table */
	id INT IDENTITY (1,1) PRIMARY KEY,
	MemberId INT,
	FriendId INT,
	FOREIGN KEY (MemberId) REFERENCES Member (MemberId),
	FOREIGN KEY (FriendId) REFERENCES Member (MemberId),
);
