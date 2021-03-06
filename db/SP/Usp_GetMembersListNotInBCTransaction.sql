USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersListNotInBCTransaction]    Script Date: 10/19/2015 12:53:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetMembersListNotInBCTransaction] --1
@GroupId int
AS
BEGIN
    
	select c.CustomerID,C.Name From customer c INNER JOIN 
 CustomerGroupDetails cgd
 ON cgd.CustomerId=c.CustomerID
 Where cgd.CustomerID not in (Select cc.CustomerID From Transactions cc Inner Join groups g on g.groupID=cc.GroupID where cc. GroupID= @GroupId) AND cgd.GroupID =@GroupId

END