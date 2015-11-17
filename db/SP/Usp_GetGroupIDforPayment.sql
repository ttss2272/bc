/****** Object:  StoredProcedure [dbo].[Usp_Usp_GetGroupIDforPayment]    Script Date: 10/14/2015 19:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 8 Aug2015
-- Description:	bind grid view
-- =============================================
Create PROCEDURE [dbo].[Usp_GetGroupIDforPayment] 
	
	@GroupID int = 0
	
AS
BEGIN
	select temp,pro.ProductName, temp.Quantity,temp.SalePrice,temp.Discount from Transactions temp

Inner join Products pro
on pro.ProductID=temp.ProductID
 where SaleTansactionID=@SaleTransactionID
END
