namespace Room
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxExits = new System.Windows.Forms.ComboBox();
            this.buttonGoHere = new System.Windows.Forms.Button();
            this.buttonGoThoughTheDoor = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 184);
            this.textBox1.TabIndex = 0;
            // 
            // comboBoxExits
            // 
            this.comboBoxExits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExits.FormattingEnabled = true;
            this.comboBoxExits.Location = new System.Drawing.Point(176, 214);
            this.comboBoxExits.Name = "comboBoxExits";
            this.comboBoxExits.Size = new System.Drawing.Size(278, 20);
            this.comboBoxExits.TabIndex = 1;
            // 
            // buttonGoHere
            // 
            this.buttonGoHere.Location = new System.Drawing.Point(13, 214);
            this.buttonGoHere.Name = "buttonGoHere";
            this.buttonGoHere.Size = new System.Drawing.Size(157, 23);
            this.buttonGoHere.TabIndex = 2;
            this.buttonGoHere.Text = "Go Here:";
            this.buttonGoHere.UseVisualStyleBackColor = true;
            this.buttonGoHere.Click += new System.EventHandler(this.buttonGoHere_Click);
            // 
            // buttonGoThoughTheDoor
            // 
            this.buttonGoThoughTheDoor.Location = new System.Drawing.Point(13, 241);
            this.buttonGoThoughTheDoor.Name = "buttonGoThoughTheDoor";
            this.buttonGoThoughTheDoor.Size = new System.Drawing.Size(441, 23);
            this.buttonGoThoughTheDoor.TabIndex = 3;
            this.buttonGoThoughTheDoor.Text = "Go Though The Door";
            this.buttonGoThoughTheDoor.UseVisualStyleBackColor = true;
            this.buttonGoThoughTheDoor.Click += new System.EventHandler(this.buttonGoThoughTheDoor_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(13, 271);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(441, 23);
            this.buttonCheck.TabIndex = 4;
            this.buttonCheck.Text = "check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(13, 301);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(441, 23);
            this.buttonHide.TabIndex = 5;
            this.buttonHide.Text = "Hide!";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 337);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonGoThoughTheDoor);
            this.Controls.Add(this.buttonGoHere);
            this.Controls.Add(this.comboBoxExits);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxExits;
        private System.Windows.Forms.Button buttonGoHere;
        private System.Windows.Forms.Button buttonGoThoughTheDoor;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonHide;
    }
}

