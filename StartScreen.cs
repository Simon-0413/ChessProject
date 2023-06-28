using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChessProject
{
    public partial class StartScreen : Form
    {

        public StartScreen()
        {
            InitializeComponent();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            this.FormClosed += (sender, e) => Application.Exit();
        }


        private void btnLocal_Click(object sender, EventArgs e)
        {
            var location = this.Location;
            this.Hide(); // Hide the current form


            ChessBoard chessBoard = new ChessBoard();
            chessBoard.StartPosition = FormStartPosition.Manual;
            chessBoard.Location = location;
            chessBoard.Show();
            chessBoard.FormClosed += (sender, e) => Application.Exit();
        }
    }
}
