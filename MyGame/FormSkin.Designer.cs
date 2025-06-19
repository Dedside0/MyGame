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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(84, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "зелень";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(508, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "желтень";
            // 
            // FormSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxSkin2);
            this.Controls.Add(this.pictureBoxSkin1);
            this.Name = "FormSkin";
            this.Text = "Выбор скина";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSkin1;
        private System.Windows.Forms.PictureBox pictureBoxSkin2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}