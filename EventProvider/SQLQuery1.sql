INSERT INTO Events
    (Name, Description, StartDate, EndDate, Location, TicketPrice, TicketAmount)
VALUES
    ('Music Fest', 'A fun outdoor music festival.', GETDATE(), DATEADD(hour, 4, GETDATE()), 'Central Park', 25, '100'),
    ('Tech Conference', 'Annual technology conference.', DATEADD(day, 1, GETDATE()), DATEADD(day, 1, DATEADD(hour, 8, GETDATE())), 'Convention Center', 150, '300'),
    ('Art Expo', 'Exhibition of modern art.', DATEADD(day, 2, GETDATE()), DATEADD(day, 2, DATEADD(hour, 6, GETDATE())), 'Art Gallery', 40, '50');
