using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanApplication
{
    class EntInstallment
    {
        public int InstId { get; set; }
        public string GrupName { get; set; }
        public string MemberName { get; set; }
        public int BCTotalAmount { get; set; }
        public int DurationMonth { get; set; }
        public int InstallAmount { get; set; }
        public int ActulInstallment { get; set; }
        public DateTime PrevInstallDate { get; set; }
        public DateTime InstallDate { get; set; }
        public string PymentMode { get; set; }
        public int ChequeNo { get; set; }
        public int Amount { get; set; }
        public int ActulAmount { get; set; }
        public DateTime DeuDate { get; set; }
        public int PrevBalance { get; set; }
        public int Balance { get; set; }
    }
}
