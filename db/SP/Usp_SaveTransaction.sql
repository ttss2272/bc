USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_SaveTransaction]    Script Date: 10/21/2015 13:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Usp_SaveTransaction] --23,10000,10,10,1111,2,09,'BC10000','KIRAN',100,1000,1000,100,1000,'CHAVAN','2015-10-21','2015-10-21',1000,0,0,'abc','pqr',100,'xyz',200
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
