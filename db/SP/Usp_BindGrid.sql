USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_BindGrid]    Script Date: 10/21/2015 14:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_BindGrid]

AS
BEGIN
select TransactionId,GroupName ,Amount,DurMonth,Member,amountofmonth,Percentage,RemainingMonths,MemberList,OffcetPrice
         ,Loss,ActualAmountforBCCustomer,ActualInstallment,BcDate,DueDate,GroupId,CustomerId
         from Transactions where IsDelete='False' AND IsActive='True'
END
