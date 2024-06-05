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
            Refresh();
            // check for win
            if (game.CheckForWin()) {
                // ADD WINNING CODE HERE
                TransparentPanel blockingPanel = new() {
                    Name = "blockingPanel",
                    Size = new Size(ActiveForm.Width, ActiveForm.Height),
                };
                Controls.Add(blockingPanel);
                blockingPanel.BringToFront();

                TextBox winMessage = new() {
                    Name = "winMessage",
                    Size = new Size(150, 50),
                    Text = "YOU WIN!",
                    Font = new Font("Segoe UI", 20),
                    TextAlign = HorizontalAlignment.Center,
                    Enabled = false
                };
                winMessage.Location = new Point((ActiveForm.Width / 2) - (winMessage.Width / 2), (ActiveForm.Height / 2) - (winMessage.Height / 2));
                Controls.Add(winMessage);
                winMessage.BringToFront();
            }
            // run ResetChecking method
            game.ResetChecking(); // moved here
        }
        private void SolverButton_Click(object sender, EventArgs e) {
            // game.board.
        }
    }
}
