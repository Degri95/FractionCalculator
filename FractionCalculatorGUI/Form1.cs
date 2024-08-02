using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractionCalculatorGUI
{
    public partial class MainForm : Form
    {
        private enum DISPLAY_MODE { CURRENT_VALUE, ACCUMULATOR, ERROR };
        private enum OPS { ADD, SUB, MULT, DIV };
        private OPS currentOperation;

        Fraction currentFraction = new Fraction();
        Fraction accumulatorFraction = new Fraction();

        private int displayValue = 0;
        private bool isEnteringNumerator = true;
        private DISPLAY_MODE displayMode= DISPLAY_MODE.CURRENT_VALUE;
        

        public MainForm()
        {
            InitializeComponent();
        }

        // Init display
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            
            switch (displayMode)
            {
                case DISPLAY_MODE.CURRENT_VALUE:
                    mainTextBox.Text = $"{currentFraction.GetNumerator()}/{currentFraction.GetDenominator()}";
                    break;
                case DISPLAY_MODE.ACCUMULATOR:
                    mainTextBox.Text = accumulatorFraction.ToString();
                    break;
                case DISPLAY_MODE.ERROR:
                    break;
            }
            
        }

        private void NumberKeyClick(int number)
        {
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            displayValue = displayValue * 10 + number;
            if (isEnteringNumerator)
            {
                currentFraction.SetNumerator(displayValue);
            }
            else
            {
                currentFraction.SetDenominator(displayValue);
            }
            UpdateDisplay();
        }
        
        // Number Buttons Begin
        private void zeroButton_Click(object sender, EventArgs e) { NumberKeyClick(0); }
        private void oneButton_Click(object sender, EventArgs e) { NumberKeyClick(1); }
        private void twoButton_Click(object sender, EventArgs e) { NumberKeyClick(2); }
        private void threeButton_Click(object sender, EventArgs e) { NumberKeyClick(3); }
        private void fourButton_Click(object sender, EventArgs e) { NumberKeyClick(4); }
        private void fiveButton_Click(object sender, EventArgs e) { NumberKeyClick(5); }
        private void sixButton_Click(object sender, EventArgs e) { NumberKeyClick(6); }
        private void sevenButton_Click(object sender, EventArgs e) { NumberKeyClick(7); }
        private void eightButton_Click(object sender, EventArgs e) { NumberKeyClick(8); }
        private void nineButton_Click(object sender, EventArgs e) { NumberKeyClick(9); }

        // Number Buttons End
        //
        // Ops Buttons Begin
        private void OpsKeyHit(OPS op)
        {
            PerformOps();
            currentOperation = op;
            isEnteringNumerator = true;
            displayValue = 0;
            //currentFraction = new Fraction();
            UpdateDisplay();
        }

        private void PerformOps()
        {

            switch (currentOperation)
            {
                case OPS.ADD:
                    accumulatorFraction = Fraction.Add(accumulatorFraction, currentFraction);

                    break;
                case OPS.SUB:
                    accumulatorFraction = Fraction.Sub(accumulatorFraction, currentFraction);
                    break;
                case OPS.MULT:
                    accumulatorFraction = Fraction.Mult(accumulatorFraction, currentFraction);
                    break;
                case OPS.DIV:
                    if (currentFraction.GetDenominator() == 0)
                    {
                        displayMode = DISPLAY_MODE.ERROR;
                        mainTextBox.Text = "No Div/0";
                        return;
                    }
                    accumulatorFraction = Fraction.Div(accumulatorFraction, currentFraction);

                    break;
            }
            currentFraction = new Fraction();
            displayValue = 0;
            displayMode = DISPLAY_MODE.ACCUMULATOR;
            UpdateDisplay();

        }

        private void plusButton_Click(object sender, EventArgs e) { OpsKeyHit(OPS.ADD); }
        private void subtractButton_Click(object sender, EventArgs e) { OpsKeyHit(OPS.SUB); }
        private void multiplyButton_Click(object sender, EventArgs e) { OpsKeyHit(OPS.MULT); }
        private void divideButton_Click(object sender, EventArgs e)
        {
            if (isEnteringNumerator)
            {
                isEnteringNumerator = false;
                displayValue = 0;
                UpdateDisplay();
            }
            
            else
            {
                OpsKeyHit(OPS.DIV);
            }
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            PerformOps();
            currentFraction = new Fraction();
        }

        //Ops Buttons End
        //
        // Clear Buttons Begin
        private void clearButton_Click(object sender, EventArgs e)
        {
            displayValue = 0;
            currentFraction = new Fraction();
            isEnteringNumerator = true;
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            UpdateDisplay();
        }

        private void allClearButton_Click(object sender, EventArgs e)
        {
            displayValue = 0;
            currentOperation = OPS.ADD;
            currentFraction = new Fraction();
            accumulatorFraction = new Fraction();
            isEnteringNumerator = true;
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            UpdateDisplay();
        }
    }
}
