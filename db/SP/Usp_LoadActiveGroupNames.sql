USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadActiveGroupNames]    Script Date: 10/27/2015 15:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 24Oct 2015
-- Description:	load group name whoes end date less tyhan current date for BC Transaction
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadActiveGroupNames] 
	
AS
BEGIN
	select '0' as groupid, 'SELECT' as groupname
union
select  GroupId,GroupName from Groups
 where StartDate<=CONVERT(date,GETDATE())  AND IsDeleted = 'False' AND EndDate>= CONVERT(date,GETDATE()) 
END
