USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNames]    Script Date: 10/13/2015 15:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadGroupNames]

AS
BEGIN
select '0' as groupid, 'SELECT' as groupname
union
select  GroupId,GroupName from Groups where IsDeleted = 'False'
END
