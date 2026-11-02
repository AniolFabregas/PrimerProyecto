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
            this.txtVel1 = new System.Windows.Forms.TextBox();
            this.txtVel2 = new System.Windows.Forms.TextBox();
            this.lblId1 = new System.Windows.Forms.Label();
            this.lblId2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVel1
            // 
            this.txtVel1.Location = new System.Drawing.Point(208, 119);
            this.txtVel1.Name = "txtVel1";
            this.txtVel1.Size = new System.Drawing.Size(100, 22);
            this.txtVel1.TabIndex = 3;
            // 
            // txtVel2
            // 
            this.txtVel2.Location = new System.Drawing.Point(376, 119);
            this.txtVel2.Name = "txtVel2";
            this.txtVel2.Size = new System.Drawing.Size(100, 22);
            this.txtVel2.TabIndex = 4;
            // 
            // lblId1
            // 
            this.lblId1.AutoSize = true;
            this.lblId1.Location = new System.Drawing.Point(205, 84);
            this.lblId1.Name = "lblId1";
            this.lblId1.Size = new System.Drawing.Size(0, 16);
            this.lblId1.TabIndex = 5;
            // 
            // lblId2
            // 
            this.lblId2.AutoSize = true;
            this.lblId2.Location = new System.Drawing.Point(384, 84);
            this.lblId2.Name = "lblId2";
            this.lblId2.Size = new System.Drawing.Size(0, 16);
            this.lblId2.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(309, 172);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // CambiarVelocidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblId2);
            this.Controls.Add(this.lblId1);
            this.Controls.Add(this.txtVel2);
            this.Controls.Add(this.txtVel1);
            this.Name = "CambiarVelocidades";
            this.Text = "CambiarVelocidades";
            this.Load += new System.EventHandler(this.CambiarVelocidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVel1;
        private System.Windows.Forms.TextBox txtVel2;
        private System.Windows.Forms.Label lblId1;
        private System.Windows.Forms.Label lblId2;
        private System.Windows.Forms.Button btnAceptar;
    }
}