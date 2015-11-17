using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class EntTransaction
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int InstallmentId { get; set; }
        public float Amount { get; set; }
        public int Month { get; set; }
        public int Member { get; set; }
        public float amountofmonth { get; set; }
        public float Percentage { get; set; }
        public int RemainingMonths { get; set; }
        public string MemberList { get; set; }
        public float OffcetPrice { get; set; }
        public float Loss { get; set; }
        public float ActualAmountforBCCustomer { get; set; }
        public int Installment { get; set; }
        public float Drawa { get; set; }
        public float ActualInstallment { get; set; }
        public string BcRecriverMember { get; set; }
        public DateTime BcDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime DueDate { get; set; }
        public string GroupName { get; set; }

        public int CustomerId { get; set; }
        public int GroupId { get; set; }

        public string Drawa1Name { get; set; }
        public int Drawa2Amount { get; set; }
        public string Drawa2Name { get; set; }
        public string RunnerUpName { get; set; }
        public int RunnerUpAmount { get; set; }
        public string InstallmentStatus { get; set; }
       




    
    }
}
