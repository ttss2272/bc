using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /*
-- =============================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	get ande set the scheme dtails
-- Updated By :
-- Updated Date:
-- =============================================    
*/
  public class EntSchemeDetails
    {
     
      public int BCId { get; set; }
      public string BCName { get; set; }
      public string  MobileNumber { get; set; }
      public DateTime StartDate { get; set; }
      public int Amount { get; set; }
      public string  Duration { get; set; }
      public DateTime InstallmentDate { get; set; }
      public DateTime EndDate { get; set; }
    
    }
}
