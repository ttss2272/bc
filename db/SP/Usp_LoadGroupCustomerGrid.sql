USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupCustomerGrid]    Script Date: 10/17/2015 18:38:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,> 
-- Updated date: 08/07/2015 
-- Description: <Add Group Name,,>  
-- =============================================  
ALTER PROCEDURE [dbo].[Usp_LoadGroupCustomerGrid]  
AS  
BEGIN  
 select cgd.GroupId,gr.GroupName,Name from CustomerGroupDetails cgd inner join Groups gr on gr.GroupId=cgd.GroupId and gr.IsDeleted='False'
 ORDER  By gr.GroupName
END
