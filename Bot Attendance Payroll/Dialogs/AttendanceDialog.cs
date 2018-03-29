
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using Microsoft.Bot.Builder.Dialogs.Internals;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;

namespace Bot_Attendance_Payroll.Dialogs
{
    [LuisModel("8fa30d4f-9134-4dad-bc66-014adb8f2f79", "42bc0b5e5d4a4515b9d1c4ef4319c673")]
    [Serializable]
    public class AttendanceDialog : LuisDialog<object>
    {
        

        // Greeting Intent
        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, IAwaitable<object> activity,LuisResult result)
        {
            var msg = await activity as Activity;
            

            if (msg.Text.Equals("hello", StringComparison.InvariantCultureIgnoreCase))
              {

                //  context.Call(new AzureAuthentication(), ResumeAfterCallingAzureAuthenctication);
                var formFLow = FormDialog.FromForm(EmployeeDetailsForm.BuildForm, FormOptions.PromptInStart);
                context.Call(formFLow, Formloaded);

            }

            else if (msg.Text.Equals("good morning", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Good Morning Friend");

            }

            else if (msg.Text.Equals("hi", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("hi how can I help you");
            }

           
            
        }


        //private async Task ResumeAfterCallingAzureAuthenctication(IDialogContext context, IAwaitable<string> result)
        //{
        //    var formFLow = FormDialog.FromForm(EmployeeDetailsForm.BuildForm, FormOptions.PromptInStart);
        //    context.Call(formFLow, Formloaded);
        //}

        ////public async  Task ResumeAfterCallingAuthenctication(IDialogContext context, IAwaitable<object> result)
        ////{

        //var formFLow = FormDialog.FromForm(EmployeeDetailsForm.BuildForm, FormOptions.PromptInStart);
        //context.Call(formFLow, Formloaded);

        ////}


        // Request.



        //v1.Leave Encashment
        [LuisIntent("Leave_Encashment")]
        public async Task LeaveEncashment(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Wait......");
            context.Call(new LeaveDialog(), ResumeAfterLeaveDialog);


        }

       
        private async Task ResumeAfterLeaveDialog(IDialogContext context, IAwaitable<object> result)
        {
             await context.PostAsync("Forwarded your request to Accounts dept");

            await context.PostAsync("You me check for other request for leave encashment...<br>"
                + "1.Type *Number of leave encashed* to know no leave encashed<br>"
                + "2.Type *calculation of leave encashemt* to know leave encashment calculation system<br>"
                + "3.Type *leave encashment not credited* if your leave encashment is not credited <br>"
                + "4.Type *leave encashment amount* to know leave encashment amount you can get.. <br>"
                + "5.Type *leave encashment cycle* to know about leave encashment cycle <br>"
                + "6.Type *how will I get leave encashment amount* to know about leave encashment deposit <br>"

                );

           
        }

        // v1.1 No of leaves get encashed
        [LuisIntent("No_of_LeaveEncashed")]
        public async Task No_of_LeaveEncashed(IDialogContext context, LuisResult result)
        {
           
            context.Call(new No_of_LeaveEncashed(), this.ResumeAfterLeaveDialog);
    
        }
        // v1.2 calculation of leave encashment
        [LuisIntent("Calculation_of_LeaveEncashment ")]
        public async Task Calculation_of_LeaveEncashment(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Leave encashment calculation is done on basic salary");

        }
        //v1.3 leaveencashment credit
        [LuisIntent("leaveencashment_credit  ")]
        public async Task leaveencashment_credit(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("It will be deposited in your account");

        }

        //v1.4 leaveencashment resign
        [LuisIntent("Leave_encashment_resign  ")]
        public async Task Leave_encashment_resign(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes you can get leave encashment benifit if you resign");

        }

        //v1.5 leave encashment cycle
        [LuisIntent("leave_encashment_cycle")]
        public async Task leave_encashment_cycle(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("leave encashment cycle is for 6 months");

        }
        //v1.5 leave encashment not ques
        [LuisIntent("leave_encashment_not ")]
        public async Task leave_encashment_not(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Oh..I need to check, request forwarded to your HR");

        }

        // v1.6 amount from leave encashment
        [LuisIntent("leave_encashment_amount  ")]
        public async Task leave_encashment_amount(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You will get 30,000 rs");

        }



        //2.Tour
        [LuisIntent("Tour")]
        public async Task CallingTourMethod(IDialogContext context, LuisResult result)
        {
                       
            await context.PostAsync("Wait......");
            context.Call(new Tour(), ResumeAfterCallingTour);


        }

        public async Task ResumeAfterCallingTour(IDialogContext context, IAwaitable<object> activity)
        {
            await context.PostAsync("Forwarded your request to Your Manager");
            await context.PostAsync("Check more for tour..."
                 +"1.Type *Accomodation Allowance* to know about accomodation allowance<br>"
                + "2.Type *Travel Allowance* to know about travel allowance<br>"
                + "3.Type *Tour application status* to check status of tour <br>"
                + "4.Type *Reason for tour disapproved* to know reason for disapproval of tour <br>"
                + "5.Type *Tour Details* to know about your tour details <br>"
                );
        }

        // v2.1 accomodation_allowance
        [LuisIntent("Accomodation_Allowance")]
        public async Task Accomodation_Allowance(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes you can get accomadation_allowance<br>"+"Put up your bill after tour<br>");
            await context.PostAsync("Max Allowance for accomodation allowed is 5000 Rs");

        }
        // v2.2 accomodation_allowance
        [LuisIntent("Travel_Allowance")]
        public async Task Travel_Allowance(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes you can get travel_allowance<br>" + "Put up your bill after tour<br>");
            await context.PostAsync("Max Allowance for travel allowed is 3000 Rs");

        }

        // v2.3 tour status
        [LuisIntent("Tour_Application_Status ")]
        public async Task Tour_Application_Status(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("It has be sent to your manager<br>"+"**Status**:pending for approval");  

        }

        // v2.4 Tour_Disapproval 
        [LuisIntent("Tour_Disapproval ")]
        public async Task Tour_Disapproval(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Your tour is reschedule<br>" + "**Reason**:Client Meeting");

        }

        // v2.5 Tour_Details
        [LuisIntent("Tour_Details ")]
        public async Task Tour_Details(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Your tour deatils are as follows<br>" + "1.Tour StartDate:18-03-2018<br>"+"2.Tour End: 20-03-2018<br>"+"3.Place:Delhi<br>");

        }



        // 3.OutdoorDuty
        [LuisIntent("Outdoor")]
        public async Task CallingOutdoorMethod(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(" I am Outdoor Duty");
            context.Call(new OutdoorDuty(), ResumeAfterCallingOutdoorDuty);
        }

        public async Task ResumeAfterCallingOutdoorDuty(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Your request is forwarded");
            await context.PostAsync("You me check for other request also..."
                 + "1.Type *apply outdoor duty* to apply for outdoor duty <br>"
                + "2.Type *travel allowance* to check travel allowance<br>"
                );

        }
        // v3.1 Outdoorduty_Disapproval 
        [LuisIntent("Outdoor_Disapproved")]
        public async Task Outdoor_Disapproved(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Your outdoor duty is reschedule<br>" + "**Reason**:Client Meeting");

        }


        //v.4 Work From Home
        [LuisIntent("WorkFromHome")]
        public async Task CallingWorkFromHome(IDialogContext context, LuisResult result)
        {
            var workform = FormDialog.FromForm(WorkFromHomeFormFlow.WorkFromHomeForm, FormOptions.PromptInStart);
            context.Call(workform, ResumeAfterCallingWorkFromHome);

        }

        private async Task ResumeAfterCallingWorkFromHome(IDialogContext context, IAwaitable<WorkFromHomeFormFlow> result)
        {
            await context.PostAsync("Your request is forwared");
            await context.PostAsync("You me check for other request also..."
                 + "1.Type *Max days for work from home* to check max work home days<br>"
                + "2.Type *working hours for work from home* to check  work fom home hours<br>"
                + "3.Type *work from home disapproved* to know reason for disapproved <br>");

        }


        // v4.1 Max_days_wfh  
        [LuisIntent("Max_days_wfh ")]
        public async Task Max_days_wfh(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can work max 20 days as work from home in a year <br>"+"Max in 8 times in a month");

        }

        // v4.2 Working_hrs_workfh  
        [LuisIntent("Working_hrs_workfh ")]
        public async Task Working_hrs_workfh(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(" You need to work net 6hrs for work from home");

        }

        // v4.3 Disapprove_workfh   
        [LuisIntent("Disapprove_workfh  ")]
        public async Task Disapprove_workfh(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You are not eligible for work from home");

        }

        //v.5 WorkTime
        [LuisIntent("Work_Time")]
        public async Task CallingWorkTimeMethod(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(" i am workTime");
            context.Call(new WorkTime(), ResumeAfterCallingWorkTime);

        }

        public async Task ResumeAfterCallingWorkTime(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync(" Your equest send for approval");
        }



        //6.Misspunch
        [LuisIntent("Mispunch")]
        private async Task CallingMisspunchMethod(IDialogContext context, LuisResult result)
       {
            await context.PostAsync("I am Misspunch");
            context.Call(new Misspunch(), ResumeAfterCallingMisspunch);
        }

        private async Task ResumeAfterCallingMisspunch(IDialogContext context, IAwaitable<string> result)
        {
            await context.PostAsync(" Your equest send for approval");
        }

        // 7.Compoff
        [LuisIntent("Compoff_apply ")]
        private async Task CallingCompOffMethod(IDialogContext context, LuisResult result)
        {

            context.Call(new Compoff(), ResumeAfterCallingCompoff);
        }

        private async Task ResumeAfterCallingCompoff(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Your request is forwared");
        }


        // v7.1 Compoff_redeem   
        [LuisIntent("Compoff_redeem")]
        public async Task Compoff_redeem(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes , your compoff can be redeem <br>");

        }

        
        //6.Apply
        [LuisIntent("Apply_leave ")]
        public async Task Apply_Leave(IDialogContext context, LuisResult result)
        {
            
            context.Call(new ApplyingLeave(),ResumeAfterLeaveApply);


        }

        private async Task ResumeAfterLeaveApply(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Your leave has been  granted by your manager");
        }










        // 2. Calling Profile
        [LuisIntent("Profile")]
        public async Task CallingProfileMethod(IDialogContext context,LuisResult result)
        {
            await context.PostAsync("I am profile");
            context.Call(new Profile(),ResumeAfterCallingProfile);
        }
        
        // Resume After Calling  Profile
        public async Task ResumeAfterCallingProfile(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync(" Your profile request send for approval");
        }



        //3. Calling Payroll
        [LuisIntent("Payroll")]
        public async Task CallingPayrollMethod(IDialogContext context,LuisResult result)
        {
            await context.PostAsync("i am Payroll");
            var payrollform = FormDialog.FromForm(Payroll.PayrollForm, FormOptions.PromptInStart);
            context.Call(payrollform, ResumeAfterCallingPayroll);


        }

        public async Task ResumeAfterCallingPayroll(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Your Request is sent for approval");
        }

        



        //4 Holidays
        //[LuisIntent("Holidays")]
        //public async Task CallingHolidaysMethod(IDialogContext context, LuisResult result)
        //{
        //    await context.PostAsync("I am Holidays");
        //    context.Call(new Holiday(), ResumeAfterCallingHoliday);

        //}
        //// Resume after Calling Holiday
        //public async Task ResumeAfterCallingHoliday(IDialogContext context, IAwaitable<object> result)
        //{
        //    await context.PostAsync(" Your equest send for approval");
        //}





        
        // Calling Default None Intent

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry I dont know what you wanted.....");
            await context.PostAsync("### What are you looking for? <br>" +
                ">1.Leave Encashment<br>"+"Try message like *leave encashment*<br><br>"+
                ">2.Tour <br>" + "Type *tour*<br><br>"+
                ">3.Outdoor Duty<br>" + "Type *Outdoor Duty*<br><br>"+
                ">4.Work From Home <br>" + "Type *Work From Home*<br><br>"+
                ">5.Compoff<br>" + "Type *Compoff*<br><br>"+
                ">6.Mispunch<br>" + "Type *Mispunch*<br><br>"+
                ">7.Working Hrs<br>" + "Type *Working Hrs*<br><br>"+
                ">8.Holidays<br>" + "Type *Holidays*<br><br>"+
                ">9.Payroll<br>" + "Type *Payroll*<br><br>"+
                ">10.Profile<br>" + "Type *Profile*<br><br>"
                );       
        context.Wait(MessageReceived);
        }

      
        public async Task FormFlowResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
           await context.PostAsync("Form Flow Finished");
            context.Wait(MessageReceived);
        }

        public async Task Formloaded(IDialogContext context, IAwaitable<EmployeeDetailsForm> result)
        {
            var token = await result;
            if(token.requestTypes.Equals("Leave Encashment"))
            {
                context.Wait(MessageReceived);
            }
            else if(token.requestTypes.Equals("Tour"))
            {
                context.Wait(MessageReceived);
            }

            else if(token.requestTypes.Equals("Outdoor Duty"))
            {
                context.Wait(MessageReceived);
            }

            else if(token.requestTypes.Equals("Work From Home"))
            {
                context.Wait(MessageReceived);
            }
            else if(token.requestTypes.Equals("CompOff"))
            {
                context.Wait(MessageReceived);
            }
            else if(token.requestTypes.Equals("Mispunch"))
            {
                context.Wait(MessageReceived);
            }

            else if(token.requestTypes.Equals("Apply For Leave"))
            {
                context.Wait(MessageReceived);
            }

            else if(token.requestTypes.Equals("WorkTime"))
            {
                context.Wait(MessageReceived);
            }
            else if(token.requestTypes.Equals("Holidays"))
            {
                context.Wait(MessageReceived);
            }

            else if(token.requestTypes.Equals("Payroll"))
            {
                context.Wait(MessageReceived);
            }
            else if(token.requestTypes.Equals("Profile"))
            {
                context.Wait(MessageReceived);
            }
            
           
        }

        
        [LuisIntent("LeaveEncashmentType ")]
        public async Task LeaveEncashmentType(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("yes it is encashable");
        }

        public async Task ResumeAfterCallingAnyMethod(IDialogContext context, IAwaitable<string> result)
        {
            await context.PostAsync("your request is under process");
            context.Wait(MessageReceived);
        }

        ///////////k////////////////
        //k1:Pf_number
        [LuisIntent("Pf_number")]
        public async Task Pfnumber(IDialogContext context, LuisResult result)
        {
            // await context.PostAsync("Pf number");
            context.Call(new Pf_number(), this.ResumeAfterTaskDialog);
            //context.Wait(MessageReceivedAsync);
        }
        private async Task ResumeAfterTaskDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("ok how else can i help you");
            await context.PostAsync("### What are you looking for? <br>" +
                ">1.Leave Encashment<br>" + "Try message like *leave encashment*<br><br>" +
                ">2.Tour <br>" + "Type *tour*<br><br>" +
                ">3.Outdoor Duty<br>" + "Type *Outdoor Duty*<br><br>" +
                ">4.Work From Home <br>" + "Type *Work From Home*<br><br>" +
                ">5.Compoff<br>" + "Type *Compoff*<br><br>" +
                ">6.Mispunch<br>" + "Type *Mispunch*<br><br>" +
                ">7.Working Hrs<br>" + "Type *Working Hrs*<br><br>" +
                ">8.Holidays<br>" + "Type *Holidays*<br><br>" +
                ">9.Payroll<br>" + "Type *Payroll*<br><br>" +
                ">10.Profile<br>" + "Type *Profile*<br><br>"
                );

            context.Wait(MessageReceived);
        }
        //k2:Join_date
        [LuisIntent("Join_date")]
        public async Task Join_date(IDialogContext context, LuisResult result)
        {
            context.Call(new Join_date(), this.ResumeAfterTaskDialog);
        }


        //k3:Experience
        [LuisIntent("Experience")]
        public async Task Experience(IDialogContext context, LuisResult result)
        {
            context.Call(new Experience(), this.ResumeAfterTaskDialog);
        }
        //k4:Holidays
        [LuisIntent("Holidays")]
        public async Task Holidays(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("3 years");
            //context.Wait(MessageReceived);
            context.Call(new Holidays(), this.ResumeAfterTaskDialog);
        }
        //k5:Work_on_holiday
        [LuisIntent("Work_on_holiday")]
        public async Task Work_on_holiday(IDialogContext context, LuisResult result)
        {
            context.Call(new Work_on_holiday(), this.ResumeAfterTaskDialog);

        }
        //k6:Hrs_work_holiday
        [LuisIntent("Hrs_work_holiday")]
        public async Task Hrs_work_holiday(IDialogContext context, LuisResult result)
        {
            context.Call(new Hrs_work_holiday(), this.ResumeAfterTaskDialog);

        }
        //k7:House_rent_allowance
        [LuisIntent("House_rent_allowance")]
        public async Task House_rent_allowance(IDialogContext context, LuisResult result)
        {
            context.Call(new Hrs_work_holiday(), this.ResumeAfterTaskDialog);
        }
        //k8:Dearness_allowance
        [LuisIntent("Dearness_allowance")]
        public async Task Dearness_allowance(IDialogContext context, LuisResult result)
        {
            context.Call(new Dearness_allowance(), this.ResumeAfterTaskDialog);
        }
        //k9:Medical_allowance
        [LuisIntent("Medical_allowance")]
        public async Task Medical_allowance(IDialogContext context, LuisResult result)
        {
            context.Call(new Medical_allowance(), this.ResumeAfterTaskDialog);
        }
        //k18:Lta_allowance 
        [LuisIntent("Lta_allowance")]
        public async Task Lta_allowance(IDialogContext context, LuisResult result)
        {
            context.Call(new Lta_allowance(), this.ResumeAfterTaskDialog);
        }
        //k10:Tax_deductions
        [LuisIntent("Tax_deductions")]
        public async Task Tax_deductions(IDialogContext context, LuisResult result)
        {
            context.Call(new Tax_deductions(), this.ResumeAfterTaskDialog);
        }
        //k11:Payslip
        [LuisIntent("Payslip")]
        public async Task Payslip(IDialogContext context, LuisResult result)
        {
            context.Call(new Payslip(), this.ResumeAfterTaskDialog);
        }
        //k12:Base_pay
        [LuisIntent("Base_pay")]
        public async Task Base_pay(IDialogContext context, LuisResult result)
        {
            context.Call(new Base_pay(), this.ResumeAfterTaskDialog);
        }
        //k16:Gross_pay
        [LuisIntent("Gross_pay")]
        public async Task Gross_pay(IDialogContext context, LuisResult result)
        {
            context.Call(new Gross_pay(), this.ResumeAfterTaskDialog);
        }
        //k17:Net_pay
        [LuisIntent("Net_pay")]
        public async Task Net_pay(IDialogContext context, LuisResult result)
        {
            context.Call(new Net_pay(), this.ResumeAfterTaskDialog);
        }
        //k13:Pf_contribution
        [LuisIntent("Pf_contribution")]
        public async Task Pf_contribution(IDialogContext context, LuisResult result)
        {
            context.Call(new Pf_contribution(), this.ResumeAfterTaskDialog);
        }
        //k14:Professional_tax_deducted
        [LuisIntent("Professional_tax_deducted")]
        public async Task Professional_tax_deducted(IDialogContext context, LuisResult result)
        {
            context.Call(new Professional_tax_deducted(), this.ResumeAfterTaskDialog);
        }
        //k15:Esi_tax
        [LuisIntent("Esi_tax")]
        public async Task Esi_tax(IDialogContext context, LuisResult result)
        {
            context.Call(new Esi_tax(), this.ResumeAfterTaskDialog);
        }


        //k19:Projected_tax
        [LuisIntent("Projected_tax")]
        public async Task Projected_tax(IDialogContext context, LuisResult result)
        {
            context.Call(new Projected_tax(), this.ResumeAfterTaskDialog);
        }
        //k20:Investment_details 
        [LuisIntent("Investment_details")]
        public async Task Investment_details(IDialogContext context, LuisResult result)
        {
            context.Call(new Hrs_work_holiday(), this.ResumeAfterTaskDialog);
        }
        //k21:Section 80d,80c
        [LuisIntent("Section")]
        public async Task Section(IDialogContext context, LuisResult result)
        {
            context.Call(new Section(), this.ResumeAfterTaskDialog);
        }
        //k22:Tds_deduction 
        [LuisIntent("Tds_deduction")]
        public async Task Tds_deduction(IDialogContext context, LuisResult result)
        {
            context.Call(new Tds_deduction(), this.ResumeAfterTaskDialog);
        }
        //k23:Allowances 
        [LuisIntent("Allowances")]
        public async Task Allowances(IDialogContext context, LuisResult result)
        {
            context.Call(new Allowances(), this.ResumeAfterTaskDialog);
        }
        [LuisIntent("Half_day")]
        public async Task Half_day(IDialogContext context, LuisResult result)
        {
            context.Call(new HalfDay(), this.ResumeAfterTaskDialog);
        }

        //k25:gross ,net and avg hrs of month
        [LuisIntent("Working_Hrs")]
        public async Task Working_Hrs(IDialogContext context, LuisResult result)
        {
            context.Call(new Working_Hrs(), this.ResumeAfterTaskDialog);
        }
        //k26:in/out time for month
        [LuisIntent("In_Out_Time")]
        public async Task In_Out_Time(IDialogContext context, LuisResult result)
        {
            context.Call(new In_Out_Time(), this.ResumeAfterTaskDialog);
        }
        //k27:Late comings of the month
        [LuisIntent("Late_Comings")]
        public async Task Late_Comings(IDialogContext context, LuisResult result)
        {
            context.Call(new Late_Comings(), this.ResumeAfterTaskDialog);
        }
        [LuisIntent("Early_leavings")]
        public async Task Early_leavings(IDialogContext context, LuisResult result)
        {
            context.Call(new Early_leavings(), this.ResumeAfterTaskDialog);
        }


    }


}
