USE [Loan_App_DB]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteTransaction]    Script Date: 07/24/2015 15:36:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_DeleteTransaction]
@TransactionId int
AS
BEGIN
update  Transactions set isdelete='True',IsActive='False' where TransactionId = @TransactionId
END
