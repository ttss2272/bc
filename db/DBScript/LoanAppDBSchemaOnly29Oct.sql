USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveSchemeDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_TransactionCustomer]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SaveGroupDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_UpdateCustomerForGroup]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SerchGroupNamesncustomerNames]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SaveCustomerForGroup]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  Table [dbo].[ReceiveInstallment]    Script Date: 10/29/2015 11:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveInstallment](
	[ReceiveInstallmentId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerGroupId] [int] NULL,
	[ReceiveAmt] [float] NULL,
	[Name] [nvarchar](50) NULL,
	[PendingAmount] [float] NULL,
	[BcDate] [date] NULL,
	[ReceiveAmount] [float] NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
 CONSTRAINT [PK_ReceiveInstallment] PRIMARY KEY CLUSTERED 
(
	[ReceiveInstallmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrivateLoanTransaction]    Script Date: 10/29/2015 11:31:24 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 10/29/2015 11:31:24 ******/
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 10/29/2015 11:31:24 ******/
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
	[BCAmount] [float] NULL,
	[NoOfMembers] [bigint] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginType]    Script Date: 10/29/2015 11:31:24 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 10/29/2015 11:31:24 ******/
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
/****** Object:  Table [dbo].[Installment]    Script Date: 10/29/2015 11:31:24 ******/
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
	[InstallmentAmount] [float] NULL,
	[InstallmentDate] [date] NULL,
	[PaymentMode] [nvarchar](100) NULL,
	[CheckNo] [int] NULL,
	[PaymentAmount] [float] NULL,
	[DueDate] [date] NULL,
	[Balance] [float] NULL,
	[GroupId] [int] NULL,
	[CustomerId] [int] NULL,
	[ActualInstallment] [float] NULL,
	[ActualAmount] [float] NULL,
	[InstallmentStatus] [nvarchar](50) NULL,
	[IsDelete] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
	[PendingAmount] [float] NULL,
	[TransactionId] [int] NULL,
 CONSTRAINT [PK_Installment] PRIMARY KEY CLUSTERED 
(
	[InstallmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/29/2015 11:31:37 ******/
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
IF EXISTS(SELECT 'True' FROM Customer WHERE Name = @CustomerName AND [MobileNumber]=@MobileNo)  
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
/****** Object:  Table [dbo].[CustomerGroupDetails]    Script Date: 10/29/2015 11:31:24 ******/
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
/****** Object:  StoredProcedure [dbo].[CountGroupMembers]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CountGroupMembers]
	@GroupID int
AS
BEGIN
	Select NoOfMembers AS 'NoOfMembers' from Groups where GroupId=@GroupID
END
GO
/****** Object:  StoredProcedure [dbo].[checklogin]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 10/29/2015 11:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[InstallmentId] [int] NULL,
	[PaidAmount] [float] NULL,
	[PaymentDate] [date] NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[ChequeNo] [nvarchar](50) NULL,
	[InstallmentStatus] [nvarchar](50) NULL,
	[PendingAmount] [float] NULL,
	[CustomerId] [int] NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewUsers]    Script Date: 10/29/2015 11:31:37 ******/
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
	select LoginUserName,[Password],ExpiryDate from Login where  Binary_checksum(LoginUserName)=Binary_checksum(@UserId) and Binary_checksum([Password])=Binary_checksum(@Paswored)
	--insert into Login (LoginType,LoginUserName,Password) values(@UserType,@UserId,@Paswored)
END
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/29/2015 11:31:24 ******/
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
	[Drawa2Amount] [float] NULL,
	[Drawa2Name] [nvarchar](50) NULL,
	[RunnerUpName] [nvarchar](50) NULL,
	[RunnerUpAmount] [float] NULL,
	[Months] [nvarchar](50) NULL,
	[Years] [nvarchar](50) NULL,
	[IsDelete] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SaveanUpdateGroup]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveanUpdateGroup]
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
GO
/****** Object:  StoredProcedure [dbo].[text_Sp]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_CheckTranscationDate]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pranjli
-- Create date: 24 Oct 2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Usp_CheckTranscationDate] 
@GroupId int
AS
BEGIN
	Select EndDate AS 'EndDate' from Groups where GroupId=@GroupId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeletePrivateLoanDetails]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetCustomerId]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetBCAmount]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 16/10/2015
-- Description:	Get BC Amount from group table
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetBCAmount]
	(
	@GroupID int
	)
AS
BEGIN
	
	Select BCAmount from Groups where GroupId=@GroupID
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupId1]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupId]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_DeleteUser]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupNames]    Script Date: 10/29/2015 11:31:38 ******/
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
select GroupId,GroupName,StartDate,EndDate,BCAmount,NoOfMembers from Groups where GroupName = @GroupName and IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGrid]    Script Date: 10/29/2015 11:31:38 ******/
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
	select GroupId,GroupName,StartDate,EndDate,BCAmount,NoOfMembers from Groups where IsDeleted = 0 and IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadCustomerGroup]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_LoadActiveGroupNames]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 24Oct 2015
-- Description:	load group name whoes end date less tyhan current date for BC Transaction
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadActiveGroupNames] 
	
AS
BEGIN
	select '0' as groupid, 'SELECT' as groupname
union
select  GroupId,GroupName from Groups
 where StartDate<=CONVERT(date,GETDATE())  AND IsDeleted = 'False' AND EndDate>= CONVERT(date,GETDATE()) 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetLoanId]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNamesforcustomer]    Script Date: 10/29/2015 11:31:38 ******/
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
    select '0' as GroupId,'Select' as GroupName
	union
	select GroupId,GroupName from Groups where IsDeleted = 'False'
	--select GroupId,GroupName,StartDate,EndDate from Groups where IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupNames]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_LoadPrivateLoanGrid]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_LoadPrivateLoanGrid]

AS
BEGIN

	
select TransactionId,FullName AS 'Full Name',CurrentAddress AS 'Current Address',PermanantAddress AS 'Prmanant Address',EmailId AS 'Email ID',MobileNo AS 'Mobile No',[date] As 'Date',PaymentMode AS 'Payment Mode',ChequeNo AS 'Cheque No',Amount AS 'Amount',Duration AS 'Duration',Interest AS 'Interest' from PrivateLoanTransaction
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveCustomerDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT 'True' FROM Customer WHERE Name = @CustomerName AND MobileNumber=@MobileNo AND CustomerID<> @CustomerId)  
BEGIN  
  --This means it exists, return it to ASP and tell us  
  set @msg = 'This record already exists!'  
   
  SELECT @msg  
END  
ELSE  
BEGIN
	set @msg =  'Record Update'  
  SELECT @msg 
		
			update Customer set 
			Name=@CustomerName,
			MobileNumber = @MobileNo,
			AlternateMobileNo =@AlterNameMobileNo,
			Address = @Address,
			Reference =@Reference , 
			Nominee =@Nominee,
			RequiredSMSnotification = @SMSRequire,
			BankName=@BankName,
			BankAccountNo = @AccountNo,
			CreatedDate=@Date,
			UpdatedDate=GETDATE(),
			IsDeleted = 0, 
			IsActive=1 where 
			CustomerId = @CustomerId
			  --SET @msg ='1'
			 -- SELECT @msg
		--end
	--ELSE
		--BEGIN
		--   insert into Customer values(@CustomerId,@CustomerName,@MobileNo,@AlterNameMobileNo,@Address,@Reference,@Nominee,@SMSRequire,@BankName,@AccountNo,@Date,GETDATE(),0,1)
		--END
End
GO
/****** Object:  StoredProcedure [dbo].[Usp_SavePrivateLoanDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SearchUsersByUserType]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SearchPrivateLoanDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
select TransactionId,FullName AS 'Full Name',CurrentAddress AS 'Current Address',PermanantAddress AS 'Prmanant Address',EmailId AS 'Email ID',MobileNo AS 'Mobile No',[date] As 'Date',PaymentMode AS 'Payment Mode',ChequeNo AS 'Cheque No',Amount AS 'Amount',Duration AS 'Duration',Interest AS 'Interest'
 from PrivateLoanTransaction where 	FullName like '%'+ @CustomerName+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchAllUsers]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SearchCustomer]    Script Date: 10/29/2015 11:31:38 ******/
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
     select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0 
	if(@CustomerId <>0 and @CustomerName <> null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId or Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId <> 0)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where CustomerId = @CustomerId and IsDeleted = 0 
	end
	if(@CustomerName <> null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where Name  like '%' + @CustomerName + '%' and IsDeleted = 0
	end
	if(@CustomerId  = 0 and @CustomerId = null)
	begin
	select CustomerId,Name AS 'Name',MobileNumber AS 'Mobile No',AlternateMobileNo AS 'Alternate No',[Address] AS 'Address', Reference AS 'Reference', Nominee AS 'Nominee',BankName AS 'Bank Name',BankAccountNo As 'Bank Account No',CreatedDate AS 'Date',RequiredSMSnotification As 'Required Notification'  from Customer where  IsDeleted = 0 
	end
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UserRegistration]    Script Date: 10/29/2015 11:31:38 ******/
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
begin
	set @expirydate=(Select DATEADD(DAY, 365, GETDATE()))
	insert into Login (LoginType,LoginUserName,Password,ExpiryDate)values(@UserType,@UserId,@Paswored,@expirydate)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateUser]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_UpdatePrivateLoanDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  View [dbo].[View_CustomerGroup]    Script Date: 10/29/2015 11:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[View_CustomerGroup]
AS
SELECT     GroupId, CustomerId

FROM         dbo.CustomerGroupDetails
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateInstallment]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_UpdateInstallment]
(
    @InstallmentId int,
	@GroupId int,
	@CustomerId int,
	@InstallmentDate date,
	@PaymentMode nvarchar(100),
	@ChequeNo int,
	@PaymentAmount int,
	@DueDate date,
	@PendingAmount float,
	@Balance int,
	@InstallmentStatus nvarchar(50)
	
)
AS

BEGIN
  --This means the record isn't in there already, let's go ahead and add it
 
 update Installment set InstallmentDate = @InstallmentDate,PaymentMode = @PaymentMode,CheckNo = @ChequeNo,
 PaymentAmount = @PaymentAmount,DueDate = @DueDate,Balance = @Balance,InstallmentStatus=@InstallmentStatus,PendingAmount=@PendingAmount
  where InstallmentId = @InstallmentId AND GroupId=@GroupId And CustomerId=@CustomerId
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateGroupMember]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_UpdateGroup]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_UpdateGroup] --13,'sai2',5000,2,'2015-10-31','2015-11-19'
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
GO
/****** Object:  StoredProcedure [dbo].[Usp_SerchGroupmembers]    Script Date: 10/29/2015 11:31:38 ******/
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
 select g.GroupName ,c.CustomerID ,c.Name from Groups g 
 INNER JOIN
 CustomerGroupDetails cgd 
 on cgd.GroupId = g.GroupId
 INNER JOIN Customer c
 On c.CustomerID=cgd.CustomerID
  where cgd.GroupId = @GroupId
 
 
 

 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SerachMembersNotInGroup]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer 
-- Create date: 15/10/2015
-- Description:	Select Member which is not in selected group
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SerachMembersNotInGroup] --3
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
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchBCTransactionDetails]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer	Shinde	
-- Create date: 21/10/2015
-- Description:	Bind BC Transaction Details to Grid view
-- =============================================
Create PROCEDURE [dbo].[Usp_SearchBCTransactionDetails] --'2015-09-20','2016-10-20'
@FromDate date,
@ToDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 Select t.TransactionId, t.GroupName,t.Amount,t.DurMonth,t.Member,t.amountofmonth,t.Percentage,t.RemainingMonths,
t.MemberList,t.OffcetPrice,t.Loss,t.ActualAmountforBCCustomer,t.Drawa,t.ActualInstallment,
t.BcRecriverMember,t.BcDate,t.DueDate,t.Installment,t.Months,t.RunnerUpName,t.RunnerUpAmount,t.Months,t.Years,g.StartDate,g.EndDate
from Transactions t inner join Groups g on g.GroupId=t.GroupId where BcDate between @FromDate and @ToDate and g.IsDeleted='False'   
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveTransaction]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SaveTransaction] --23,10000,10,10,1111,2,09,'BC10000','KIRAN',100,1000,1000,100,1000,'CHAVAN','2015-10-21','2015-10-21',1000,0,0,'abc','pqr',100,'xyz',200
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
declare @msg nvarchar(50)
set @bc=(SELECT LEFT(CONVERT(NVARCHAR, @DueDate, 120), 10))

BEGIN 

set @year=(Select SUBSTRING(@bc,1,4))
set @months=(Select SUBSTRING(@bc,6,2))
if not exists (Select TransactionId from Transactions where TransactionId=@TransactionId)
begin
if not exists(select Months,Years from Transactions where  GroupId=@GroupId and Months=@months and Years=@year)--CONVERT (month,('2015-07-15')))
	begin
		insert into Transactions values--(30000,20,20000,2,20,'snehal',1000)
		(@TransactionId,@Amount,@Month,@Member,@amountofmonth,@Percentage,@RemainingMonths,@MemberList,@OffcetPrice,
		@Loss,@ActualAmountforBCCustomer,@Drawa,@ActualInstallment,@BcRecriverMember,@BcDate,@DueDate,@Installment,@GroupName,
		@CustomerId,@GroupId,@Drawa1Name,@Drawa2Amount,@Drawa2Name,@RunerUpName, @RunerUpAmount,@months,
		@year,'False','True')  
		
		set @Id=(select MAX(TransactionId) from Transactions where TransactionId=@TransactionId)
		select GroupId from Transactions where TransactionId=@Id 
	end
	end
	----Sameer write code->
	ELSE ---For Update
	begin
	Update Transactions SET Amount=@Amount,DurMonth=@Month,Member=@Member,amountofmonth=@amountofmonth,Percentage=@Percentage,RemainingMonths=@RemainingMonths,MemberList=@MemberList,OffcetPrice=@OffcetPrice,
		Loss=@Loss,ActualAmountforBCCustomer=@ActualAmountforBCCustomer,Drawa=@Drawa,ActualInstallment=@ActualInstallment,BcRecriverMember=@BcRecriverMember,BcDate=@BcDate,DueDate=@DueDate,Installment=@Installment,GroupName=@GroupName,
		Drawa1Name=@Drawa1Name,Drawa2Amount=@Drawa2Amount,Drawa2Name=@Drawa2Name,RunnerUpName=@RunerUpName,RunnerUpAmount=@RunerUpAmount,Months=@months,
		Years=@year where TransactionId=@TransactionId
		
	end
	
END 


--select * from Transactions 
--select * from groups
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPendingPaymentReport]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal>
-- Create date: <21-july-2015>
-- Description:	<Pening Payment Report>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchPendingPaymentReport]--3,2
@GroupId int,
@CustomerId int
AS
BEGIN 
	--select *,tr.BcDate, PendingAmount from  Installment ins inner join Groups gr on gr.GroupId=ins.GroupId
	--inner join Transactions tr on tr.GroupId=gr.GroupId 
	-- where ins.GroupId = @GroupId and ins.CustomerId = @CustomerId 
	select g.GroupName,c.Name,tr.amountofmonth,tr.BcDate,
	p.PaidAmount,p.PendingAmount
	 from Payment p 
	inner join Installment i on p.InstallmentId=i.InstallmentId
	inner join Groups g on g.GroupId =i.GroupId
	inner join Customer c on c.CustomerId=i.CustomerId
	inner join Transactions tr on tr.GroupId=i.GroupId
	
	

	where i.GroupId LIKE CASE WHEN @GroupId <>0 then @GroupId else CONVERT(nvarchar(50),i.GroupId ) END
	and i.CustomerId LIKE CASE WHEN @CustomerId <>0 THEN @CustomerId ELSE CONVERT(nvarchar(50),i.CustomerId)END 

	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchPendingInstallmentReport]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SearchMemberwiseReport]    Script Date: 10/29/2015 11:31:38 ******/
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
	---select * from Transactions t inner join Groups g on g.GroupId=t.GroupId where CustomerId = @CustomerId
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
--select * from Installment
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchGroupwiseReport]    Script Date: 10/29/2015 11:31:38 ******/
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
select g.GroupName,c.Name,tr.Amount,tr.amountofmonth,tr.BcDate,p.PaidAmount, p.InstallmentStatus from Payment p 
inner join Installment i on p.InstallmentId=i.InstallmentId
	inner join Groups g on g.GroupId =i.GroupId
	inner join Customer c on c.CustomerId=i.CustomerId
	inner join Transactions tr on tr.GroupId=i.GroupId
where i.GroupId LIKE CASE WHEN @GroupId <>0 then @GroupId else CONVERT(nvarchar(50),i.GroupId ) END
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchDatabydate]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_SearchDatabydate] --'2015-09-20','2016-10-20'
@FromDate date,
@ToDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 Select t.TransactionId,t.GroupName,t.Amount,t.DurMonth,t.Member,t.amountofmonth,t.Percentage,t.RemainingMonths,
t.MemberList,t.OffcetPrice,t.Loss,t.ActualAmountforBCCustomer,t.Drawa,t.ActualInstallment,
t.BcRecriverMember,t.BcDate,t.DueDate,t.Installment,t.Months,t.RunnerUpName,t.RunnerUpAmount,t.Months,t.Years,g.StartDate,g.EndDate
from Transactions t inner join Groups g on g.GroupId=t.GroupId where BcDate between @FromDate and @ToDate and g.IsDeleted='False'   
END
--select * from Transactions where BcDate between '2014-01-01' and '2015-01-01'
GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchDailyTransactionReport]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[Usp_SearchDailyTransactionReport]--'2015-10-24','2015-11-26'
@BcDate date,
@DueDate date
AS
BEGIN 
	select TransactionId,GroupName ,Amount,DurMonth,Member,amountofmonth,Percentage,RemainingMonths,MemberList,OffcetPrice
         ,Loss,ActualAmountforBCCustomer,ActualInstallment,BcDate,DueDate
         from Transactions 
         where BcDate between @BcDate and @DueDate 
	---select * from Transactions t inner join Groups g on g.GroupId=t.GroupId where CustomerId = @CustomerId
END
--select * from  Transactions where GroupId = @GroupId and CustomerId = @CustomerId
--select * from Installment
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveNewInstallment]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usp_SaveNewInstallment]
(
    @InstallmentId int,
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
	@InstallmentStatus nvarchar(50),
	@PendingAmount float
	
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
  insert into Installment(InstallmentId,BCTotalAmount,DurationInMonths,InstallmentAmount,
  InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance,GroupId,CustomerId,ActualInstallment,
  ActualAmount,InstallmentStatus,Isdelete,IsActive,PendingAmount)
   values(@InstallmentId,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@InstallmentDate,@PaymentMode,@ChequeNo,@PaymentAmount,@DueDate,@Balance,@GroupId,
  @CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus,'False','True',@PendingAmount)
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveInstallmentDemo]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SaveInstallment]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_SaveGroupInstallment]    Script Date: 10/29/2015 11:31:38 ******/
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
	@InstallmentStatus nvarchar(50),
	@TransactionId int
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
   GroupId ,CustomerId,ActualInstallment,ActualAmount,InstallmentStatus,IsActive,IsDelete,TransactionId)
   values(@InstallmentId,@GroupName,@MemberName,@TotalAmount,@DurationInMonths,
  @InstallmentAmount,@GroupId,@CustomerId,@ActualInstallment,@ActualAmount,@InstallmentStatus,'True','False',@TransactionId)
END

--select * from Customer
GO
/****** Object:  StoredProcedure [dbo].[USP_ReceiveInstallment]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh Sortee
-- Create date: 
-- Description:	read text file
-- =============================================
CREATE PROCEDURE [dbo].[USP_ReceiveInstallment] --005,1000,'abc',1000,'2015-10-28',1000 
(
@CustomerGroupId int,
@ReceiveAmt float,
@Name nvarchar(50),
@PendingAmount float,
@BcDate date,
@ReceiveAmount float
)

AS
Declare @CustomrId int
Declare @GroupId int
Declare @InstallmentID int

BEGIN
--set @TempId= (select InstallmentId from Installment where MemberName=@MemberName) 
   --if (@ReceiveInstallmentId=0)
    begin
		Insert into  ReceiveInstallment(CustomerGroupId,ReceiveAmt,Name,PendingAmount,BcDate,ReceiveAmount,CreatedDate,UpdatedDate)
		values (@CustomerGroupId,@ReceiveAmt,@Name,@PendingAmount,CONVERT(datetime,@BcDate,103),@ReceiveAmount,CONVERT(datetime,GETDATE(),103),CONVERT(datetime,GETDATE(),103))
		
		--Insert data in Payment table
		Set @CustomrId=(Select CustomerId from CustomerGroupDetails where CustomerGroupId=@CustomerGroupId)
		Set @GroupId=(Select GroupId from CustomerGroupDetails where CustomerGroupId=@CustomerGroupId)
		Set @InstallmentID=(Select MAX(InstallmentId) from Installment where CustomerId=@CustomrId and GroupId=@GroupId)
		
		Insert into  Payment(InstallmentId,PaidAmount,PendingAmount,PaymentDate,CreatedDate,UpdatedDate,CustomerId,GroupId)
		values (@InstallmentID,@ReceiveAmt,@PendingAmount,CONVERT(datetime,@BcDate,103),CONVERT(datetime,GETDATE(),103),CONVERT(datetime,GETDATE(),103),@CustomrId,@GroupId)
	end
 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_PaidPayment]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde	
-- Create date: 19/10/2015
-- Description:	Save Payment Details
-- =============================================
CREATE PROCEDURE [dbo].[Usp_PaidPayment]
	(
	@InstallmentId int,
	@PaidAmount float,
	@PaymentDate date,
	@PaymentMode nvarchar(50),
	@ChequeNo nvarchar(50),
	@InstallmentStatus nvarchar(50),
	@PendingAmount float,
	@CustomerId int,
	@GroupId int
	)
AS
BEGIN
     insert into Payment(InstallmentId,PaidAmount,PaymentDate,CreatedDate,UpdatedDate,PaymentMode,ChequeNo,InstallmentStatus,PendingAmount,CustomerId,GroupId) values(@InstallmentId,@PaidAmount,@PaymentDate,CONVERT(datetime,GETDATE(),103),CONVERT(datetime,GETDATE(),103),@PaymentMode,@ChequeNo,@InstallmentStatus, @PendingAmount,@CustomerId,@GroupId)
   
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadInstallmentGrid]    Script Date: 10/29/2015 11:31:38 ******/
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
	select GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,InstallmentDate,
	PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from Installment where InstallmentStatus='Pending' and isdelete='False'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadGroupCustomerGrid]    Script Date: 10/29/2015 11:31:38 ******/
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
 ORDER  By gr.GroupName
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetInstallmentTransfer]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
CREATE PROCEDURE [dbo].[USP_GetInstallmentTransfer] --11,'2015-11-26'   
@GroupId int  , 
@CurrentDate date   
AS    
declare @year nvarchar(50)  
declare @months nvarchar(50)  
declare @bc nvarchar(50)  
set @bc=(SELECT LEFT(CONVERT(NVARCHAR, @CurrentDate, 120), 10))  
DECLARE @cnt int
set @cnt =(select COUNT (TransactionId) from Transactions where GroupId=@GroupId) 
BEGIN    
     
 ---Sameer try sp
 
 

select   cgd.CustomerGroupId,'00000' as ReceiveAmt, cust.Name,((tr.amountofmonth * @cnt)-isnull(SUM(pay.PaidAmount)  ,0) ) as PendingAmount,Convert(nvarchar(10), tr.BcDate,104) AS BcDate,'00000' as ReceiveAmt 
from  CustomerGroupDetails cgd
inner join Customer cust
on cust.CustomerId=cgd.CustomerId
inner join Groups gr
on gr.GroupId=cgd.GroupId
inner join Transactions tr
on tr.GroupId=gr.GroupId and tr.BcDate=(select MAX (BcDate) from Transactions)
left join Payment pay
on  cust.CustomerId=pay.customerId and gr.GroupId=pay.groupId

where cgd.GroupId=@GroupId 
group by cgd.CustomerGroupId,cust.Name,tr.amountofmonth,tr.BcDate
Having ((tr.amountofmonth * @cnt)-isnull(SUM(pay.PaidAmount)  ,0) )>0
  
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentMonths]    Script Date: 10/29/2015 11:31:38 ******/
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
@GroupId int,
@MemberID int
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
			Select  i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId Inner Join Customer c 
			on c.CustomerId=i.CustomerId
			 where StartDate between @startdate and @enddate and i.GroupId=@GroupId AND i.CustomerId=@MemberID 
			AND i.InstallmentDate  IS not null
		END
END

--Select i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId
--			 where StartDate between '2014-01-01' and '2015-01-01' and i.GroupId=6
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentId]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentDetails]    Script Date: 10/29/2015 11:31:38 ******/
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
	--Sameer change sp
     select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
	InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from  
	Installment where GroupId = @GroupId and CustomerId = @CustomerId and isdelete='False'
	
	--select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,
	--InstallmentDate,PaymentMode,CheckNo,PaymentAmount,DueDate,Balance from  
	--Installment where GroupId = @GroupId and CustomerId = @CustomerId and InstallmentStatus='Pending' and isdelete='False'
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_getTransactionId]    Script Date: 10/29/2015 11:31:38 ******/
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
--BEGIN
--select MAX(TransactionId)+ 1 from Transactions
--END
DECLARE @Output nvarchar(50)
DECLARE @no nvarchar(50)

BEGIN
	set @no= (select COUNT(*)from Transactions)
	
	set @no=@no+1
	
	set @Output= '00'+@no
	
	select @Output 	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetRemainingMonths]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetPreviousInstallment]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersofGroupBCTransaction1]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Usp_GetMembersofGroupBCTransaction1] --1
@GroupId int
AS
BEGIN
    
	select CustomerId,Name from CustomerGroupDetails where GroupId  = @GroupId 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersofGroupBCTransaction]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Usp_GetMembersofGroupBCTransaction] --1
@GroupId int
AS
BEGIN
    
	select CustomerId,Name from CustomerGroupDetails where GroupId  = @GroupId 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersofGroup]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetMembersofGroup] --1
@GroupId int
AS
BEGIN
    select '0' as CustomerId,'Select' as Name
	union
	select CustomerId,Name from CustomerGroupDetails where GroupId  = @GroupId 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMembersListNotInBCTransaction]    Script Date: 10/29/2015 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetMembersListNotInBCTransaction] --1
@GroupId int
AS
BEGIN
    
	select c.CustomerID,C.Name From customer c INNER JOIN 
 CustomerGroupDetails cgd
 ON cgd.CustomerId=c.CustomerID
 Where cgd.CustomerID not in (Select cc.CustomerID From Transactions cc Inner Join groups g on g.groupID=cc.GroupID where cc. GroupID= @GroupId) AND cgd.GroupID =@GroupId

END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetMaxTransactionGroupID]    Script Date: 10/29/2015 11:31:38 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupMembrsCount]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 17 OCT 2015
-- Description:	Get availble no of group members and Max no of Group Members
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetGroupMembrsCount] --1
	(
	@GroupId int = 0
	)
AS
BEGIN
IF NOT EXISTS (SELECT CustomerGroupId FROM CustomerGroupDetails WHERE GroupId=@GroupId)
	BEGIN
		SELECT ISNULL(g.NoOfMembers,0) AS 'MaxMembers',0 AS 'AvailableMembers'
		FROM Groups g
		WHERE g.GroupID= @GroupId
	END
ELSE
	BEGIN
		SELECT ISNULL(g.NoOfMembers,0) AS 'MaxMembers',ISNULL(COUNT(cgd.CustomerID),0) AS 'AvailableMembers'
		FROM Groups g 
		INNER JOIN CustomerGroupDetails cgd
		ON g.GroupId=cgd.GroupId
		Where cgd.GroupId LIKE CASE WHEN @GroupId <>0 THEN @GroupID ELSE CONVERT(NVARCHAR(50),cgd.GroupId)END
		Group BY g.NoOfMembers
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupMembers]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_DeleteTransaction]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_GetDetailsofTransaction]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetDetailsofTransaction] --1,4
@GroupId int,
@MemberId int

AS
BEGIN
	select InstallmentId,GroupName,MemberName,BCTotalAmount,DurationInMonths,InstallmentAmount,InstallmentDate,PaymentMode,CheckNo,
	PaymentAmount,DueDate,Balance,ActualInstallment,ActualAmount,InstallmentStatus,PendingAmount from Installment 
	where GroupId = @GroupId and CustomerId = @MemberId and InstallmentStatus='Pending' and IsDelete='False' 
END

--select Amount,[DurMonth],amountofmonth,ActualAmountforBCCustomer,ActualInstallment from Transactions 
--	where GroupId = @GroupId and CustomerId = @MemberId
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetDetailsofInstallment]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetDetailsofInstallment] --21,2
@GroupId int,
@MemberId int

AS
Declare @MaxInstallmentId int
DECLARE @PendingAmount FLOAT
DECLARE @TotalAmount float
DECLARE @TotalPaidAmount float
DECLARE @BCAmount Float
DECLARE @CurrentBalance float
BEGIN
Set @MaxInstallmentId=(Select MAX(InstallmentId) from Installment where GroupId=@GroupId AND	CustomerId=@MemberId)
SET @TotalAmount =(Select  isnull(Sum(amountofmonth),0) From Transactions where GroupId=@GroupId )
SET @TotalPaidAmount= (SELECT isnull(SUM(p.PaidAmount),0) FROM Payment p INNER JOIN Installment i ON i.InstallmentId = p.InstallmentId where i.GroupId=@GroupId AND i.CustomerId=@MemberId)
SET @BCAmount = (SELECT BCAmount from Groups where GroupId=@GroupId)
	SET @PendingAmount =@TotalAmount-@TotalPaidAmount
	SET @CurrentBalance= @BCAmount-@TotalPaidAmount
	select @MaxInstallmentId As InstallmentID, DurationInMonths,InstallmentAmount,BCTotalAmount,@PendingAmount AS 'PendingAmount',@CurrentBalance AS 'CurrentBalance' from Installment 
	where GroupId = @GroupId and CustomerId = @MemberId and InstallmentId=@MaxInstallmentId and IsDelete='False' 
END

--select Amount,[DurMonth],amountofmonth,ActualAmountforBCCustomer,ActualInstallment from Transactions 
--	where GroupId = @GroupId and CustomerId = @MemberId
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetBalance]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetBalance] --1,4
@GroupId int,
@MemberId int
AS
BEGIN
	select Balance from Installment where GroupId = @GroupId and CustomerId = @MemberId and isdelete='False' and InstallmentStatus='Pending'
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_FetchTransaction]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_DeleteInstallment]    Script Date: 10/29/2015 11:31:37 ******/
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
/****** Object:  StoredProcedure [dbo].[Usp_DeleteGroup]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_DeleteGroup] --15
@GroupId int
AS
Declare @Msg nvarchar(MAX)
if not EXISTS(Select GroupId from Transactions where GroupId=@GroupId)
BEGIN
       
		update Groups  set IsDeleted= 1,IsActive=0 where GroupId = @GroupId
		AND  EndDate<convert(date,Getdate())
		if (@@ROWCOUNT =1)
		begin
	    SET @Msg='Group Deleted Sucessfully'
	    select @Msg
	    end
	    else
	    begin
	      set @msg='group transaction is pending you cannot delete this group.'
	      select @Msg
	    end
END
else
begin
SET @Msg='Group Transaction is done'
	    select @Msg
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomerfromGroup]    Script Date: 10/29/2015 11:31:37 ******/
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
@CustomerID int
AS
BEGIN
IF NOT EXISTS (SELECT TRANSACTIONID FROM Transactions WHERE GroupId = @GroupId )
BEGIN 
delete from CustomerGroupDetails where GroupId = @GroupId and CustomerID = @CustomerID
END
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCustomer]    Script Date: 10/29/2015 11:31:37 ******/
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
declare @msg nvarchar(100) = ''  
IF EXISTS(SELECT CustomerId FROM CustomerGroupDetails WHERE CustomerId = @CustomerId)  
BEGIN  
  --This means it exists, return it to ASP and tell us  
  set @msg = 'This Customer Already in Group,So you cannot delete this Customer!'  
   
  SELECT @msg  
END  
Else
BEGIN
set @msg = 'Record Deleted Sucessfully..'  
   
  SELECT @msg  
update  Customer set IsDeleted = 1,IsActive=0 where CustomerId = @CustomerId
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_DailyDebitCreditReport]    Script Date: 10/29/2015 11:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[Usp_DailyDebitCreditReport]--4
@GroupId int

AS
BEGIN 
	--select * from  Installment 
	--where GroupId = @GroupId  
	select g.GroupName,c.Name,tr.Amount,tr.amountofmonth,tr.DurMonth,tr.BcDate,p.PaymentMode,p.PaymentDate,p.PaidAmount, p.PendingAmount	
	 from Payment p 
	 inner join Installment i on p.InstallmentId=i.InstallmentId
	inner join Groups g on g.GroupId =i.GroupId
	inner join Customer c on c.CustomerId=i.CustomerId
	inner join Transactions tr on tr.GroupId=i.GroupId
	where i.GroupId LIKE CASE WHEN @GroupId <>0 then @GroupId else CONVERT(nvarchar(50),i.GroupId ) END
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_BindGrid]    Script Date: 10/29/2015 11:31:37 ******/
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
select TransactionId,GroupName ,Amount,DurMonth,Member,amountofmonth,Percentage,RemainingMonths,MemberList,OffcetPrice
         ,Loss,ActualAmountforBCCustomer,ActualInstallment,BcDate,DueDate,GroupId,CustomerId
         from Transactions where IsDelete='False' AND IsActive='True'
END
GO
/****** Object:  View [dbo].[transaction_view]    Script Date: 10/29/2015 11:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[transaction_view] as
SELECT     dbo.Customer.CustomerId, dbo.Customer.Name, dbo.CustomerGroupDetails.CustomerGroupId, dbo.Groups.GroupId, dbo.Groups.GroupName, 
                      dbo.Installment.InstallmentId, dbo.Transactions.TransactionId, dbo.Transactions.amountofmonth
FROM         dbo.Customer INNER JOIN
                      dbo.CustomerGroupDetails ON dbo.Customer.CustomerId = dbo.CustomerGroupDetails.CustomerId INNER JOIN
                      dbo.Groups ON dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId INNER JOIN
                      dbo.Installment ON dbo.Customer.CustomerId = dbo.Installment.CustomerId AND dbo.Groups.GroupId = dbo.Installment.GroupId AND 
                      dbo.Groups.GroupId = dbo.Installment.GroupId AND dbo.Groups.GroupId = dbo.Installment.GroupId AND dbo.Groups.GroupId = dbo.Installment.GroupId INNER JOIN
                      dbo.Transactions ON dbo.Customer.CustomerId = dbo.Transactions.CustomerId AND dbo.Groups.GroupId = dbo.Transactions.GroupId
GO
/****** Object:  View [dbo].[payment_view]    Script Date: 10/29/2015 11:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[payment_view] as
SELECT     dbo.Customer.CustomerId, dbo.CustomerGroupDetails.CustomerGroupId, dbo.Groups.GroupId, dbo.Installment.InstallmentId, dbo.Payment.PaidAmount
FROM         dbo.Customer INNER JOIN
                      dbo.CustomerGroupDetails ON dbo.Customer.CustomerId = dbo.CustomerGroupDetails.CustomerId INNER JOIN
                      dbo.Groups ON dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND 
                      dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId AND dbo.CustomerGroupDetails.GroupId = dbo.Groups.GroupId INNER JOIN
                      dbo.Installment ON dbo.Customer.CustomerId = dbo.Installment.CustomerId AND dbo.Groups.GroupId = dbo.Installment.GroupId AND 
                      dbo.Groups.GroupId = dbo.Installment.GroupId AND dbo.Groups.GroupId = dbo.Installment.GroupId AND dbo.Groups.GroupId = dbo.Installment.GroupId INNER JOIN
                      dbo.Payment ON dbo.Customer.CustomerId = dbo.Payment.CustomerId
GO
/****** Object:  ForeignKey [FK__CustomerG__Custo__3B75D760]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD  CONSTRAINT [FK__CustomerG__Custo__3B75D760] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerGroupDetails] CHECK CONSTRAINT [FK__CustomerG__Custo__3B75D760]
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__41B8C09B]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__42ACE4D4]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__43A1090D]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__44952D46]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__4589517F]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__467D75B8]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__477199F1]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__4865BE2A]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__56E8E7AB]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__57DD0BE4]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__58D1301D]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__59C55456]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__5AB9788F]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__5BAD9CC8]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__5CA1C101]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__5D95E53A]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__60A75C0F]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__619B8048]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__628FA481]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__6383C8BA]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__6477ECF3]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__656C112C]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__66603565]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__CustomerG__Group__6754599E]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[CustomerGroupDetails]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
/****** Object:  ForeignKey [FK__Installme__Custo__398D8EEE]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Custo__398D8EEE] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Custo__398D8EEE]
GO
/****** Object:  ForeignKey [FK__Installme__Group__440B1D61]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__440B1D61] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__440B1D61]
GO
/****** Object:  ForeignKey [FK__Installme__Group__44FF419A]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__44FF419A] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__44FF419A]
GO
/****** Object:  ForeignKey [FK__Installme__Group__45F365D3]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__45F365D3] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__45F365D3]
GO
/****** Object:  ForeignKey [FK__Installme__Group__46E78A0C]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Installment]  WITH CHECK ADD  CONSTRAINT [FK__Installme__Group__46E78A0C] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Installment] CHECK CONSTRAINT [FK__Installme__Group__46E78A0C]
GO
/****** Object:  ForeignKey [FK_Payment_Customer]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Customer]
GO
/****** Object:  ForeignKey [FK_Transactions_Customer]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Customer]
GO
/****** Object:  ForeignKey [FK_Transactions_Groups]    Script Date: 10/29/2015 11:31:24 ******/
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Groups]
GO
