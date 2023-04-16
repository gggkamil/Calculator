using System.Runtime.CompilerServices;

namespace Calculator;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        ClickedOnClear(this, null);
    }

    int currentState = 1;
    string currentInput = "";
    string decimalFormat = "N0";
    double x = 0, y = 0;
    string mathOperator;

    void ClickedOnClear(object sender, EventArgs e)
    {
        this.resultText.Text = "0";
        x = 0;
        y = 0;
        currentState = 1;
        decimalFormat = "N0";
        currentInput = string.Empty;

    }
    void ClickedOnNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;

        if (currentInput.Length == 1 && currentInput == "0" && pressed != ".")
        {
            currentInput = "";
        }

        if (pressed == "." && currentInput.Contains("."))
        {
            return;
        }

        this.resultText.Text = currentInput += pressed;

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }
    }

    void ClickedOnOperator(object sender, EventArgs e)
    {
        NumberValue(resultText.Text);
        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;

        currentInput = string.Empty;
    }

    private void NumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                x = number;
            }
            else
            {
                y = number;
            }
            currentInput = string.Empty;
        }
    }
    void ClickedOnEqual(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            if (y == 0)
                NumberValue(resultText.Text);
            if (mathOperator == "÷" && y == 0)
            {
                resultText.Text = "Error";
                return;
            }

            double result = Calculator.Calculate(x, y, mathOperator);

            CurrentCalculation.Text = $"{x} {mathOperator} {y}";
            resultText.Text = result.ToString(decimalFormat);
            x = result;
            y = 0;
            currentState = -1;
            currentInput = "";
        }
    }
    void ClickedOnDivide(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            decimalFormat = "N2";
            NumberValue(resultText.Text);
            y = x * 0.01;
            mathOperator = "/";
            currentState = 2;
            ClickedOnEqual(this, null);
        }
    }
}
