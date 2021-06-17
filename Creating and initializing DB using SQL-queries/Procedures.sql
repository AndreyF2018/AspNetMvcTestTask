USE InventoryDB

GO

CREATE PROCEDURE MakeMonthlyReport @Month TINYINT, @Year SMALLINT
AS
BEGIN
	SELECT p.id as id, p.positionName, SUM(t.quantityPosition) as positionQuantity
	FROM Tickets t, Positions p
	WHERE t.positionId = p.id AND MONTH(t.dateCreation) = @Month AND YEAR (t.dateCreation) = @Year
	GROUP BY p.id, p.positionName
END

--EXEC MakeMonthlyReport 6, 2021

GO

CREATE PROCEDURE AddTicket @Comment nvarchar(75), @PositionId int, @QuantityPosition int
AS
BEGIN
	INSERT INTO Tickets (comment, positionId, quantityPosition)
	VALUES
	(@Comment, @PositionId, @QuantityPosition)
END