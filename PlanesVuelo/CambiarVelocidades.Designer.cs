namespace PlanesVuelo
{
    partial class CambiarVelocidades
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
            this.lblId1 = new System.Windows.Forms.Label();
            this.lblId2 = new System.Windows.Forms.Label();
            this.txtVel1 = new System.Windows.Forms.TextBox();
            this.txtVel2 = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId1
            // 
            this.lblId1.AutoSize = true;
            this.lblId1.Location = new System.Drawing.Point(276, 98);
            this.lblId1.Name = "lblId1";
            this.lblId1.Size = new System.Drawing.Size(0, 16);
            this.lblId1.TabIndex = 2;
            this.lblId1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblId2
            // 
            this.lblId2.AutoSize = true;
            this.lblId2.Location = new System.Drawing.Point(413, 98);
            this.lblId2.Name = "lblId2";
            this.lblId2.Size = new System.Drawing.Size(0, 16);
            this.lblId2.TabIndex = 3;
            // 
            // txtVel1
            // 
            this.txtVel1.Location = new System.Drawing.Point(275, 140);
            this.txtVel1.Name = "txtVel1";
            this.txtVel1.Size = new System.Drawing.Size(100, 22);
            this.txtVel1.TabIndex = 7;
            // 
            // txtVel2
            // 
            this.txtVel2.Location = new System.Drawing.Point(412, 140);
            this.txtVel2.Name = "txtVel2";
            this.txtVel2.Size = new System.Drawing.Size(100, 22);
            this.txtVel2.TabIndex = 8;
            this.txtVel2.TextChanged += new System.EventHandler(this.txtVel2_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(352, 236);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // CambiarVelocidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtVel2);
            this.Controls.Add(this.txtVel1);
            this.Controls.Add(this.lblId2);
            this.Controls.Add(this.lblId1);
            this.Name = "CambiarVelocidades";
            this.Text = "CambiarVelocidades";
            this.Load += new System.EventHandler(this.CambiarVelocidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId1;
        private System.Windows.Forms.Label lblId2;
        private System.Windows.Forms.TextBox txtVel1;
        private System.Windows.Forms.TextBox txtVel2;
        private System.Windows.Forms.Button btnAceptar;
    }
}