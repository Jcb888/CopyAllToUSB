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
            labelPathEnCours.Text = ""; //init
            XmlSerializer xs = new XmlSerializer(typeof(configObject));//pour serialiser en XML la config (sauvegarde des paths src et dst)
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + "config.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {
                co.strSourcePath = "";
                co.strDestinationPath = "";
                using (StreamWriter wr = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory.ToString() + "config.xml"))
                {
                    xs.Serialize(wr, co);
                }

            }

            //init des txtbox avec les params enregistres dans le xml
            using (StreamReader rd = new StreamReader(AppDomain.CurrentDomain.BaseDirectory.ToString() + "config.xml"))
            {
                co = xs.Deserialize(rd) as configObject;
                this.txtBoxSourcePath.Text = co.strSourcePath;
                this.txtBoxDestinationPath.Text = co.strDestinationPath;

            }

            // si l'aplli est ouverte avec param == /hide on cache la fenetre et on lance la copie
            if (args.Length > 1)
            {
                if (args[1] == "/hide")
                {
                    this.SetVisibleCore(false);
                    if (!this.verifierSource())
                    {
                        this.SetVisibleCore(true);
                        return;
                    }

                    if (!this.verifierDest())
                    {
                        this.SetVisibleCore(true);
                        return;
                    }

                    this.lancerLaCopie();
                    MessageBox.Show(new Form { TopMost = true }, "Sauvegarde terminée");
                    this.Close();
                }
            }

        }

        /// <summary>
        /// Réécriture de setvisible core pour cacher la fenetre si le parametre "/hide" est passé en argument
        /// </summary>
        /// <param name="value"> true affcihe la fenetre</param>
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        /// <summary>
        /// Pour sérialiser l'objet contenant strSourcePath et strDestinationPath dans le fichier config.xml 
        /// </summary>
        private void creatXML()
        {

            if (!verifierSource())
                return;

            if (!verifierDest())
                return;


            try
            {
                co.strSourcePath = this.txtBoxSourcePath.Text;
                co.strDestinationPath = this.txtBoxDestinationPath.Text;

                XmlSerializer xs = new XmlSerializer(typeof(configObject));
                using (StreamWriter wr = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory.ToString() + "config.xml"))
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
                //co.strSourcePath = fbd.SelectedPath.ToString();
                //txtBoxSourcePath.Text = co.strSourcePath;
                txtBoxSourcePath.Text = fbd.SelectedPath.ToString();
                //this.creatXML();
            }
        }

        private void buttonExecuter_Click(object sender, EventArgs e)
        {
            if (!this.verifierSource())
            {
                return;
            }

            if (!this.verifierDest())
            {
                return;
            }

            this.lancerLaCopie();
        }

        /// <summary>
        /// Copie tous les fichiers et dossiers en dessous de src vers dest 
        /// </summary>
        private void lancerLaCopie()
        {

            try
            {
                labelPathEnCours.Text = "";//reinit
                String strFichiersNonCopiés = "";
                FileStream fs = null;
                //pour créer l'arborescense
                foreach (string dirPath in Directory.GetDirectories(txtBoxSourcePath.Text, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(txtBoxSourcePath.Text, txtBoxDestinationPath.Text));
                //pour copier les fichiers
                foreach (string newPath in Directory.GetFiles(txtBoxSourcePath.Text, "*.*", SearchOption.AllDirectories))
                {
                    labelPathEnCours.Text = newPath.ToString();
                    labelPathEnCours.Refresh();
                    if (this.TryOpen(newPath, out fs))//On test d'abord si l'ouverture est possible
                    {
                        //File.Copy(newPath, newPath.Replace(txtBoxSourcePath.Text, txtBoxDestinationPath.Text), true);
                        //fs.CopyTo()
                        progressBar.Maximum = 
                    }
                    else//si l'ouverture n'est pas possible
                    {
                        if (strFichiersNonCopiés.Length < 5000)//reduction volontaire de l'affichage à 5000 car. affichés
                            strFichiersNonCopiés += newPath;
                    }
                }

                labelPathEnCours.Text = "Terminée";
                if(strFichiersNonCopiés.Length > 1)
                MessageBox.Show(new Form { TopMost = true }, "Ces fichiers n'ont pas pu etre copiés (accès refusé) :\n\r " + strFichiersNonCopiés); //pour avoir la fenetre au premier plans qd option "/hide"
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la copie: " + e.StackTrace.ToString());
            }
        }

        //return true si le path source existe false sinon
        private bool verifierSource()
        {

            if (!Directory.Exists(txtBoxSourcePath.Text))
            {
                MessageBox.Show("Le repertoire source n'existe pas");
                return false;
            }

            return true;
        }

        //return true si le path destination existe false sinon
        private bool verifierDest()
        {

            if (!Directory.Exists(txtBoxDestinationPath.Text))
            {
                MessageBox.Show("Le repertoire destination n'existe pas");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Rnvoit true si le fichier passé en param peut etre ouvert 
        /// </summary>
        /// <param name="filePath"> le chemin vers le fichier à tester</param>
        /// <param name="fs">non utilisé pour l'instant</param>
        /// <returns></returns>
        private bool TryOpen(string filePath, out FileStream fs)
        {
            try
            {
                //fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                fs.Close();
                return true;
            }
            catch
            {
                fs = null;
                return false;
            }
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

        //avant de sortir on verifie les params à enregistrer et on laisse l'utilisateur choisir
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = DialogResult.Ignore;

            if (!this.verifierSource())
                ret = MessageBox.Show("Le repertoire source n'existe pas voulez vous quitter et abandonner les modifications (OK) ou modifier(Annuler) ", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (!this.verifierDest())
                ret = MessageBox.Show("Le repertoire destination n'existe pas voulez vous quitter et abandonner les modifications (OK) ou modifier(Annuler) ", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);

            if (ret == DialogResult.Ignore)
            {

                this.creatXML();
            }
            if (ret == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }

    /// <summary>
    /// Objet pour conserver les params et serialisable en XML
    /// </summary>
    public class configObject
    {
        public String strSourcePath { get; set; }
        public String strDestinationPath { get; set; }

    }
}
