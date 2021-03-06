USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/14/2015 11:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertCustomer]  
(  
    @CustomerId int,  
 @CustomerName nvarchar(100),  
 @MobileNo nvarchar(100),  
 @AlterNameMobileNo nvarchar(100),  
 @Address nvarchar(100),  
 @Reference nvarchar(100),  
 @Nominee  nvarchar(100),  
 @SMSRequire nvarchar(100),  
 
 @BankName nvarchar(100),  
 @AccountNo nvarchar(100),  
 
 @Date date  
)  
AS  
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT 'True' FROM Customer WHERE Name = @CustomerName AND MobileNumber=@MobileNo)  
BEGIN  
  --This means it exists, return it to ASP and tell us  
  set @msg = 'This record already exists!'  
   
  SELECT @msg  
END  
ELSE  
BEGIN  
  --This means the record isn't in there already, let's go ahead and add it  
  set @msg =  'Record Added'  
  SELECT @msg  
  INSERT INTO [Customer]([CustomerId]
           ,[Name]
           ,[MobileNumber]
           ,[AlternateMobileNo]
           ,[Address]
           ,[Reference]
           ,[Nominee]
           ,[RequiredSMSnotification]
          
           ,[BankName]
           ,[BankAccountNo]
          
           ,[CreatedDate]
           ,[UpdatedDate]
           ,[IsDeleted]
           ,[IsActive]) values(@CustomerId,@CustomerName,@MobileNo,@AlterNameMobileNo,@Address,@Reference,@Nominee,
           @SMSRequire,@BankName,@AccountNo,@Date,GETDATE(),0,1)  
END  
  
--select * from Customer
