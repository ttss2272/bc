USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetDetailsofTransaction]    Script Date: 10/17/2015 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetDetailsofTransaction] --1,4
@GroupId int,
@MemberId int

AS
BEGIN
	select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,InstallmentDate,PaymentMode,CheckNo,
	PaymentAmount,DueDate,Balance,ActualInstallment,ActualAmount,InstallmentStatus,PendingAmount from Installment 
	where GroupId = @GroupId and CustomerId = @MemberId and InstallmentStatus='Pending' and IsDelete='False' 
END

--select Amount,[DurMonth],amountofmonth,ActualAmountforBCCustomer,ActualInstallment from Transactions 
--	where GroupId = @GroupId and CustomerId = @MemberId
