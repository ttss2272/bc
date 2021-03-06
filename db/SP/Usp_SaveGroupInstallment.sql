USE [Loan_App_DB]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveGroupInstallment]    Script Date: 07/30/2015 19:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_SaveGroupInstallment]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	--@InstallmentDate date,
	--@PaymentMode nvarchar(100),
	--@ChequeNo int,
	--@PaymentAmount int,
	--@DueDate date,
	--@Balance int,
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
   GroupId ,CustomerId,ActualInstallment,ActualAmount,InstallmentStatus,IsActive,IsDelete)
   values(@InstallmentId,@GroupName,@MemberName,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@GroupId,@CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus,'True','False')
END

--select * from Customer
