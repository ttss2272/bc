USE [Loan_App_DB]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveSchemeDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SaveSchemeDetails]
	@BCId int,
	@BCName nvarchar(max),
	@StartDate date,
	@EndDate date,
	@Amount int,
	@Duration  nvarchar(100),
	@InstallmentDate date
AS
BEGIN
	IF EXISTS (SELECT  * FROM BCSchemeDetails WHERE BCName = @BCName)
BEGIN
    --UPDATE HERE
    update BCSchemeDetails set BCName=@BCName,StartDate = @StartDate,EndDate = @EndDate,Amount = @Amount,Duration =@Duration , InstallmentDate =@InstallmentDate where BCName=@BCName
END
ELSE
BEGIN
   -- INSERT HERE
   insert into BCSchemeDetails values(@BCId,@BCName,@StartDate,@EndDate,@Amount,@Duration,@InstallmentDate)
END
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_TransactionCustomer]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_TransactionCustomer]
@TransactionId int
AS
BEGIN
delete from tbl_TransactionDetails where TransactionId = @TransactionId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveGroupDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SaveGroupDetails]
@GroupName nvarchar(100)
AS
BEGIN
	insert into Tbl_GroupDetails values(@GroupName)
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateCustomerForGroup]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UpdateCustomerForGroup]
    @GroupcustomerId int,
	@GroupName nvarchar(100),
	@CustomerName nvarchar(100)
	
AS

BEGIN
   -- INSERT 
  update Tbl_GroupCustomerDetails set GroupName=@GroupName,CustomerName = @CustomerName where GroupCustomerId = @GroupcustomerId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SerchGroupNamesncustomerNames]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SerchGroupNamesncustomerNames] --'Tertech123','Raj'
	@GroupName nvarchar(100),
	@CustomerName nvarchar(100)
AS
BEGIN
 
  
  if(@GroupName = 'NA' and  @CustomerName = 'NA')
  begin
  select * from Tbl_GroupCustomerDetails
  end
  
  if(@GroupName <> 'NA' and  @CustomerName <> 'NA')
  begin
   select * from Tbl_GroupCustomerDetails where CustomerName = @CustomerName and GroupName = @GroupName
  end
  
  if(@GroupName <> 'NA' and @CustomerName = 'NA')
  begin
  select * from Tbl_GroupCustomerDetails where GroupName = @GroupName
  end
  
   if(@CustomerName <> 'NA' and @GroupName = 'NA')
  begin
  select * from Tbl_GroupCustomerDetails where CustomerName = @CustomerName
  end
 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveCustomerForGroup]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SaveCustomerForGroup]
	@GroupName  nvarchar(100),
	@CustomerName nvarchar(100)
	
AS

BEGIN
   -- INSERT 
   insert into Tbl_GroupCustomerDetails values(@GroupName,@CustomerName)
END
GO
/****** Object:  Table [dbo].[ReceiveInstallment]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveInstallment](
	[ReceiveInstallmentId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
	[MemberName] [nvarchar](100) NOT NULL,
	[BCTotalAmount] [int] NULL,
	[DurationInMonths] [int] NULL,
	[InstallmentAmount] [int] NULL,
	[InstallmentDate] [date] NULL,
	[PaymentMode] [nvarchar](100) NULL,
	[CheckNo] [int] NULL,
	[PaymentAmount] [int] NULL,
	[DueDate] [date] NULL,
	[Balance] [int] NULL,
	[GroupId] [int] NULL,
	[CustomerId] [int] NULL,
	[ActualInstallment] [float] NULL,
	[ActualAmount] [float] NULL,
	[InstallmentStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_ReceiveInstallment] PRIMARY KEY CLUSTERED 
(
	[ReceiveInstallmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ReceiveInstallment] ON
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (1, N'Teratech BC', N'raj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (2, N'Teratech BC', N'ram', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (3, N'Teratech BC', N'lakhan', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (4, N'Teratech BC', N'swapnil', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (5, N'Teratech BC', N'Pritesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (6, N'Teratech BC', N'Purva', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (7, N'Teratech BC', N'Priti', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (8, N'Teratech BC', N'Rajesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (9, N'Teratech BC', N'Ramesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (10, N'Teratech BC', N'Pritesh s', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (11, N'Teratech BC', N'Manoj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (12, N'Teratech BC', N'Suresh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (13, N'Teratech BC', N'Lalit', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (14, N'Teratech BC', N'Yogita', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (15, N'Teratech BC', N'Pratik', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (16, N'Teratech BC', N'Prashant', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (17, N'Teratech BC', N'Test Kalpesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (18, N'Teratech BC', N'vishal', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (19, N'Teratech BC', N'raj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (20, N'Teratech BC', N'ram', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (21, N'Teratech BC', N'lakhan', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (22, N'Teratech BC', N'swapnil', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (23, N'Teratech BC', N'Pritesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (24, N'Teratech BC', N'Purva', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (25, N'Teratech BC', N'Priti', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (26, N'Teratech BC', N'Rajesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (27, N'Teratech BC', N'Ramesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (28, N'Teratech BC', N'Pritesh s', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (29, N'Teratech BC', N'Manoj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (30, N'Teratech BC', N'Suresh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (31, N'Teratech BC', N'Lalit', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (32, N'Teratech BC', N'Yogita', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (33, N'Teratech BC', N'Pratik', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (34, N'Teratech BC', N'Prashant', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (35, N'Teratech BC', N'Test Kalpesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (36, N'Teratech BC', N'vishal', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (37, N'Teratech BC', N'raj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (38, N'Teratech BC', N'ram', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (39, N'Teratech BC', N'lakhan', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (40, N'Teratech BC', N'swapnil', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (41, N'Teratech BC', N'Pritesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (42, N'Teratech BC', N'Purva', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (43, N'Teratech BC', N'Priti', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (44, N'Teratech BC', N'Rajesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (45, N'Teratech BC', N'Ramesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (46, N'Teratech BC', N'Pritesh s', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (47, N'Teratech BC', N'Manoj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (48, N'Teratech BC', N'Suresh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (49, N'Teratech BC', N'Lalit', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (50, N'Teratech BC', N'Yogita', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (51, N'Teratech BC', N'Pratik', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (52, N'Teratech BC', N'Prashant', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (53, N'Teratech BC', N'Test Kalpesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (54, N'Teratech BC', N'vishal', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 11641, 220000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (55, N'Teratech BC', N'raj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (56, N'Teratech BC', N'ram', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (57, N'Teratech BC', N'lakhan', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (58, N'Teratech BC', N'swapnil', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (59, N'Teratech BC', N'Pritesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (60, N'Teratech BC', N'Purva', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (61, N'Teratech BC', N'Priti', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (62, N'Teratech BC', N'Rajesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (63, N'Teratech BC', N'Ramesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (64, N'Teratech BC', N'Pritesh s', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (65, N'Teratech BC', N'Manoj', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (66, N'Teratech BC', N'Suresh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (67, N'Teratech BC', N'Lalit', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (68, N'Teratech BC', N'Yogita', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (69, N'Teratech BC', N'Pratik', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (70, N'Teratech BC', N'Prashant', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (71, N'Teratech BC', N'Test Kalpesh', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
INSERT [dbo].[ReceiveInstallment] ([ReceiveInstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus]) VALUES (72, N'Teratech BC', N'vishal', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, 10557, 200000, NULL)
SET IDENTITY_INSERT [dbo].[ReceiveInstallment] OFF
/****** Object:  Table [dbo].[PrivateLoanTransaction]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivateLoanTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [int] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[CurrentAddress] [nvarchar](100) NULL,
	[PermanantAddress] [nvarchar](100) NULL,
	[EmailId] [nvarchar](100) NULL,
	[date] [date] NULL,
	[PaymentMode] [nvarchar](100) NULL,
	[ChequeNo] [nvarchar](100) NULL,
	[Amount] [float] NULL,
	[Duration] [nvarchar](100) NULL,
	[Interest] [float] NULL,
	[MobileNo] [nvarchar](100) NULL,
 CONSTRAINT [PK_PrivateLoanTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PrivateLoanTransaction] ON
INSERT [dbo].[PrivateLoanTransaction] ([Id], [TransactionId], [FullName], [CurrentAddress], [PermanantAddress], [EmailId], [date], [PaymentMode], [ChequeNo], [Amount], [Duration], [Interest], [MobileNo]) VALUES (1, 1, N'Kunal S Shinde', N'Pune', N'Satara', N'kunalshihnde39@gmail.com', CAST(0x303A0B00 AS Date), N'CASH', N'', 100000, N'1 year', 10, N'7385935093')
SET IDENTITY_INSERT [dbo].[PrivateLoanTransaction] OFF
/****** Object:  Table [dbo].[LoginType]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginType](
	[LoginTypeId] [int] IDENTITY(1,1) NOT NULL,
	[LoginTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LoginType] PRIMARY KEY CLUSTERED 
(
	[LoginTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginuserId] [int] IDENTITY(1,1) NOT NULL,
	[LoginUserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[LoginType] [nvarchar](100) NULL,
	[ExpiryDate] [date] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginuserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([LoginuserId], [LoginUserName], [Password], [LoginType], [ExpiryDate]) VALUES (2, N'mahesh123', N'123456', N'Accountant', CAST(0x403A0B00 AS Date))
INSERT [dbo].[Login] ([LoginuserId], [LoginUserName], [Password], [LoginType], [ExpiryDate]) VALUES (3, N'kunalshinde39@gmail.com', N'kunal3991', N'Admin', CAST(0x3E3A0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[Groups]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (1, N'10-lakh', CAST(0x293A0B00 AS Date), CAST(0x973B0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (2, N'88-lakhss', CAST(0x293A0B00 AS Date), CAST(0x293A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (3, N'20-lakh', CAST(0x233A0B00 AS Date), CAST(0x333A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (4, N'55-lakh', CAST(0x293A0B00 AS Date), CAST(0x293A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (5, N'1 Lakh', CAST(0x283A0B00 AS Date), CAST(0x333A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (6, N'15-lakh', CAST(0x01380B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (7, N'5lakhP_group', CAST(0x323A0B00 AS Date), CAST(0xCB3A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (8, N'Test', CAST(0x233A0B00 AS Date), CAST(0x343A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (9, N'Demo', CAST(0x233A0B00 AS Date), CAST(0x343A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (10, N'Demo2', CAST(0x01380B00 AS Date), CAST(0x8C390B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (11, N'Demo3', CAST(0x233A0B00 AS Date), CAST(0x343A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (12, N'TEST1', CAST(0x01380B00 AS Date), CAST(0x383A0B00 AS Date), 1, 1)
INSERT [dbo].[Groups] ([GroupId], [GroupName], [StartDate], [EndDate], [IsDeleted], [IsActive]) VALUES (13, N'Teratech BC', CAST(0x3A3A0B00 AS Date), CAST(0x3A3A0B00 AS Date), 0, 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
/****** Object:  Table [dbo].[Customer]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[MobileNumber] [nvarchar](50) NOT NULL,
	[AlternateMobileNo] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Reference] [nvarchar](100) NULL,
	[Nominee] [nvarchar](100) NULL,
	[RequiredSMSnotification] [nvarchar](100) NULL,
	[BankName] [nvarchar](100) NULL,
	[BankAccountNo] [nvarchar](max) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[IsDeleted] [int] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [employees_pk] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (1, 1, N'raj', N'9825140365', N'nmnm', N'jkjkl', N'jkjkjk', N'jhhjjh', N'No', N'jkkj', N'8888', CAST(0x333A0B00 AS Date), CAST(0x333A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (2, 2, N'ram', N'6666666666', N'mnmn', N'nmnm', N'nmnm', N'bnbn', N'yes', N'nnm', N'8777', CAST(0x293A0B00 AS Date), CAST(0x293A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (3, 3, N'lakhan', N'8585858585', N'nnm', N'jkjkkj', N'kjjk', N'bnbn', N'yes', N'kjjkjk', N'4555', CAST(0x293A0B00 AS Date), CAST(0x293A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (4, 4, N'Snehal', N'1212121212', N'', N'jalgaon District', N'', N'Mother', N'yes', N'Janata', N'012547863', CAST(0x3A3A0B00 AS Date), CAST(0x3A3A0B00 AS Date), 1, 0)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (5, 5, N'swapnil', N'8796541231', N'', N'Jalna', N'', N'Father', N'yes', N'ICICI', N'012135464', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (6, 6, N'Pritesh', N'6859123475', N'', N'Jalna', N'', N'Father', N'yes', N'MAH', N'0132341654', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (7, 7, N'Purva', N'8896541234', N'', N'Nasik', N'', N'Brother', N'yes', N'Dutch', N'.215745342', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (8, 8, N'Priti', N'.985623147', N'9845632147', N'Tuljapur', N'', N'Bhavani', N'yes', N'Tuljapur Branch', N'012345668', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (9, 9, N'Rajesh', N'7896541235', N'', N'Aurangabad', N'', N'Father', N'yes', N'City Bank', N'0213546756', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (10, 10, N'Ramesh', N'9876584655', N'3254352435', N'Delhi', N'', N'Mother', N'yes', N'Delhi Bank', N'546535454', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (11, 11, N'Pritesh s', N'6786466465', N'', N'Aug', N'', N'Brother', N'yes', N'AGBD Bank', N'3646465564', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (12, 12, N'Manoj', N'3543544557', N'', N'Mumbai', N'', N'Father', N'yes', N'Janata', N'1245252', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (13, 13, N'Suresh', N'6876545654', N'', N'Pune', N'', N'Mother', N'yes', N'SBI', N'01224562', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (14, 14, N'Lalit', N'5486765456', N'', N'Jalgaon', N'', N'Brother', N'yes', N'Jalgaon Dist', N'254564545', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (15, 15, N'Yogita', N'5875453451', N'', N'Mumbai', N'', N'df', N'yes', N'xyz', N'523423', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (16, 16, N'Pratik', N'7895545554', N'', N'Hadapsar', N'', N'rfgf', N'yes', N'jhgjh', N'565', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (17, 17, N'abc', N'2345456567', N'', N'Pune', N'', N'fgfg', N'yes', N'Mah', N'32432453254', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (18, 18, N'Prashant', N'7565635345', N'', N'tyghgh', N'', N'ghgfh', N'yes', N'dfh', N'546546', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (19, 19, N'jgujhg', N'5674587465', N'', N'ljkhjkl', N'', N'kgb', N'yes', N'hgk', N'64654', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (20, 20, N'gffgg', N'3454366789', N'', N'xdvfg', N'', N'fvg', N'yes', N'dfdsf', N'324324', CAST(0x2A3A0B00 AS Date), CAST(0x2A3A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (21, 21, N'Test Kalpesh', N'9096589681', N'9405802450', N'Pune', N'23', N'NA', N'yes', N'SBI', N'1234564896', CAST(0x313A0B00 AS Date), CAST(0x313A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (22, 22, N'XYZ', N'1234657890', N'', N'pune', N'', N'', N'No', N'', N'', CAST(0x313A0B00 AS Date), CAST(0x313A0B00 AS Date), 1, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (23, 23, N'vishal', N'8087087424', N'', N'pune', N'', N'', N'No', N'', N'', CAST(0x323A0B00 AS Date), CAST(0x323A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (24, 24, N'nilkesh1', N'8888888888', N'', N'paratwada', N'', N'', N'No', N'No', N'', CAST(0x323A0B00 AS Date), CAST(0x323A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (25, 25, N'CUST1', N'8087087424', N'', N'PUNE', N'', N'', N'No', N'', N'', CAST(0x363A0B00 AS Date), CAST(0x363A0B00 AS Date), 0, 1)
INSERT [dbo].[Customer] ([Id], [CustomerId], [Name], [MobileNumber], [AlternateMobileNo], [Address], [Reference], [Nominee], [RequiredSMSnotification], [BankName], [BankAccountNo], [CreatedDate], [UpdatedDate], [IsDeleted], [IsActive]) VALUES (26, 26, N'Demo', N'8452139658', N'', N'Pune', N'', N'', N'yes', N'', N'', CAST(0x373A0B00 AS Date), CAST(0x373A0B00 AS Date), 0, 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
/****** Object:  StoredProcedure [dbo].[Usp_AddNewUsers]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 11-06-2015
-- Description:	Add new user
-- =============================================
CREATE PROCEDURE [dbo].[Usp_AddNewUsers]
	--@UserType nvarchar(100),
	@UserId nvarchar(100),
	@Paswored nvarchar(100)
AS
BEGIN
	select LoginUserName,Password,ExpiryDate from Login where LoginUserName=@UserId and Password=@Paswored
	--insert into Login (LoginType,LoginUserName,Password) values(@UserType,@UserId,@Paswored)
END
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[DurMonth] [int] NOT NULL,
	[Member] [int] NOT NULL,
	[amountofmonth] [float] NOT NULL,
	[Percentage] [float] NULL,
	[RemainingMonths] [int] NULL,
	[MemberList] [nvarchar](max) NULL,
	[OffcetPrice] [float] NOT NULL,
	[Loss] [float] NULL,
	[ActualAmountforBCCustomer] [float] NULL,
	[Drawa] [float] NULL,
	[ActualInstallment] [float] NULL,
	[BcRecriverMember] [nvarchar](100) NULL,
	[BcDate] [date] NULL,
	[DueDate] [date] NULL,
	[Installment] [int] NULL,
	[GroupName] [nvarchar](100) NULL,
	[CustomerId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Drawa1Name] [nvarchar](50) NULL,
	[Drawa2Amount] [int] NULL,
	[Drawa2Name] [nvarchar](50) NULL,
	[RunnerUpName] [nvarchar](50) NULL,
	[RunnerUpAmount] [int] NULL,
	[Months] [nvarchar](50) NULL,
	[Years] [nvarchar](50) NULL,
	[IsDelete] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions] ([Id], [TransactionId], [Amount], [DurMonth], [Member], [amountofmonth], [Percentage], [RemainingMonths], [MemberList], [OffcetPrice], [Loss], [ActualAmountforBCCustomer], [Drawa], [ActualInstallment], [BcRecriverMember], [BcDate], [DueDate], [Installment], [GroupName], [CustomerId], [GroupId], [Drawa1Name], [Drawa2Amount], [Drawa2Name], [RunnerUpName], [RunnerUpAmount], [Months], [Years], [IsDelete], [IsActive]) VALUES (1, 1, 400000, 19, 19, 21052, 2, 19, N'raj', 152000, 190000, 210000, 100, 11115, N'raj', CAST(0x3A3A0B00 AS Date), CAST(0x1D3A0B00 AS Date), 11052, N'Teratech BC', 1, 13, N'Prashant', 100, N'Select', N'Select', 1000, N'06', N'2015', NULL, NULL)
INSERT [dbo].[Transactions] ([Id], [TransactionId], [Amount], [DurMonth], [Member], [amountofmonth], [Percentage], [RemainingMonths], [MemberList], [OffcetPrice], [Loss], [ActualAmountforBCCustomer], [Drawa], [ActualInstallment], [BcRecriverMember], [BcDate], [DueDate], [Installment], [GroupName], [CustomerId], [GroupId], [Drawa1Name], [Drawa2Amount], [Drawa2Name], [RunnerUpName], [RunnerUpAmount], [Months], [Years], [IsDelete], [IsActive]) VALUES (2, 2, 400000, 19, 19, 21052, 2, 18, N'Snehal', 144000, 180000, 220000, 100, 11641, N'Snehal', CAST(0x3A3A0B00 AS Date), CAST(0xEC390B00 AS Date), 11578, N'Teratech BC', 4, 13, N'Test Kalpesh', 100, N'vishal', N'Suresh', 1000, N'05', N'2015', NULL, NULL)
INSERT [dbo].[Transactions] ([Id], [TransactionId], [Amount], [DurMonth], [Member], [amountofmonth], [Percentage], [RemainingMonths], [MemberList], [OffcetPrice], [Loss], [ActualAmountforBCCustomer], [Drawa], [ActualInstallment], [BcRecriverMember], [BcDate], [DueDate], [Installment], [GroupName], [CustomerId], [GroupId], [Drawa1Name], [Drawa2Amount], [Drawa2Name], [RunnerUpName], [RunnerUpAmount], [Months], [Years], [IsDelete], [IsActive]) VALUES (3, 3, 400000, 19, 19, 21052, 2, 17, N'raj', 136000, 200000, 200000, 100, 10557, N'raj', CAST(0x3A3A0B00 AS Date), CAST(0xCD390B00 AS Date), 10526, N'Teratech BC', 1, 13, N'Suresh', 200, N'Rajesh', N'Rajesh', 300, N'04', N'2015', N'False', N'True')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
/****** Object:  StoredProcedure [dbo].[text_Sp]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh Sortee
-- Create date: 
-- Description:	read text file
-- =============================================
CREATE PROCEDURE [dbo].[text_Sp] 
@Id  int,
@Name nvarchar(50),
@LastName 	nvarchar(50),
@ContactNo nvarchar(50)

AS
Declare @TempId int =0
BEGIN
set @TempId= (select GroupId from Groups where GroupId=@Id)

   if (@TempId=0)
    begin
		Insert into Groups (GroupName,StartDate,EndDate)values (@Name,@LastName,@ContactNo)
	end
   else
	begin
		update Groups set GroupName=@Name,StartDate=@LastName,EndDate=@ContactNo
	end
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[checklogin]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checklogin]
@Username varchar(50),
@Password varchar(50),
@LoginType varchar(50)
AS
BEGIN
	if exists(select LoginuserId  from Login where LoginUserName =@Username and Password=@Password and LoginType = @LoginType)
	begin
	select * from Login where LoginUserName=@Username and Password=@Password and LoginType = @LoginType	
	end
END
GO
/****** Object:  Table [dbo].[CustomerGroupDetails]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerGroupDetails](
	[CustomerGroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_CustomerGroupDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerGroupDetails] ON
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (1, 13, 1, N'raj')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (2, 13, 2, N'ram')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (3, 13, 3, N'lakhan')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (4, 13, 4, N'Snehal')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (5, 13, 5, N'swapnil')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (6, 13, 6, N'Pritesh')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (7, 13, 7, N'Purva')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (8, 13, 8, N'Priti')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (9, 13, 9, N'Rajesh')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (10, 13, 10, N'Ramesh')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (11, 13, 11, N'Pritesh s')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (12, 13, 12, N'Manoj')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (13, 13, 13, N'Suresh')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (14, 13, 14, N'Lalit')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (15, 13, 15, N'Yogita')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (16, 13, 16, N'Pratik')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (17, 13, 18, N'Prashant')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (18, 13, 21, N'Test Kalpesh')
INSERT [dbo].[CustomerGroupDetails] ([CustomerGroupId], [GroupId], [CustomerId], [Name]) VALUES (19, 13, 23, N'vishal')
SET IDENTITY_INSERT [dbo].[CustomerGroupDetails] OFF
/****** Object:  Table [dbo].[Installment]    Script Date: 07/25/2015 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InstallmentId] [int] NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
	[MemberName] [nvarchar](100) NOT NULL,
	[BCTotalAmount] [int] NULL,
	[DurationInMonths] [int] NULL,
	[InstallmentAmount] [int] NULL,
	[InstallmentDate] [date] NULL,
	[PaymentMode] [nvarchar](100) NULL,
	[CheckNo] [int] NULL,
	[PaymentAmount] [int] NULL,
	[DueDate] [date] NULL,
	[Balance] [int] NULL,
	[GroupId] [int] NULL,
	[CustomerId] [int] NULL,
	[ActualInstallment] [float] NULL,
	[ActualAmount] [float] NULL,
	[InstallmentStatus] [nvarchar](50) NULL,
	[IsDelete] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
 CONSTRAINT [PK_Installment] PRIMARY KEY CLUSTERED 
(
	[InstallmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Installment] ON
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (1, 1, N'Teratech BC', N'raj', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 1, 11641, 220000, N'Pending', N'True', N'False')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (2, 2, N'Teratech BC', N'ram', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 2, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (3, 3, N'Teratech BC', N'lakhan', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 3, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (4, 4, N'Teratech BC', N'Snehal', 400000, 19, 21052, CAST(0x063A0B00 AS Date), N'CASH', 0, 9000, CAST(0x303A0B00 AS Date), 391000, 13, 4, 11641, 220000, N'Paid', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (5, 5, N'Teratech BC', N'swapnil', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 5, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (6, 6, N'Teratech BC', N'Pritesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 6, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (7, 7, N'Teratech BC', N'Purva', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 7, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (8, 8, N'Teratech BC', N'Priti', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 8, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (9, 9, N'Teratech BC', N'Rajesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 9, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (10, 10, N'Teratech BC', N'Ramesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 10, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (11, 11, N'Teratech BC', N'Pritesh s', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 11, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (12, 12, N'Teratech BC', N'Manoj', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 12, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (13, 13, N'Teratech BC', N'Suresh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 13, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (14, 14, N'Teratech BC', N'Lalit', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 14, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (15, 15, N'Teratech BC', N'Yogita', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 15, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (16, 16, N'Teratech BC', N'Pratik', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 16, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (17, 17, N'Teratech BC', N'Prashant', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 18, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (18, 18, N'Teratech BC', N'Test Kalpesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 21, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (19, 19, N'Teratech BC', N'vishal', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 23, 11641, 220000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (20, 20, N'Teratech BC', N'raj', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 1, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (21, 21, N'Teratech BC', N'ram', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 2, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (22, 22, N'Teratech BC', N'lakhan', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 3, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (23, 23, N'Teratech BC', N'Snehal', 400000, 19, 21052, CAST(0x313A0B00 AS Date), N'CASH', 0, 5000, CAST(0x233A0B00 AS Date), 395000, 13, 4, 10557, 200000, N'Paid', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (24, 24, N'Teratech BC', N'swapnil', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 5, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (25, 25, N'Teratech BC', N'Pritesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 6, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (26, 26, N'Teratech BC', N'Purva', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 7, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (27, 27, N'Teratech BC', N'Priti', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 8, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (28, 28, N'Teratech BC', N'Rajesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 9, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (29, 29, N'Teratech BC', N'Ramesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 10, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (30, 30, N'Teratech BC', N'Pritesh s', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 11, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (31, 31, N'Teratech BC', N'Manoj', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 12, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (32, 32, N'Teratech BC', N'Suresh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 13, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (33, 33, N'Teratech BC', N'Lalit', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 14, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (34, 34, N'Teratech BC', N'Yogita', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 15, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (35, 35, N'Teratech BC', N'Pratik', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 16, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (36, 36, N'Teratech BC', N'Prashant', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 18, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (37, 37, N'Teratech BC', N'Test Kalpesh', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 21, 10557, 200000, N'Pending', N'False', N'True')
INSERT [dbo].[Installment] ([Id], [InstallmentId], [GroupName], [MemberName], [BCTotalAmount], [DurationInMonths], [InstallmentAmount], [InstallmentDate], [PaymentMode], [CheckNo], [PaymentAmount], [DueDate], [Balance], [GroupId], [CustomerId], [ActualInstallment], [ActualAmount], [InstallmentStatus], [IsDelete], [IsActive]) VALUES (38, 38, N'Teratech BC', N'vishal', 400000, 19, 21052, NULL, NULL, NULL, NULL, NULL, NULL, 13, 23, 10557, 200000, N'Pending', N'False', N'True')
SET IDENTITY_INSERT [dbo].[Installment] OFF
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer]  
(  
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
)  
AS  
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT 'True' FROM Customer WHERE Name = @CustomerName)  
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
  INSERT INTO [Customer]([CustomerId]
           ,[Name]
           ,[MobileNumber]
           ,[AlternateMobileNo]
           ,[Address]
           ,[Reference]
           ,[Nominee]
           ,[RequiredSMSnotification]
          
           ,[BankName]
           ,[BankAccountNo]
          
           ,[CreatedDate]
           ,[UpdatedDate]
           ,[IsDeleted]
           ,[IsActive]) values(@CustomerId,@CustomerName,@MobileNo,@AlterNameMobileNo,@Address,@Reference,@Nominee,
           @SMSRequire,@BankName,@AccountNo,@Date,GETDATE(),0,1)  
END  
  
--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[SaveanUpdateGroup]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveanUpdateGroup]
(
   @GroupName nvarchar(100),
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
   insert into Groups values(@GroupName,@StartDate,@EndDate,0,1)
   end
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomer]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteCustomer]
@CustomerId int
AS
BEGIN
update  Customer set IsDeleted = 1,IsActive=0 where CustomerId = @CustomerId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteGroup]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteGroup]
@GroupId int
AS
BEGIN
update Groups  set IsDeleted = 'True',IsActive='False' where GroupId = @GroupId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeletePrivateLoanDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_DeletePrivateLoanDetails]
@CustomerId int
AS
BEGIN
delete from PrivateLoanTransaction where TransactionId = @CustomerId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteUser]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 11-06-2015
-- Description:	Add new user
-- =============================================
create PROCEDURE [dbo].[Usp_DeleteUser]
	@UserId nvarchar(100)

AS
BEGIN
delete from [Login] where LoginUserName = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetCustomerId]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetCustomerId] 

AS
BEGIN
select MAX(CustomerId) +1 from Customer
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupId1]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[Usp_GetGroupId1] 
	@GroupId int
AS
BEGIN
	select Groups.GroupId,Customer.CustomerId,Customer.Name from Groups 
	INNER JOIN Customer
	on Groups.GroupId = @GroupId
	
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupId]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetGroupId] 
	@GroupName nvarchar(100)
AS
BEGIN
	select Groups.GroupId,Customer.CustomerId,Customer.Name from Groups 
	INNER JOIN Customer
	on Groups.GroupName = @GroupName
	
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetLoanId]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_GetLoanId]

AS
BEGIN
select MAX(TransactionId)+ 1 from PrivateLoanTransaction
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGrid]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadGrid]
AS
BEGIN
	select GroupId,GroupName,StartDate,EndDate from Groups where IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadCustomerGroup]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadCustomerGroup]
AS
BEGIN
	select CustomerId,Name from Customer
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupNames]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetGroupNames]
@GroupName nvarchar(100)
AS
BEGIN
select GroupId,GroupName,StartDate,EndDate from Groups where GroupName = @GroupName and IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNamesforcustomer]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadGroupNamesforcustomer]
AS
BEGIN
	select GroupId,GroupName,StartDate,EndDate from Groups where IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNames]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadGroupNames]

AS
BEGIN
select '0' as groupid, 'SELECT' as groupname
union
select  GroupId,GroupName from Groups where IsDeleted = 'False'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveCustomerDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SaveCustomerDetails]
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
BEGIN
	IF EXISTS (SELECT  * FROM Customer WHERE CustomerId = @CustomerId)
BEGIN
    --UPDATE 
    update Customer set Name=@CustomerName,MobileNumber = @MobileNo,AlternateMobileNo =@AlterNameMobileNo,Address = @Address,
    Reference =@Reference , Nominee =@Nominee,RequiredSMSnotification = @SMSRequire,BankName=@BankName,BankAccountNo = @AccountNo,CreatedDate=@Date,UpdatedDate=GETDATE(),IsDeleted = 0, IsActive=1 where CustomerId = @CustomerId
END
ELSE
BEGIN
   -- INSERT 
   insert into Customer values(@CustomerId,@CustomerName,@MobileNo,@AlterNameMobileNo,@Address,@Reference,@Nominee,@SMSRequire,@BankName,@AccountNo,@Date,GETDATE(),0,1)
END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ReceiveInstallment]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh Sortee
-- Create date: 
-- Description:	read text file
-- =============================================
CREATE PROCEDURE [dbo].[USP_ReceiveInstallment] 
@ReceiveInstallmentId int,
@GroupName nvarchar(100),
@MemberName nvarchar(100),
@ActualInstallment float,
@ActualAmount float,
@PaymentAmount int,
@Balance int,
@InstallmentDate date

AS
--Declare @TempId int =0
BEGIN
--set @TempId= (select InstallmentId from Installment where MemberName=@MemberName) 
   --if (@ReceiveInstallmentId=0)
    begin
		Insert into  ReceiveInstallment(GroupName,MemberName,ActualInstallment,ActualAmount,PaymentAmount,
		Balance,InstallmentDate)
		values (@GroupName,@MemberName,@ActualInstallment,@ActualAmount,@PaymentAmount,@Balance,@InstallmentDate)
	end
 --  else
	--begin
	--	update ReceiveInstallment set --InstallmentId=@InstallmentId,
	--	GroupName=@GroupName,MemberName=@MemberName,ActualInstallment=@ActualInstallment
	--	,ActualAmount=@ActualAmount,PaymentAmount=@PaymentAmount,Balance=@Balance,InstallmentDate=@InstallmentDate 
	--	where ReceiveInstallmentId=@ReceiveInstallmentId
	--end 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadPrivateLoanGrid]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_LoadPrivateLoanGrid]

AS
BEGIN

	
select TransactionId,FullName,CurrentAddress,PermanantAddress,EmailId,MobileNo,[date],PaymentMode,ChequeNo,Amount,Duration,Interest from PrivateLoanTransaction
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SavePrivateLoanDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SavePrivateLoanDetails]
(
    @TransactionId int,
	@FullName nvarchar(100),
	@CurrentAddress nvarchar(100),
	@PermanantAddress nvarchar(100),
	@EmailId nvarchar(100),
	
	@TransactionDate date,
	@PymentMode nvarchar(100),
	@ChequeNo nvarchar(100),
	@Amount decimal,
	@Duration nvarchar(100),
	@Interest decimal,
	@MobileNO nvarchar(100)
	
)
AS
declare @msg nvarchar(100) = ''
IF EXISTS(SELECT 'True' FROM PrivateLoanTransaction WHERE TransactionId = @TransactionId)
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
  insert into PrivateLoanTransaction values(@TransactionId,@FullName,@CurrentAddress,@PermanantAddress,@EmailId,@TransactionDate,@PymentMode,@ChequeNo,@Amount,@Duration,@Interest,@MobileNO)
END

--select * from PrivateLoanTransaction
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchCustomer]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchCustomer]-- 0,'Mahes'
	@CustomerId int,
	@CustomerName nvarchar(100)
AS
BEGIN
     select CustomerId,Name,MobileNumber,AlternateMobileNo,Address,Reference,Nominee,RequiredSMSnotification,BankName,BankAccountNo,CreatedDate  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0 
	if(@CustomerId <>0 and @CustomerName <> null)
	begin
	select CustomerId,Name,MobileNumber,AlternateMobileNo,Address,Reference,Nominee,RequiredSMSnotification,BankName,BankAccountNo ,CreatedDate  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId <> 0)
	begin
	select CustomerId,Name,MobileNumber,AlternateMobileNo,Address,Reference,Nominee,RequiredSMSnotification,BankName,BankAccountNo,CreatedDate  from Customer where CustomerId = @CustomerId and IsDeleted = 0 
	end
	if(@CustomerName <> null)
	begin
	select CustomerId,Name,MobileNumber,AlternateMobileNo,Address,Reference,Nominee,RequiredSMSnotification,BankName,BankAccountNo,CreatedDate  from Customer where Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId  = 0 and @CustomerId = null)
	begin
	select CustomerId,Name,MobileNumber,AlternateMobileNo,Address,Reference,Nominee,RequiredSMSnotification,BankName,BankAccountNo,CreatedDate  from Customer where  IsDeleted = 0 
	end
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchAllUsers]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchAllUsers]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT LoginUserName,[Password],LoginType from login
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchUsersByUserType]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchUsersByUserType]
@Usertype nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT LoginUserName,[Password],LoginType from login where LoginType = @Usertype
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPrivateLoanDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchPrivateLoanDetails]
	-- Add the parameters for the stored procedure here
	@CustomerName nvarchar(100)
AS
BEGIN
select * from PrivateLoanTransaction where 	FullName like @CustomerName
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateGroup]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UpdateGroup]
@Id int,
@GroupName nvarchar(100),
@StartDate date,
@EndDate date
AS

BEGIN
	IF EXISTS (SELECT  * FROM Groups WHERE GroupId = @Id)
BEGIN
    --UPDATE 
    update Groups set StartDate=@StartDate,EndDate=@EndDate, GroupName=@GroupName where GroupId = @Id
END
ELSE
BEGIN
   -- INSERT 
   insert into Groups values(@GroupName,@StartDate,@EndDate,0,1)
END
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UserRegistration]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kunal
-- Create date: 18-07-2015
-- Description:	Add new user
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UserRegistration]
	@UserType nvarchar(100),
	@UserId nvarchar(100),
	@Paswored nvarchar(100)
AS
declare @expirydate date
BEGIN

if not exists(Select LoginUserName from Login where LoginUserName=@UserId) 
	set @expirydate=(Select DATEADD(DAY, 10, GETDATE()))
	insert into Login (LoginType,LoginUserName,Password,ExpiryDate)values(@UserType,@UserId,@Paswored,@expirydate)
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateUser]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UpdateUser]
@Usertype nvarchar(50),
@UserName nvarchar(50),
@Password nvarchar(50)
AS
declare @expirydate date
BEGIN 
	SET NOCOUNT ON; 
	set @expirydate=(Select DATEADD(DAY, 10, GETDATE()))
	update login set LoginUserName = @UserName, [Password] = @Password,LoginType=@Usertype ,ExpiryDate=@expirydate  where LoginType = @Usertype
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdatePrivateLoanDetails]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_UpdatePrivateLoanDetails]
(
    @TransactionId int,
	@FullName nvarchar(100),
	@CurrentAddress nvarchar(100),
	@PermanantAddress nvarchar(100),
	@EmailId nvarchar(100),
	@MobileNO nvarchar(100),
	@TransactionDate date,
	@PymentMode nvarchar(100),
	@ChequeNo nvarchar(100),
	@Amount decimal,
	@Duration nvarchar(100),
	@Interest decimal
	
)
AS
begin
update PrivateLoanTransaction set FullName = @FullName,CurrentAddress = @CurrentAddress,PermanantAddress=@PermanantAddress,EmailId=@EmailId,MobileNo=@MobileNO,[date] = @TransactionDate,PaymentMode=@PymentMode,ChequeNo=@ChequeNo,Amount=@Amount,Duration=@Duration,Interest=@Interest where  TransactionId = @TransactionId
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateInstallment]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_UpdateInstallment]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@Balance int,
	@InstallmentStatus nvarchar(50)
	
)
AS

BEGIN
  --This means the record isn't in there already, let's go ahead and add it
 
 update Installment set GroupName = @GroupName,MemberName = @MemberName,BCTotalAmount = @TotalAmount,DurationInMonths =@DurationInMonths,InstallmentAmount = @InstallmentAmount, InstallmentDate = @InstallmentDate,PaymentMode = @PaymentMode,CheckNo = @ChequeNo,
 PaymentAmount = @PaymentAmount,DueDate = @DueDate,Balance = @Balance,InstallmentStatus=@InstallmentStatus
  where InstallmentId = @InstallmentId
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateGroupMember]    Script Date: 07/25/2015 15:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UpdateGroupMember]
@GroupId int,
@CustomerName nvarchar(100)
AS
BEGIN
	update CustomerGroupDetails set Name = @CustomerName where GroupId = @GroupId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SerchGroupmembers]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SerchGroupmembers]-- 1
	@GroupId int
	
AS
BEGIN
 select g.GroupName , c.Name from Groups g 
 INNER JOIN
 CustomerGroupDetails c 
 on c.GroupId = g.GroupId where c.GroupId = @GroupId
 
 
 

 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPendingPaymentReport]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal>
-- Create date: <21-july-2015>
-- Description:	<Pening Payment Report>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchPendingPaymentReport]
@GroupId int,
@CustomerId int
AS
BEGIN 
	select *,tr.BcDate from  Installment ins inner join Groups gr on gr.GroupId=ins.GroupId
	inner join Transactions tr on tr.GroupId=gr.GroupId 
	 where ins.GroupId = @GroupId and ins.CustomerId = @CustomerId 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPendingInstallmentReport]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchPendingInstallmentReport]
@GroupId int,
@CustomerId int
AS
BEGIN 
	select * from  
	Installment  
	where GroupId = @GroupId and CustomerId = @CustomerId and InstallmentStatus='Pending'
END
--select i.*,t.Loss,t.OffcetPrice,t.Drawa,t.Member,t.RemainingMonths,t.Percentage,t.Installment from  Installment i inner join Transactions t on t.GroupId=i.GroupId  
--	where i.GroupId = 3 and i.CustomerId = 3 and i.InstallmentStatus='Pending'
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchMemberwiseReport]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchMemberwiseReport]
@GroupId int,
@CustomerId int
AS
BEGIN 
	select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId 
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
--select * from Installment
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchGroupwiseReport]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchGroupwiseReport]
@GroupId int
AS
--declare @bcdatecount date 
BEGIN 
	--set @bcdatecount=(select DueDate from Installment where GroupId=@GroupId)
	select * from  installment where GroupId = @GroupId --and DueDate=@bcdatecount 
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchDatabydate]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchDatabydate]
@FromDate date,
@ToDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select * from Transactions t inner join Groups g on g.GroupId=t.GroupId where BcDate between @FromDate and @ToDate and g.IsDeleted='False'
    
END
--select * from Transactions where BcDate between '2014-01-01' and '2015-01-01'
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveTransactionDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Usp_SaveTransactionDetails]
	@TransactionId int,
	@Amount float,
	@Month int,
	@Member int,
	@amountofmonth float,
	@Percentage float,
	@RemainingMonths float,
	@GroupName nvarchar(100),
	@MemberList nvarchar(max),
	@OffcetPrice float,
	@Loss float,
	@ActualAmountforBCCustomer float,
	@Drawa float,
	@ActualInstallment float,
	@BcRecriverMember nvarchar(100),
	@BcDate date,
	@Installment int,
	@CustomerId int,
	@GroupId int,
	@Drawa1Name nvarchar(100),
	@Drawa2Name nvarchar(100),
	@Drawa2Amount int,
	@RunerUpName nvarchar(100),
	@RunerUpAmount int
	
AS
BEGIN
	IF EXISTS (SELECT  * FROM Transactions WHERE TransactionId = @TransactionId)
BEGIN
    --UPDATE 
    update Transactions set TransactionId = @TransactionId,Amount = @Amount,[DurMonth] = @Month,Member=@Member,amountofmonth=@amountofmonth,Percentage = @Percentage,RemainingMonths=@RemainingMonths,MemberList = @MemberList,
    OffcetPrice = @OffcetPrice,Loss = @Loss,ActualAmountforBCCustomer = @ActualAmountforBCCustomer,
    Drawa = @Drawa,ActualInstallment = @ActualInstallment,BcRecriverMember = @BcRecriverMember,BcDate = @BcDate,Installment = @Installment,
    GroupName=@GroupName,Drawa1Name = @Drawa1Name , Drawa2Name = @Drawa2Name, Drawa2Amount = @Drawa2Amount,RunnerUpName = @RunerUpName , RunnerUpAmount = @RunerUpAmount where TransactionId = @TransactionId
END
ELSE
BEGIN
   -- INSERT 
   insert into Transactions values(@TransactionId,@Amount,@Month,@Member,@amountofmonth,@Percentage,@RemainingMonths,@MemberList,@OffcetPrice,
   @Loss,@ActualAmountforBCCustomer,@Drawa,@ActualInstallment,@BcRecriverMember,@BcDate,@Installment,@GroupName,@CustomerId,@GroupId,@Drawa1Name,@Drawa2Amount,@Drawa2Name,@RunerUpName, @RunerUpAmount)
END
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveTransaction]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SaveTransaction]
	@TransactionId int,
	@Amount float,
	@Month int,
	@Member int,
	@amountofmonth float,
	@Percentage float,
	@RemainingMonths float,
	@GroupName nvarchar(100),
	@MemberList nvarchar(max),
	@OffcetPrice float,
	@Loss float,
	@ActualAmountforBCCustomer float,
	@Drawa float,
	@ActualInstallment float,
	@BcRecriverMember nvarchar(100),
	@BcDate date,
	@DueDate date,
	@Installment int,
	@CustomerId int,
	@GroupId int,
	@Drawa1Name nvarchar(100),
	@Drawa2Name nvarchar(100),
	@Drawa2Amount int,
	@RunerUpName nvarchar(100),
	@RunerUpAmount int
	
AS
declare @Id int;
declare @year nvarchar(50);
declare @months nvarchar(50);
declare @InstallmentId int;
declare @bc nvarchar(50);
declare @i int;

set @bc=(SELECT LEFT(CONVERT(NVARCHAR, @DueDate, 120), 10))

BEGIN 

set @year=(Select SUBSTRING(@bc,1,4))
set @months=(Select SUBSTRING(@bc,6,2))

if not exists(select Months,Years from Transactions where Months=@months and Years=@year and GroupId=@GroupId)--CONVERT (month,('2015-07-15')))
	begin
		insert into Transactions values--(30000,20,20000,2,20,'snehal',1000)
		(@TransactionId,@Amount,@Month,@Member,@amountofmonth,@Percentage,@RemainingMonths,@MemberList,@OffcetPrice,
		@Loss,@ActualAmountforBCCustomer,@Drawa,@ActualInstallment,@BcRecriverMember,@BcDate,@DueDate,@Installment,@GroupName,
		@CustomerId,@GroupId,@Drawa1Name,@Drawa2Amount,@Drawa2Name,@RunerUpName, @RunerUpAmount,@months,
		@year,'False','True')
	   
		set @Id=(select MAX(TransactionId) from Transactions where TransactionId=@TransactionId)
		select GroupId from Transactions where TransactionId=@Id
	end
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveInstallmentDemo]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Usp_SaveInstallmentDemo]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@Balance int,
	@GroupId int,
	@CustomerId int,
	@ActualInstallment float,
	@ActualAmount float
)
as
declare @count int;
begin

--set @count=(select max(TransactionId) from Transactions)
--	while(@count!=null)
--	begin
		insert into Installment(GroupName,MemberName,InstallmentAmount,DurationInMonths,BCTotalAmount,
								GroupId,CustomerId,ActualInstallment,ActualAmount)
								--values(@GroupName,@MemberList,@Month,@GroupId,@CustomerId,
								--@ActualInstallment,@ActualAmountforBCCustomer)
		SELECT GroupName,MemberList,amountofmonth,DurMonth,Amount,GroupId,CustomerId,
		ActualInstallment,ActualAmountforBCCustomer
		from Transactions where GroupName=@GroupName
		--,MemberList=@MemberName,amountofmonth=@InstallmentAmount,
		--DurMonth=@DurationInMonths,Amount=@TotalAmount,GroupId=@GroupId,CustomerId=@CustomerId,
		--ActualInstallment=@ActualInstallment,ActualAmountforBCCustomer=@ActualAmount
		
	--end
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveInstallment]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SaveInstallment]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@Balance int,
	@GroupId int,
	@CustomerId int,
	@ActualInstallment float,
	@ActualAmount float,
	@InstallmentStatus nvarchar(50)
)
AS
declare @msg nvarchar(100) = ''
IF EXISTS(SELECT 'True' FROM Installment WHERE InstallmentId = @InstallmentId)
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
  insert into Installment(InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
  InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance,GroupId,CustomerId,ActualInstallment,
  ActualAmount,InstallmentStatus,Isdelete,IsActive)
   values(@InstallmentId,@GroupName,@MemberName,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@InstallmentDate,@PaymentMode,@ChequeNo,@PaymentAmount,@DueDate,@Balance,@GroupId,
  @CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus,'False','True')
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveGroupInstallment]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SaveGroupInstallment]
(
    @InstallmentId int,
	@GroupName nvarchar(100),
	@MemberName nvarchar(100),
	@TotalAmount int,
	@DurationInMonths int,
	@InstallmentAmount int,
	--@InstallmentDate date,
	--@PaymentMode nvarchar(100),
	--@ChequeNo int,
	--@PaymentAmount int,
	--@DueDate date,
	--@Balance int,
	@GroupId int,
	@CustomerId int,
	@ActualInstallment float,
	@ActualAmount float,
	@InstallmentStatus nvarchar(50)
)
AS
declare @msg nvarchar(100) = ''
IF EXISTS(SELECT 'True' FROM Installment WHERE InstallmentId = @InstallmentId)
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
  insert into Installment(InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
   GroupId ,CustomerId,ActualInstallment,ActualAmount,InstallmentStatus)
   values(@InstallmentId,@GroupName,@MemberName,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@GroupId,@CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus)
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadInstallmentGrid]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadInstallmentGrid]
AS
BEGIN
	select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,InstallmentDate,
	PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from Installment where InstallmentStatus='Pending' and isdelete='False'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupCustomerGrid]    Script Date: 07/25/2015 15:44:23 ******/
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
CREATE PROCEDURE [dbo].[Usp_LoadGroupCustomerGrid]  
AS  
BEGIN  
 select cgd.GroupId,gr.GroupName,Name from CustomerGroupDetails cgd inner join Groups gr on gr.GroupId=cgd.GroupId and gr.IsDeleted='False'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupMembers]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_GetGroupMembers] 
	@GroupID int
AS

BEGIN 
	select Name,CustomerId
	from  CustomerGroupDetails where GroupId=@GroupID
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_getTransactionId]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_getTransactionId]

AS
BEGIN
select MAX(TransactionId)+ 1 from Transactions
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetRemainingMonths]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal>
-- Create date: <21-july-2015>
-- Description:	<For Calculate Remaining Months>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetRemainingMonths]
@GroupId int
AS
declare @remainingMonths int
declare @startdate date
declare @enddate date
declare @bcdatecount int
BEGIN
	set @startdate = (select StartDate from Groups where GroupId = @GroupId)
	set @enddate = (select EndDate from Groups where GroupId = @GroupId)
	set @bcdatecount=(select count(bcdate) from Transactions where GroupId=@GroupId)--BcDate between @startdate and @enddate
	if (@bcdatecount<>0)--exists (select bcdate from Transactions where BcDate between @startdate and @enddate and GroupId=@GroupId) 
	begin
		;WITH Groups AS
		(
		   select DateDiff(DD,@startdate, DateAdd(DD, 1,@enddate)) as days                 --'2014-01-01''2015-01-01'
		)
		SELECT (CAST(days as float) / 30)-@bcdatecount  as Months FROM Groups 
	END
	else
	begin
		;WITH Groups AS
		(
		   select DateDiff(DD,@startdate, DateAdd(DD, 1,@enddate)) as days                 --'2014-01-01''2015-01-01'
		)
		SELECT CAST(days as float) / 30  as Months FROM Groups 
	end
End
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetPreviousInstallment]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Usp_GetPreviousInstallment] 
	@InstallmentDate date
AS

BEGIN 
	select *
	from  Installment where InstallmentDate=@InstallmentDate
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersofGroup]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetMembersofGroup]
@GroupId int
AS
BEGIN
	select Name,CustomerId from CustomerGroupDetails where GroupId  = @GroupId 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMaxTransactionGroupID]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Usp_GetMaxTransactionGroupID] 
	
AS
declare @Id int; 
BEGIN 
	set @Id=(select MAX(TransactionId) from Transactions )
	select GroupId from Transactions where TransactionId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetInstallmentTransfer]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
CREATE PROCEDURE [dbo].[USP_GetInstallmentTransfer]  
@GroupId int  
--@memberId int  
AS  
BEGIN  
 select InstallmentId,ins.GroupName,MemberName,ActualInstallment,ActualAmount,PaymentAmount,Balance,InstallmentDate from Installment ins 
 inner join Groups grp on grp.GroupId=ins.GroupId
 where ins.GroupId = @GroupId and InstallmentStatus='Pending' and grp.IsDeleted='False' --and CustomerId = @MemberId  
END  
  
--select Amount,[DurMonth],amountofmonth,ActualAmountforBCCustomer,ActualInstallment from Transactions   
-- where GroupId = @GroupId and CustomerId = @MemberId
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentMonths]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal Shinde>
-- Create date: <09-07-2015>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetInstallmentMonths]
--@customerId int,
@GroupId int
AS

declare @remainingMonths int
declare @startdate date
declare @enddate date
declare @date date
declare @tab TABLE(MONTH_NAME varchar(20))
declare @count int
set @count=0 

BEGIN
set @startdate = (select StartDate from Groups where GroupId = @GroupId)
set @enddate = (select EndDate from Groups where GroupId = @GroupId) 
		BEGIN 
			Select i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId
			 where StartDate between @startdate and @enddate and i.GroupId=@GroupId 
		END
END

--Select i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId
--			 where StartDate between '2014-01-01' and '2015-01-01' and i.GroupId=6
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentId]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_GetInstallmentId]

AS
BEGIN
select MAX(InstallmentId)+ 1 from Installment
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentDetails]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetInstallmentDetails]
@GroupId int,
@CustomerId int
AS
BEGIN
	
	select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
	InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from  
	Installment where GroupId = @GroupId and CustomerId = @CustomerId and InstallmentStatus='Pending' and isdelete='False'
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetDetailsofTransaction]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetDetailsofTransaction]
@GroupId int,
@MemberId int
AS
BEGIN
	select BCTotalAmount,[DurationInMonths],InstallmentAmount,ActualAmount,ActualInstallment,* from Installment 
	where GroupId = @GroupId and CustomerId = @MemberId and InstallmentStatus='Pending' and isdelete='False'
END

--select Amount,[DurMonth],amountofmonth,ActualAmountforBCCustomer,ActualInstallment from Transactions 
--	where GroupId = @GroupId and CustomerId = @MemberId
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetBalance]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetBalance]
@GroupId int,
@MemberId int
AS
BEGIN
	select Balance from Installment where GroupId = @GroupId and CustomerId = @MemberId and isdelete='False' and InstallmentStatus='Pending'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_FetchTransaction]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_FetchTransaction]
@TransactionId int
AS
BEGIN
select *
 --Amount,DurMonth,Member,amountofmonth,Percentage,RemainingMonths,MemberList,OffcetPrice
 --        ,Loss,ActualAmountforBCCustomer,ActualInstallment,BcDate,GroupName 
         from Transactions where TransactionId=@TransactionId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteTransaction]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteTransaction]
@TransactionId int
AS
BEGIN
update  Transactions set isdelete='True',IsActive='False' where TransactionId = @TransactionId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteInstallment]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteInstallment]
@InstallmentId int
AS
BEGIN
update Installment set Isdelete='True',IsActive='False' where InstallmentId = @InstallmentId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomerfromGroup]    Script Date: 07/25/2015 15:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteCustomerfromGroup]
@GroupId int,
@CustomerName nvarchar(100)
AS
BEGIN
delete from CustomerGroupDetails where GroupId = @GroupId and Name = @CustomerName
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DailyDebitCreditReport]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DailyDebitCreditReport]
@GroupId int
AS
BEGIN 
	select * from  Installment 
	where GroupId = @GroupId  
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId 
--select * from Transactions
--select * from Installment
GO
/****** Object:  StoredProcedure [dbo].[Usp_BindGrid]    Script Date: 07/25/2015 15:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_BindGrid]

AS
BEGIN
select TransactionId,Amount,DurMonth,Member,amountofmonth,Percentage,RemainingMonths,MemberList,OffcetPrice
         ,Loss,ActualAmountforBCCustomer,ActualInstallment,BcDate,DueDate,GroupName 
         from Transactions
END
GO
/****** Object:  ForeignKey [FK__CustomerG__Custo__3B75D760]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD  CONSTRAINT [FK__CustomerG__Custo__3B75D760] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerGroupDetails] CHECK CONSTRAINT [FK__CustomerG__Custo__3B75D760]
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__4D94879B]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__4E88ABD4]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__4F7CD00D]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__5070F446]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__Installme__Custo__398D8EEE]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Custo__398D8EEE] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Custo__398D8EEE]
GO
/****** Object:  ForeignKey [FK__Installme__Group__440B1D61]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__440B1D61] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__440B1D61]
GO
/****** Object:  ForeignKey [FK__Installme__Group__44FF419A]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__44FF419A] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__44FF419A]
GO
/****** Object:  ForeignKey [FK__Installme__Group__45F365D3]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__45F365D3] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__45F365D3]
GO
/****** Object:  ForeignKey [FK__Installme__Group__46E78A0C]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__46E78A0C] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__46E78A0C]
GO
/****** Object:  ForeignKey [FK_Transactions_Customer]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Customer]
GO
/****** Object:  ForeignKey [FK_Transactions_Groups]    Script Date: 07/25/2015 15:44:05 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Groups]
GO
