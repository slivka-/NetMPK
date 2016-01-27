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
(1, 'Salwator'), -- 100
(2, 'Malczewskiego N¯'),
(3, 'Aleja Waszyngtona N¯'),
(4, 'Kopiec Koœciuszki'),
(5, 'Os.Podwawelskie'),
(6, 'Centrum Kongresowe'),
(7, 'Szwedzka'),
(8, 'Kapelanka'),
(9, 'Zieliñskiego');

--for bus no 100

INSERT INTO Connection(Id_route, From_stop_id, To_stop_id, Transfer_time) VALUES
(1, 1, 2, '00:02:00'), -- Salwator - Malczewskiego
(2, 2, 3, '00:02:00'),
(3, 3, 4, '00:00:00'),
(4, 4, 4, '00:00:00'),
(5, 1, 1, '00:00:00'),
(6, 5, 6, '00:00:00'), -- 101
(7, 6, 7, '00:00:00'),
(8, 7, 8, '00:00:00'),
(9, 8, 9, '00:00:00'),
(10, 9, 2, '00:00:00'),
(11, 5, 5, '00:00:00');


INSERT INTO LineRoute (Id_route, Id_line, Stop_number) VALUES
(5, 1, 1), --Salwator - Salwator
(2, 1, 2), -- Malczewskiego - Aleja
(3, 1, 3), -- Aleja - Kopiec
(4, 1, 4), -- Kopiec - Kopiec
(11, 2, 1), --Podwawelskie - Podwawelskie --101
(7, 2, 2), -- Centrum Kongresowe - Szwedzka
(8, 2, 3), -- Szwedzka - Kapelanka
(9, 2, 4), --Kapelanka - Zieliñskiego
(10, 2, 5), -- Zieliñskiego - Malczewskiego
(2, 2, 6), -- Malczewskiego - Aleja
(3, 2, 7), -- Aleja - Kopiec
(4, 2, 8);-- Kopiec - Kopiec

--From Salwator
INSERT INTO LineDetails (Line_number, Starting_time, DayWeek, Holiday, Saturday) VALUES
-- Weekday
(100, '07:10:00', 'w'),
(100, '08:10:00', 'w'),
(100, '09:10:00', 'w'),
(100, '10:10:00', 'w'),
(100, '11:10:00', 'w'),
(100, '12:10:00', 'w'),
(100, '13:10:00', 'w'),
(100, '14:10:00', 'w'),
(100, '15:10:00', 'w'),
(100, '16:10:00', 'w'),
(100, '17:10:00', 'w'),
(100, '18:10:00', 'w'),
(100, '19:10:00', 'w'),
(100, '20:10:00', 'w'),
-- Holiday
(100, '07:10:00', 'h'),
(100, '08:10:00', 'h'),
(100, '09:10:00', 'h'),
(100, '10:10:00', 'h'),
(100, '11:10:00', 'h'),
(100, '12:10:00', 'h'),
(100, '13:10:00', 'h'),
(100, '14:10:00', 'h'),
(100, '15:10:00', 'h'),
(100, '16:10:00', 'h'),
(100, '17:10:00', 'h'),
(100, '18:10:00', 'h'),
(100, '19:10:00', 'h'),
--Saturday
(100, '07:10:00', 's'),
(100, '08:10:00', 's'),
(100, '09:10:00', 's'),
(100, '10:10:00', 's'),
(100, '11:10:00', 's'),
(100, '12:10:00', 's'),
(100, '13:10:00', 's'),
(100, '14:10:00', 's'),
(100, '15:10:00', 's'),
(100, '16:10:00', 's'),
(100, '17:10:00', 's'),
(100, '18:10:00', 's'),
(100, '19:10:00', 's');