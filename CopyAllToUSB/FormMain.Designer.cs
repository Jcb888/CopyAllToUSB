namespace CopyAllToUSB
{
    partial class FormMain
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtBoxSourcePath = new System.Windows.Forms.TextBox();
            this.buttonExecuter = new System.Windows.Forms.Button();
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonDestination = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.txtBoxDestinationPath = new System.Windows.Forms.TextBox();
            this.labelPathEnCours = new System.Windows.Forms.Label();
            this.textBoxFichierSource = new System.Windows.Forms.TextBox();
            this.buttonFichierSource = new System.Windows.Forms.Button();
            this.labelFichierSource = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxSourcePath
            // 
            this.txtBoxSourcePath.Location = new System.Drawing.Point(12, 69);
            this.txtBoxSourcePath.Name = "txtBoxSourcePath";
            this.txtBoxSourcePath.Size = new System.Drawing.Size(340, 20);
            this.txtBoxSourcePath.TabIndex = 0;
            // 
            // buttonExecuter
            // 
            this.buttonExecuter.Location = new System.Drawing.Point(12, 172);
            this.buttonExecuter.Name = "buttonExecuter";
            this.buttonExecuter.Size = new System.Drawing.Size(73, 44);
            this.buttonExecuter.TabIndex = 2;
            this.buttonExecuter.Text = "Copie Rép.";
            this.toolTip2.SetToolTip(this.buttonExecuter, "Executer une sauvegarde");
            this.buttonExecuter.UseVisualStyleBackColor = true;
            this.buttonExecuter.Click += new System.EventHandler(this.buttonExecuter_Click);
            // 
            // buttonSource
            // 
            this.buttonSource.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSource.FlatAppearance.BorderSize = 0;
            this.buttonSource.Location = new System.Drawing.Point(358, 69);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(40, 20);
            this.buttonSource.TabIndex = 3;
            this.buttonSource.Text = "...";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // buttonDestination
            // 
            this.buttonDestination.Location = new System.Drawing.Point(358, 109);
            this.buttonDestination.Name = "buttonDestination";
            this.buttonDestination.Size = new System.Drawing.Size(40, 20);
            this.buttonDestination.TabIndex = 4;
            this.buttonDestination.Text = "...";
            this.buttonDestination.UseVisualStyleBackColor = true;
            this.buttonDestination.Click += new System.EventHandler(this.buttonDestination_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CopyAllToUSB.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(223, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 29);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(10, 50);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(91, 13);
            this.labelSource.TabIndex = 8;
            this.labelSource.Text = "Répertoire source";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(10, 93);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(60, 13);
            this.labelDestination.TabIndex = 9;
            this.labelDestination.Text = "Destination";
            // 
            // txtBoxDestinationPath
            // 
            this.txtBoxDestinationPath.Location = new System.Drawing.Point(12, 109);
            this.txtBoxDestinationPath.Name = "txtBoxDestinationPath";
            this.txtBoxDestinationPath.Size = new System.Drawing.Size(340, 20);
            this.txtBoxDestinationPath.TabIndex = 1;
            // 
            // labelPathEnCours
            // 
            this.labelPathEnCours.AutoSize = true;
            this.labelPathEnCours.Location = new System.Drawing.Point(12, 136);
            this.labelPathEnCours.Name = "labelPathEnCours";
            this.labelPathEnCours.Size = new System.Drawing.Size(35, 13);
            this.labelPathEnCours.TabIndex = 10;
            this.labelPathEnCours.Text = "label1";
            // 
            // textBoxFichierSource
            // 
            this.textBoxFichierSource.Location = new System.Drawing.Point(15, 27);
            this.textBoxFichierSource.Name = "textBoxFichierSource";
            this.textBoxFichierSource.Size = new System.Drawing.Size(340, 20);
            this.textBoxFichierSource.TabIndex = 11;
            // 
            // buttonFichierSource
            // 
            this.buttonFichierSource.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonFichierSource.FlatAppearance.BorderSize = 0;
            this.buttonFichierSource.Location = new System.Drawing.Point(358, 27);
            this.buttonFichierSource.Name = "buttonFichierSource";
            this.buttonFichierSource.Size = new System.Drawing.Size(40, 20);
            this.buttonFichierSource.TabIndex = 12;
            this.buttonFichierSource.Text = "...";
            this.buttonFichierSource.UseVisualStyleBackColor = true;
            this.buttonFichierSource.Click += new System.EventHandler(this.buttonFichierSource_Click);
            // 
            // labelFichierSource
            // 
            this.labelFichierSource.AutoSize = true;
            this.labelFichierSource.Location = new System.Drawing.Point(12, 11);
            this.labelFichierSource.Name = "labelFichierSource";
            this.labelFichierSource.Size = new System.Drawing.Size(73, 13);
            this.labelFichierSource.TabIndex = 13;
            this.labelFichierSource.Text = "Fichier source";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Copie File";
            this.toolTip2.SetToolTip(this.button1, "Executer une sauvegarde");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 228);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelFichierSource);
            this.Controls.Add(this.buttonFichierSource);
            this.Controls.Add(this.textBoxFichierSource);
            this.Controls.Add(this.labelPathEnCours);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonDestination);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.buttonExecuter);
            this.Controls.Add(this.txtBoxDestinationPath);
            this.Controls.Add(this.txtBoxSourcePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Arterris USB Sauve";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxSourcePath;
        private System.Windows.Forms.Button buttonExecuter;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonDestination;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox txtBoxDestinationPath;
        private System.Windows.Forms.Label labelPathEnCours;
        private System.Windows.Forms.TextBox textBoxFichierSource;
        private System.Windows.Forms.Button buttonFichierSource;
        private System.Windows.Forms.Label labelFichierSource;
        private System.Windows.Forms.Button button1;
    }
}

