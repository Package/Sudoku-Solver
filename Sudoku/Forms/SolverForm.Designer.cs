namespace Sudoku.Forms
{
    partial class SolverForm
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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.speedTrack = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lblDefault = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.comboDefault = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.label2);
            this.groupOptions.Controls.Add(this.label1);
            this.groupOptions.Controls.Add(this.lblDelay);
            this.groupOptions.Controls.Add(this.speedTrack);
            this.groupOptions.Controls.Add(this.btnReset);
            this.groupOptions.Controls.Add(this.btnSolve);
            this.groupOptions.Controls.Add(this.lblDefault);
            this.groupOptions.Controls.Add(this.btnLoad);
            this.groupOptions.Controls.Add(this.comboDefault);
            this.groupOptions.Location = new System.Drawing.Point(477, 12);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(311, 418);
            this.groupOptions.TabIndex = 2;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(12, 285);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(144, 15);
            this.lblDelay.TabIndex = 6;
            this.lblDelay.Text = "Solve Delay (milliseconds)";
            // 
            // speedTrack
            // 
            this.speedTrack.Location = new System.Drawing.Point(13, 303);
            this.speedTrack.Maximum = 1000;
            this.speedTrack.Name = "speedTrack";
            this.speedTrack.Size = new System.Drawing.Size(266, 45);
            this.speedTrack.TabIndex = 5;
            this.speedTrack.TickFrequency = 100;
            this.speedTrack.Value = 200;
            this.speedTrack.Scroll += new System.EventHandler(this.speedTrack_Scroll);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(169, 368);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 35);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Puzzle";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(6, 368);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(136, 35);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Solve Puzzle";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Location = new System.Drawing.Point(6, 23);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(81, 15);
            this.lblDefault.TabIndex = 2;
            this.lblDefault.Text = "Default Puzzle";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(230, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // comboDefault
            // 
            this.comboDefault.FormattingEnabled = true;
            this.comboDefault.Items.AddRange(new object[] {
            "Sample_EviI_Input",
            "Sample_Hard_Input",
            "Sample_Easy_Input"});
            this.comboDefault.Location = new System.Drawing.Point(93, 20);
            this.comboDefault.Name = "comboDefault";
            this.comboDefault.Size = new System.Drawing.Size(121, 23);
            this.comboDefault.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "1,000";
            // 
            // SolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupOptions);
            this.Name = "SolverForm";
            this.Text = "Sudoku Solver";
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox comboDefault;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblDelay;
        public System.Windows.Forms.TrackBar speedTrack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}