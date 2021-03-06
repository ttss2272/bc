USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchMemberwiseReport]    Script Date: 11/24/2015 10:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SearchMemberwiseReport] --0,1
@GroupId int,
@CustomerId int
AS

BEGIN 


	select distinct cust.Name,gr.GroupName,tr.BcDate,tr.DueDate,(tr.Amount-tr.Loss/tr.Member)As 'Installment',
	case  pay.PendingAmount WHEN 0 Then 'Paid'  ELSE  'Pending' END AS 'Status'
	
	 from  Payment pay
inner join Groups gr
on gr.GroupId=pay.GroupId
inner join Customer cust
on cust.CustomerId=pay.CustomerId
inner join Transactions tr
on tr.GroupId=gr.GroupId


where pay.CustomerId=@CustomerId 
	
	
	--Sam comment GroupId = @GroupId and CustomerId = @CustomerId 
	---select * from Transactions t inner join Groups g on g.GroupId=t.GroupId where CustomerId = @CustomerId
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
--select * from Installment
