USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetBalance]    Script Date: 10/14/2015 12:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetBalance] --1,4
@GroupId int,
@MemberId int
AS
BEGIN
	select Balance from Installment where GroupId = @GroupId and CustomerId = @MemberId and isdelete='False' and InstallmentStatus='Pending'
END
