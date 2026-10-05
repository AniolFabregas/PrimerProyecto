namespace PlanesVuelo
{
    partial class DatosSimulacion
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.distanciaSeguridad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tiempoCiclo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distancia de seguridad:";
            // 
            // distanciaSeguridad
            // 
            this.distanciaSeguridad.Location = new System.Drawing.Point(195, 24);
            this.distanciaSeguridad.Name = "distanciaSeguridad";
            this.distanciaSeguridad.Size = new System.Drawing.Size(100, 22);
            this.distanciaSeguridad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tiempo de ciclo:";
            // 
            // tiempoCiclo
            // 
            this.tiempoCiclo.Location = new System.Drawing.Point(152, 65);
            this.tiempoCiclo.Name = "tiempoCiclo";
            this.tiempoCiclo.Size = new System.Drawing.Size(100, 22);
            this.tiempoCiclo.TabIndex = 4;
            // 
            // DatosSimulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tiempoCiclo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.distanciaSeguridad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "DatosSimulacion";
            this.Text = "DatosSimulacion";
            this.Load += new System.EventHandler(this.DatosSimulacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox distanciaSeguridad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tiempoCiclo;
    }
}