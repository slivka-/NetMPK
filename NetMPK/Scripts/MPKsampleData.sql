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
(1, 1, 2, '00:00:02'),
(2, 2, 3, '00:00:02'),
(3, 3, 4, '00:00:00');

INSERT INTO LineRoute VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3);