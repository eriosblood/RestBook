USE [RestBook]
GO
/****** Object:  StoredProcedure [dbo].[GetSortedBooksAuthorTitleSproc]    Script Date: 1/25/2022 2:32:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetSortedBooksAuthorTitleSproc]
as 
begin
	select * 
	from dbo.Books
	order by AuthorLastName, AuthorFirstName, Title

end