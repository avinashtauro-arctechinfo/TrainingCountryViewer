USE [Test]
GO
/****** Object:  Table [dbo].[Continent]    Script Date: 21-02-2023 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 21-02-2023 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](2) NOT NULL,
	[Latitude] [decimal](10, 6) NOT NULL,
	[Longitude] [decimal](10, 6) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[ContinentId] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continent] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
/****** Object:  StoredProcedure [dbo].[GetContinentWithCountryCount]    Script Date: 21-02-2023 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetContinentWithCountryCount]
as
BEGIN
	select 
		c.Id, c.Name, count(Country.Id) as CountryCount
	from 
		Continent c
	left join
		Country
	on
		c.Id = Country.ContinentId
	group by
		c.Id, c.Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetCountriesByContinent]    Script Date: 21-02-2023 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCountriesByContinent]
(
	@ContinentName varchar(100)
)
as
BEGIN
	select
		*
	from
		Country
	where
		ContinentId = 
		(select Id from Continent where Name = @ContinentName)
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCountryByName]    Script Date: 21-02-2023 19:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SearchCountryByName]
(
	@NameSearchText varchar(100)
)
as
BEGIN
	DECLARE @WhereClause varchar(100) = @NameSearchText + '%'
	
	SELECT *
	  FROM [Test].[dbo].[Country]
	  where name like @WhereClause
END
GO
