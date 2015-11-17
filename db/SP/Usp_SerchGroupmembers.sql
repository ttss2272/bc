USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SerchGroupmembers]    Script Date: 10/20/2015 18:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SerchGroupmembers]-- 1
	@GroupId int
	
AS
BEGIN
 select g.GroupName ,c.CustomerID ,c.Name from Groups g 
 INNER JOIN
 CustomerGroupDetails cgd 
 on cgd.GroupId = g.GroupId
 INNER JOIN Customer c
 On c.CustomerID=cgd.CustomerID
  where cgd.GroupId = @GroupId
 
 
 

 
END
