namespace PlanesVuelo
{
    partial class Simulacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulacion));
            this.btnMover = new System.Windows.Forms.Button();
            this.avionA = new System.Windows.Forms.PictureBox();
            this.avionB = new System.Windows.Forms.PictureBox();
            this.miPanel = new System.Windows.Forms.Panel();
            this.iniciarSimulacion = new System.Windows.Forms.Button();
            this.detenerSimulacion = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDatos = new System.Windows.Forms.Button();
            this.btnConflicto = new System.Windows.Forms.Button();
            this.lblAlarma = new System.Windows.Forms.Label();
            this.Resetbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).BeginInit();
            this.miPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(55, 77);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Ciclo";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // avionA
            // 
            this.avionA.Image = ((System.Drawing.Image)(resources.GetObject("avionA.Image")));
            this.avionA.Location = new System.Drawing.Point(18, 21);
            this.avionA.Name = "avionA";
            this.avionA.Size = new System.Drawing.Size(30, 30);
            this.avionA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avionA.TabIndex = 2;
            this.avionA.TabStop = false;
            this.avionA.Click += new System.EventHandler(this.avionA_Click);
            // 
            // avionB
            // 
            this.avionB.Image = ((System.Drawing.Image)(resources.GetObject("avionB.Image")));
            this.avionB.Location = new System.Drawing.Point(18, 252);
            this.avionB.Name = "avionB";
            this.avionB.Size = new System.Drawing.Size(30, 30);
            this.avionB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avionB.TabIndex = 3;
            this.avionB.TabStop = false;
            this.avionB.Click += new System.EventHandler(this.avionB_Click);
            // 
            // miPanel
            // 
            this.miPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.miPanel.Controls.Add(this.avionA);
            this.miPanel.Controls.Add(this.avionB);
            this.miPanel.Location = new System.Drawing.Point(311, 12);
            this.miPanel.Name = "miPanel";
            this.miPanel.Size = new System.Drawing.Size(477, 426);
            this.miPanel.TabIndex = 4;
            this.miPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Simulacion_Paint);
            // 
            // iniciarSimulacion
            // 
            this.iniciarSimulacion.Location = new System.Drawing.Point(30, 136);
            this.iniciarSimulacion.Name = "iniciarSimulacion";
            this.iniciarSimulacion.Size = new System.Drawing.Size(133, 23);
            this.iniciarSimulacion.TabIndex = 5;
            this.iniciarSimulacion.Text = "Iniciar simulación";
            this.iniciarSimulacion.UseVisualStyleBackColor = true;
            this.iniciarSimulacion.Click += new System.EventHandler(this.iniciarSimulacion_Click);
            // 
            // detenerSimulacion
            // 
            this.detenerSimulacion.Location = new System.Drawing.Point(33, 192);
            this.detenerSimulacion.Name = "detenerSimulacion";
            this.detenerSimulacion.Size = new System.Drawing.Size(130, 23);
            this.detenerSimulacion.TabIndex = 6;
            this.detenerSimulacion.Text = "Detener simulación";
            this.detenerSimulacion.UseVisualStyleBackColor = true;
            this.detenerSimulacion.Click += new System.EventHandler(this.detenerSimulacion_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDatos
            // 
            this.btnDatos.Location = new System.Drawing.Point(46, 252);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(97, 23);
            this.btnDatos.TabIndex = 7;
            this.btnDatos.Text = "Ver Datos";
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConflicto
            // 
            this.btnConflicto.Location = new System.Drawing.Point(30, 387);
            this.btnConflicto.Name = "btnConflicto";
            this.btnConflicto.Size = new System.Drawing.Size(142, 23);
            this.btnConflicto.TabIndex = 8;
            this.btnConflicto.Text = "Hay Conflicto?";
            this.btnConflicto.UseVisualStyleBackColor = true;
            this.btnConflicto.Click += new System.EventHandler(this.btnConflicto_Click);
            // 
            // lblAlarma
            // 
            this.lblAlarma.AutoSize = true;
            this.lblAlarma.Location = new System.Drawing.Point(72, 335);
            this.lblAlarma.Name = "lblAlarma";
            this.lblAlarma.Size = new System.Drawing.Size(0, 16);
            this.lblAlarma.TabIndex = 9;
            this.lblAlarma.Click += new System.EventHandler(this.lblInformacion_Click);
            // 
            // Resetbtn
            // 
            this.Resetbtn.Location = new System.Drawing.Point(30, 354);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(142, 23);
            this.Resetbtn.TabIndex = 10;
            this.Resetbtn.Text = "Reiniciar";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Resetbtn);
            this.Controls.Add(this.lblAlarma);
            this.Controls.Add(this.btnConflicto);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.detenerSimulacion);
            this.Controls.Add(this.iniciarSimulacion);
            this.Controls.Add(this.miPanel);
            this.Controls.Add(this.btnMover);
            this.Name = "Simulacion";
            this.Text = "Simulacion";
            this.Load += new System.EventHandler(this.Simulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).EndInit();
            this.miPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.PictureBox avionA;
        private System.Windows.Forms.PictureBox avionB;
        private System.Windows.Forms.Panel miPanel;
        private System.Windows.Forms.Button iniciarSimulacion;
        private System.Windows.Forms.Button detenerSimulacion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.Button btnConflicto;
        private System.Windows.Forms.Label lblAlarma;
        private System.Windows.Forms.Button Resetbtn;
    }
}