CREATE PROCEDURE dbo.spPrizes
	@PlaceNumber int,
	@PlaceName nvarchar(50),
	@PrizeAmount MONEY, 
	@PrizePercentage float
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO dbo.Prizes (PlaceNumber, PlaceName, PrizeAmount, PricePercentage)
	VALUES ()
END
GO