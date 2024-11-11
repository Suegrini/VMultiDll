using System;
using System.Collections.Generic;

namespace VMultiDllWrapper
{
    [Flags]
    public enum MouseButton : byte
    {
        LeftButton = 0x01,
        MiddleButton = 0x04,
        RightButton = 0x02,
        X1Button = 0x08,
        X2Button = 0x10,
    }

    public class MouseReport
    {
        private MouseButton buttons;
        public MouseButton Buttons => buttons;
        private HashSet<MouseButton> heldButtons = new HashSet<MouseButton>();
        public HashSet<MouseButton> HeldButtons => heldButtons;

        private ushort mouseX;
        private ushort mouseY;
        public ushort MouseX { get => mouseX; set => mouseX = value; }
        public ushort MouseY { get => mouseY; set => mouseY = value; }

        private byte relativeMouseX;
        private byte relativeMouseY;
        public byte RelativeMouseX { get => relativeMouseX; set => relativeMouseX = value; }
        public byte RelativeMouseY { get => relativeMouseY; set => relativeMouseY = value; }

        private byte wheelPosition;
        public byte WheelPosition
        {
            get => wheelPosition;
            set => wheelPosition = value;
        }

        public void ButtonDown(MouseButton button)
        {
            buttons |= button;
            heldButtons.Add(button);
        }

        public void ButtonUp(MouseButton button)
        {
            buttons &= ~button;
            heldButtons.Remove(button);
        }

        public void SetButtons(MouseButton Buttons)
        {
            buttons = Buttons;
        }

        public void SetPosition(ushort x, ushort y)
        {
            MouseX = x;
            MouseY = y;
        }

        public void MovePosition(byte x, byte y)
        {
            RelativeMouseX = x;
            RelativeMouseY = y;
        }

        public void VerticalScroll(int amount)
        {
            WheelPosition = (byte)(WheelPosition + amount);
        }
    }
}
