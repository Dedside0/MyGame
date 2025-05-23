namespace MyGame
{
    partial class FormSkin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSkin));
            this.pictureBoxSkin1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSkin2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSkin1
            // 
            this.pictureBoxSkin1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSkin1.Image")));
            this.pictureBoxSkin1.Location = new System.Drawing.Point(75, 103);
            this.pictureBoxSkin1.Name = "pictureBoxSkin1";
            this.pictureBoxSkin1.Size = new System.Drawing.Size(154, 166);
            this.pictureBoxSkin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSkin1.TabIndex = 0;
            this.pictureBoxSkin1.TabStop = false;
            this.pictureBoxSkin1.Click += new System.EventHandler(this.pictureBoxSkin1_Click);
            // 
            // pictureBoxSkin2
            // 
            this.pictureBoxSkin2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSkin2.Image")));
            this.pictureBoxSkin2.Location = new System.Drawing.Point(507, 103);
            this.pictureBoxSkin2.Name = "pictureBoxSkin2";
            this.pictureBoxSkin2.Size = new System.Drawing.Size(154, 166);
            this.pictureBoxSkin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSkin2.TabIndex = 1;
            this.pictureBoxSkin2.TabStop = false;
            this.pictureBoxSkin2.Click += new System.EventHandler(this.pictureBoxSkin2_Click);
            // 
            // FormSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxSkin2);
            this.Controls.Add(this.pictureBoxSkin1);
            this.Name = "FormSkin";
            this.Text = "FormSkin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSkin1;
        private System.Windows.Forms.PictureBox pictureBoxSkin2;
    }
}