using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketDashboard
{
    private TextMeshProUGUI currentScoreTxt;
    private TextMeshProUGUI highScoreTxt;
    private Slider fuelSlider;

    private float highScore = 0f;

    public RocketDashboard(TextMeshProUGUI currentScoreTxt, TextMeshProUGUI highScoreTxt, Slider fuelSlider)
    {
        this.currentScoreTxt = currentScoreTxt;
        this.highScoreTxt = highScoreTxt;
        this.fuelSlider = fuelSlider;
        highScore = PlayerPrefs.GetFloat("High Score", 0);
    }

    public void InitializeHighScore()
    {
        highScoreTxt.text = $"High Score {highScore:F1} M";
    }

    public void UpdateScore(float currentScore)
    {
        currentScoreTxt.text = $"Score {currentScore:F1} M";
    }

    public void UpdateHighScore(float currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreTxt.text = $"High Score: {highScore:F1} M";
            PlayerPrefs.SetFloat("High Score", highScore);
        }
    }

    public void InitializeFuelSlider(float maxFuel)
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = maxFuel;
    }

    public void UpdateFuelSlider(float currentFuel)
    {
        fuelSlider.value = currentFuel;
    }
}
