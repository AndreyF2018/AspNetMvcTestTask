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
('����'),
('����'),
('�����������'),
('�����'),
('�����')

INSERT INTO Tickets (comment, positionId, quantityPosition)
VALUES
('����������� ����������', 3, 1),
('����� ���������', 2, 3),
('������ ����������', 5, 4),
('����������� ����', 4, 2),
('������ ��� �����������', 1, 10),
('����� �������', 2, 2),
('������������� ������������', 3, 5),
('', 4, 3)