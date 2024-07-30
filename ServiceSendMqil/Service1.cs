using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceSendMqil
{
    public partial class Service1 : ServiceBase
    {
        private static System.Timers.Timer aTimer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            WriteLogSystem("Demarrage du service Send Mail", string.Format("Le service a démarré à {0}", DateTime.Now));
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            WriteLogSystem("Arret du service SenMail", string.Format("Le service est arrété à {0}", DateTime.Now));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            try
            {
                /*WriteLogSystem("test", DateTime.Now.ToString());*/
                ProcessData().Wait();
            }
            catch (Exception ex)
            {

            }

            //Thread.Sleep(300000);
            aTimer.Start();
        }

        /// <summary>
        /// Cette methode permet de logger dans le systeme
        /// </summary>
        /// <param name="erreur">message d'erreur</param>
        /// <param name="libelle">titre erreur</param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Send Mail: ";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
        private static async Task ProcessData()
        {
            try
            {
                WriteLogSystem("Arret du service SenMail", string.Format("Le service est arrété à {0}", DateTime.Now));
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "SendMail");
            }
        }
    }
}
