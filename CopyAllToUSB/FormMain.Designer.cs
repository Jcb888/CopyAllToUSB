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
            this.txtBoxDestinationPath = new System.Windows.Forms.TextBox();
            this.buttonExecuter = new System.Windows.Forms.Button();
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonDestination = new System.Windows.Forms.Button();
            this.buttonSauveConfig = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCopieEnCours = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxSourcePath
            // 
            this.txtBoxSourcePath.Location = new System.Drawing.Point(12, 21);
            this.txtBoxSourcePath.Name = "txtBoxSourcePath";
            this.txtBoxSourcePath.Size = new System.Drawing.Size(340, 20);
            this.txtBoxSourcePath.TabIndex = 0;
            // 
            // txtBoxDestinationPath
            // 
            this.txtBoxDestinationPath.Location = new System.Drawing.Point(12, 61);
            this.txtBoxDestinationPath.Name = "txtBoxDestinationPath";
            this.txtBoxDestinationPath.Size = new System.Drawing.Size(340, 20);
            this.txtBoxDestinationPath.TabIndex = 1;
            // 
            // buttonExecuter
            // 
            this.buttonExecuter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExecuter.Location = new System.Drawing.Point(12, 105);
            this.buttonExecuter.Name = "buttonExecuter";
            this.buttonExecuter.Size = new System.Drawing.Size(95, 23);
            this.buttonExecuter.TabIndex = 2;
            this.buttonExecuter.Text = "Exécuter";
            this.toolTip2.SetToolTip(this.buttonExecuter, "Exécuter une sauvegarde");
            this.buttonExecuter.UseVisualStyleBackColor = true;
            this.buttonExecuter.Click += new System.EventHandler(this.buttonExecuter_Click);
            // 
            // buttonSource
            // 
            this.buttonSource.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSource.FlatAppearance.BorderSize = 0;
            this.buttonSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSource.Location = new System.Drawing.Point(358, 20);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(40, 20);
            this.buttonSource.TabIndex = 3;
            this.buttonSource.Text = "...";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // buttonDestination
            // 
            this.buttonDestination.Location = new System.Drawing.Point(358, 60);
            this.buttonDestination.Name = "buttonDestination";
            this.buttonDestination.Size = new System.Drawing.Size(40, 20);
            this.buttonDestination.TabIndex = 4;
            this.buttonDestination.Text = "...";
            this.buttonDestination.UseVisualStyleBackColor = true;
            this.buttonDestination.Click += new System.EventHandler(this.buttonDestination_Click);
            // 
            // buttonSauveConfig
            // 
            this.buttonSauveConfig.Location = new System.Drawing.Point(157, 105);
            this.buttonSauveConfig.Name = "buttonSauveConfig";
            this.buttonSauveConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonSauveConfig.TabIndex = 5;
            this.buttonSauveConfig.Text = "Enregistrer";
            this.toolTip1.SetToolTip(this.buttonSauveConfig, "Pour enregistrer les paramétres actuels");
            this.buttonSauveConfig.UseVisualStyleBackColor = true;
            this.buttonSauveConfig.Click += new System.EventHandler(this.buttonSauveConfig_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CopyAllToUSB.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(223, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 29);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelCopieEnCours
            // 
            this.labelCopieEnCours.AutoSize = true;
            this.labelCopieEnCours.Location = new System.Drawing.Point(13, 135);
            this.labelCopieEnCours.Name = "labelCopieEnCours";
            this.labelCopieEnCours.Size = new System.Drawing.Size(0, 13);
            this.labelCopieEnCours.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 197);
            this.Controls.Add(this.labelCopieEnCours);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSauveConfig);
            this.Controls.Add(this.buttonDestination);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.buttonExecuter);
            this.Controls.Add(this.txtBoxDestinationPath);
            this.Controls.Add(this.txtBoxSourcePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Arterris USB Sauve";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxSourcePath;
        private System.Windows.Forms.TextBox txtBoxDestinationPath;
        private System.Windows.Forms.Button buttonExecuter;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonDestination;
        private System.Windows.Forms.Button buttonSauveConfig;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCopieEnCours;
    }
}

