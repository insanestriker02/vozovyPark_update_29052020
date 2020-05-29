namespace vozovyParkV2
{
    partial class VynuceniZmenyHesla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listUzivatelu = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.potvrdPassResetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listUzivatelu
            // 
            this.listUzivatelu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listUzivatelu.FormattingEnabled = true;
            this.listUzivatelu.ItemHeight = 16;
            this.listUzivatelu.Location = new System.Drawing.Point(12, 45);
            this.listUzivatelu.Margin = new System.Windows.Forms.Padding(5);
            this.listUzivatelu.Name = "listUzivatelu";
            this.listUzivatelu.Size = new System.Drawing.Size(256, 292);
            this.listUzivatelu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vyberte uživatele:";
            // 
            // potvrdPassResetBtn
            // 
            this.potvrdPassResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.potvrdPassResetBtn.Location = new System.Drawing.Point(12, 344);
            this.potvrdPassResetBtn.Name = "potvrdPassResetBtn";
            this.potvrdPassResetBtn.Size = new System.Drawing.Size(256, 40);
            this.potvrdPassResetBtn.TabIndex = 3;
            this.potvrdPassResetBtn.Text = "Potvrdit restet hesla";
            this.potvrdPassResetBtn.UseVisualStyleBackColor = true;
            this.potvrdPassResetBtn.Click += new System.EventHandler(this.potvrdPassResetBtn_Click);
            // 
            // VynuceniZmenyHesla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 396);
            this.Controls.Add(this.potvrdPassResetBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listUzivatelu);
            this.Name = "VynuceniZmenyHesla";
            this.Text = "VynuceniZmenyHesla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listUzivatelu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button potvrdPassResetBtn;
    }
}