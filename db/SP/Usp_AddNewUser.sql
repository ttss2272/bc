USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewUsers]    Script Date: 10/13/2015 15:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 11-06-2015
-- Description:	Add new user
-- =============================================
ALTER PROCEDURE [dbo].[Usp_AddNewUsers]
	--@UserType nvarchar(100),
	@UserId nvarchar(100),
	@Paswored nvarchar(100)
AS
BEGIN
	select LoginUserName,[Password],ExpiryDate from Login where  Binary_checksum(LoginUserName)=Binary_checksum(@UserId) and Binary_checksum([Password])=Binary_checksum(@Paswored)
	--insert into Login (LoginType,LoginUserName,Password) values(@UserType,@UserId,@Paswored)
END
