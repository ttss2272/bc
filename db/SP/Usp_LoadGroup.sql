USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroup]    Script Date: 11/17/2015 19:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadGroup] --1
@CustomerId int
AS
BEGIN
    select '0' as GroupId,'Select' as GroupName
	union
	select gr.GroupId,gr.GroupName from Groups gr 
	inner join CustomerGroupDetails cd
	on  cd.GroupId= gr.GroupId
	 where cd.CustomerId = @CustomerId
END

--select count(*) from CustomerGroupDetails where CustomerId=1