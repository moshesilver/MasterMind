using System.Drawing;

namespace MasterMindLogic {
    internal class Board {
        private const int TURNS = 12;
        internal const int CODE_LENGTH = 4;
        private Color[,] slots = new Color[TURNS, CODE_LENGTH];
        private static Board? board;
        private Board() {
            for (int i = 0; i < slots.GetLength(0); i++) {
                for (int j = 0; j < slots.GetLength(1); j++) {
                    slots[i,j] = Color.Black;
                }
            }
        }
        internal static Board GetBoard() {
            board ??= new Board();
            return board;
        }
        private static void FullReset() {
            board = new Board();
        }
    }
}
