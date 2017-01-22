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
using Microsoft.VisualBasic.FileIO;

namespace CopyAllToUSB
{

    public partial class FormMain : Form
    {
        // Les variables globals au formulaire
        configObject co = new configObject();
        string appDataArterris = "";//c'est dans ce repertoire qu'on a les droits et qu'il convient d'écrire
        //string appdata = "";//son ss rep.
        BindingSource bsLSF = new BindingSource();
        BindingSource bsSD = new BindingSource();
        BindingSource bsDD = new BindingSource();

        List<String> ListSourceFile = new List<string>();
        List<String> ListSourceDirectory= new List<string>();
        List<String> ListdestinationDirectory = new List<string>();

        
        

        public FormMain()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();//pour récupérer les arguments de la ligne de commande
            bsLSF.DataSource = ListSourceFile;
            bsSD.DataSource = ListSourceDirectory;
            bsDD.DataSource = ListdestinationDirectory;
            // On peut ecrire dans le repertoire AppDatas pas dans programme
            //appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //appDataArterris = Path.Combine(appdata, "Arterris");
            appDataArterris = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //if (!Directory.Exists(appDataArterris))
            //    Directory.CreateDirectory(appDataArterris);

            //string strFilConfig = specificFolder + "\\config.xml";
            //labelPathEnCours.Text = ""; //init
            XmlSerializer xs = new XmlSerializer(typeof(configObject));//pour serialiser en XML la config (sauvegarde des paths src et dst)
            if (!File.Exists(appDataArterris + "\\config.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {
                co.strSourcePath = "";
                co.strDestinationPath = "";
                co.strFileSourcePath = "";
                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\config.xml"))
                {
                    xs.Serialize(wr, co);
                }

            }

            //init des txtbox avec les params enregistres dans le xml
            using (StreamReader rd = new StreamReader(appDataArterris + "\\config.xml"))
            {
                co = xs.Deserialize(rd) as configObject;
                this.comboBoxSourcePath.Text = co.strSourcePath;
                this.comboBoxDestination.Text = co.strDestinationPath;
                this.comboBoxSourceFile.Text = co.strFileSourcePath;
                //this.comboBoxSourcePath.Text = co.strSourcePath;

            }

            // si l'aplli est ouverte avec param == /hide on cache la fenetre et on lance la copie sans fenetre
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
                    MessageBox.Show(new Form { TopMost = true }, "Sauvegarde terminée");//passage de la fenetre au premier plan.
                    this.Close();
                }
            }

        }

        /// <summary>
        /// Réécriture (sucharge) de setvisible core pour cacher la fenetre si le parametre "/hide" est passé en argument
        /// </summary>
        /// <param name="value"> true affcihe la fenetre</param>
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        /// <summary>
        /// Pour sérialiser (parser) l'objet contenant strSourcePath et strDestinationPath dans le fichier config.xml 
        /// </summary>
        public void creatXML()
        {
            //string repAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string AppdataArterris = Path.Combine(repAppData, "Arterris");

            //if (!verifierSource())
            //    return;

            //if (!verifierDest())
            //    return;

            if (co == null)//un min de verif qd mm
                return;

            try
            {
                co.strSourcePath = this.comboBoxSourcePath.Text;
                co.strDestinationPath = this.comboBoxDestination.Text;
                co.strFileSourcePath = this.comboBoxSourceFile.Text;

                XmlSerializer xs = new XmlSerializer(typeof(configObject));
                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\config.xml"))
                {
                    xs.Serialize(wr, co);
                }

                //MessageBox.Show("Enregitrement des paramétres bien effectué \n\r" + "Source: " + co.strSourcePath + "\n\r" + "Destination: " + co.strDestinationPath);

            }
            catch (Exception e)
            {

                MessageBox.Show("Erreur lors de la sauvegarde des paramètres: " + e.StackTrace.ToString());
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
                comboBoxSourcePath.Text = fbd.SelectedPath.ToString();
                ListSourceDirectory.Add(comboBoxSourcePath.Text); //rajout à la list pour reutilisation
                comboBoxSourcePath.Items.Add(comboBoxSourcePath.Text);
                //this.creatXML();
            }
        }

        private void buttonExecuter_Click(object sender, EventArgs e)
        {
        //    if (!this.verifierSource())
        //    {
        //        return;
        //    }

            if (!this.verifierDest())
            {
                return;
            }

            this.lancerLaCopieAvecDialog();
        }

        /// <summary>
        /// Copie tous les fichiers et dossiers en dessous de src vers dest sans demander confirmation et sans dialogue excepté les erreurs
        /// </summary>
        private void lancerLaCopie()
        {

            try
            {
                //labelPathEnCours.Text = "";//reinit
                String strFichiersNonCopiés = "";
                //pour créer l'arborescense
                foreach (string dirPath in Directory.GetDirectories(comboBoxSourcePath.Text, "*", System.IO.SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(comboBoxSourcePath.Text, comboBoxDestination.Text));
                //pour copier les fichiers
                foreach (string newPath in Directory.GetFiles(comboBoxSourcePath.Text, "*.*", System.IO.SearchOption.AllDirectories))
                {
                    //labelPathEnCours.Text = newPath.ToString();
                    //labelPathEnCours.Refresh();
                    if (this.TryOpen(newPath))
                    {
                        File.Copy(newPath, newPath.Replace(comboBoxSourcePath.Text, comboBoxDestination.Text), true);

                    }
                    else
                    {
                        if (strFichiersNonCopiés.Length < 5000)//reduction volontaire de la fenetre à 5000 car. affichés
                            strFichiersNonCopiés += newPath;
                    }
                }

                //labelPathEnCours.Text = "Terminée";
                if (strFichiersNonCopiés.Length > 1)
                    MessageBox.Show(new Form { TopMost = true }, "Ces fichiers n'ont pas pu être copiés (accès refusé) :\n\r " + strFichiersNonCopiés); //pour avoir la fenetre au premier plans qd option "/hide"
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la copie: " + e.StackTrace.ToString());
            }
        }

        private void lancerLaCopieAvecDialog()// copie en mode avec fenetre
        {
            try
            {
                FileSystem.CopyDirectory(comboBoxSourcePath.Text, comboBoxDestination.Text, UIOption.AllDialogs);
            }

            catch (System.OperationCanceledException oce)
            {
                MessageBox.Show("Opération annulée par l'utilisateur " /*+ oce.StackTrace*/);
            }
            catch (PathTooLongException ptle)
            {
                MessageBox.Show("Le chemin vers le répertoir est trop long " /*+ ptle.StackTrace*/);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Le chemin vers le répertoir n'existe pas " );
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Il manque un chemin ");
            }
            catch (IOException)
            {
                MessageBox.Show("Erreur lecture écriture");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accés fichier refusé par le system");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la copie: " + e.StackTrace.ToString());
            }
           
        }


        //return true si le path source existe false sinon
        private bool verifierSource()
        {

            if (!Directory.Exists(comboBoxSourcePath.Text))
            {
                MessageBox.Show("Le répertoire source n'existe pas.");
                return false;
            }

            return true;
        }

        //return true si le path destination existe false sinon
        private bool verifierDest()
        {

            if (!Directory.Exists(comboBoxDestination.Text))
            {
                MessageBox.Show("Le répertoire destination n'existe pas");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Renvoit true si le fichier passé en param peut etre ouvert 
        /// </summary>
        /// <param name="filePath"> le chemin vers le fichier à tester (source)</param>
        /// <returns> true si on peut ouvrir le fichier</returns>
        private bool TryOpen(string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
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
            fbd.SelectedPath = this.comboBoxDestination.Text;

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                co.strDestinationPath = fbd.SelectedPath.ToString();
                this.comboBoxDestination.Text = co.strDestinationPath;
                this.creatXML();
            }
        }

        //avant de sortir on verifie les params à enregistrer et on laisse l'utilisateur choisir
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult ret = DialogResult.Ignore;

            //if (!this.verifierSource())
            //    ret = MessageBox.Show("Le répertoire source n'existe pas voulez vous quitter et abandonner les modifications  (OK) ou modifier (Annuler). ", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            //if (!this.verifierDest())
            //    ret = MessageBox.Show("Le répertoire destination n'existe pas voulez vous quitter et abandonner les modifications  (OK) ou modifier  (Annuler). ", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);

            //if (ret == DialogResult.Ignore)
            //{

                this.creatXML();
            //}
            //if (ret == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        private void buttonFichierSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {

                if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
                {
                    string file = openFileDialog1.FileName;
                    //co.strSourcePath = fbd.SelectedPath.ToString();
                    //txtBoxSourcePath.Text = co.strSourcePath;
                    comboBoxSourceFile.Text = openFileDialog1.FileName;
                    //this.creatXML();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String destPath = comboBoxDestination.Text + "\\" + Path.GetFileName(comboBoxSourceFile.Text);

            try
            {
                FileSystem.CopyFile(comboBoxSourceFile.Text, destPath, UIOption.AllDialogs);
            }

            catch (System.OperationCanceledException /*oce*/)
            {
                MessageBox.Show("Opération annulée par l'utilisateur " /*+ oce.StackTrace*/);
            }
            catch (PathTooLongException /*ptle*/)
            {
                MessageBox.Show("Le chemin vers le répertoir est trop long " /*+ ptle.StackTrace*/);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Le chemin vers le répertoir n'existe pas ");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Il manque un chemin ");
            }
            catch (IOException)
            {
                MessageBox.Show("Erreur lecture écriture");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accés fichier refusé par le system");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la copie: " + ex.StackTrace.ToString());
            }

            MessageBox.Show("Fichier : " + Path.GetFileName(comboBoxSourceFile.Text) +" copié", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

    /// <summary>
    /// Objet pour conserver les params et serialisable en XML
    /// </summary>
    public class configObject
    {
        public String strFileSourcePath { get; set; }
        public String strSourcePath { get; set; }
        public String strDestinationPath { get; set; }

    }
}
