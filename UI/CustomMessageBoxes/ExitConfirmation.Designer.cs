namespace HFRM_BARCODEGENERATOR.UI.CustomMessageBoxes
{
    partial class ExitConfirmation
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
            this.formEllipse = new HFRM_BARCODEGENERATOR.UI.Components.Ellipse();
            this.SuspendLayout();
            // 
            // formEllipse
            // 
            this.formEllipse.CornerRadius = 30;
            this.formEllipse.TargetControl = this;
            // 
            // ExitConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 230);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExitConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExitConfirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Ellipse formEllipse;
    }
}