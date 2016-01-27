CREATE DATABASE MPK
GO
USE MPK
GO
--Timetable data

CREATE TABLE [Line] (
	Id_line INT NOT NULL,
	Line_number INT NOT NULL,
	CONSTRAINT pk_Id_line PRIMARY KEY (Id_line)
  )
GO
CREATE TABLE [LineConnection] (
	Id_route INT NOT NULL,
	Id_line INT NOT NULL,
	Stop_number INT NOT NULL
  )
GO
CREATE TABLE [Connection] (
	Id_route INT NOT NULL,
	From_stop_id INT NOT NULL,
	To_stop_id INT NOT NULL,
	Transfer_time time(7) NOT NULL,
	CONSTRAINT pk_Id_route PRIMARY KEY (Id_route)
   )
GO
CREATE TABLE [LineStop] (
	Id_stop INT NOT NULL,
	Name VARCHAR(30) NOT NULL,
	CONSTRAINT pk_Id_stop PRIMARY KEY (Id_stop)
   )
GO
--w (weekday), s (saturday), h (holiday)- Dayweek
CREATE TABLE [LineDetails] (
	Line_number INT NOT NULL,
	Starting_time time(7) NOT NULL,
	DayWeek varchar(1) NOT NULL,
	Direction bit
  )

GO
CREATE TABLE [Users] (
	Id_user INT NOT NULL,
	Username varchar(25) NOT NULL,
	Mail varchar(40) NOT NULL,
	User_password varchar(12) NOT NULL,
	User_status BIT NOT NULL,
	CONSTRAINT pk_Id_user PRIMARY KEY (Id_user)
  )
GO
CREATE TABLE [UserTicket] (
	Id_user INT NOT NULL,
	Line_number INT NOT NULL
  )
GO
CREATE TABLE [UserStatistics] (
	Id_user INT NOT NULL,
	Avg_time time(7) NULL,
	Fav_line INT NULL
  )
GO
CREATE TABLE [UserTracks] (
	Id_user INT NOT NULL,
	Id_track INT NOT NULL
  )
GO
CREATE TABLE [Track] (
	Id_track INT NOT NULL,
	Id_start INT NOT NULL,
	Id_end INT NOT NULL,
	CONSTRAINT pk_Track_Id_track PRIMARY KEY (Id_track)
  )
GO
USE MPK
GO
ALTER TABLE [LineConnection] 
	ADD CONSTRAINT fk_Id_route FOREIGN KEY(Id_route) REFERENCES [Connection](Id_route),
	CONSTRAINT fk_Id_line FOREIGN KEY(Id_line) REFERENCES [Line](Id_line)
GO
ALTER TABLE [Connection]
	ADD CONSTRAINT fk_From_stop_id FOREIGN KEY (From_stop_id) REFERENCES [LineStop](Id_stop),
	CONSTRAINT fk_To_stop_id FOREIGN KEY (To_stop_id) REFERENCES [LineStop](Id_stop)
GO
ALTER TABLE [UserTicket]
	ADD CONSTRAINT fk_UserTicket_Id_user FOREIGN KEY(Id_user) REFERENCES [Users](Id_user)
GO
ALTER TABLE [UserStatistics]
	ADD CONSTRAINT fk_UserStatistics_Id_user FOREIGN KEY(Id_user) REFERENCES [Users](Id_user)
GO
ALTER TABLE [UserTracks]
	ADD CONSTRAINT fk_UserTracks_Id_user FOREIGN KEY(Id_user) REFERENCES [Users](Id_user),
	CONSTRAINT fk_UserTracks_Id_track FOREIGN KEY(Id_track) REFERENCES [Track](Id_track)
GO
ALTER TABLE [Track]
	ADD CONSTRAINT fk_Track_Id_start FOREIGN KEY (Id_start) REFERENCES [LineStop](Id_stop),
	CONSTRAINT fk_Track_Id_stop FOREIGN KEY (Id_end) REFERENCES [LineStop](Id_stop)
GO
CREATE INDEX stop_number_index ON [LineConnection] (Stop_number)
GO
CREATE PROCEDURE CZAS_DO_PRZYSTANKU @NAZWA_P varchar(30), @LINIA INT, @START_TIME time(7), @DIRECTION bit
AS
BEGIN
	DECLARE @TIME_TOTAL time(7);
	SET @TIME_TOTAL = @START_TIME;
	DECLARE @StopNumber INT;
	DECLARE @START INT;
	DECLARE @STOP INT;
	DECLARE @LINIA_ID INT = (SELECT Id_line FROM Line WHERE Line_number = @LINIA);
	SET @StopNumber = (SELECT lr.Stop_number FROM LineConnection lr
	JOIN Line l ON l.Id_line = lr.Id_line
	JOIN Connection c ON c.Id_route = lr.Id_route
	JOIN LineStop ls ON c.From_stop_id = ls.Id_stop
	WHERE l.Line_number = @LINIA
	AND ls.Name = @NAZWA_P)
	DECLARE @LICZNIK INT = 1;
	WHILE @LICZNIK < @StopNumber
	BEGIN
		IF(@DIRECTION = 0)
		BEGIN
			SET @START = (SELECT c.From_stop_id FROM Connection c
			JOIN LineConnection lr ON c.Id_route = lr.Id_route
			WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

			SET @STOP = (SELECT c.To_stop_id FROM Connection c
			JOIN LineConnection lr ON c.Id_route = lr.Id_route
			WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

			SET @TIME_TOTAL = (SELECT DATEADD(minute, DATEPART(minute, c.Transfer_time), @TIME_TOTAL)
			FROM Connection c
			WHERE c.From_stop_id = @START
			AND c.To_stop_id = @STOP);
		END
		ELSE
		BEGIN
			SET @START = (SELECT c.To_stop_id FROM Connection c
			JOIN LineConnection lr ON c.Id_route = lr.Id_route
			WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

			SET @STOP = (SELECT c.From_stop_id FROM Connection c
			JOIN LineConnection lr ON c.Id_route = lr.Id_route
			WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

			SET @TIME_TOTAL = (SELECT DATEADD(minute, DATEPART(minute, c.Transfer_time), @TIME_TOTAL)
			FROM Connection c
			WHERE c.From_stop_id = @START
			AND c.To_stop_id = @STOP);
		END
		SET @LICZNIK = @LICZNIK + 1;
	END
	SELECT @TIME_TOTAL;
END