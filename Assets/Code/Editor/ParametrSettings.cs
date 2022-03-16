#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class ParametrSettings : EditorWindow
{
    private int[] _posX = new int[] { 80, 200 };
    private const int _height = 20;
    private static bool CheckStart = true;
    private const int LineString = 20;
    private static int[] _posY;

    [MenuItem("Инструменты/ Окна/ Настройки объектов")]
    public static void ShowWindowSettingGame()
    {
        GetWindow(typeof(ParametrSettings), false, "Настройки объектов");
        Started();
    }

    private void OnGUI()
    {
        var _player = GameObject.FindObjectOfType<PlayerProvider>();
        GameObject.FindObjectOfType<BulletProvider>().TryGetComponent<BulletProvider>(out BulletProvider _bullet);
        LabelSlider(20, ref EntityData.GameSetting._playerAnimationSpeed, ref EntityData.GameSetting._playerAnimationSpeed_max, "Animation Speed");
        LabelSlider(40, ref EntityData.GameSetting._parallaxSpeed, ref EntityData.GameSetting._parallaxSpeed_max, "Paralax Coef");

        LabelSlider(60, ref _bullet.BulletAcceleration, ref EntityData.GameSetting._parallaxSpeed_max, "BulletAcceleration");
        LabelSlider(80, ref _bullet.BulletRadius, ref EntityData.GameSetting._parallaxSpeed_max, "BulletRadius");
        LabelSlider(100, ref _bullet.BulletGroundLevel, ref EntityData.GameSetting._parallaxSpeed_max, "BulletGroundLevel");
        LabelSlider(240, ref _bullet.ShootDelay, ref EntityData.GameSetting._parallaxSpeed_max, "Shooting Delay");

        LabelSlider(120, ref _player.PlayerWalkSpeed, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerWalkSpeed");
        LabelSlider(140, ref _player.PlayerMoveTresh, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerMovingTresh");
        LabelSlider(160, ref _player.PlayerAcceleration, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerAcceleration");
        LabelSlider(180, ref _player.PlayerJumpStartSpeed, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerJumpStartSpeed");
        LabelSlider(200, ref _player.PlayerGroundLevel, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerGroundLevel");
        LabelSlider(220, ref _player.PlayerFlyTresh, ref EntityData.GameSetting._parallaxSpeed_max, "PlayerFlyTresh");



    }


    float LabelSlider(int posY, ref float sliderValue, ref float sliderMaxValue, string labelText)
    {
        string inStrVolue;
        string inStrMaxVolue;
        Rect sliderRect1 = new Rect(_posX[0] + _posX[1] / 2, posY, _posX[1] / 2, _height);
        Rect labelRect = new Rect(_posX[0], posY, _posX[1] / 2, _height);
        Rect labelRect2 = new Rect(_posX[0] + _posX[1] + 5, posY, _posX[1] / 4, _height);
        Rect labelRect3 = new Rect(labelRect2);
        Rect labelRect4 = new Rect(labelRect2);
        labelRect3.x += 60;
        labelRect4.x += 100;
        GUILayout.BeginHorizontal();
        inStrMaxVolue = GUI.TextField(labelRect4, sliderMaxValue.ToString());
        sliderMaxValue = GetString(inStrMaxVolue);
        GUI.Label(labelRect, labelText);
        GUI.Label(labelRect3, "Max");
        sliderValue = GUI.HorizontalSlider(sliderRect1, sliderValue, -10.0f, sliderMaxValue);
        inStrVolue = GUI.TextField(labelRect2, sliderValue.ToString());
        sliderValue = GetString(inStrVolue);
        GUILayout.EndHorizontal();
        SaveChanges();
        return sliderValue;
    }

    private float GetString(string str)
    {
        float.TryParse(str, out var tmp);
        return tmp;
    }

    static void Started()
    {
        if (CheckStart)
        {
            CheckStart = false;

            _posY = new int[LineString];
            for (int i = 0; i < LineString; i++)
            {
                _posY[i] = i * 20 + 20;
            }
        }
    }
}

#endif