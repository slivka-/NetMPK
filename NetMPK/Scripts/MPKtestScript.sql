USE MPK;

--Timetable data

CREATE TABLE [Line] (
	Id_line INT NOT NULL,
	Line_number INT NOT NULL,
	CONSTRAINT pk_Id_line PRIMARY KEY (Id_line)
  );

CREATE TABLE LineRoute (
	Id_route INT NOT NULL,
	Id_line INT NOT NULL,
	Stop_number INT NOT NULL,
	--CONSTRAINT pk_Id_route_Id_line PRIMARY KEY (Id_route, Id_line)
  );

CREATE TABLE Connection (
	Id_route INT NOT NULL,
	From_stop_id INT NOT NULL,
	To_stop_id INT NOT NULL,
	Transfer_time time(7) NOT NULL,
	CONSTRAINT pk_Id_route PRIMARY KEY (Id_route)
   );

CREATE TABLE LineStop (
	Id_stop INT NOT NULL,
	Name VARCHAR(30) NOT NULL,
	CONSTRAINT pk_Id_stop PRIMARY KEY (Id_stop)
   );

CREATE TABLE LineDetails (
	Line_number INT NOT NULL,
	Starting_time time(7) NOT NULL,
	DayWeek varchar(1) NULL,
	Saturday varchar(1) NULL,
	Holiday varchar(1) NULL
  );

  -- User data

CREATE TABLE Users (
	Id_user INT NOT NULL,
	Username varchar(25) NOT NULL,
	Mail varchar(40) NOT NULL,
	User_password varchar(12) NOT NULL,
	User_status BIT NOT NULL,
	CONSTRAINT pk_Id_user PRIMARY KEY (Id_user)
  );

CREATE TABLE UserTicket (
	Id_user INT NOT NULL,
	Line_number INT NOT NULL,
	--CONSTRAINT pk_UserTicket_Id_user PRIMARY KEY (Id_user)
  );

CREATE TABLE UserStatistics (
	Id_user INT NOT NULL,
	Avg_time time(7) NULL,
	Fav_line INT NULL,
	--CONSTRAINT pk_UserStatistics_Id_user PRIMARY KEY (Id_user)
  );

CREATE TABLE UserTracks (
	Id_user INT NOT NULL,
	Id_track INT NOT NULL,
	--CONSTRAINT pk_UserTracks_Id_user_Id_track PRIMARY KEY (Id_user, Id_track)
  );

CREATE TABLE Track (
	Id_track INT NOT NULL,
	Id_route INT NOT NULL,
	Line_number INT NOT NULL,
	Stop_number INT NOT NULL,
	CONSTRAINT pk_Track_Id_track PRIMARY KEY (Id_track)
  );