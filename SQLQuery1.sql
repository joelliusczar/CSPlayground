
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 10/25/2017 4:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leagues](
	[LeaguePK] [int] NOT NULL,
	[LeagueName] [varchar](50) NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	[LeaguePK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Players]    Script Date: 10/25/2017 4:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerPK] [int] NOT NULL,
	[TeamFK] [int] NULL,
	[PlayerName] [varchar](50) NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 10/25/2017 4:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamPK] [int] NOT NULL,
	[LeagueFK] [int] NULL,
	[TeamName] [varchar](50) NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Leagues] ([LeaguePK], [LeagueName]) VALUES (1, N'American')
GO
INSERT [dbo].[Leagues] ([LeaguePK], [LeagueName]) VALUES (2, N'National')
GO
INSERT [dbo].[Leagues] ([LeaguePK], [LeagueName]) VALUES (3, N'Outlaw')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (1, 3, N'Greg Maddox')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (2, 3, N'John Smotes')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (3, 3, N'David Justice')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (4, 1, N'Chuck Finley')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (5, 1, N'Scott Spiezio')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (6, 1, N'Tim Salmon')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (7, 3, N'John Rocker')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (8, 2, N'Ivan Rodriguez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (9, 2, N'George Bush')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (10, 2, N'Nolan Ryan')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (11, 2, N'Juan Gonzalez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (12, 4, N'Nomar Garcia Parra')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (13, 4, N'Manny Ramirez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (14, NULL, N'Babe Ruth')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (15, NULL, N'Dude Lebowsky')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (16, 4, N'David Ortiz')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (17, 5, N'Kevin Brown')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (18, 5, N'Jack McKeon')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (19, 5, N'Jim Leeland')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (20, 5, N'Al Leiter')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (21, 6, N'Vinny Castilla')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (22, 6, N'Andres Galaraga')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (23, 7, N'Mike Piazza')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (24, 7, N'Pedro Martinez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (25, 7, N'Joe Torre')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (26, 8, N'Albert Bell')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (27, 8, N'Kenny Loftin')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (28, 8, N'Jim Tome')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (29, 8, N'David Bell')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (30, 9, N'Barry Bonds')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (31, 10, N'Ken Griffey Jr.')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (32, 10, N'Edgar Martinez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (33, 10, N'Ichiro Suzuki')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (34, 10, N'Alex Rodriguez')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (35, 11, N'George Knox')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (36, 11, N'Mel Clark')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (37, 11, N'Roger Bomman')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (38, 11, N'Ranch Wilder')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (39, 12, N'Ed Gentry')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (40, 12, N'Lewis Medlock')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (41, 12, N'Ronny Cox')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (42, 12, N'Bobby Trippe')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (43, NULL, N'Stephen Spielberg')
GO
INSERT [dbo].[Players] ([PlayerPK], [TeamFK], [PlayerName]) VALUES (44, NULL, N'C.S. Lewis')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (1, 1, N'Angels')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (2, 1, N'Rangers')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (3, 2, N'Braves')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (4, 1, N'Red Sox')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (5, 2, N'Marlins')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (6, 2, N'Rockies')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (7, 2, N'Dodgers')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (8, 1, N'Indians')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (9, 2, N'Giants')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (10, 1, N'Mariners')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (11, NULL, N'Phantoms')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (12, NULL, N'Dukes')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (13, 2, N'Expos')
GO
INSERT [dbo].[Teams] ([TeamPK], [LeagueFK], [TeamName]) VALUES (14, NULL, N'Orphans')
GO