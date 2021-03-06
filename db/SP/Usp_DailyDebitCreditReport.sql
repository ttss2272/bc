USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DailyDebitCreditReport]    Script Date: 11/24/2015 13:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

ALTER PROCEDURE [dbo].[Usp_DailyDebitCreditReport] --7
@GroupId int

AS

BEGIN 

	select c.Name,g.GroupName,g.BCAmount,tr.Installment as 'BC Installment',tr.DurMonth,tr.BcDate,p.PaymentMode,p.PaymentDate,tr.DueDate,COALESCE(DATEDIFF(DAY,tr.DueDate,p.PaymentDate),0) As 'LateDays',p.PaidAmount	
	 from Payment p 
	 inner join Installment i on p.InstallmentId=i.InstallmentId
	inner join Groups g on g.GroupId =i.GroupId
	inner join Customer c on c.CustomerId=i.CustomerId
	inner join Transactions tr on tr.GroupId=i.GroupId and tr.GroupId = g.GroupId
	
	where i.GroupId LIKE CASE WHEN @GroupId <>0 then @GroupId else CONVERT(nvarchar(50),i.GroupId ) END
	
END
