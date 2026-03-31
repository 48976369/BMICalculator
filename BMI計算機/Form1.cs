using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(this.txtHeight.Text, out double height) || height <= 0 ||
        !Double.TryParse(this.txtWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("請輸入正確的身高(>0cm)與體重(>0kg)數字！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            height = height / 100.0;
            double bmi = weight / (height * height);
            bmi = Math.Round(bmi, 2); 

            string category = "";
            string suggestion = "";
            Color categoryColor = Color.LightGray; 

            if (bmi < 18.5)
            {
                category = "體重過輕";
                suggestion = "建議均衡攝取營養，增加體重。";
                categoryColor = Color.DodgerBlue; 
            }
            else if (bmi >= 18.5 && bmi < 24)
            {
                category = "健康體位";
                suggestion = "建議維持目前的健康習慣。";
                categoryColor = Color.DarkGreen; 
            }
            else if (bmi >= 24 && bmi < 27)
            {
                category = "體重過重";
                suggestion = "建議規律運動，控制飲食。";
                categoryColor = Color.DarkOrange; 
            }
            else
            {
                category = "肥胖";
                suggestion = "建議諮詢專業醫師或營養師，制定減重計畫。";
                categoryColor = Color.Firebrick; 
            }

            this.lblBmiDisplay.BackColor = categoryColor;
            this.lblBmiDisplay.ForeColor = Color.White;

            this.lblBmiDisplay.Text = $"{bmi} ({category})";

            this.lblSuggestion.Text = $"建議: {suggestion}";
        }
    }
}
