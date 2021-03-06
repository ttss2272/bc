/****** Object:  StoredProcedure [dbo].[Usp_SearchCustomer]    Script Date: 10/17/2015 19:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SearchCustomer]-- 0,'Mahes'
	@CustomerId int,
	@CustomerName nvarchar(100)
AS
BEGIN
     select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0 
	if(@CustomerId <>0 and @CustomerName <> null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId <> 0)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId and IsDeleted = 0 
	end
	if(@CustomerName <> null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId  = 0 and @CustomerId = null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where  IsDeleted = 0 
	end
END
