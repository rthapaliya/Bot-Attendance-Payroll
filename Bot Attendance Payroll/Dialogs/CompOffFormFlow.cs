using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Attendance_Payroll.Dialogs
{
    [Serializable]
    public class CompOffFormFlow
    {
        public CompOffReq compoffreq;

        public static IForm<CompOffFormFlow> CompoffForm()
        {
            return new FormBuilder<CompOffFormFlow>()
                 .Field(nameof(compoffreq))



                    .Build();
        }
        [Serializable]
        public enum CompOffReq
        {
            Apply_CompOff = 1,
            Compoff_Redeem = 2

        }
    }
}