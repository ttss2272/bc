USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNamesforcustomer]    Script Date: 10/13/2015 16:00:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadGroupNamesforcustomer]
AS
BEGIN
    select '0' as GroupId,'Select' as GroupName
	union
	select GroupId,GroupName from Groups where IsDeleted = 'False'
	--select GroupId,GroupName,StartDate,EndDate from Groups where IsDeleted = 0
END
