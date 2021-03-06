USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_UserRegistration]    Script Date: 10/14/2015 10:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kunal
-- Create date: 18-07-2015
-- Description:	Add new user
-- =============================================
ALTER PROCEDURE [dbo].[Usp_UserRegistration]
	@UserType nvarchar(100),
	@UserId nvarchar(100),
	@Paswored nvarchar(100)
AS
declare @expirydate date
BEGIN

if not exists(Select LoginUserName from Login where LoginUserName=@UserId) 
begin
	set @expirydate=(Select DATEADD(DAY, 365, GETDATE()))
	insert into Login (LoginType,LoginUserName,Password,ExpiryDate)values(@UserType,@UserId,@Paswored,@expirydate)
	end
END
