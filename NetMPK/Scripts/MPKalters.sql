USE MPK

ALTER TABLE LineRoute ADD CONSTRAINT fk_Id_route FOREIGN KEY(Id_route) REFERENCES Connection(Id_route);

ALTER TABLE LineRoute
ADD CONSTRAINT fk_Id_line FOREIGN KEY(Id_line) REFERENCES Line(Id_line);

ALTER TABLE UserTicket
	ADD CONSTRAINT fk_UserTicket_Id_user FOREIGN KEY(Id_user) REFERENCES Users(Id_user);

ALTER TABLE UserStatistics
	ADD CONSTRAINT fk_UserStatistics_Id_user FOREIGN KEY(Id_user) REFERENCES Users(Id_user);

ALTER TABLE UserTracks
	ADD CONSTRAINT fk_UserTracks_Id_user FOREIGN KEY(Id_user) REFERENCES Users(Id_user),
	CONSTRAINT fk_UserTracks_Id_track FOREIGN KEY(Id_track) REFERENCES Track(Id_track);

ALTER TABLE Track
	ADD CONSTRAINT fk_Track_Id_route FOREIGN KEY(Id_route) REFERENCES Connection(Id_route);