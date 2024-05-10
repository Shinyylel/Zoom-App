namespace ZoomApp
{
    partial class MagnifierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagnifierForm));
            this.cbmZoom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbmZoom
            // 
            this.cbmZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbmZoom.FormattingEnabled = true;
            this.cbmZoom.Location = new System.Drawing.Point(366, 184);
            this.cbmZoom.Name = "cbmZoom";
            this.cbmZoom.Size = new System.Drawing.Size(60, 21);
            this.cbmZoom.TabIndex = 0;
            this.cbmZoom.SelectedIndexChanged += new System.EventHandler(this.cbmZoom_SelectedIndexChanged);
            // 
            // MagnifierForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(426, 206);
            this.Controls.Add(this.cbmZoom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MagnifierForm";
            this.Text = "Magnifier";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MagnifierForm_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MagnifierForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MagnifierForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MagnifierForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MagnifierForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MagnifierForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbmZoom;
    }
}