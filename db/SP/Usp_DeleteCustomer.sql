USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomer]    Script Date: 10/16/2015 12:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_DeleteCustomer]
@CustomerId int
AS
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT CustomerId FROM CustomerGroupDetails WHERE CustomerId = @CustomerId)  
BEGIN  
  --This means it exists, return it to ASP and tell us  
  set @msg = 'This Customer Already in Group,So you cannot delete this Customer!'  
   
  SELECT @msg  
END  
Else
BEGIN
set @msg = 'Record Deleted Sucessfully..'  
   
  SELECT @msg  
update  Customer set IsDeleted = 1,IsActive=0 where CustomerId = @CustomerId
END
