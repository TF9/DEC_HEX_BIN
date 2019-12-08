using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DEC_HEX_BIN
{
    public partial class Form1 : Form
    {
        bool keyHandled;
        public Form1()
        {
            InitializeComponent();
        }

        private string Bin2Dec(string text)
        {
            string result = "0";
            string a = "1";
            int i = text.Length - 1;
            char[] charArray = text.ToCharArray();

            while(i >= 0)
            {
                if (charArray[i] == '1')
                {
                    result = Sum(a, result);
                }
                a = Sum(a, a);
                --i;
            }
            return result;
        }

        private string Dec2Bin(string text)
        {
            if (text == "0")
                return "0";
            string num = text;
            string bin = string.Empty;

            while (num != "0")
            {
                bin = OddsToOne(num) + bin;
                num = DivByTwo(num);
            }
            return bin;
        }

        private int OddsToOne(string s)
        {
            switch (s.Last())
            {
                case '1':
                case '3':
                case '5':
                case '7':
                case '9':
                    return 1;
                default:
                    return 0;
            }
        }

        private string DivByTwo(string s)
        {
            string new_s = string.Empty;
            string new_dig;
            int add = 0;
            char[] cs = s.ToCharArray();
            int i = 0;
            int len = s.Length;

            while (i < len)
            {
                new_dig = ((int.Parse(cs[i].ToString()) / 2) + add).ToString();
                add = OddsToOne(cs[i].ToString()) * 5;
                new_s += new_dig;
                ++i;
            }

            while ((new_s.Length > 1) && (new_s.StartsWith("0")))
            {
                new_s = new_s.Remove(0, 1);
            }
            return new_s;
        }

        string Sum(string a, string b)
        {
            int i = a.Length - 1;
            int k = b.Length - 1;
            int s1, s2;
            int step;
            int rest = 0;
            string result = string.Empty;
            char[] c_a = a.ToCharArray();
            char[] c_b = b.ToCharArray();

            while (((i >= 0) || (k >= 0) || (rest > 0)))
            {
                s1 = 0;
                s2 = 0;
                if (k >= 0)
                {
                    s1 = int.Parse(c_b[k].ToString());
                }
                if (i >= 0)
                {
                    s2 = int.Parse(c_a[i].ToString());
                }

                step = s1 + s2 + rest;
                rest = step / 10;
                step %= 10;
                result = step + result;
                --k;
                --i;
            }
            return result;
        }

        string Bin2Hex(string bin)
        {
            char[] map = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', };

            int i = bin.Length;
            string s;
            string result = string.Empty;
            while (i > 0)
            {
                if ((i - 4) <= 0)
                {
                    s = bin.Substring(0, i);
                    i = 0;
                }
                else
                {
                    i -= 4;
                    s = bin.Substring(i, 4);
                }
                result = map[int.Parse(Bin2Dec(s))] + result;
            }
            return result;
        }

        string HexBin2(string hex)
        {
            var map = new Dictionary<char, string>()
            {
                { '0',"0000" },
                { '1',"0001" },
                { '2',"0010" },
                { '3',"0011" },
                { '4',"0100" },
                { '5',"0101" },
                { '6',"0110" },
                { '7',"0111" },
                { '8',"1000" },
                { '9',"1001" },
                { 'A',"1010" },
                { 'B',"1011" },
                { 'C',"1100" },
                { 'D',"1101" },
                { 'E',"1110" },
                { 'F',"1111" }
            };

            char[] c_h = hex.ToUpper().ToCharArray();
            int i = hex.Length;
            string result = string.Empty;
            while (i > 0)
            {
                --i;
                result = map[c_h[i]] + result;
            }
            return result;
        }

        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(((MaskedTextBox)sender).Text))
            {
                tbDec.Text = string.Empty;
                tbBin.Text = string.Empty;
                tbHex.Text = string.Empty;
                return;
            }

            if (keyHandled == false)
            {
                string s = ((MaskedTextBox)sender).Text;
                s = s.TrimStart('0').PadLeft(1, '0');
                ((MaskedTextBox)sender).Text = s;
                switch (((MaskedTextBox)sender).Name)
                {
                    case "tbDec":
                        tbBin.Text = Dec2Bin(s);
                        tbHex.Text = Bin2Hex(tbBin.Text);
                        break;
                    case "tbBin":
                        tbDec.Text = Bin2Dec(s);
                        tbHex.Text = Bin2Hex(s);
                        break;
                    case "tbHex":
                        tbBin.Text = HexBin2(s);
                        tbDec.Text = Bin2Dec(tbBin.Text);
                        break;
                }
            }
            else
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyHandled == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (keyHandled == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private bool SpecialKeyOk(Keys k, Keys m)
        {
            if (
                   (k == Keys.ShiftKey)
                || (k == Keys.Back)
                || (k == Keys.Delete)
                || (k == Keys.Left)
                || (k == Keys.Right)
                || (k == Keys.End)
                || (k == Keys.Home)
                || (m == Keys.Control)
                || ((m == Keys.Control) && (k == Keys.V))
                || ((m == Keys.Control) && (k == Keys.X))
                || ((m == Keys.Control) && (k == Keys.C))
                || ((m == Keys.Control) && (k == Keys.A))
                )
            {
                return true;
            }
            return false;
        }

        private void tbBin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Initialize the flag to false.
            keyHandled = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D1)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad1)
                {
                    // Determine whether the keystroke is a valid special key.
                    if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                    {
                        System.Drawing.Color colr = tbBin.BackColor;
                        tbBin.BackColor = System.Drawing.Color.Salmon;
                        tbBin.Update();
                        System.Threading.Thread.Sleep(100);
                        tbBin.BackColor = colr;
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        keyHandled = true;
                    }
                }
            }
        }

        private void tbDec_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Initialize the flag to false.
            keyHandled = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a valid special key.
                    if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                    {
                        System.Drawing.Color colr = tbDec.BackColor;
                        tbDec.BackColor = System.Drawing.Color.Salmon;
                        tbDec.Update();
                        System.Threading.Thread.Sleep(100);
                        tbDec.BackColor = colr;
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        keyHandled = true;
                    }
                }
            }
        }

        private void tbHex_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Initialize the flag to false.
            keyHandled = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode < Keys.A || e.KeyCode > Keys.F)
                    {
                        // Determine whether the keystroke is a valid special key.
                        if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                        {
                            System.Drawing.Color colr = tbHex.BackColor;
                            tbHex.BackColor = System.Drawing.Color.Salmon;
                            tbHex.Update();
                            System.Threading.Thread.Sleep(100);
                            tbHex.BackColor = colr;
                            // A non-numerical keystroke was pressed.
                            // Set the flag to true and evaluate in KeyPress event.
                            keyHandled = true;
                        }
                    }
                }
            }
        }
    }
}
