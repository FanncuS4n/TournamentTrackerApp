Create database Tournaments;
go
Use Tournaments
go
CREATE TABLE People (
    id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    EmailAddress VARCHAR(100),
    CellphoneNumber VARCHAR(20)
);
Create table Tournaments(
	id INT PRIMARY KEY IDENTITY,
	TournamentName VARCHAR(50),
	EntryFee money
);
CREATE TABLE Teams (
    id INT PRIMARY KEY IDENTITY,
    TeamName VARCHAR(50)
);
CREATE TABLE Prizes (
    id INT PRIMARY KEY IDENTITY,
    PlaceNumber INT,
    PlaceName VARCHAR(50),
    PrizeAmount DECIMAL(10, 2),
    PrizePercentage DECIMAL(5, 2)
);
CREATE TABLE TournamentEntries (
    id INT PRIMARY KEY IDENTITY,
    TournamentId INT,
    TeamId INT,
    FOREIGN KEY (TournamentId) REFERENCES Tournaments(id),
    FOREIGN KEY (TeamId) REFERENCES Teams(id)
);

CREATE TABLE TournamentPrizes (
    id INT PRIMARY KEY IDENTITY,
    TournamentId INT,
    PrizeId INT,
    FOREIGN KEY (TournamentId) REFERENCES Tournaments(id),
    FOREIGN KEY (PrizeId) REFERENCES Prizes(id)
);
CREATE TABLE TeamMembers (
    id INT PRIMARY KEY IDENTITY,
    TeamId INT,
    PersonId INT,
    FOREIGN KEY (TeamId) REFERENCES Teams(id),
    FOREIGN KEY (PersonId) REFERENCES People(id)
);

CREATE TABLE Matchups (
    id INT PRIMARY KEY IDENTITY,
    WinnerId INT,
    MatchupRound INT
);
CREATE TABLE MatchupEntries (
    id INT PRIMARY KEY IDENTITY,
    MatchupId INT,
    ParentMatchupId INT,
    TeamCompetingId INT,
    Score INT,
    FOREIGN KEY (MatchupId) REFERENCES Matchups(id),
    FOREIGN KEY (ParentMatchupId) REFERENCES Matchups(id),
    FOREIGN KEY (TeamCompetingId) REFERENCES Teams(id)
);