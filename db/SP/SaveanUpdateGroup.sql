
/****** Object:  StoredProcedure [dbo].[SaveanUpdateGroup]    Script Date: 10/16/2015 17:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaveanUpdateGroup]
(
   @GroupName nvarchar(100),
   @BCAmount float,
   @NoOfMembers int,
   @StartDate date,
   @EndDate date
)
AS
declare @msg nvarchar(100) = ''
IF EXISTS(SELECT 'True' FROM Groups WHERE GroupName = @GroupName)
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
   insert into Groups (GroupName,StartDate,EndDate,IsDeleted,IsActive,BCAmount,NoOfMembers)
    values(@GroupName,@StartDate,@EndDate,0,1,@BCAmount,@NoOfMembers)
   end
