namespace checkers
{
    partial class BoardScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.Name = "BoardScreen";
            this.Size = new System.Drawing.Size(400, 400);
            this.Load += new System.EventHandler(this.BoardScreen_Load);
            this.Click += new System.EventHandler(this.BoardScreen_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
