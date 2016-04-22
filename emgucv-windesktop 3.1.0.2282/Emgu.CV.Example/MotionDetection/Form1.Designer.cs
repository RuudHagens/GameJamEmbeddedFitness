namespace MotionDetection
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.capturedImage = new Emgu.CV.UI.ImageBox();
            this.afterProcesImage = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterProcesImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Captured Image:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(714, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "People detection";
            // 
            // capturedImage
            // 
            this.capturedImage.Location = new System.Drawing.Point(19, 42);
            this.capturedImage.Name = "capturedImage";
            this.capturedImage.Size = new System.Drawing.Size(688, 512);
            this.capturedImage.TabIndex = 2;
            this.capturedImage.TabStop = false;
            // 
            // afterProcesImage
            // 
            this.afterProcesImage.Location = new System.Drawing.Point(717, 43);
            this.afterProcesImage.Name = "afterProcesImage";
            this.afterProcesImage.Size = new System.Drawing.Size(885, 511);
            this.afterProcesImage.TabIndex = 2;
            this.afterProcesImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 593);
            this.Controls.Add(this.afterProcesImage);
            this.Controls.Add(this.capturedImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.capturedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterProcesImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox capturedImage;
        private Emgu.CV.UI.ImageBox afterProcesImage;
    }
}

