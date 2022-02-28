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
        EntityData.GameSetting._playerAnimationSpeed = LabelSlider(20, ref EntityData.GameSetting._playerAnimationSpeed, ref EntityData.GameSetting._playerAnimationSpeed_max, "Animation Speed");
        EntityData.GameSetting._parallaxSpeed = LabelSlider(40, ref EntityData.GameSetting._parallaxSpeed, ref EntityData.GameSetting._parallaxSpeed_max, "Paralax Coef");
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
        sliderValue = GUI.HorizontalSlider(sliderRect1, sliderValue, 0.0f, sliderMaxValue);
        inStrVolue = GUI.TextField(labelRect2, sliderValue.ToString());
        sliderValue = GetString(inStrVolue);
        GUILayout.EndHorizontal();
        SaveChanges();
        return sliderValue;
    }
    private float GetString(string str)
    {
        float tmp = 0f;
        float.TryParse(str, out tmp);
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