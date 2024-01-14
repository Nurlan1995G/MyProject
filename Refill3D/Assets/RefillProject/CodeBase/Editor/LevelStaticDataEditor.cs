﻿using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Person.BuyerSpawner;
using Assets.RefillProject.CodeBase.StaticData;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.RefillProject.CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.BuyerSpawners = FindObjectsOfType<SpawnMarker>()
                    .Select(x => new BuyerSpawnerData(x.GetComponent<UniqueId>().Id, x.BuyerTypeId,x.transform.position))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }

    }
}