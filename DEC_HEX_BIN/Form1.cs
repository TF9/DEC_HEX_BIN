using System;
using System.Collections.Generic;
using System.Drawing;
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
            // fix hight of the form
            this.MaximumSize = new Size(Int32.MaxValue, 130); 
            this.MinimumSize  = new Size(300, 130);
        }

        private string Bin2Dec(string text)
        {
            /* Convert a binary string into a decimal string:
             * start from low digit
             * if digit is '1' the actual value of 'power of 2' is added to the result.
             */
            string result = "0";
            string pwOf2 = "1";
            int i = text.Length - 1;
            char[] charArray = text.ToCharArray();

            while(i >= 0)
            {
                if (charArray[i] == '1')
                {
                    result = Sum(pwOf2, result);
                }
                pwOf2 = Sum(pwOf2, pwOf2);
                --i;
            }
            return result;
        }

        private string Dec2Bin(string text)
        {
            /* Convert a decimal string into a binary string:
             * loopwise:
             * - if the lowest digit is odd, set a '1' else a '0' at the front of the result string
             * - divide the string by '2' -> next
             */
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
            /* check if the last digit in a string is odd (return '1') or even (return '0') 
              */
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
            /* Divide a decimal string by two without rest:
             * start from highes digit
             * - if the actual digit is odd keep rounding value ('5') for next loop
             * - divide actual digit by two, add rounding value from last step ('5')
             * - add digit at the end of string
             */
            string result = string.Empty;
            string digit;
            int add = 0;
            char[] cs = s.ToCharArray();
            int i = 0;
            int len = s.Length;

            while (i < len)
            {
                digit = ((int.Parse(cs[i].ToString()) / 2) + add).ToString();
                add = OddsToOne(cs[i].ToString()) * 5;
                result += digit;
                ++i;
            }
            // remove leading 0 anreturn result
            return result.TrimStart('0').PadLeft(1, '0');
        }

        string Sum(string a, string b)
        {
            /* Summarize two decimal strings:
             * strings a,b are not checked for valid deciml char
             * must be done by caller
             */
            int i = a.Length - 1;
            int k = b.Length - 1;
            int s1, s2;
            int step;
            int trans = 0;
            string result = string.Empty;
            char[] c_a = a.ToCharArray();
            char[] c_b = b.ToCharArray();

            while (((i >= 0) || (k >= 0) || (trans > 0)))
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

                step = s1 + s2 + trans;
                trans = step / 10;      // get the tens digit for next loop
                step %= 10;             // get unit digit
                result = step + result; // store unit in front of result string
                --k;
                --i;
            }
            return result;
        }

        string Bin2Hex(string bin)
        {
            /* Convert a binary string into a HEX-string
             * - convert a binary nibble (from low to high) into HEX-expression value 
             * - add the mapping value at the front of the result string
             */
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
            /* Convert a HEX-string to a binary string (lower case char are allowed.)
             * No check of input string for valid characters.
             * - each digit is mapped via mapping table to its binary expression (low to high)
             * - add the result of each step to the front of the result string
             */
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
                // deleted content - clear all
                tbDec.Text = string.Empty;
                tbBin.Text = string.Empty;
                tbHex.Text = string.Empty;
                return;
            }

            if (keyHandled == false)
            {
                // valid character is pressed
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
                // The character which is pressed is not within the specific range
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
            /* check the input for binary text-box:
             * [0 or 1 or special keys]
             */
            // Initialize the flag to false.
            keyHandled = false;

            // Determine whether the keystroke is '0' or '1' from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D1)
            {
                // Determine whether the keystroke is '0' or '1' from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad1)
                {
                    // Determine whether the keystroke is a valid special key (-combination).
                    if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                    {
                        // feedback user for wrong input: short red flash
                        System.Drawing.Color colr = tbBin.BackColor;
                        tbBin.BackColor = System.Drawing.Color.Salmon;
                        tbBin.Update();
                        System.Threading.Thread.Sleep(100);
                        tbBin.BackColor = colr;
                        // Set the flag to true and evaluate in KeyPress event.
                        keyHandled = true;
                    }
                }
            }
        }

        private void tbDec_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /* check the input for decimal text-box:
             * [0 to 9 or special keys]
             */
            // Initialize the flag to false.
            keyHandled = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a valid special key (-combination).
                    if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                    {
                        // feedback user for wrong input: short red flash
                        System.Drawing.Color colr = tbDec.BackColor;
                        tbDec.BackColor = System.Drawing.Color.Salmon;
                        tbDec.Update();
                        System.Threading.Thread.Sleep(100);
                        tbDec.BackColor = colr;
                        // Set the flag to true and evaluate in KeyPress event.
                        keyHandled = true;
                    }
                }
            }
        }

        private void tbHex_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /* check the input for hexadecimal text-box:
             * [0 to 9 or A to F or special keys]
             */
            // Initialize the flag to false.
            keyHandled = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a valid letter from the keypad.
                    if (e.KeyCode < Keys.A || e.KeyCode > Keys.F)
                    {
                        // Determine whether the keystroke is a valid special key (-combination).
                        if (!SpecialKeyOk(e.KeyCode, e.Modifiers))
                        {
                            // feedback user for wrong input: short red flash
                            System.Drawing.Color colr = tbHex.BackColor;
                            tbHex.BackColor = System.Drawing.Color.Salmon;
                            tbHex.Update();
                            System.Threading.Thread.Sleep(100);
                            tbHex.BackColor = colr;
                            // Set the flag to true and evaluate in KeyPress event.
                            keyHandled = true;
                        }
                    }
                }
            }
        }
    }
}
