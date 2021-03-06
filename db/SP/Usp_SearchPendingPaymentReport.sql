USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPendingPaymentReport]    Script Date: 11/24/2015 12:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_SearchPendingPaymentReport] --7,1
@GroupId int,
@CustomerId int
AS

BEGIN 

	 select Distinct cust.Name,gr.GroupName,tr.Member,tr.Loss,tr.Amount,(tr.Amount-tr.Loss/tr.Member)As 'Installment', pay.PaidAmount,pay.PendingAmount As 'PendingAmt',pay.PaymentDate,tr.DueDate,COALESCE(DATEDIFF(DAY,tr.DueDate,pay.PaymentDate),0) As 'LateDays', pay.InstallmentId
from Payment pay
inner join Groups gr
on gr.GroupId=pay.GroupId
inner join Installment i on pay.InstallmentId=i.InstallmentId
inner join Transactions tr
on tr.GroupId = i.GroupId and tr.CustomerId=i.CustomerId
inner join Customer cust
on cust.CustomerId=pay.CustomerId
where gr.GroupId=@GroupId and cust.CustomerId=@CustomerId

END
