USE MPK

INSERT INTO Line (Id_line, Line_number) VALUES
(1, 100),
(2, 101),
(3, 102),
(4, 103),
(5, 104),
(6, 105),
(7, 106),
(8, 107),
(9, 109);

INSERT INTO LineStop (Id_stop, Name) VALUES
(1, 'Salwator'),
(2, 'Malczewskiego N¯'),
(3, 'Aleja Waszyngtona N¯'),
(4, 'Kopiec Koœciuszki'),
(5, 'Os.Podwawelskie'),
(6, 'Centrum Kongresowe'),
(7, 'Szwedzka'),
(8, 'Kapelanka'),
(9, 'Zieliñskiego'),
(10, 'Malczewskiego N¯');

--for bus no 100

INSERT INTO Connection(Id_route, From_stop_id, To_stop_id, Transfer_time) VALUES
(1, 1, 2, '00:02:00'),
(2, 2, 3, '00:02:00'),
(3, 3, 4, '00:00:00'),
(4, 4, 4, '00:00:00'),
(5, 1, 1, '00:00:00');

INSERT INTO LineRoute (Id_route, Id_line, Stop_number) VALUES
(5, 1, 1), --Salwator - Salwator
(2, 1, 2), -- Malczewskiego - Aleja
(3, 1, 3), -- Aleja - Kopiec
(4, 1, 4); -- Kopiec - Kopiec

--From Salwator
INSERT INTO LineDetails (Line_number, Starting_time, DayWeek, Holiday, Saturday) VALUES
-- Weekday
(100, '07:10:00', 't', 'f', 'f'),
(100, '08:10:00', 't', 'f', 'f'),
(100, '09:10:00', 't', 'f', 'f'),
(100, '10:10:00', 't', 'f', 'f'),
(100, '11:10:00', 't', 'f', 'f'),
(100, '12:10:00', 't', 'f', 'f'),
(100, '13:10:00', 't', 'f', 'f'),
(100, '14:10:00', 't', 'f', 'f'),
(100, '15:10:00', 't', 'f', 'f'),
(100, '16:10:00', 't', 'f', 'f'),
(100, '17:10:00', 't', 'f', 'f'),
(100, '18:10:00', 't', 'f', 'f'),
(100, '19:10:00', 't', 'f', 'f'),
(100, '20:10:00', 't', 'f', 'f'),
-- Holiday
(100, '07:10:00', 'f', 't', 'f'),
(100, '08:10:00', 'f', 't', 'f'),
(100, '09:10:00', 'f', 't', 'f'),
(100, '10:10:00', 'f', 't', 'f'),
(100, '11:10:00', 'f', 't', 'f'),
(100, '12:10:00', 'f', 't', 'f'),
(100, '13:10:00', 'f', 't', 'f'),
(100, '14:10:00', 'f', 't', 'f'),
(100, '15:10:00', 'f', 't', 'f'),
(100, '16:10:00', 'f', 't', 'f'),
(100, '17:10:00', 'f', 't', 'f'),
(100, '18:10:00', 'f', 't', 'f'),
(100, '19:10:00', 'f', 't', 'f'),
--Saturday
(100, '07:10:00', 'f', 'f', 't'),
(100, '08:10:00', 'f', 'f', 't'),
(100, '09:10:00', 'f', 'f', 't'),
(100, '10:10:00', 'f', 'f', 't'),
(100, '11:10:00', 'f', 'f', 't'),
(100, '12:10:00', 'f', 'f', 't'),
(100, '13:10:00', 'f', 'f', 't'),
(100, '14:10:00', 'f', 'f', 't'),
(100, '15:10:00', 'f', 'f', 't'),
(100, '16:10:00', 'f', 'f', 't'),
(100, '17:10:00', 'f', 'f', 't'),
(100, '18:10:00', 'f', 'f', 't'),
(100, '19:10:00', 'f', 'f', 't');