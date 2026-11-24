namespace AppWinForms
{
    partial class MAinForms
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AnimationTimer = new System.Windows.Forms.Timer(components);
            AnimationPanel = new Panel();
            SuspendLayout();
            // 
            // AnimationTimer
            // 
            AnimationTimer.Tick += this.timer1_Tick;
            // 
            // AnimationPanel
            // 
            AnimationPanel.BackColor = SystemColors.MenuHighlight;
            AnimationPanel.Location = new Point(40, 180);
            AnimationPanel.Name = "AnimationPanel";
            AnimationPanel.Size = new Size(118, 100);
            AnimationPanel.TabIndex = 0;
            AnimationPanel.Paint += this.panel1_Paint;
            // 
            // MAinForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AnimationPanel);
            Name = "MAinForms";
            Text = "Анимация";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer AnimationTimer;
        private Panel AnimationPanel;
    }
}
