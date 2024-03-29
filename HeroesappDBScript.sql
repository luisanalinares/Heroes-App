USE [HeroesappDB]
GO
/****** Object:  Table [dbo].[hero]    Script Date: 11/2/2020 12:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hero](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[home_id] [bigint] NOT NULL,
	[name] [varchar](30) NOT NULL,
	[bio] [varchar](500) NULL,
	[image] [varchar](100) NULL,
	[first_appearance] [datetime] NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hero_home]    Script Date: 11/2/2020 12:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hero_home](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[image] [varchar](100) NULL,
	[create_date] [datetime] NOT NULL,
	[update_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[hero] ON 

INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (3, 3, N'Batman', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/batman.png', CAST(N'1939-05-01 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (5, 3, N'Linterna Verde', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/linterna-verde.png', CAST(N'1940-06-01 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (6, 1, N'Spider-Man', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/spiderman.png', CAST(N'1962-08-01 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10002, 1, N'Ant-Man', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/antman.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10003, 1, N'Capitán América', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/capitan-america.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10004, 1, N'Wolverine', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/wolverine.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10005, 3, N'Flash', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/flash.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10006, 1, N'Iron Man', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/ironman.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[hero] ([id], [home_id], [name], [bio], [image], [first_appearance], [create_date], [update_date]) VALUES (10007, 1, N'Thor', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus in hac habitasse platea dictumst vestibulum. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus. ', N'assets/img/thor.png', CAST(N'1962-08-12 00:00:00.000' AS DateTime), CAST(N'2019-10-20 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[hero] OFF
SET IDENTITY_INSERT [dbo].[hero_home] ON 

INSERT [dbo].[hero_home] ([id], [name], [image], [create_date], [update_date]) VALUES (1, N'Marvel', N'assets/img/marvel_logo.jpeg', CAST(N'2019-10-10 00:00:00.000' AS DateTime), CAST(N'2019-10-10 00:00:00.000' AS DateTime))
INSERT [dbo].[hero_home] ([id], [name], [image], [create_date], [update_date]) VALUES (3, N'DC', N'assets/img/dc_logo.jpeg', CAST(N'2019-10-10 00:00:00.000' AS DateTime), CAST(N'2019-10-10 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[hero_home] OFF
ALTER TABLE [dbo].[hero]  WITH CHECK ADD  CONSTRAINT [FK_heroes_home] FOREIGN KEY([home_id])
REFERENCES [dbo].[hero_home] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[hero] CHECK CONSTRAINT [FK_heroes_home]
GO
