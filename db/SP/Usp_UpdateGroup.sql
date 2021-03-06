USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateGroup]    Script Date: 10/27/2015 16:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_UpdateGroup] --13,'sai2',5000,2,'2015-10-31','2015-11-19'
@Id int,
@GroupName nvarchar(100),
@BCAmount float,
@NoOfMembers int,
@StartDate date,
@EndDate date
AS
Declare @msg nvarchar(50)
BEGIN
	IF EXISTS (SELECT  * FROM Groups WHERE GroupId = @Id)
	BEGIN
		If not exists(select GroupId from Groups where GroupName=@GroupName and GroupId<>@Id)
		begin
		if not exists(Select GroupId from Transactions where GroupId=@Id)
		begin
			--UPDATE 
			update Groups set StartDate=@StartDate,EndDate=@EndDate, GroupName=@GroupName,BCAmount=@BCAmount,NoOfMembers=@NoOfMembers where GroupId = @Id
			SET @msg='1'
			select @msg
		END
		else
		begin
		SET @msg='This group transaction already done'
		select @msg
		end
		End
	End
ELSE
BEGIN
   -- INSERT 
   insert into Groups values(@GroupName,@StartDate,@EndDate,0,1,@BCAmount,@NoOfMembers)
END
END
