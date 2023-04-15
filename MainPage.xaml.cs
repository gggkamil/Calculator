namespace Calculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		ClickedOnClear(this, null);
	}

	int currentState = 0;

	void ClickedOnClear(object sender, EventArgs e)
	{
		currentState = 0;
        this.resultText.Text = "0";

    }
	void ClickedOnNumber(object sender, EventArgs e)
	{
		Button button= (Button)sender;
		string pressed = button.Text;

        this.resultText.Text += pressed;
    }
}

