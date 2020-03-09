using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{

    public partial class Image : Form
    {
        // 심심해서 만들어본 폼
        // 메인폼 위에 Internal Securi... 부분을 5~6번 누르면 이 창이 뜬다
        // 아래 트레이 아이콘을 우클릭하여 정보를 눌러도 뜬다

        // Picturebox 사용과 Label의 백그라운드색을 투명으로 변경

        /// <summary>
        /// 생성자
        /// </summary>
        public Image()
        {
            InitializeComponent();

            // Label 배경 투명으로 변경
            this.Controls.Add(this.pictureBox);
            this.pictureBox.Controls.Add(this.label);
        }
    }
}
