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
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).BeginInit();
            this.SuspendLayout();
            // 
            // miPanel
            // 
            this.miPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.miPanel.Location = new System.Drawing.Point(238, 30);
            this.miPanel.Name = "miPanel";
            this.miPanel.RowHeadersWidth = 51;
            this.miPanel.RowTemplate.Height = 24;
            this.miPanel.Size = new System.Drawing.Size(550, 408);
            this.miPanel.TabIndex = 0;
            // 
            // btnMover
            
            this.btnMover.Location = new System.Drawing.Point(40, 77);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(150, 35);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Mover un ciclo";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.button1_Click);
            // 
            // avionA
            // 
            this.avionA.Location = new System.Drawing.Point(280, 63);
            this.avionA.Name = "avionA";
            this.avionA.Size = new System.Drawing.Size(100, 50);
            this.avionA.TabIndex = 2;
            this.avionA.TabStop = false;
            // 
            // avionB
            // 
            this.avionB.Location = new System.Drawing.Point(280, 172);
            this.avionB.Name = "avionB";
            this.avionB.Size = new System.Drawing.Size(100, 50);
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
            // Simulacion
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.miPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView miPanel;
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
    }
}