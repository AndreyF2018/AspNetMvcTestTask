CREATE DATABASE InventoryDB  
GO  

USE InventoryDB

CREATE TABLE Positions (
id INT IDENTITY NOT NULL CONSTRAINT PK_Positions PRIMARY KEY,
positionName NVARCHAR(15) NOT NULL
)

CREATE TABLE Tickets (
id INT IDENTITY NOT NULL CONSTRAINT PK_Tickets PRIMARY KEY,
comment NVARCHAR(75),
dateCreation DATE NOT NULL DEFAULT GETDATE(),
positionId INT NOT NULL,
quantityPosition INT NOT NULL,
FOREIGN KEY (positionId) REFERENCES Positions (id) ON DELETE NO ACTION
)

INSERT INTO Positions (positionName)
VALUES
('Стул'),
('Стол'),
('Калькулятор'),
('Ведро'),
('Веник')

INSERT INTO Tickets (comment, positionId, quantityPosition)
VALUES
('Калькулятор инженерный', 3, 1),
('Столы обеденные', 2, 3),
('Веники соломенные', 5, 4),
('Пластиковые вёдра', 4, 2),
('Стулья для посетителей', 1, 10),
('Столы офисные', 2, 2),
('Бухгалтерские калькуляторы', 3, 5),
('', 4, 3)