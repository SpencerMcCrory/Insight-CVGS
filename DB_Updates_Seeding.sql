
-- games_categories table
INSERT INTO GameCategory VALUES ('Board'); /*(e.g., Monopoly).*/
INSERT INTO GameCategory VALUES ('Adventure'); /*(e.g., The Legend of Zelda).*/
INSERT INTO GameCategory VALUES ('Fighting');/*(e.g., Street Fighter V).*/
INSERT INTO GameCategory VALUES ('Survival');/*(e.g., Minecraft).*/
INSERT INTO GameCategory VALUES ('Racing');/*(e.g., Need for Speed).*/
INSERT INTO GameCategory VALUES ('Horror');/*(e.g., Resident Evil).*/
INSERT INTO GameCategory VALUES ('Platformer');/*(e.g., Super Mario).*/

-- ReviewStatus table
INSERT INTO ReviewStatus VALUES ('Approved');
INSERT INTO ReviewStatus VALUES ('Pending');
INSERT INTO ReviewStatus VALUES ('Rejected');

-- EventType table
INSERT INTO EventType VALUES ('Virtual');
INSERT INTO EventType VALUES ('On-Site');

-- LanguageTable table
INSERT INTO LanguageTable VALUES ('English');
INSERT INTO LanguageTable VALUES ('French');

-- Account table
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('admin_acc@gmail.com', 'admin123', 'ADMIN');
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('member1@gmail.com', 'member123', 'MEMBER');
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('member2@gmail.com', 'member123', 'MEMBER');
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('member3@gmail.com', 'member123', 'MEMBER');
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('member4@gmail.com', 'member123', 'MEMBER');
--INSERT INTO Account (EmailAddress, UserPassword, AccountType) VALUES ('member5@gmail.com', 'member123', 'MEMBER');

INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (1,'Salma123','member5@gmail.com', 1,'123-123-1234', 1, 0,0,0);
INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (2,'SalmaEssam','salma@gmail.com', 1,'123-123-1234', 1, 0,0,0);
INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (3,'Ali123','ali@gmail.com', 1,'123-123-1234', 1, 0,0,0);
INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (4,'Omar123','omar@gmail.com', 1,'123-123-1234', 1, 0,0,0);
INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (5,'Aya123','aya@gmail.com', 1,'123-123-1234', 1, 0,0,0);
INSERT INTO AspNetUsers (id,UserName, Email, EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) 
VALUES (6,'Hazem123','hazem@gmail.com', 1,'123-123-1234', 1, 0,0,0);


-- GameEvent table
INSERT INTO GameEvent (EventName, Details, StartDate, StartTime, EndTime, EvTypeId, EventLink) VALUES 
('KW GamesCom', 'KW GamesCom details', '2024-08-30', '13:00', '14:00', 1, 'https://www.example.com/events/event1');
INSERT INTO GameEvent (EventName, Details, StartDate, StartTime, EndTime, EvTypeId, EventLink) VALUES 
('Tokyo Game Show', 'Tokyo Game Show details', '2024-12-30', '14:00', '16:00', 1, 'https://www.example.com/events/event2');
INSERT INTO GameEvent (EventName, Details, StartDate, StartTime, EndTime, EvTypeId, EventLink) VALUES 
('Astronomical Showdown', 'Astronomical Showdown details', '2024-05-30', '15:00', '17:00', 1, 'https://www.example.com/events/event3');
INSERT INTO GameEvent (EventName, Details, StartDate, StartTime, EndTime, EvTypeId, EventLink) VALUES 
('Collision Soundwave', 'Collision Soundwave details', '2024-01-30', '14:30', '16:30', 1, 'https://www.example.com/events/event4');


-- Employee table
INSERT INTO Employee (FirstName, LastName, AccountId) VALUES 
('Adam', 'John', 1);

-- Member table
INSERT INTO Member (FirstName, LastName, DisplayName,Gender,AccountId) VALUES 
('Salma', 'Essam','Salma Essam' ,'Female',2);
INSERT INTO Member (FirstName, LastName, DisplayName, Gender,AccountId)VALUES 
('Ali', 'Mher','Ali Maher', 'Male',3);
INSERT INTO Member (FirstName, LastName, DisplayName, Gender,AccountId) VALUES 
('Omar', 'Karim','Omar Karim', 'Male',4);
INSERT INTO Member (FirstName, LastName, DisplayName, Gender,AccountId) VALUES 
('Aya', 'Khalid','Aya Khalid', 'Female',5);
INSERT INTO Member (FirstName, LastName, DisplayName, Gender,AccountId) VALUES 
('Hazem', 'Tarek','Hazem Tarek', 'Male',6);


-- Game table
INSERT INTO Game (GameName, Details, Price) VALUES 
('Super Mario', 'game details', 10);
INSERT INTO Game (GameName, Details, Price)  VALUES 
('Sonic Mania', 'game details', 20);
INSERT INTO Game (GameName, Details, Price)  VALUES 
('Life is Strange', 'game details',30);
INSERT INTO Game (GameName, Details, Price)  VALUES 
('Minecraft', 'game details',40);
INSERT INTO Game (GameName, Details, Price)  VALUES 
('Monopoly', 'game details',50);


-- OrderTable table
INSERT INTO OrderTable (OrderDate, OrderTime, TotalPayment, MemberId) VALUES ('2024-03-21', '10:00', '40', '1'); /*order 1 - member 1*/
INSERT INTO OrderTable (OrderDate, OrderTime, TotalPayment, MemberId) VALUES ('2024-04-22', '10:00', '20', '1'); /*order 2 - member 1*/
INSERT INTO OrderTable (OrderDate, OrderTime, TotalPayment, MemberId)VALUES ('2024-05-22', '10:00', '50', '2'); /*order 3 - member 2*/
INSERT INTO OrderTable (OrderDate, OrderTime, TotalPayment, MemberId) VALUES ('2024-05-22', '10:00', '70', '3'); /*order 4 - member 3*/
INSERT INTO OrderTable (TotalPayment, MemberId) VALUES ('50','4');												/*order 5 - member 4*/

-- OrderItem table
INSERT INTO OrderItem (OrderId, GameId) VALUES (1,1); /* order 1 -member1 - game 1*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (1,3); /*order 1 - member1 - game 3*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (2,2); /*order 2 -member1 - game 2*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (3,2);/*order 3 -member2 - game 2*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (3,3); /*order 3 -member2 - game 3*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (4,3);/*order 4 -member3 - game 3*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (4,4); /*order 4 -member3 - game 4*/
INSERT INTO OrderItem (OrderId, GameId) VALUES (5,5); /*order 5 -member4 - game 5*/

-- Review table
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (1, 1, 2, 'member 1 review on game 1');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (1, 2, 1, 'member 1 review on game 2');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (1, 3, 3, 'member 1 review on game 3');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (2, 2, 1, 'member 2 review on game 2');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (2, 3, 1, 'member 2 review on game 3');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (3, 3, 1, 'member 3 review on game 3');
INSERT INTO Review (GameId, MemberId, StatusId, ReviewBody) VALUES (3, 4, 1, 'member 3 review on game 4');

-- member_game_preferences table
INSERT INTO MemberGameCategoryPref (MemberId, CategoryId) VALUES 
(1,7);
INSERT INTO MemberGameCategoryPref (MemberId, CategoryId) VALUES 
(1,2);
INSERT INTO MemberGameCategoryPref (MemberId, CategoryId) VALUES 
(2,2);
INSERT INTO MemberGameCategoryPref (MemberId, CategoryId) VALUES 
(2,3);
INSERT INTO MemberGameCategoryPref (MemberId, CategoryId) VALUES 
(2,1);

-- WishList table
INSERT INTO WishList (MemberId, GameId) VALUES 
(1,4);
INSERT INTO WishList (MemberId, GameId) VALUES 
(1,5);
INSERT INTO WishList (MemberId, GameId) VALUES 
(3,1);
INSERT INTO WishList (MemberId, GameId) VALUES 
(3,5);

-- MemberEventRegist table
INSERT INTO MemberEventRegist (MemberId, EventId) VALUES 
(1,1);
INSERT INTO MemberEventRegist (MemberId, EventId) VALUES 
(2,1);
INSERT INTO MemberEventRegist (MemberId, EventId) VALUES 
(3,1);
INSERT INTO MemberEventRegist (MemberId, EventId) VALUES 
(2,2);
INSERT INTO MemberEventRegist (MemberId, EventId) VALUES 
(3,2);

-- Friend table
INSERT INTO Friend (MemberId, FriendId) VALUES 
(1,2);
INSERT INTO Friend (MemberId, FriendId) VALUES 
(1,3);
INSERT INTO Friend (MemberId, FriendId) VALUES 
(1,4);
INSERT INTO Friend (MemberId, FriendId) VALUES 
(2,3);
INSERT INTO Friend (MemberId, FriendId) VALUES 
(2,4);
INSERT INTO Friend (MemberId, FriendId) VALUES 
(3,5);

--Address Table
INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping) 
	VALUES (1,'123','King Street','1A','N2J 5T5','Waterloo','Ontario','canada',0);

INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping
      ,DelivaryInstructions) 
	VALUES (1,'123','King Street','1A','N2J 5T5','Waterloo','Ontario','canada',1,'My Delivary Instructions');



INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping) 
	VALUES (2,'222','Weber Street','2B','N2K 5Y9','Waterloo','Ontario','canada',0);

INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping
      ,DelivaryInstructions) 
	VALUES (2,'321','Westmount Street','3B','N2S 4R5','Kitchener','Ontario','canada',1,'My Delivary Instructions2');


INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping) 
	VALUES (3,'333','Alin Street','2B','N2K 5Y9','Toronto','Ontario','canada',0);

INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping
      ,DelivaryInstructions) 
	VALUES (3,'32','Westmount Street','3B','N2S 4R5','Toronto','Ontario','canada',1,'My Delivary Instructions2');


INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping) 
	VALUES (4,'15','Bristol Street','1A','N2J 5T5','Waterloo','Ontario','canada',0);

INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping
      ,DelivaryInstructions) 
	VALUES (4,'15','Bristol Street','1A','N2J 5T5','Waterloo','Ontario','canada',1,'My Delivary Instructions');


INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping) 
	VALUES (5,'3','Erb Street','1A','N2J 5T5','Waterloo','Ontario','canada',0);

INSERT INTO AddressTable (MemberId, StreetNumber, StreetName, Unit
      , PostalCode , City , Province , Country , IsShipping
      ,DelivaryInstructions) 
	VALUES (5,'3','Erb Street','1A','N2J 5T5','Waterloo','Ontario','canada',1,'My Delivary Instructions');



/*UPDATE GameEvent SET IsDeleted = 0
WHERE EventId = 1;*/


