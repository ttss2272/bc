-- =============================================
-- Author:		Sameer 
-- Create date: 15/10/2015
-- Description:	Select Member which is not in selected group
-- =============================================
Alter PROCEDURE [dbo].[Usp_SerachMembersNotInGroup] --3
	@GroupId int
	
AS
BEGIN
 select DISTINCT c.CustomerId,c.Name  from Customer c
inner join CustomerGroupDetails cgg 
on cgg.CustomerId=c.CustomerId
where   c.CustomerId NOT in (select cg.CustomerId from CustomerGroupDetails cg where cg.GroupId=@GroupId AND c.IsActive=1 AND c.IsDeleted=0)
union
select DISTINCT c.CustomerId,c.Name  from Customer c
where   c.CustomerId NOT in (select cg.CustomerId from CustomerGroupDetails cg where cg.GroupId=@GroupId AND c.IsActive=1 AND c.IsDeleted=0)
 
  
END