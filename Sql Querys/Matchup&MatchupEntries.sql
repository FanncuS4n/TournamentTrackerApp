CREATE PROCEDURE dbo.spMatchups_Insert 
	@TournamentId int,
	@MatchupRound int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Matchups(TournamentId, MatchupRound)
	VALUES(@TournamentId, @MatchupRound);

	SELECT @id = SCOPE_IDENTITY();
END
GO
CREATE PROCEDURE dbo.spMatchupEntries_Insert
	@MatchupId int,
	@ParentMatchupId int,
	@TeamCompetingId int,
	@Id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.MatchupEntries(MatchupId, ParentMatchupId, TeamCompetingId) 
	VALUES(@MatchupId, @ParentMatchupId, @TeamCompetingId);

	SELECT @Id = SCOPE_IDENTITY();
END
GO

