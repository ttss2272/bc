USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadMember]    Script Date: 11/17/2015 19:28:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_LoadMember] --1

AS
BEGIN
    select '0' as CustomerId,'Select' as Name
	union
	select CustomerId,Name from Customer
END