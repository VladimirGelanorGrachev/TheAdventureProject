using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateLevelView))]
public class GenerateLevelEditor : Editor
{
    private GenerateLevelController _generateLevelController;

    private void OnEnable()
    {
        var generateLevelView =(GenerateLevelView) target;
        _generateLevelController = new GenerateLevelController(generateLevelView);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var tileMap = serializedObject.FindProperty("_tileMapGround");
        EditorGUILayout.PropertyField(tileMap);

        var tileGround = serializedObject.FindProperty("_tileGround");
        EditorGUILayout.PropertyField(tileGround);

        var widthMap = serializedObject.FindProperty("_widthMap");
        EditorGUILayout.PropertyField(widthMap);

        var heightMap = serializedObject.FindProperty("_heightMap");
        EditorGUILayout.PropertyField(heightMap);

        var factorSmooth = serializedObject.FindProperty("_factorSmooth");
        EditorGUILayout.PropertyField(factorSmooth);

        var randomFillPercent = serializedObject.FindProperty("_randomFillPercent");
        EditorGUILayout.PropertyField(randomFillPercent);

        if (GUI.Button(new Rect(10,140,65,40), "Generate"))
            _generateLevelController.Awake();

        if (GUI.Button(new Rect(10, 190, 65, 40), "Clear"))
            _generateLevelController.ClearTileMap();

        GUILayout.Space(100);

        serializedObject.ApplyModifiedProperties();
    }
}
