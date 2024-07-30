namespace ServiceSendMqil
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendMail = new System.ServiceProcess.ServiceProcessInstaller();
            this.sendMail1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // SendMail
            // 
            this.SendMail.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SendMail.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.sendMail1});
            this.SendMail.Password = null;
            this.SendMail.Username = null;
            // 
            // sendMail1
            // 
            this.sendMail1.ServiceName = "Service1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SendMail});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SendMail;
        private System.ServiceProcess.ServiceInstaller sendMail1;
    }
}