USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersofGroup]    Script Date: 10/16/2015 15:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetMembersofGroup] --1
@GroupId int
AS
BEGIN
    select '0' as CustomerId,'Select' as Name
	union
	select CustomerId,Name from CustomerGroupDetails where GroupId  = @GroupId 
END
