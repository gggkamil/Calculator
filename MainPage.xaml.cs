﻿using System.Runtime.CompilerServices;

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
    double x, y;
    string mathOperator;


    void ClickedOnNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;


        if ((this.resultText.Text == "0" && pressed == "0")
    || (currentEntry.Length <= 1 && pressed != "0")
    || currentState < 0)
        {
            currentInput = "";
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        //if (pressed == "." && currentInput.Contains("."))
        //{
        //    return;
        //}
        
        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }
        this.resultText.Text+= pressed;
    }

    void ClickedOnOperator(object sender, EventArgs e)
    {
        NumberValue(resultText.Text);
        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;

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
    void ClickedOnClear(object sender, EventArgs e)
    {
        this.resultText.Text = "0";
        x = 0;
        y = 0;
        currentState = 1;
        decimalFormat = "N0";
        currentInput = string.Empty;

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

            this.CurrentCalculation.Text = $"{x} {mathOperator} {y}";
            this.resultText.Text = result.ToString(decimalFormat);
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
