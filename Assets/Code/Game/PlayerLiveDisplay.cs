using UnityEngine.UI;

public class PlayerLiveDisplay
{
    public Image[] _liveImages;
    public PlayerLiveDisplay(Image[] lives)
    {
        _liveImages = lives;
        for (int i = 0; i < lives.Length; i++)
        {
            _liveImages[i].enabled = true;
        }
    }
    public void UpdatePlayerLife(int value)
    {
        _liveImages[value - 1].enabled = false;
    }
}
