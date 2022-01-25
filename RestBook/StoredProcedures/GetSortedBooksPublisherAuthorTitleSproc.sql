USE [RestBook]
GO
/****** Object:  StoredProcedure [dbo].[GetSortedBooksPublisherAuthorTitleSproc]    Script Date: 1/25/2022 2:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetSortedBooksPublisherAuthorTitleSproc]
as 
begin
	select * 
	from dbo.Books
	order by Publisher, AuthorLastName, AuthorFirstName, Title

end