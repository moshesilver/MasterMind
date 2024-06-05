using MasterMindLogic;

namespace MasterMindForm {
    internal class MyPanel : Panel {
        internal static List<MyPanel> panels = [];
        internal ColorSlot colorSlot;
        public MyPanel() : base() {
            colorSlot = new ColorSlot(BackColor);
            panels.Add(this);
        }
    }
}
