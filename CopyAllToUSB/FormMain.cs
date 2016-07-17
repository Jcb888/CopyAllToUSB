using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CopyAllToUSB
{


    public partial class FormMain : Form
    {
        configObject co = new configObject();

        public FormMain()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();//pour récupérer les arguments de la ligne de commande
            labelPathEnCours.Text = "";
            XmlSerializer xs = new XmlSerializer(typeof(configObject));//pour serialiser en XML la config (sauvegarde des paths src et dst)
            using (StreamReader rd = new StreamReader("config.xml"))
            {
                co = xs.Deserialize(rd) as configObject;
                this.txtBoxSourcePath.Text = co.strSourcePath;
                this.txtBoxDestinationPath.Text = co.strDestinationPath;

            }

            // si aplli est ouverte avec param == hide on cache la feneter et on lance la copie
            if (args[0] == "hide")
            {
                this.SetVisibleCore(false);
                this.lancerLaCopie();
            }

        }
        /// <summary>
        /// Pour cacher la fenetre si le parametre "hide" est passe en argument
        /// </summary>
        /// <param name="value"> true affcihe la fenetre</param>
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        //public void copyAll()
        //{
        //    //On copy déja toute l'arborescense
        //    foreach (string dirPath in Directory.GetDirectories(co.strSourcePath, "*", SearchOption.AllDirectories))
        //        Directory.CreateDirectory(dirPath.Replace(co.strSourcePath, co.strDestinationPath));

        //    //On copie tout les fichiers
        //    foreach (string newPath in Directory.GetFiles(co.strSourcePath, "*.*",
        //        SearchOption.AllDirectories))
        //        File.Copy(newPath, newPath.Replace(co.strSourcePath, co.strDestinationPath), true);
        //}

        /// <summary>
        /// Pour sérialiser l'objet contenant strSourcePath et strDestinationPath dans le fichier XML config.xml 
        /// </summary>
        private void creatXML()
        {

            if (!verifierLaConfig())
                return;


            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(configObject));
                using (StreamWriter wr = new StreamWriter("config.xml"))
                {
                    xs.Serialize(wr, co);
                }

                //MessageBox.Show("Enregitrement des paramétres bien effectué \n\r" + "Source: " + co.strSourcePath + "\n\r" + "Destination: " + co.strDestinationPath);

            }
            catch (Exception e)
            {

                MessageBox.Show("Erreur lors de la sauvegarde des paramétres: " + e.StackTrace.ToString());
            }

        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                co.strSourcePath = fbd.SelectedPath.ToString();
                txtBoxSourcePath.Text = co.strSourcePath;
                this.creatXML();
            }
        }

        private void buttonExecuter_Click(object sender, EventArgs e)
        {
            lancerLaCopie();

        }

        private void lancerLaCopie()
        {
            if (!verifierLaConfig())
                return;

            try
            {
                labelPathEnCours.Text = "";

                foreach (string dirPath in Directory.GetDirectories(co.strSourcePath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(co.strSourcePath, co.strDestinationPath));

                foreach (string newPath in Directory.GetFiles(co.strSourcePath, "*.*", SearchOption.AllDirectories))
                {
                    labelPathEnCours.Text = newPath.ToString();
                    labelPathEnCours.Refresh();
                    File.Copy(newPath, newPath.Replace(co.strSourcePath, co.strDestinationPath), true);

                }

                labelPathEnCours.Text = "Terminée";
                //MessageBox.Show("la sauvegarde s'est bien terminée");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la copie: " + e.StackTrace.ToString());
            }
        }

        private bool verifierLaConfig()
        {
            if (string.IsNullOrEmpty(co.strDestinationPath))
            {
                MessageBox.Show("Veuillez choisir une destination");
                return false;
            }

            if (string.IsNullOrEmpty(co.strSourcePath))
            {
                MessageBox.Show("Veuillez choisir une source");
                return false;

            }

            return true;
        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                co.strDestinationPath = fbd.SelectedPath.ToString();
                this.txtBoxDestinationPath.Text = co.strDestinationPath;
                this.creatXML();
            }
        }

        private void buttonSauveConfig_Click(object sender, EventArgs e)
        {
            this.creatXML();
        }

        private void txtBoxSourcePath_TextChanged(object sender, EventArgs e)
        {
            this.creatXML();
        }
    }

    public class configObject
    {
        public String strSourcePath { get; set; }
        public String strDestinationPath { get; set; }

    }


}
