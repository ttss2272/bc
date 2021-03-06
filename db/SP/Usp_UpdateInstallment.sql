USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateInstallment]    Script Date: 10/17/2015 18:12:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_UpdateInstallment]
(
    @InstallmentId int,
	@GroupId int,
	@CustomerId int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@PendingAmount float,
	@Balance int,
	@InstallmentStatus nvarchar(50)
	
)
AS

BEGIN
  --This means the record isn't in there already, let's go ahead and add it
 
 update Installment set InstallmentDate = @InstallmentDate,PaymentMode = @PaymentMode,CheckNo = @ChequeNo,
 PaymentAmount = @PaymentAmount,DueDate = @DueDate,Balance = @Balance,InstallmentStatus=@InstallmentStatus,PendingAmount=@PendingAmount
  where InstallmentId = @InstallmentId AND GroupId=@GroupId And CustomerId=@CustomerId
END

--select * from Customer
