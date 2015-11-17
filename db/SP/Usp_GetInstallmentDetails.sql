USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentDetails]    Script Date: 10/17/2015 18:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetInstallmentDetails]
@GroupId int,
@CustomerId int
AS
BEGIN
	--Sameer change sp
     select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
	InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from  
	Installment where GroupId = @GroupId and CustomerId = @CustomerId and isdelete='False'
	
	--select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
	--InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from  
	--Installment where GroupId = @GroupId and CustomerId = @CustomerId and InstallmentStatus='Pending' and isdelete='False'
	
END
