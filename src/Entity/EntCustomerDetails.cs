using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public  class EntCustomerDetails
    {
 
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Reference { get; set; }
        public string Nominee { get; set; }
        public string RequiredSMSnotification { get; set; }
        public string IdentityProof { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string CreditcardNo { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
       
       

    }
}
