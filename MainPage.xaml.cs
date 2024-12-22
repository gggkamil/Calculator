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
    string currentEntry = "";
    string decimalFormat = "N0";
    double x, y;
    string mathOperator;
    private double ubezEmerytalne = 0.0976;
    private double ubezRentowe = 0.015;
    private double ubezChorobowe = 0.0245;
    private double skladka = 0;
    private double z;


    void ClickedOnNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;

        if (currentState < 0)
        {
            resultText.Text = "0";
            currentState *= -1;
        }

        if (pressed == "," && resultText.Text.Contains(",")) return;

        if (resultText.Text == "0" && pressed != ",")
        {
            resultText.Text = pressed; // Start fresh if "0" is the only input
        }
        else
        {
            resultText.Text += pressed; // Append input for multi-digit numbers
        }
    }

    void ClickedOnOperator(object sender, EventArgs e)
    {
        NumberValue(resultText.Text);
        currentState = -2;
        Button button = (Button)sender;
        mathOperator = button.Text;

    }

    private void NumberValue(string text)
    {
        // Replace comma with dot for consistent parsing
        text = text.Replace(',', '.');

        if (double.TryParse(text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double number))
        {
            if (currentState == 1)
            {
                x = number;
            }
            else
            {
                y = number;
            }
        }
    }

    void ClickedOnClear(object sender, EventArgs e)
    {
        resultText.Text = "0";
        x = 0;
        y = 0;
        currentState = 1;
        decimalFormat = "N0";
    }

    void ClickedOnEqual(object sender, EventArgs e)
    {

        if (currentState == 2)
        {
            NumberValue(resultText.Text);
            if (mathOperator == "÷" && y == 0)
            {
                resultText.Text = "Error";
                return;
            }


            double result = Calculator.Calculate(x, y, mathOperator);
            decimalFormat = "N2";
            CurrentCalculation.Text = $"{x} {mathOperator} {y}";
            resultText.Text = result.ToString(decimalFormat);
            x = result;
            y = 0;
            currentState = -1;
        }
    }

    void ClickedOnNetto(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            NumberValue(resultText.Text);
            z = (x - (x * ubezRentowe) - (x * ubezChorobowe) - (x * ubezEmerytalne));
            skladka = z * 0.09;
            double q = z - 250;
            double zaliczka = double.Round((q * 0.12) - 300);
            y = z - skladka - zaliczka;
            decimalFormat = "N2";
            resultText.Text = y.ToString(decimalFormat);

            currentState = 2;
            // ClickedOnEqual(this, null);
        }

    }
}
