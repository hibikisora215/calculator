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

        public Form1()
        {
            InitializeComponent();
        }

        // 電卓の初期値
        public void initializeAnswer()
        {
            strAnswer = "0";
            textAnswer.Text = strAnswer;
        }

        // フォームロード時に電卓の初期値を入れる
        private void Form1_Load(object sender, EventArgs e)
        {
            initializeAnswer();
        }

        // Clearボタン押下時に電卓の初期値を入れる
        private void btnClear_Click(object sender, EventArgs e)
        {
            initializeAnswer();
        }

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

        // 符号の変更をしたい　btnSign
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
