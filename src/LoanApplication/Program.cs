using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security;
using System.Text;
using System.Configuration;
namespace LoanApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        //public class Company : ConfigurationElement
        //{

        //    [ConfigurationProperty("name", IsRequired = true)]
        //    public string Name
        //    {
        //        get
        //        {
        //            return this["name"] as string;
        //        }
        //    }
        //    [ConfigurationProperty("code", IsRequired = true)]
        //    public string Code
        //    {
        //        get
        //        {
        //            return this["code"] as string;
        //        }
        //    }
        //}

        //public class Companies : ConfigurationElementCollection
        //{
        //    public Company this[int index]
        //    {
        //        get
        //        {
        //            return base.BaseGet(index) as Company;
        //        }
        //        set
        //        {
        //            if (base.BaseGet(index) != null)
        //            {
        //                base.BaseRemoveAt(index);
        //            }
        //            this.BaseAdd(index, value);
        //        }
        //    }

        //    public new Company this[string responseString]
        //    {
        //        get { return (Company)BaseGet(responseString); }
        //        set
        //        {
        //            if (BaseGet(responseString) != null)
        //            {
        //                BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
        //            }
        //            BaseAdd(value);
        //        }
        //    }

        //    protected override System.Configuration.ConfigurationElement CreateNewElement()
        //    {
        //        return new Company();
        //    }

        //    protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        //    {
        //        return ((Company)element).Name;
        //    }
        //}

        //public class RegisterCompaniesConfig : ConfigurationSection
        //{
        //    public static RegisterCompaniesConfig GetConfig()
        //    {
        //        return (RegisterCompaniesConfig)System.Configuration.ConfigurationManager.GetSection("RegisterCompanies") ?? new RegisterCompaniesConfig();
        //    }

        //    [System.Configuration.ConfigurationProperty("Companies")]
        //    [ConfigurationCollection(typeof(Companies), AddItemName = "Company")]
        //    public Companies Companies
        //    {
        //        get
        //        {
        //            object o = this["Companies"];
        //            return o as Companies;
        //        }
        //    }

        //}

        //public bool Algorithm(String appPassword, String pass)
        //{
        //    globalPath = pass;
        //    bool chpass = checkPassword(appPassword);
        //    if (chpass == true) //execute
        //        return true;
        //    else
        //    {
        //        bool block = blackListCheck();
        //        if (block == false)
        //        {
        //            string chinstall = checkfirstDate();
        //            if (chinstall == "First")
        //            {
        //                firstTime();// installation date
        //                DialogResult ds = MessageBox.Show("You are using trial Pack! Would you Like to Activate it Now!", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                if (ds == DialogResult.Yes)
        //                {
        //                    Login f1 = new Login(appPassword, globalPath);
        //                    DialogResult ds1 = f1.ShowDialog();
        //                    if (ds1 == DialogResult.OK)
        //                        return true;
        //                    else
        //                        return false;
        //                }
        //                else
        //                    return true;
        //            }
        //            else
        //            {
        //                string status = dayDifPutPresent();
        //                if (status == "Error")
        //                {
        //                    blackList();
        //                    DialogResult ds = MessageBox.Show("Application Can't be loaded, Unauthorized Date Interrupt Occurred! Without activation it can't run! Would you like to activate it?", "Terminate Error-02", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //                    if (ds == DialogResult.Yes)
        //                    {
        //                        Login f1 = new Login(appPassword, globalPath);
        //                        DialogResult ds1 = f1.ShowDialog();
        //                        if (ds1 == DialogResult.OK)
        //                            return true;
        //                        else
        //                            return false;
        //                    }
        //                    else
        //                        return false;
        //                }
        //                else if (status == "Expired")
        //                {
        //                    DialogResult ds = MessageBox.Show("The trial version is now expired! Would you Like to Activate it Now!", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                    if (ds == DialogResult.Yes)
        //                    {
        //                        Login f1 = new Login(appPassword, globalPath);
        //                        DialogResult ds1 = f1.ShowDialog();
        //                        if (ds1 == DialogResult.OK)
        //                            return true;
        //                        else
        //                            return false;
        //                    }
        //                    else
        //                        return false;
        //                }
        //                else // execute with how many day remaining
        //                {
        //                    DialogResult ds = MessageBox.Show("You are using trial Pack, you have " + status + " days left to Activate! Would you Like to Activate it now!", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                    if (ds == DialogResult.Yes)
        //                    {
        //                        Login f1 = new Login(appPassword, globalPath);
        //                        DialogResult ds1 = f1.ShowDialog();
        //                        if (ds1 == DialogResult.OK)
        //                            return true;
        //                        else
        //                            return false;
        //                    }
        //                    else
        //                        return true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            DialogResult ds = MessageBox.Show("Application Can't be loaded, Unauthorized Date Interrupt Occurred! Without activation it can't run! Would you like to activate it?", "Terminate Error-01", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //            if (ds == DialogResult.Yes)
        //            {
        //                Login f1 = new Login(appPassword, globalPath);
        //                DialogResult ds1 = f1.ShowDialog();
        //                if (ds1 == DialogResult.OK)
        //                    return true;
        //                else
        //                    return false;
        //            }
        //            else
        //                return false;
        //            //return "BlackList";
        //        }
        //    }
        //}  

        class TrialTimeManager
        {
            /// <summary>
            /// A Temporary variable.
            /// </summary>
            private string temp = "";

            /// <summary>
            /// The constructor.
            /// </summary>
            public TrialTimeManager()
            {

            }

            /// <summary>
            /// Sets the new date +31 days add for trial.
            /// </summary>
            public void SetNewDate()
            {
                DateTime newDate = DateTime.Now.AddDays(31);
                temp = newDate.ToLongDateString();
                StoreDate(temp);
            }

            /// <summary>
            /// Checks if expire or NOT.
            /// </summary>
            public void Expired()
            {
                string d = "";
                using (Microsoft.Win32.RegistryKey key =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"C:\Program Files\Test"))
                {
                    d = (String)key.GetValue("Date");
                }
                DateTime now = DateTime.Parse(d);
                int day = (now.Subtract(DateTime.Now)).Days;
                if (day > 30) { }
                else if (0 < day && day <= 30)
                {
                    string daysLeft = string.Format("{0} days more to expire", now.Subtract(DateTime.Now).Days);
                    MessageBox.Show(daysLeft);
                }
                else if (day <= 0)
                {
                    /* Fill with more code, once it has expired, what will happen nex! */
                }
            }

            /// <summary>
            /// Stores the new date value in registry.
            /// </summary>
            /// <param name="value"></param>
            private void StoreDate(string value)
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key =
                        Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"C:\Program Files\Test"))
                    {
                        key.SetValue("Date", value, Microsoft.Win32.RegistryValueKind.String);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}

