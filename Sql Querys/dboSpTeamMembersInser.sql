
CREATE PROCEDURE dbo.spTeams_Insert 
	@TeamName VARCHAR(50),
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.Teams(TeamName)
	Values (@TeamName);
	Select @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE dbo.SpTeamMembers_Insert
	@TeamId int,
	@PersonId int,
	@id int = 0 output
	
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO dbo.TeamMembers(TeamId, PersonId)
	VALUES (@TeamId, @PersonId);

	select @id = SCOPE_IDENTITY();
END
GO