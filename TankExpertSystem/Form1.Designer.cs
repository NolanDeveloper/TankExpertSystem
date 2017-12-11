namespace TankExpertSystem
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameField1 = new TankExpertSystem.Field();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButtonObstacle = new System.Windows.Forms.RadioButton();
            this.radioButtonTarget = new System.Windows.Forms.RadioButton();
            this.radioButtonTank = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.gameField1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(896, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gameField1
            // 
            this.gameField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameField1.Location = new System.Drawing.Point(3, 3);
            this.gameField1.Moveable = TankExpertSystem.Field.ActiveObject.TANK;
            this.gameField1.Name = "gameField1";
            this.gameField1.Size = new System.Drawing.Size(690, 598);
            this.gameField1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.radioButtonObstacle);
            this.groupBox1.Controls.Add(this.radioButtonTarget);
            this.groupBox1.Controls.Add(this.radioButtonTank);
            this.groupBox1.Location = new System.Drawing.Point(699, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Пуск";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButtonObstacle
            // 
            this.radioButtonObstacle.AutoSize = true;
            this.radioButtonObstacle.Location = new System.Drawing.Point(6, 72);
            this.radioButtonObstacle.Name = "radioButtonObstacle";
            this.radioButtonObstacle.Size = new System.Drawing.Size(128, 17);
            this.radioButtonObstacle.TabIndex = 2;
            this.radioButtonObstacle.Text = "Изменять преграды";
            this.radioButtonObstacle.UseVisualStyleBackColor = true;
            this.radioButtonObstacle.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTarget
            // 
            this.radioButtonTarget.AutoSize = true;
            this.radioButtonTarget.Location = new System.Drawing.Point(6, 48);
            this.radioButtonTarget.Name = "radioButtonTarget";
            this.radioButtonTarget.Size = new System.Drawing.Size(118, 17);
            this.radioButtonTarget.TabIndex = 1;
            this.radioButtonTarget.Text = "Перемещать цель";
            this.radioButtonTarget.UseVisualStyleBackColor = true;
            this.radioButtonTarget.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTank
            // 
            this.radioButtonTank.AutoSize = true;
            this.radioButtonTank.Checked = true;
            this.radioButtonTank.Location = new System.Drawing.Point(6, 24);
            this.radioButtonTank.Name = "radioButtonTank";
            this.radioButtonTank.Size = new System.Drawing.Size(117, 17);
            this.radioButtonTank.TabIndex = 0;
            this.radioButtonTank.TabStop = true;
            this.radioButtonTank.Text = "Перемещать танк";
            this.radioButtonTank.UseVisualStyleBackColor = true;
            this.radioButtonTank.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Моделирование системы управления танком";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Field gameField1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButtonObstacle;
        private System.Windows.Forms.RadioButton radioButtonTarget;
        private System.Windows.Forms.RadioButton radioButtonTank;
    }
}

