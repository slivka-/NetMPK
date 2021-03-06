USE [MPK]
GO
/****** Object:  Table [dbo].[Connection]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connection](
	[Id_route] [int] NOT NULL,
	[From_stop_id] [int] NOT NULL,
	[To_stop_id] [int] NOT NULL,
	[Transfer_time] [time](7) NOT NULL,
 CONSTRAINT [pk_Id_route] PRIMARY KEY CLUSTERED 
(
	[Id_route] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Line]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Line](
	[Id_line] [int] NOT NULL,
	[Line_number] [int] NOT NULL,
 CONSTRAINT [pk_Id_line] PRIMARY KEY CLUSTERED 
(
	[Id_line] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineDetails]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LineDetails](
	[Line_number] [int] NOT NULL,
	[Starting_time] [time](7) NOT NULL,
	[DayWeek] [varchar](1) NULL,
	[Saturday] [varchar](1) NULL,
	[Holiday] [varchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LineRoute]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineRoute](
	[Id_route] [int] NOT NULL,
	[Id_line] [int] NOT NULL,
	[Stop_number] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineStop]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LineStop](
	[Id_stop] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [pk_Id_stop] PRIMARY KEY CLUSTERED 
(
	[Id_stop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Track]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[Id_track] [int] NOT NULL,
	[Id_route] [int] NOT NULL,
	[Line_number] [int] NOT NULL,
	[Stop_number] [int] NOT NULL,
 CONSTRAINT [pk_Track_Id_track] PRIMARY KEY CLUSTERED 
(
	[Id_track] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id_user] [int] NOT NULL,
	[Username] [varchar](25) NOT NULL,
	[Mail] [varchar](40) NOT NULL,
	[User_password] [varchar](12) NOT NULL,
	[User_status] [bit] NOT NULL,
 CONSTRAINT [pk_Id_user] PRIMARY KEY CLUSTERED 
(
	[Id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserStatistics]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatistics](
	[Id_user] [int] NOT NULL,
	[Avg_time] [time](7) NULL,
	[Fav_line] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTicket]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTicket](
	[Id_user] [int] NOT NULL,
	[Line_number] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTracks]    Script Date: 2015-12-16 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTracks](
	[Id_user] [int] NOT NULL,
	[Id_track] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LineRoute]  WITH CHECK ADD  CONSTRAINT [fk_Id_line] FOREIGN KEY([Id_line])
REFERENCES [dbo].[Line] ([Id_line])
GO
ALTER TABLE [dbo].[LineRoute] CHECK CONSTRAINT [fk_Id_line]
GO
ALTER TABLE [dbo].[LineRoute]  WITH CHECK ADD  CONSTRAINT [fk_Id_route] FOREIGN KEY([Id_route])
REFERENCES [dbo].[Connection] ([Id_route])
GO
ALTER TABLE [dbo].[LineRoute] CHECK CONSTRAINT [fk_Id_route]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [fk_Track_Id_route] FOREIGN KEY([Id_route])
REFERENCES [dbo].[Connection] ([Id_route])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [fk_Track_Id_route]
GO
ALTER TABLE [dbo].[UserStatistics]  WITH CHECK ADD  CONSTRAINT [fk_UserStatistics_Id_user] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[UserStatistics] CHECK CONSTRAINT [fk_UserStatistics_Id_user]
GO
ALTER TABLE [dbo].[UserTicket]  WITH CHECK ADD  CONSTRAINT [fk_UserTicket_Id_user] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[UserTicket] CHECK CONSTRAINT [fk_UserTicket_Id_user]
GO
ALTER TABLE [dbo].[UserTracks]  WITH CHECK ADD  CONSTRAINT [fk_UserTracks_Id_track] FOREIGN KEY([Id_track])
REFERENCES [dbo].[Track] ([Id_track])
GO
ALTER TABLE [dbo].[UserTracks] CHECK CONSTRAINT [fk_UserTracks_Id_track]
GO
ALTER TABLE [dbo].[UserTracks]  WITH CHECK ADD  CONSTRAINT [fk_UserTracks_Id_user] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Users] ([Id_user])
GO
ALTER TABLE [dbo].[UserTracks] CHECK CONSTRAINT [fk_UserTracks_Id_user]
GO
