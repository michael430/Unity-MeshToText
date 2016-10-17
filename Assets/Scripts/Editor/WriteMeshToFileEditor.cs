using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WriteMeshToFile))]
public class WriteMeshToFileEditor : Editor {

	WriteMeshToFile editorTarget;

	void OnEnable ()
	{
		editorTarget = (WriteMeshToFile)target;
	}

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		
		EditorGUILayout.Space ();
		
		if (GUILayout.Button ("Export File", GUILayout.MinHeight (30f)))
			editorTarget.WriteToFile();
	}
}
