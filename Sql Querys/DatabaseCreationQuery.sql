USE master
DROP DATABASE Tournaments
CREATE DATABASE Tournaments
Use Tournaments
go
CREATE TABLE dbo.People (
    id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    EmailAddress VARCHAR(100),
    CellphoneNumber VARCHAR(20)
);
Create table dbo.Tournaments(
	id INT PRIMARY KEY IDENTITY,
	TournamentName VARCHAR(50),
	EntryFee money
);
CREATE TABLE dbo.Teams (
    id INT PRIMARY KEY IDENTITY,
    TeamName VARCHAR(50)
);
CREATE TABLE dbo.Prizes (
    id INT PRIMARY KEY IDENTITY,
    PlaceNumber INT NOT NULL,
    PlaceName VARCHAR(50) NOT NULL,
    PrizeAmount MONEY NOT NULL,
    PrizePercentage FLOAT NOT NULL
);
CREATE TABLE dbo.TournamentEntries (
    id INT PRIMARY KEY IDENTITY,
    TournamentId INT,
    TeamId INT,
    FOREIGN KEY (TournamentId) REFERENCES Tournaments(id),
    FOREIGN KEY (TeamId) REFERENCES Teams(id)
);

CREATE TABLE dbo.TournamentPrizes (
    id INT PRIMARY KEY IDENTITY,
    TournamentId INT,
    PrizeId INT,
    FOREIGN KEY (TournamentId) REFERENCES Tournaments(id),
    FOREIGN KEY (PrizeId) REFERENCES Prizes(id)
);
CREATE TABLE dbo.TeamMembers (
    id INT PRIMARY KEY IDENTITY,
    TeamId INT,
    PersonId INT,
    FOREIGN KEY (TeamId) REFERENCES Teams(id),
    FOREIGN KEY (PersonId) REFERENCES People(id)
);

CREATE TABLE dbo.Matchups (
    id INT PRIMARY KEY IDENTITY,
    WinnerId INT,
    MatchupRound INT
);
CREATE TABLE dbo.MatchupEntries (
    id INT PRIMARY KEY IDENTITY,
    MatchupId INT,
    ParentMatchupId INT,
    TeamCompetingId INT,
    Score INT,
    FOREIGN KEY (MatchupId) REFERENCES Matchups(id),
    FOREIGN KEY (ParentMatchupId) REFERENCES Matchups(id),
    FOREIGN KEY (TeamCompetingId) REFERENCES Teams(id)
);