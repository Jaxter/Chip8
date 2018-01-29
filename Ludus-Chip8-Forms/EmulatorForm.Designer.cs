namespace Ludus_Chip8_Forms
{
    partial class EmulatorForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadRom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadRom
            // 
            this.btnLoadRom.Location = new System.Drawing.Point(253, 269);
            this.btnLoadRom.Name = "btnLoadRom";
            this.btnLoadRom.Size = new System.Drawing.Size(75, 23);
            this.btnLoadRom.TabIndex = 0;
            this.btnLoadRom.Text = "Load Rom";
            this.btnLoadRom.UseVisualStyleBackColor = true;
            this.btnLoadRom.Click += new System.EventHandler(this.btnLoadRom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 304);
            this.Controls.Add(this.btnLoadRom);
            this.Name = "Form1";
            this.Text = "Ludus - CHIP-8 Emulator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadRom;
    }
}

