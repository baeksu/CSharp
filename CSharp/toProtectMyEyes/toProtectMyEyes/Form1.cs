using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toProtectMyEyes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1_Init();

        }

        public void dataGridView1_Init()
        {

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Tray ID";

            dataGridView1.KeyDown += dataGridView1_keyDown;
        }

        
        public void dataGridView1_keyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true && e.KeyCode == Keys.V)
            {
                //클립보드에 있는 내용들
                //   \r\n 행바꿈      \t 열바꿈
                string inputData = Clipboard.GetText(System.Windows.Forms.TextDataFormat.UnicodeText);

                for(int i = 0; i< inputData.Length; )
                {
                    string subStr = inputData.Substring(i, 2);

                    if (subStr == "\r\n" || subStr == "\t")
                    {
                        i += 2;
                        continue;
                    }
                    subStr = inputData.Substring(i, 7);
                    i += 7;
                    dataGridView1.Rows.Add(subStr);


                }


            }
        }


    }
}
