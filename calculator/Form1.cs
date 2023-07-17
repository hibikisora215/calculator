using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        String strAnswer = "";
        Decimal num1 = 0; //計算用数値1
        Decimal num2 = 0; //計算用数値2
        int operators = 0; //四則演算子

        public Form1()
        {
            InitializeComponent();
        }

        // 電卓の初期値
        public void initializeAnswer()
        {
            strAnswer = "0";
            textAnswer.Text = strAnswer;
            textEquation.Text = "";
        }

        // フォームロード時に電卓の初期値を入れる
        private void Form1_Load(object sender, EventArgs e)
        {
            initializeAnswer();
        }

        // 計算の実施
        private Decimal Calc(Decimal num1, Decimal num2, int operators)
        {
            switch (operators)
            {
                case 1: // +
                    return Decimal.Add(num1, num2);
                case 2: // -
                    return Decimal.Subtract(num1, num2);
                case 3:
                    return Decimal.Multiply(num1, num2);
                case 4:
                    return Decimal.Divide(num1, num2);
                default:
                    return Decimal.Zero;
            }
        }

        // Clearボタン押下時に電卓の初期値を入れる
        private void btnClear_Click(object sender, EventArgs e)
        {
            initializeAnswer();
        }

        // CEボタン押下時にstrAnswerの中身のみ0にする
        private void btnCE_Click(object sender, EventArgs e)
        {
            strAnswer = "0";
            textAnswer.Text = strAnswer;
        }

        // 数字ボタン押下時の共通処理。ボタン上の数字を追記する。
        private void numBtnClick(object sender, EventArgs e)
        {
            if (strAnswer != "0")
            {
                strAnswer += ((Button)sender).Text;
                textAnswer.Text = strAnswer;
            }
            else
            {
                strAnswer = ((Button)sender).Text;
                textAnswer.Text = strAnswer;
            }
        }

        // ドットボタン押下時に既にドットがなければ追記
        private void dotButton_Click(object sender, EventArgs e)
        {
            if (strAnswer.Contains("."))
            {
                ;
            }
            else
            {
                strAnswer += ".";
                textAnswer.Text = strAnswer;
            }
        }

        // 符号の変更をしたい　btnSign
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Operators_Click(object sender, EventArgs e)
        {
            Decimal.TryParse(strAnswer, out decimal d);

            if ( operators == 0 )
            {
                num1 = d;
            }
            else
            {
                num2 = d;
                num1 = Calc(num1, num2, operators);
            }

            switch (((Button)sender).Text)
            {
                case "+":
                    operators = 1;
                    break;
                case "-":
                    operators = 2;
                    break;
                case "×":
                    operators = 3;
                    break;
                case "/":
                    operators = 4;
                    break;
            }

            textEquation.Text = num1.ToString();
            strAnswer = "0";
            textAnswer.Text = strAnswer;
        }

    }
}
