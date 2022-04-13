using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugeInteger
{
    public partial class HugeIntegerForm : Form
    {
        HugeInteger huge = new HugeInteger();
        HugeInteger hugeInt = new HugeInteger();
        HugeInteger value = new HugeInteger();
        public HugeIntegerForm()
        {
            InitializeComponent();
        }

    
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            value.Input(numberTextBox.Text);
            if (addRadioButton.Checked)
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                displayLabel.Text = huge.Add(hugeInt).ToString();
            }
            else if (subtractButton.Checked)
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                displayLabel.Text = huge.Subtract(hugeInt).ToString();
            }

            else if (multiplyRadioButton.Checked)
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                displayLabel.Text = huge.Multiply(hugeInt).ToString();
            }

            else if (divideRadioButton.Checked)
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                displayLabel.Text = huge.Divide(hugeInt).ToString();
            }
            else
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                displayLabel.Text = huge.Remainder(hugeInt).ToString();
            }
        
            if (value.IsGreaterThan(hugeInt))
            {

                greaterThanCheckBox.Checked = true;
            }
            else
            {
                greaterThanCheckBox.Checked = false;
            }

            if (value.IsLessThan(hugeInt))
            {
                lessThanCheckBox.Checked = true;
            }
            else
            {
                lessThanCheckBox.Checked = false;
            }

            if (value.IsGreaterThanOrEqualTo(hugeInt))
            {
                greaterThanOrEqualToCheckBox.Checked = true;
            }
            else
            {
                greaterThanOrEqualToCheckBox.Checked = false;
            }

            if (value.IsLessThanOrEqualTo(hugeInt))
            {
                lessThanOrEqualToCheckBox.Checked = true;
            }
            else
            {
                lessThanOrEqualToCheckBox.Checked = false;
            }

            if (value.IsEqualTo(hugeInt))
            {
                huge.Input(numberTextBox.Text);
                hugeInt.Input(number2TextBox.Text);
                equalToCheckBox.Checked = true;
                isNotEqualToCheckBox.Checked = false;
            }
            else
            {
                equalToCheckBox.Checked = false;
                isNotEqualToCheckBox.Checked = true;
            }

            if (huge.IsZero())
            {
                isZeroCheckBox.Checked = true;
            }

            else
            {
                isZeroCheckBox.Checked = false;
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
