USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadInstallmentGrid]    Script Date: 10/16/2015 15:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadInstallmentGrid]
AS
BEGIN
	select GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,InstallmentDate,
	PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from Installment where InstallmentStatus='Pending' and isdelete='False'
END
