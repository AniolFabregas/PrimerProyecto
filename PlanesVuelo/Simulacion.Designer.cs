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
            this.miPanel = new System.Windows.Forms.DataGridView();
            this.btnMover = new System.Windows.Forms.Button();
            this.avionA = new System.Windows.Forms.PictureBox();
            this.avionB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.miPanel)).BeginInit();
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
            // 
            this.btnMover.Location = new System.Drawing.Point(55, 77);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Ciclo";
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
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.avionB);
            this.Controls.Add(this.avionA);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.miPanel);
            this.Name = "Simulacion";
            this.Text = "Simulacion";
            this.Load += new System.EventHandler(this.Simulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.miPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avionB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView miPanel;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.PictureBox avionA;
        private System.Windows.Forms.PictureBox avionB;
    }
}