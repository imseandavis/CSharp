using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Dotware.Components.PropertySheet
{
	public class Sample : Dotware.Components.PropertySheet.SheetControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components = null;

		public Sample()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Sample));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SheetIcon
			// 
			this.SheetIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SheetIcon.Icon")));
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(104, 56);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Hello World!";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(32, 104);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 240);
			this.button1.Name = "button1";
			this.button1.TabIndex = 6;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(32, 144);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "textBox2";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(32, 192);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 4;
			this.textBox3.Text = "textBox3";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(176, 104);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 1;
			this.textBox4.Text = "textBox4";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(176, 148);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 3;
			this.textBox5.Text = "textBox5";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(176, 192);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 5;
			this.textBox6.Text = "textBox6";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(40, 280);
			this.button2.Name = "button2";
			this.button2.TabIndex = 7;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Sample
			// 
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "Sample";
			this.SheetTitle = "dwHello";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("button1 pressed!");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("button2 pressed!");
		}
	}
}

