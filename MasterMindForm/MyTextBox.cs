using MasterMindLogic;

namespace MasterMindForm {
    internal class MyTextBox : TextBox {
        internal ColorSlot colorSlot;
        public MyTextBox() : base() {
            colorSlot = new ColorSlot(BackColor);
        }
    }
}
