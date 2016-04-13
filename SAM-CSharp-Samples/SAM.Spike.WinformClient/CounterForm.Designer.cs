namespace SAM.Spike.WinformClient
{
	partial class CounterForm
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
			this.buttonSubmitAction = new System.Windows.Forms.Button();
			this.labelCounter = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonSubmitAction
			// 
			this.buttonSubmitAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSubmitAction.Location = new System.Drawing.Point(12, 102);
			this.buttonSubmitAction.Name = "buttonSubmitAction";
			this.buttonSubmitAction.Size = new System.Drawing.Size(196, 44);
			this.buttonSubmitAction.TabIndex = 0;
			this.buttonSubmitAction.Text = "Submit Action";
			this.buttonSubmitAction.UseVisualStyleBackColor = true;
			this.buttonSubmitAction.Click += new System.EventHandler(this.buttonSubmitAction_Click);
			// 
			// labelCounter
			// 
			this.labelCounter.AutoSize = true;
			this.labelCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCounter.Location = new System.Drawing.Point(13, 13);
			this.labelCounter.Name = "labelCounter";
			this.labelCounter.Size = new System.Drawing.Size(104, 29);
			this.labelCounter.TabIndex = 1;
			this.labelCounter.Text = "Counter:";
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.Location = new System.Drawing.Point(13, 55);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(85, 29);
			this.labelStatus.TabIndex = 2;
			this.labelStatus.Text = "Status:";
			// 
			// CounterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 167);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.labelCounter);
			this.Controls.Add(this.buttonSubmitAction);
			this.Name = "CounterForm";
			this.Text = "Counter Form";
			this.Load += new System.EventHandler(this.CounterForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSubmitAction;
		private System.Windows.Forms.Label labelCounter;
		private System.Windows.Forms.Label labelStatus;
	}
}