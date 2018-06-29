using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace eggKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIdex">The n idex.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIdex);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Keybds the event.
        /// </summary>
        /// <param name="bVK">The b vk.</param>
        /// <param name="bScan">The b scan.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="dwExtraInfo">The dw extra information.</param>
        [DllImport("User32.dll")]
        public static extern void keybd_event(byte bVK, byte bScan, Int32 dwFlags, int dwExtraInfo);
        /// <summary>
        /// The Shift Key flag
        /// </summary>
        bool shiftOn = false;
        /// <summary>
        /// The caps lock flag
        /// </summary>
        bool capsLockOn = false;
        /// <summary>
        /// The control key flag
        /// </summary>
        bool ctrlOn = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            
            InitializeComponent();
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Left;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }
        /// <summary>
        /// Changes the between functions with capslock/shift.
        /// </summary>
        private void changeKeys()
        {
            if (capsLockOn || shiftOn)
            {
                #region FirstRow
                btnTilde.Content = "~";
                btn1.Content = "!";
                btn2.Content = "@";
                btn3.Content = "#";
                btn4.Content = "$";
                btn5.Content = "%";
                btn6.Content = "^";
                btn7.Content = "&";
                btn8.Content = "*";
                btn9.Content = "(";
                btn0.Content = ")";
                btnDash.Content = "_";
                btnEqual.Content = "+";
                #endregion
                #region SecondRow
                btnQ.Content = "Q";
                btnW.Content = "W";
                btnE.Content = "E";
                btnR.Content = "R";
                btnT.Content = "T";
                btnY.Content = "Y";
                btnU.Content = "U";
                btnI.Content = "I";
                btnO.Content = "O";
                btnP.Content = "P";
                btnOBracket.Content = "{";
                btnCBracket.Content = "}";
                btnBSlash.Content = "|";
                #endregion
                #region ThirdRow
                btnA.Content = "A";
                btnS.Content = "S";
                btnD.Content = "D";
                btnF.Content = "F";
                btnG.Content = "G";
                btnH.Content = "H";
                btnJ.Content = "J";
                btnK.Content = "K";
                btnL.Content = "L";
                btnSemi.Content = ":";
                btnApost.Content = "\"";
                #endregion
                #region FourthRow
                btnZ.Content = "Z";
                btnX.Content = "X";
                btnC.Content = "C";
                btnV.Content = "V";
                btnB.Content = "B";
                btnN.Content = "N";
                btnM.Content = "M";
                btnComma.Content = "<";
                btnDot.Content = ">";
                btnSlash.Content = "?";
                #endregion
            }
            else
            {
                #region FirstRow
                btnTilde.Content = "`";
                btn1.Content = "1";
                btn2.Content = "2";
                btn3.Content = "3";
                btn4.Content = "4";
                btn5.Content = "5";
                btn6.Content = "6";
                btn7.Content = "7";
                btn8.Content = "8";
                btn9.Content = "9";
                btn0.Content = "0";
                btnDash.Content = "-";
                btnEqual.Content = "=";
                #endregion
                #region SecondRow
                btnQ.Content = "q";
                btnW.Content = "w";
                btnE.Content = "e";
                btnR.Content = "r";
                btnT.Content = "t";
                btnY.Content = "y";
                btnU.Content = "u";
                btnI.Content = "i";
                btnO.Content = "o";
                btnP.Content = "p";
                btnOBracket.Content = "[";
                btnCBracket.Content = "]";
                btnBSlash.Content = "\\";
                #endregion
                #region ThirdRow
                btnA.Content = "a";
                btnS.Content = "s";
                btnD.Content = "d";
                btnF.Content = "f";
                btnG.Content = "g";
                btnH.Content = "h";
                btnJ.Content = "j";
                btnK.Content = "k";
                btnL.Content = "l";
                btnSemi.Content = ";";
                btnApost.Content = "'";
                #endregion
                #region FourthRow
                btnZ.Content = "z";
                btnX.Content = "x";
                btnC.Content = "c";
                btnV.Content = "v";
                btnB.Content = "b";
                btnN.Content = "n";
                btnM.Content = "m";
                btnComma.Content = ",";
                btnDot.Content = ".";
                btnSlash.Content = "/";
                #endregion
            }
        }
        /// <summary>
        /// Adds the key input.
        /// This also changes actions depending on whether or not shift,caps lock or ctrl are pressed.
        /// </summary>
        /// <param name="input">The input.</param>
        private void addKeyInput(byte input)
        {
            if (ctrlOn)
            {
                keybd_event(0x11, 0x9d, 0x01, 0);
                keybd_event(input, 0x9e, 0x01, 0);
                keybd_event(input, 0x9e, 0x02, 0);
                keybd_event(0x11, 0x9d, 0x01 | 0x02, 0);

                changeCtrl();
            }
            else if (shiftOn)
            {
                keybd_event(0x10, 0, 0, 0);
                keybd_event(input, 0, 0, 0);
                keybd_event(input, 0, 0x02, 0);
                keybd_event(0x10, 0, 0x02, 0);
                changeShift();
                changeKeys();
            }
            else if (capsLockOn)
            {
                keybd_event(0x10, 0, 0, 0);
                keybd_event(input, 0, 0, 0);
                keybd_event(input, 0, 0x02, 0);
                keybd_event(0x10, 0, 0x02, 0);
            }
            else
            {
                keybd_event(input, 0, 0, 0);
                keybd_event(input, 0, 0x02, 0);
            }

        }
        /// <summary>
        /// Handles the MouseDown event of the Window control.
        /// This allows you to move the window around.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs" /> instance containing the event data.</param>
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr a = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            int temp = GetWindowLong(a, -20);
            SetWindowLong(a, -20, temp | 0x08000000);
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.ShowInTaskbar = false;
        }
        /// <summary>
        /// Handles the click event of the most of the standard keys on the keyboard.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btn_click(object sender, RoutedEventArgs e)
        {
            Button keys = sender as Button;
            switch (keys.Name)
            {
                #region FirstRow
                case "btnTilde":
                    addKeyInput(0xc0);
                    break;
                case "btn1":
                    addKeyInput(0x31);
                    break;
                case "btn2":
                    addKeyInput(0x32);
                    break;
                case "btn3":
                    addKeyInput(0x33);
                    break;
                case "btn4":
                    addKeyInput(0x34);
                    break;
                case "btn5":
                    addKeyInput(0x35);
                    break;
                case "btn6":
                    addKeyInput(0x36);
                    break;
                case "btn7":
                    addKeyInput(0x37);
                    break;
                case "btn8":
                    addKeyInput(0x38);
                    break;
                case "btn9":
                    addKeyInput(0x39);
                    break;
                case "btn0":
                    addKeyInput(0x30);
                    break;
                case "btnDash":
                    addKeyInput(0xbd);
                    break;
                case "btnEqual":
                    addKeyInput(0xbb);
                    break;
                case "btnBack":
                    addKeyInput(0x08);
                    break;
                #endregion
                #region SecondRow
                case "btnQ":
                    addKeyInput(0x51);
                    break;
                case "btnW":
                    addKeyInput(0x57);
                    break;
                case "btnE":
                    addKeyInput(0X45);
                    break;
                case "btnR":
                    addKeyInput(0X52);
                    break;
                case "btnT":
                    addKeyInput(0X54);
                    break;
                case "btnY":
                    addKeyInput(0X59);
                    break;
                case "btnU":
                    addKeyInput(0X55);
                    break;
                case "btnI":
                    addKeyInput(0X49);
                    break;
                case "btnO":
                    addKeyInput(0X4F);
                    break;
                case "btnP":
                    addKeyInput(0X50);
                    break;
                case "btnOBracket":
                    addKeyInput(0xdb);
                    break;
                case "btnCBracket":
                    addKeyInput(0xdd);
                    break;
                case "btnBSlash":
                    addKeyInput(0xdc);
                    break;
                #endregion
                #region ThirdRow
                case "btnA":
                    addKeyInput(0x41);
                    break;
                case "btnS":
                    addKeyInput(0x53);
                    break;
                case "btnD":
                    addKeyInput(0x44);
                    break;
                case "btnF":
                    addKeyInput(0x46);
                    break;
                case "btnG":
                    addKeyInput(0x47);
                    break;
                case "btnH":
                    addKeyInput(0x48);
                    break;
                case "btnJ":
                    addKeyInput(0x4A);
                    break;
                case "btnK":
                    addKeyInput(0X4B);
                    break;
                case "btnL":
                    addKeyInput(0X4C);
                    break;
                case "btnSemi":
                    addKeyInput(0xba);
                    break;
                case "btnApost":
                    addKeyInput(0xde);
                    break;
                case "btnEnter":
                    addKeyInput(0x0d);
                    break;
                #endregion
                #region FourthRow
                case "btnZ":
                    addKeyInput(0X5A);
                    break;
                case "btnX":
                    addKeyInput(0X58);
                    break;
                case "btnC":
                    addKeyInput(0X43);
                    break;
                case "btnV":
                    addKeyInput(0X56);
                    break;
                case "btnB":
                    addKeyInput(0X42);
                    break;
                case "btnN":
                    addKeyInput(0x4E);
                    break;
                case "btnM":
                    addKeyInput(0x4D);
                    break;
                case "btnComma":
                    addKeyInput(0xbc);
                    break;
                case "btnDot":
                    addKeyInput(0xbe);
                    break;
                case "btnSlash":
                    addKeyInput(0xbf);
                    break;
                #endregion
                #region FifthRow
                case "btnSpace":
                    addKeyInput(0x20);
                    break;
                case "btnClose":
                    keybd_event(0x11, 0x9d, 0x01, 0);
                    keybd_event(0x57, 0x9e, 0x01, 0);
                    keybd_event(0x57, 0x9e, 0x02, 0);
                    keybd_event(0x11, 0x9d, 0x01 | 0x02, 0);
                    Application.Current.Shutdown();
                    break;
                    #endregion

            }
        }
        /// <summary>
        /// Handles the Click event of the btnCapsLock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnCapsLock_Click(object sender, RoutedEventArgs e)
        {
            if (capsLockOn)
            {
                capsLockOn = false;
                btnCapsLock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
            }
            else
            {
                capsLockOn = true;
                btnCapsLock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")); 
            }
            changeKeys();
        }
        /// <summary>
        /// Handles the Click event of the btnShift control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnShift_Click(object sender, RoutedEventArgs e)
        {
            changeShift();
            changeKeys();
        }
        /// <summary>
        /// Turns shift on or off.
        /// </summary>
        private void changeShift()
        {
            if (shiftOn)
            {
                shiftOn = false;
                btnShift.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
                btnRShift.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
            }
            else
            {
                shiftOn = true;
                btnShift.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                btnRShift.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }
        /// <summary>
        /// Handles the Click event of the btnCtrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnCtrl_Click(object sender, RoutedEventArgs e)
        {
            changeCtrl();
        }
        /// <summary>
        /// Turns ctrl on or off
        /// </summary>
        private void changeCtrl()
        {
            if (ctrlOn)
            {
                ctrlOn = false;
                btnCtrl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
                btnCtrl2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
            }
            else
            {
                ctrlOn = true;
                btnCtrl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                btnCtrl2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }

        private void btnTop_Click(object sender, RoutedEventArgs e)
        {
            if (btnTop.Content.ToString() == "Top")
            {
                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
                this.Top = desktopWorkingArea.Top;
                this.Left = desktopWorkingArea.Left;
                btnTop.Content = "Bottom";
            }
            else
            {
                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
                this.Top = desktopWorkingArea.Bottom - this.Height;
                this.Left = desktopWorkingArea.Left;
                btnTop.Content = "Top";
            }

        }
    }
}
