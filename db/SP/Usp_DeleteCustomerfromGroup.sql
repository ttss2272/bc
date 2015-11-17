USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomerfromGroup]    Script Date: 10/21/2015 18:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_DeleteCustomerfromGroup]
@GroupId int,
@CustomerID int
AS
BEGIN
IF NOT EXISTS (SELECT TRANSACTIONID FROM Transactions WHERE GroupId = @GroupId )
BEGIN 
delete from CustomerGroupDetails where GroupId = @GroupId and CustomerID = @CustomerID
END
END
