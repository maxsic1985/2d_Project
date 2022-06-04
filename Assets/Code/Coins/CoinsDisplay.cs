using UnityEngine.UI;

public class CoinsDisplay 
{
    public Text _ScoreCoinsText;

    public CoinsDisplay(Text text)
    {
        _ScoreCoinsText = text;
    }
    public void UpdateScore(int value)
    {
        _ScoreCoinsText.text = value.ToString();
    }
}
