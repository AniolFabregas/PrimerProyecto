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
            this.miPanel = new System.Windows.Forms.Panel();
            this.avionB = new System.Windows.Forms.PictureBox();
            this.avionA = new System.Windows.Forms.PictureBox();
            this.btnMover = new System.Windows.Forms.Button();
            this.miPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).BeginInit();
            this.SuspendLayout();
            
            // miPanel
            
            this.miPanel.BackColor = System.Drawing.Color.White;
            this.miPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miPanel.Controls.Add(this.avionB);
            this.miPanel.Controls.Add(this.avionA);
            this.miPanel.Location = new System.Drawing.Point(238, 30);
            this.miPanel.Name = "miPanel";
            this.miPanel.Size = new System.Drawing.Size(550, 408);
            this.miPanel.TabIndex = 0;
            
            // avionB
            
            this.avionB.BackColor = System.Drawing.Color.Blue;
            this.avionB.Location = new System.Drawing.Point(20, 260);
            this.avionB.Name = "avionB";
            this.avionB.Size = new System.Drawing.Size(20, 20);
            this.avionB.TabIndex = 3;
            this.avionB.TabStop = false;
            
            // avionA
            
            this.avionA.BackColor = System.Drawing.Color.Red;
            this.avionA.Location = new System.Drawing.Point(20, 20);
            this.avionA.Name = "avionA";
            this.avionA.Size = new System.Drawing.Size(20, 20);
            this.avionA.TabIndex = 2;
            this.avionA.TabStop = false;
            
            // btnMover
            
            this.btnMover.Location = new System.Drawing.Point(40, 77);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(150, 35);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Mover un ciclo";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            
            // Simulacion
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.miPanel);
            this.Name = "Simulacion";
            this.Text = "Simulacion";
            this.Load += new System.EventHandler(this.Simulacion_Load);
            this.miPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel miPanel;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.PictureBox avionA;
        private System.Windows.Forms.PictureBox avionB;
    }
}