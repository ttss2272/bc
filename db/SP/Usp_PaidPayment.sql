USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_PaidPayment]    Script Date: 10/27/2015 20:27:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sameer Shinde	
-- Create date: 19/10/2015
-- Description:	Save Payment Details
-- =============================================
ALTER PROCEDURE [dbo].[Usp_PaidPayment]
	(
	@InstallmentId int,
	@PaidAmount float,
	@PaymentDate date,
	@PaymentMode nvarchar(50),
	@ChequeNo nvarchar(50),
	@InstallmentStatus nvarchar(50),
	@PendingAmount float,
	@CustomerId int,
	@GroupId int
	)
AS
BEGIN
     insert into Payment(InstallmentId,PaidAmount,PaymentDate,CreatedDate,UpdatedDate,PaymentMode,ChequeNo,InstallmentStatus,PendingAmount,CustomerId,GroupId) values(@InstallmentId,@PaidAmount,@PaymentDate,CONVERT(datetime,GETDATE(),103),CONVERT(datetime,GETDATE(),103),@PaymentMode,@ChequeNo,@InstallmentStatus, @PendingAmount,@CustomerId,@GroupId)
   
	
END
