USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchGroupwiseReport]    Script Date: 11/24/2015 13:25:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SearchGroupwiseReport]--7
@GroupId int
AS

BEGIN 

select cust.Name,gr.GroupName,gr.BCAmount,(tr.Amount-tr.Loss/tr.Member)As 'Installment',p.PaymentDate,tr.DueDate,COALESCE(DATEDIFF(DAY,tr.DueDate,p.PaymentDate),0) As 'LateDays',p.PaidAmount, p.InstallmentStatus from Payment p 
inner join Groups gr
on gr.GroupId=p.GroupId
inner join Customer cust
on cust.CustomerId=p.CustomerId
inner join Transactions tr
on tr.GroupId = gr.GroupId
where gr.GroupId=@GroupId
	
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
