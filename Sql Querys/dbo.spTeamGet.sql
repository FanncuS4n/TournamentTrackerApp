
CREATE PROCEDURE dbo.spTeam_GetAll
	
AS
BEGIN
	SET NOCOUNT ON;
    SELECT * FROM dbo.Teams
END
GO

CREATE PROCEDURE dbo.spTeamMembers_GetByTeam
	@TeamId int
AS
BEGIN
	SET NOCOUNT ON;
    SELECT P.* FROM dbo.TeamMembers M
	INNER JOIN dbo.People P on P.id = M.PersonId
	WHERE M.TeamId = @TeamId;
END
GO
