using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estacionamento.Dialog;
using System.Reflection;
using System.IO;

namespace Estacionamento.Dialog
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            lblTitle.Text = AssemblyTitle;
            lblVersion.Text = AssemblyVersion;
            lblCopy.Text = AssemblyCopyright;
        }

        // Método para preencher a progressbar
        private void loadProgress()
        {
            progressSplash.Value = 0;
            
            /*int contador = 1;

            while (contador <= 1000)
            {
                progressSplash.PerformStep();
                contador++;
            }*/

            for (int i = 1; i <= 1000; i++)
            {
               progressSplash.PerformStep();
            }

            progressSplash.Value = 0;
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            if (progressSplash.Value < 100)
            {
                progressSplash.Value += 2;
            }
            else
            {
                timerSplash.Enabled = false;
                this.Visible = false;

                // Chamar a tela Login
                Login telaLogin = new Login();
                telaLogin.ShowDialog();

            }
        }

        #region AssemblyInfo
        /*
         * Dados para Splash Screen
         * Arquivo: AssemblyInfo.cs
         */

        // Propriedade que retorna o titulo do programa
        public string AssemblyTitle 
        { 
            get
            {
                object[] atributos = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyKeyNameAttribute), false);
                if (atributos.Length > 0)
	            {
		            AssemblyTitleAttribute titulo = (AssemblyTitleAttribute)atributos[0];
                    if (titulo.Title != "")
                    {
                        return titulo.Title;
                    }
	            }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        // Propriedade que retorna a versão do programa
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        // Propriedade que retorna a nota de copyrighy do programa
        public string AssemblyCopyright
        {
            get
            {
                object[] atributos = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (atributos.Length == 0)
                {
                    return "";
                }

                return ((AssemblyCopyrightAttribute)atributos[0]).Copyright;
            }
        }

        #endregion

    }
}
