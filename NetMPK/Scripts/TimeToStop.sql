CREATE PROCEDURE CZAS_DO_PRZYSTANKU @NAZWA_P varchar(30), @LINIA INT, @START_TIME time(7)
AS
BEGIN
	DECLARE @TIME_TOTAL time(7);
	SET @TIME_TOTAL = @START_TIME;
	DECLARE @StopNumber INT;
	DECLARE @START INT;
	DECLARE @STOP INT;
	DECLARE @LINIA_ID INT = (SELECT Id_line FROM Line WHERE Line_number = @LINIA);
	SET @StopNumber = (SELECT lr.Stop_number FROM LineRoute lr
	JOIN Line l ON l.Id_line = lr.Id_line
	JOIN Connection c ON c.Id_route = lr.Id_route
	JOIN LineStop ls ON c.From_stop_id = ls.Id_stop
	WHERE l.Line_number = @LINIA
	AND ls.Name = @NAZWA_P)
	DECLARE @LICZNIK INT = 1;
	WHILE @LICZNIK < @StopNumber
	BEGIN
		SET @START = (SELECT c.From_stop_id FROM Connection c
		JOIN LineRoute lr ON c.Id_route = lr.Id_route
		WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

		SET @STOP = (SELECT c.To_stop_id FROM Connection c
		JOIN LineRoute lr ON c.Id_route = lr.Id_route
		WHERE lr.Id_line = @LINIA_ID AND lr.Stop_number = @LICZNIK);

		SET @TIME_TOTAL = (SELECT DATEADD(minute, DATEPART(minute, c.Transfer_time), @TIME_TOTAL)
		FROM Connection c
		WHERE c.From_stop_id = @START
		AND c.To_stop_id = @STOP);

		SET @LICZNIK = @LICZNIK + 1;
	END
	SELECT @TIME_TOTAL;
END

--drop procedure CZAS_DO_PRZYSTANKU
--SELECT * FROM LineStop
--exec CZAS_DO_PRZYSTANKU @NAZWA_P = 'Kopiec Koœciuszki', @LINIA = 101, @START_TIME = '07:10:00'