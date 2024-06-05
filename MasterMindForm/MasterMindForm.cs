using MasterMindLogic;
using MasterMindSolver;

namespace MasterMindForm {
    public partial class MasterMindForm : Form {
        Game game = Game.GetGame();
        Solver solver = Solver.GetSolver();
        public MasterMindForm() {
            InitializeComponent();
            textBox3.Text = game.GetAnswer();
        }
        private void Button_Click(object sender, EventArgs e) {
            var backColor = ((Button)sender).BackColor;
            int buttonNum = ((Button)sender).TabIndex;
            if (buttonNum < 6) {
                panel1.BackColor = backColor;
            }
            else if (buttonNum < 12) {
                panel2.BackColor = backColor;
            }
            else if (buttonNum < 18) {
                panel3.BackColor = backColor;
            }
            else if (buttonNum < 24) {
                panel4.BackColor = backColor;
            }
        }
        private void Submit_Click(object sender, EventArgs e) {
            List<ColorSlot> tempClrs = [];
            // add colors to board
            foreach (MyPanel panel in MyPanel.panels) {
                MyTextBox tb = new() {
                    Enabled = false,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0),
                    // FIGURE OUT HOW TO SET SIZE
                    BackColor = panel.BackColor
                };
                board.Controls.Add(tb);
                tempClrs.Add(new ColorSlot(panel.BackColor));
            }
            // run CheckCode method
            game.CheckCode(tempClrs);
            // display results
            resultsTable.Controls.Add(
                new Label() {
                    Text = Convert.ToString(game.containsAndPosition)
                }
            );
            resultsTable.Controls.Add(
                new Label() {
                    Text = Convert.ToString(game.containsWithoutPosition)
                }
            );
            // run ResetChecking method
            game.ResetChecking();
            // check for win
            if (game.CheckForWin()) {
                // ADD WINNING CODE HERE
                new Panel() {
                    BackColor = Color.FromArgb(10, 255, 255, 255),
                    BorderStyle = BorderStyle.Fixed3D,
                    //Location = new Point(609, 135),
                    Margin = new Padding(3, 2, 3, 2),
                    Name = "blockingPanel",
                    Size = new Size(ActiveForm.Width, ActiveForm.Height)
                };
            }
        }
        private void solverButton_Click(object sender, EventArgs e) {

        }
    }
}
