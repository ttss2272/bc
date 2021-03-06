USE [Loan_App_DB]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveInstallment]    Script Date: 07/24/2015 15:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_SaveInstallment]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@Balance int,
	@GroupId int,
	@CustomerId int,
	@ActualInstallment float,
	@ActualAmount float,
	@InstallmentStatus nvarchar(50)
)
AS
declare @msg nvarchar(100) = ''
IF EXISTS(SELECT 'True' FROM Installment WHERE InstallmentId = @InstallmentId)
BEGIN
  --This means it exists, return it to ASP and tell us
  set @msg = 'This record already exists!'
 
  SELECT @msg
END
ELSE
BEGIN
  --This means the record isn't in there already, let's go ahead and add it
  set @msg =  'Record Added'
  SELECT @msg
  insert into Installment(InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
  InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance,GroupId,CustomerId,ActualInstallment,
  ActualAmount,InstallmentStatus,Isdelete,IsActive)
   values(@InstallmentId,@GroupName,@MemberName,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@InstallmentDate,@PaymentMode,@ChequeNo,@PaymentAmount,@DueDate,@Balance,@GroupId,
  @CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus,'False','True')
END

--select * from Customer
