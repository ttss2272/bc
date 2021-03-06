USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetInstallmentTransfer]    Script Date: 10/28/2015 18:26:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
ALTER PROCEDURE [dbo].[USP_GetInstallmentTransfer] --11,'2015-11-26'   
@GroupId int  , 
@CurrentDate date   
AS    
declare @year nvarchar(50)  
declare @months nvarchar(50)  
declare @bc nvarchar(50)  
set @bc=(SELECT LEFT(CONVERT(NVARCHAR, @CurrentDate, 120), 10))  
DECLARE @cnt int
set @cnt =(select COUNT (TransactionId) from Transactions where GroupId=@GroupId) 
BEGIN    
     
 ---Sameer try sp
 
 

select   cgd.CustomerGroupId,'00000' as ReceiveAmt, cust.Name,((tr.amountofmonth * @cnt)-isnull(SUM(pay.PaidAmount)  ,0) ) as PendingAmount,Convert(nvarchar(10), tr.BcDate,104) AS BcDate,'00000' as ReceiveAmt 
from  CustomerGroupDetails cgd
inner join Customer cust
on cust.CustomerId=cgd.CustomerId
inner join Groups gr
on gr.GroupId=cgd.GroupId
inner join Transactions tr
on tr.GroupId=gr.GroupId and tr.BcDate=(select MAX (BcDate) from Transactions)
left join Payment pay
on  cust.CustomerId=pay.customerId and gr.GroupId=pay.groupId

where cgd.GroupId=@GroupId 
group by cgd.CustomerGroupId,cust.Name,tr.amountofmonth,tr.BcDate
Having ((tr.amountofmonth * @cnt)-isnull(SUM(pay.PaidAmount)  ,0) )>0
  
END    
    
