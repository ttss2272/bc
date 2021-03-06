USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetDetailsofInstallment]    Script Date: 11/17/2015 19:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetDetailsofInstallment] --10,10
@GroupId int,
@MemberId int

AS
Declare @MaxInstallmentId int
DECLARE @PendingAmount FLOAT
DECLARE @TotalAmount float
DECLARE @TotalPaidAmount float
DECLARE @BCAmount Float
DECLARE @CurrentBalance float
DECLARE @Installment float
DECLARE @forcurrent float
DECLARE @TeampCurr float


BEGIN

Set @MaxInstallmentId=(Select MAX(InstallmentId) from Installment where GroupId=@GroupId AND	CustomerId=@MemberId)
SET @TotalAmount =(Select  isnull(Sum(Installment),0) From Transactions where GroupId=@GroupId )
SET @Installment =(Select  isnull(Sum(Installment),0) From Transactions where GroupId=@GroupId )
SET @forcurrent =(Select  isnull(Sum(amountofmonth),0) From Transactions where GroupId=@GroupId )
SET @TotalPaidAmount= (SELECT isnull(SUM(p.PaidAmount),0) FROM Payment p INNER JOIN Installment i ON i.InstallmentId = p.InstallmentId where i.GroupId=@GroupId AND i.CustomerId=@MemberId)
SET @TeampCurr=@forcurrent-@Installment
SET @BCAmount = (SELECT BCAmount from Groups where GroupId=@GroupId)
	SET @PendingAmount =@TotalAmount-@TotalPaidAmount 
	SET @CurrentBalance= @BCAmount-@Installment
	SET @CurrentBalance=@CurrentBalance-@TeampCurr
	select @MaxInstallmentId As InstallmentID, DurationInMonths,@Installment As 'InstallmentAmount',BCTotalAmount,@PendingAmount AS 'PendingAmount',@CurrentBalance AS 'CurrentBalance' from Installment 
	where GroupId = @GroupId and CustomerId = @MemberId and InstallmentId=@MaxInstallmentId and IsDelete='False' 
	
	
END
