USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchDatabydate]    Script Date: 10/21/2015 15:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SearchDatabydate] --'2015-09-20','2016-10-20'
@FromDate date,
@ToDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 Select t.TransactionId,t.GroupName,t.Amount,t.DurMonth,t.Member,t.amountofmonth,t.Percentage,t.RemainingMonths,
t.MemberList,t.OffcetPrice,t.Loss,t.ActualAmountforBCCustomer,t.Drawa,t.ActualInstallment,
t.BcRecriverMember,t.BcDate,t.DueDate,t.Installment,t.Months,t.RunnerUpName,t.RunnerUpAmount,t.Months,t.Years,g.StartDate,g.EndDate
from Transactions t inner join Groups g on g.GroupId=t.GroupId where BcDate between @FromDate and @ToDate and g.IsDeleted='False'   
END
--select * from Transactions where BcDate between '2014-01-01' and '2015-01-01'
