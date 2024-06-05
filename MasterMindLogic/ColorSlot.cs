using System.Drawing;

namespace MasterMindLogic {
    public class ColorSlot {
        internal Color color;
        internal bool found;
        public ColorSlot(Color color) {
            this.color = color;
            found = false;
        }
        public override bool Equals(object? obj) {
            return color == ((ColorSlot)obj).color;
        }
    }
}
