﻿using UnityEngine;
using UnityEditor;

public class ConstIntDBEditor {
    private static string GetSavePath() {
        return EditorUtility.SaveFilePanelInProject("New item database", "New item database", "asset", "Create a new item database.");
    }

    [MenuItem("Assets/Create/Databases/ConstIntDB")]
    public static void CreateDatabase() {
        string assetPath = GetSavePath();
        MonsterDB asset = ScriptableObject.CreateInstance("ConstIntDB") as MonsterDB;  //scriptable object
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(assetPath));
        AssetDatabase.Refresh();
    }
}

