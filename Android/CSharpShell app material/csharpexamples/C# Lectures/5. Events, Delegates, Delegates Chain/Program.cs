using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Events_Delegates
{
    class Program
    {
        ///////////////////////////////////////////////EVENTS////////////////////////////////////////////
        internal sealed class CallEventArgs: EventArgs
        {
            private readonly string   m_CallerName;
            private readonly DateTime m_CallStartTime;
            private readonly string m_CallerNumber;
            public CallEventArgs(string callername, string callernumber, DateTime starttime)
            {
                m_CallerName = callername;
                m_CallerNumber = callernumber;
                m_CallStartTime = starttime;
            }
            public string CallerName
            {
                get { return m_CallerName; }
            }
            public string CallerNumber
            {
                get { return m_CallerNumber; }
            }
            public DateTime CallStartTime
            {
                get { return m_CallStartTime; }
            }
        }
        internal class CellPhone
        {
            public event EventHandler<CallEventArgs> NewCallEvent;
            protected virtual void OnNewCallEvent(CallEventArgs e)
            {
                //here we make a copy of event to make sure we don't
                //call on null
                EventHandler<CallEventArgs> temp = System.Threading.Volatile.Read(ref NewCallEvent);
                if (temp != null)
                    temp(this, e);
            }
            public void NewCallHappened(string username, string usernumber, DateTime time)
            {
                //create event data
                CallEventArgs eventData = new CallEventArgs(username, usernumber, time);
                //raise the event
                OnNewCallEvent(eventData);
            }
        }
        internal sealed class CellPhoneCallsLog
        {
            public void AttachListener(CellPhone phone)
            {
                phone.NewCallEvent += AddNewCallToLog;
            }
            public void DetachListener(CellPhone phone)
            {
                phone.NewCallEvent -= AddNewCallToLog;
            }
            private void AddNewCallToLog(object sender, CallEventArgs e)
            {
                Console.WriteLine("I'm CallsLog and handling this call by adding to log following data:");
                Console.WriteLine("Name:" + e.CallerName);
                Console.WriteLine("Number:" + e.CallerNumber); 
                Console.WriteLine("Time:" + e.CallStartTime.ToString());
            }
        }
        internal sealed class CallHandler 
        {
            public CallHandler(CellPhone phone)
            {
                phone.NewCallEvent += HandleTheCall;
            }
            private void HandleTheCall(object sender, CallEventArgs e)
            {
                Console.WriteLine("I'm CallHandler and handling this call by:");
                Console.WriteLine("-ringing music");
                Console.WriteLine("-vibrate");
                Console.WriteLine("-show caller information at screen");
            }
            public void DetachFromNewCallEvent(CellPhone phone)
            {
                phone.NewCallEvent -= HandleTheCall;
            }
        }

        //////////////////////////////////////////////DELEGATES///////////////////////////////////////////
        internal delegate string DelegateForNotification(string s);

        internal class Notificator
        {
            public void DemoNotification(string s, DelegateForNotification outputFunction)
            {
                Console.WriteLine("we're going to process string: " + s);
                if (outputFunction != null) //if we have callbacks let's call them
                {
                    Console.WriteLine("Function that is used as delegate is: " + outputFunction.Method);
                    Console.WriteLine("Delegate output is: " + outputFunction(s));
                }
                else 
                {
                    Console.WriteLine("Sorry, but no processing methods were registered!!!");
                }
            }
        }
        internal class NotificationHandler 
        {
            public string SendNotificationByMail(string s)
            {
                Console.WriteLine("We are sending notification:\"" + s + "\" by MAIL");
                return "MAIL NOTIFICATION IS SENT";
            }
            public string SendNotificationByFax(string s)
            {
                Console.WriteLine("We are sending notification: \"" + s + "\" by FAX");
                return "FAX NOTIFICATION IS SENT";
            }
            public static string SendNotificationByInstantMessenger(string s)
            {
                Console.WriteLine("We are sending notification: \"" + s + "\" by IM");
                return "IM NOTIFICATION IS SENT";
            }
        }

        static void Main(string[] args)
        {
            //------------------EVENTS-----------
            Console.WriteLine("---------------------------------EVENTS------------------------:");
            CellPhone phone = new CellPhone();
            CellPhoneCallsLog log = new CellPhoneCallsLog();
            CallHandler handler = new CallHandler(phone);
            log.AttachListener(phone);
            Console.WriteLine("----------------Calling first time with two listeners:");
            phone.NewCallHappened("sergey", "1234567", DateTime.Now);
            handler.DetachFromNewCallEvent(phone);
            Console.WriteLine("----------------Calling again without CallHandler:");
            phone.NewCallHappened("sergey", "1234567", DateTime.Now);

            //------------------DELEGATES-----------
            Console.WriteLine("---------------------------------DELEGATES------------------------:");
            Notificator notificator = new Notificator();
            NotificationHandler notification_handler = new NotificationHandler();
            //calling static delegate
            notificator.DemoNotification("static example", null);//nothing happen here we don't pass any handler
            notificator.DemoNotification("static example", new DelegateForNotification(NotificationHandler.SendNotificationByInstantMessenger));//nothing happen here
            //calling instance delegate
            notificator.DemoNotification("instance example", null);//nothing happen here we don't pass any handler
            notificator.DemoNotification("instance example", new DelegateForNotification(notification_handler.SendNotificationByMail));
            notificator.DemoNotification("instance example", new DelegateForNotification(notification_handler.SendNotificationByFax));
            //passing null instead of correct value, it builds well
            NotificationHandler nullhandler = null;
            try 
            {
                notificator.DemoNotification("instance example", new DelegateForNotification(nullhandler.SendNotificationByFax));
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("We've tried to pass null object for delegate and catched: " + e.Message);
            }
            //------------------DELEGATES CHAIN-----------
            Console.WriteLine("-----------------------------DELEGATES CHAIN--------------------:");
            DelegateForNotification dlg1 = new DelegateForNotification(NotificationHandler.SendNotificationByInstantMessenger);
            DelegateForNotification dlg2 = new DelegateForNotification(notification_handler.SendNotificationByMail);
            DelegateForNotification dlg3 = new DelegateForNotification(notification_handler.SendNotificationByFax);

            DelegateForNotification dlg_chain = null;
            dlg_chain += dlg1;
            dlg_chain += dlg2;
            dlg_chain = (DelegateForNotification)Delegate.Combine(dlg_chain,dlg3);//more complex way to combine delegate to chain
            //you can view invocation list
            Delegate[] list = dlg_chain.GetInvocationList();
            foreach (Delegate del in list)
            {
                Console.WriteLine("Method: " + del.Method.ToString());
            }
            notificator.DemoNotification("chain example", dlg_chain);//calling notification to chain from 3 functions

        }
    }
}
