using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{

    [Serializable]
    public class Payroll
    {

        public PayrollTypes payrollTypes;





        public static IForm<Payroll> PayrollForm()
        {
            return new FormBuilder<Payroll>()
                .Message("Pls select any category")//printing msg to bot
                .Field(nameof(payrollTypes))//calling fileds with priority
                .Build();


        }


        [Serializable]

        public enum PayrollTypes
        {
            Allowances = 1,
            BasePay = 2,
            EsiTax = 3,
            GrossPay=4,
            InvestmentDetails=5,
            NetPay=6,
            PaySlip=7,
            PFContribution=8,
            ProfesstionalTaxDeducted=9,
            ProjectedTax=10,
            TaxDeduction=11,
            TDSDeduction=12


        }

        //    [Serializable]
        //    public enum IsApply
        //    {
        //        Yes = 1,
        //        No = 2
        //    }
        //}

    }

}