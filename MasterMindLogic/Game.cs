using System.Drawing;

namespace MasterMindLogic {
    public class Game {
        private static readonly Dictionary<Color, string> ColorNames = new() {
            { Color.FromArgb(255, 128, 0), "orange"},
            { Color.Yellow, "yellow" },
            { Color.Lime, "green" },
            { Color.FromArgb(255, 128, 255), "pink" },
            { Color.DarkViolet, "purple" },
            { Color.White, "white" }
        };
        public static readonly Dictionary<int, Color> GameColors = new() {
            { 0, Color.FromArgb(255, 128, 0) },
            { 1, Color.Yellow },
            { 2, Color.Lime },
            { 3, Color.FromArgb(255, 128, 255) },
            { 4, Color.DarkViolet },
            { 5, Color.White }
        };
        public int containsAndPosition = 0;
        public int containsWithoutPosition = 0;
        public Board board = Board.GetBoard();
        private ColorSlot[] code = new ColorSlot[Board.CODE_LENGTH];
        private static Game? game;
        private Game() {
            GenerateCode();
        }
        public static Game GetGame() {
            game ??= new Game();
            return game;
        }
        public string GetAnswer() {
            return string.Join(", ", code.Select(x => ColorNames[x.color]));
        }
        private static Random rand = new();
        private void GenerateCode() {
            for (int i = 0; i < code.Length; i++) {
                code[i] = new(GameColors[rand.Next(GameColors.Count)]);
            }
        }
        public void CheckCode(List<ColorSlot> guess) {
            for (int i = 0; i < code.Length; i++) {
                if (code[i].Equals(guess[i]) && !guess[i].found) {
                    code[i].found = true;
                    guess[i].found = true;
                    containsAndPosition++;
                }
                else {
                    foreach (var color in guess.Where(x => !x.found)) {
                        if (code[i].Equals(color)) {
                            code[i].found = true;
                            color.found = true;
                            containsWithoutPosition++;
                            break;
                        }
                    }
                }
            }
        }
        public void ResetChecking() {
            foreach (var s in code) {
                s.found = false;
            }
            containsAndPosition = 0;
            containsWithoutPosition = 0;
        }
        public bool CheckForWin() {
            if (containsAndPosition == 4) {
                return true;
            }
            return false;
        }
    }
}
