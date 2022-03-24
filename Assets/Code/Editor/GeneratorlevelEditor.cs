using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(GenerateLevelView))]
public class GeneratorlevelEditor : Editor
{
    private GenerateLevelController _generateLevelController;
    private void OnEnable()
    {
        var generateLevelView = (GenerateLevelView)target;
        _generateLevelController = new GenerateLevelController(generateLevelView);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var tileMap = serializedObject.FindProperty(GenerateLevelController.TileMapName);
        var tileGround = serializedObject.FindProperty(GenerateLevelController.TileGroundName);
        var mapWeight = serializedObject.FindProperty(GenerateLevelController.MapWeightName);
        var mapHeight = serializedObject.FindProperty(GenerateLevelController.MapHeightName);
        var smoothFactor = serializedObject.FindProperty(GenerateLevelController.FactorSmoothName);
        var fillPercent = serializedObject.FindProperty(GenerateLevelController.RandomFillPercentName);


        if (GUI.Button(new Rect(10, 0, 100, 30), "Generate Map"))
        {
            _generateLevelController.ClearMap();
            _generateLevelController.GenerateLevel();
        }

        if (GUI.Button(new Rect(10, 55, 100, 30), "Clear Map"))
        {
            _generateLevelController.ClearMap();
        }

        GUILayout.Space(100);
        EditorGUILayout.PropertyField(tileMap);
        EditorGUILayout.PropertyField(tileGround);
        EditorGUILayout.PropertyField(mapWeight);
        EditorGUILayout.PropertyField(mapHeight);
        EditorGUILayout.PropertyField(smoothFactor);
        EditorGUILayout.PropertyField(fillPercent);

        serializedObject.ApplyModifiedProperties();
    }
}
