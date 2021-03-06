/****** Object:  StoredProcedure [dbo].[Usp_SaveCustomerDetails]    Script Date: 10/16/2015 16:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SaveCustomerDetails]
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
AS
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT 'True' FROM Customer WHERE Name = @CustomerName AND MobileNumber=@MobileNo AND CustomerID<> @CustomerId)  
BEGIN  
  --This means it exists, return it to ASP and tell us  
  set @msg = 'This record already exists!'  
   
  SELECT @msg  
END  
ELSE  
BEGIN
	set @msg =  'Record Update'  
  SELECT @msg 
		
			update Customer set 
			Name=@CustomerName,
			MobileNumber = @MobileNo,
			AlternateMobileNo =@AlterNameMobileNo,
			Address = @Address,
			Reference =@Reference , 
			Nominee =@Nominee,
			RequiredSMSnotification = @SMSRequire,
			BankName=@BankName,
			BankAccountNo = @AccountNo,
			CreatedDate=@Date,
			UpdatedDate=GETDATE(),
			IsDeleted = 0, 
			IsActive=1 where 
			CustomerId = @CustomerId
			  --SET @msg ='1'
			 -- SELECT @msg
		--end
	--ELSE
		--BEGIN
		--   insert into Customer values(@CustomerId,@CustomerName,@MobileNo,@AlterNameMobileNo,@Address,@Reference,@Nominee,@SMSRequire,@BankName,@AccountNo,@Date,GETDATE(),0,1)
		--END
End