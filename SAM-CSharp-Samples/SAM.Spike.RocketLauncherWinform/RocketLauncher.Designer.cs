namespace SAM.Spike.RocketLauncherWinform
{
	partial class RocketLauncher
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
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonDecrement = new System.Windows.Forms.Button();
			this.buttonLaunch = new System.Windows.Forms.Button();
			this.buttonAbort = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(12, 12);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(88, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonDecrement
			// 
			this.buttonDecrement.Location = new System.Drawing.Point(12, 52);
			this.buttonDecrement.Name = "buttonDecrement";
			this.buttonDecrement.Size = new System.Drawing.Size(88, 23);
			this.buttonDecrement.TabIndex = 1;
			this.buttonDecrement.Text = "Decrement";
			this.buttonDecrement.UseVisualStyleBackColor = true;
			this.buttonDecrement.Click += new System.EventHandler(this.buttonDecrement_Click);
			// 
			// buttonLaunch
			// 
			this.buttonLaunch.Location = new System.Drawing.Point(12, 90);
			this.buttonLaunch.Name = "buttonLaunch";
			this.buttonLaunch.Size = new System.Drawing.Size(88, 23);
			this.buttonLaunch.TabIndex = 2;
			this.buttonLaunch.Text = "Launch";
			this.buttonLaunch.UseVisualStyleBackColor = true;
			this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
			// 
			// buttonAbort
			// 
			this.buttonAbort.Location = new System.Drawing.Point(12, 128);
			this.buttonAbort.Name = "buttonAbort";
			this.buttonAbort.Size = new System.Drawing.Size(88, 23);
			this.buttonAbort.TabIndex = 3;
			this.buttonAbort.Text = "Abort";
			this.buttonAbort.UseVisualStyleBackColor = true;
			this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
			// 
			// RocketLauncher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 170);
			this.Controls.Add(this.buttonAbort);
			this.Controls.Add(this.buttonLaunch);
			this.Controls.Add(this.buttonDecrement);
			this.Controls.Add(this.buttonStart);
			this.Name = "RocketLauncher";
			this.Text = "Rocket Launcher";
			this.Load += new System.EventHandler(this.RocketLauncher_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonDecrement;
		private System.Windows.Forms.Button buttonLaunch;
		private System.Windows.Forms.Button buttonAbort;
	}
}