using System;
using System.Windows.Forms;
using static TankExpertSystem.Field;

namespace TankExpertSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameField1.StopEvent += FieldStop;
        }

        private void FieldStop()
        {
            groupBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameField1.Start();
            groupBox1.Enabled = false;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTank.Checked)
            {
                gameField1.Moveable = ActiveObject.TANK;
            }
            else if (radioButtonTarget.Checked)
            {
                gameField1.Moveable = ActiveObject.TARGET;
            }
            else if (radioButtonObstacle.Checked)
            {
                gameField1.Moveable = ActiveObject.OBSTACLE;
            }
        }
    }
}
