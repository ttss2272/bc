USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGrid]    Script Date: 10/27/2015 11:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadGrid]
AS
BEGIN
	select GroupId,GroupName,StartDate,EndDate,BCAmount,NoOfMembers from Groups where IsDeleted =0
END
