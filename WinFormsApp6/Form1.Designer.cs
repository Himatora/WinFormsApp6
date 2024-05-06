namespace WinFormsApp6
{
    partial class Form1
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
            pbMain = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtLog = new RichTextBox();
            label1 = new Label();
            scoreInfo = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.Location = new Point(0, 2);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(581, 448);
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            pbMain.Paint += pbMain_Paint;
            pbMain.MouseClick += pbMain_MouseClick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(584, 2);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(214, 448);
            txtLog.TabIndex = 1;
            txtLog.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(528, 5);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // scoreInfo
            // 
            scoreInfo.AutoSize = true;
            scoreInfo.Location = new Point(453, 9);
            scoreInfo.Name = "scoreInfo";
            scoreInfo.Size = new Size(47, 20);
            scoreInfo.TabIndex = 3;
            scoreInfo.Text = "Счёт: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 9);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(scoreInfo);
            Controls.Add(label1);
            Controls.Add(txtLog);
            Controls.Add(pbMain);
            Name = "Form1";
            Text = "Поймай шарик";
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox txtLog;
        private Label label1;
        private Label scoreInfo;
        private Label label2;
    }
}