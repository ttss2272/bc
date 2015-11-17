USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchGroupwiseReport]    Script Date: 10/24/2015 20:18:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_SearchGroupwiseReport]
@GroupId int
AS
--declare @bcdatecount date 
BEGIN 
	--set @bcdatecount=(select DueDate from Installment where GroupId=@GroupId)
select i.GroupName,MemberName,BCTotalAmount,PaymentAmount, p.InstallmentStatus from  Installment as i
inner join  Payment as p on
p.InstallmentId=i.InstallmentId
where i.GroupId = @GroupId --and DueDate=@bcdatecount 
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
