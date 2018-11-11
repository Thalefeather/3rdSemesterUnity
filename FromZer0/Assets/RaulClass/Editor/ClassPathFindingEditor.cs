using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ClassPathFinding))]
public class ClassPathFindingEditor : Editor {
    ClassPathFinding pathfinding;
    public ClassGrid Grid => pathfinding.grid;

    private void OnEnable()
    {
        pathfinding = target as ClassPathFinding;
        if (pathfinding.grid == null) {
            //pathfinding.Init();
        }
    }

    private void OnSceneGUI()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
