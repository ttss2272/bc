USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadPrivateLoanGrid]    Script Date: 10/17/2015 18:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadPrivateLoanGrid]

AS
BEGIN

	
select TransactionId,FullName AS 'Full Name',CurrentAddress AS 'Current Address',PermanantAddress AS 'Prmanant Address',EmailId AS 'Email ID',MobileNo AS 'Mobile No',[date] As 'Date',PaymentMode AS 'Payment Mode',ChequeNo AS 'Cheque No',Amount AS 'Amount',Duration AS 'Duration',Interest AS 'Interest' from PrivateLoanTransaction
END
