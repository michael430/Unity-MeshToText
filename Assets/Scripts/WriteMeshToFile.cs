/* This script will write a static or procedural generated Mesh with unity standard variables format into a text or C# file.
* Variables array: 
* Vector3[] vertices = { new Vector3(.... };
* Vector3[] normals = { new Vector3(.... };
* Vector4[] tangents = { new Vector4(.... };
* Vector2[] uv0 = { new Vector2(.... };
* Vector2[] uv2 = { new Vector2(.... };
* int[] triangles = { .... };
* 
* NOTE:
* If the mesh is a procedural generated Mesh, it needs to Recalculate the tangents of the mesh. 
* Other wise bumpmap shaders will not work.
* 
* Also keep in mind that RecalculateNormals() in unity does NOT generate tangents automatically. 
* At the moment unity does not have built-in RecalculateTangents function.
* So it needs to write your own tangents function.
* 
* Reference for tangents coding:
* http://answers.unity3d.com/questions/7789/calculating-tangents-vector4.html
* https://forum.unity3d.com/threads/how-to-calculate-mesh-tangents.38984/
*/

// Suggestion:
// If writing a very huge or high resolution mesh to file, properly need to add the 
// UnityEditor.EditorUtility.DisplayCancelableProgressBar () function.
// So that user can be able to cancel it while it is taking too long to write the file in editor.

// USAGE:
// Apply this script to a game object like Cube or Sphere..etc.
// The mesh that you want to be written which assign to mesh field in MeshFilter. 
// Hit "PLAY" Buttom : A text file will be created in your current Assets folder.


using UnityEngine;
using System.IO;

public class WriteMeshToFile : MonoBehaviour 
{
	public enum ExportFileFormat { TextFile = 0, CSharpFile = 1}

	public string FileName = "BakedMeshData";
	public bool WriteNormals = true;
	public bool WriteTangents = true;
	public bool WriteUV2 = true;
	public ExportFileFormat FileFormat = ExportFileFormat.CSharpFile;

/*
	void Start () {
		WriteToFile ();
	}
*/
	public void WriteToFile () 
	{
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		Vector4[] tangents = mesh.tangents;
		Vector2[] uv0 = mesh.uv;
		Vector2[] uv2 = mesh.uv2;
		int[] triangles = mesh.triangles;

		string formatExtension = (FileFormat == ExportFileFormat.CSharpFile)? ".cs":".txt";

		string path = "Assets/" + FileName + formatExtension;
		StreamWriter sw = File.CreateText(path);

		if (FileFormat == ExportFileFormat.CSharpFile)
			WriteCSFileFormat (sw, FileName);


		string writeData = "";


		// Vertices ------------------------------------------------------------
		sw.WriteLine ("// Mesh Vertices " + "#"+ vertices.Length) ;
		sw.WriteLine ("Vector3[] vertices = {");
		for (int i = 0; i < vertices.Length; i++)
		{
			string end = (i == vertices.Length -1)? string.Empty : ",";
			writeData = string.Format ("\t{0}({1}f,{2}f,{3}f){4}", "new Vector3", vertices[i].x, vertices[i].y, vertices[i].z, end);
			sw.WriteLine ( writeData );
		}
		sw.WriteLine ("};");
		sw.WriteLine (""); // space

		// UV0 ------------------------------------------------------------
		sw.WriteLine ("// UV0 " + "#"+ uv0.Length) ;
		sw.WriteLine ("Vector2[] UV0 = {");
		for (int i = 0; i < uv0.Length; i++)
		{
			string end = (i == uv0.Length -1)? string.Empty : ",";
			writeData = string.Format ("\t{0}({1}f,{2}f){3}", "new Vector2", uv0[i].x, uv0[i].y, end);
			sw.WriteLine ( writeData );
		}
		sw.WriteLine ("};");
		sw.WriteLine (""); // space
		
		// UV2 ------------------------------------------------------------
		if (WriteUV2)
		{
			sw.WriteLine ("// UV2 " + "#" + uv2.Length);
			sw.WriteLine ("Vector2[] UV2 = {");
			for (int i = 0; i < uv2.Length; i++) {
				string end = (i == uv2.Length - 1) ? string.Empty : ",";
				writeData = string.Format ("\t{0}({1}f,{2}f){3}", "new Vector2", uv2 [i].x, uv2 [i].y, end);
				sw.WriteLine (writeData);
			}
			sw.WriteLine ("};");
		}
		sw.WriteLine (""); // space

		// Triangles ------------------------------------------------------------
		sw.WriteLine ("// Triangles " + "#"+ triangles.Length) ;
		sw.WriteLine ("int[] triangles = {");
		string row = "";
		int Column = 0;
		for (int i = 0; i < triangles.Length; i++)
		{
			string end = (i == triangles.Length -1)? string.Empty : ",";
			writeData = string.Format ("{0}{1}", triangles[i], end);

			// reformat the row : write 3 int values at single line.
			row = row + writeData;

			if(Column == 2)// 0,1,2
			{
				row = "\t" + row;
				sw.WriteLine (row);
				row = "";
			}

			Column++;
			if (Column >= 3)	// reached 3 Column at single row?
				Column = 0;		// reset

		}
		sw.WriteLine ("};");
		sw.WriteLine (""); // space


		// Normals ------------------------------------------------------------
		if (WriteNormals) 
		{
			sw.WriteLine ("// Normals " + "#" + normals.Length);
			sw.WriteLine ("Vector3[] normals = {");
			for (int i = 0; i < normals.Length; i++) {
				string end = (i == normals.Length - 1) ? string.Empty : ",";
				writeData = string.Format ("\t{0}({1}f,{2}f,{3}f){4}", "new Vector3", normals [i].x, normals [i].y, normals [i].z, end);
				sw.WriteLine (writeData);
			}
			sw.WriteLine ("};");
			sw.WriteLine (""); // space
		}

		// Tangents ------------------------------------------------------------
		if (WriteTangents)
		{
			sw.WriteLine ("// Tangents " + "#" + tangents.Length);
			sw.WriteLine ("Vector4[] tangents = {");
			for (int i = 0; i < tangents.Length; i++) {
				string end = (i == tangents.Length - 1) ? string.Empty : ",";
				writeData = string.Format ("\t{0}({1}f,{2}f,{3}f,{4}){5}", "new Vector4", tangents [i].x, tangents [i].y, tangents [i].z, tangents [i].w, end);
				sw.WriteLine (writeData);
			}
			sw.WriteLine ("};");
		}

		if (FileFormat == ExportFileFormat.CSharpFile)
			sw.WriteLine ("}"); // CSharp end closing brasket

		sw.Close ();

	#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh ();
	#endif

		Debug.Log ("Saved the " + FileName + formatExtension +" into the Assets folder.");

	}

	void WriteCSFileFormat(StreamWriter sw, string className){
		sw.WriteLine ("using UnityEngine;");
		sw.WriteLine ("");
		sw.WriteLine ("public class " + className + " {");
		sw.WriteLine ("");

		// write generation code
		sw.WriteLine ("public Mesh GenerateMeshFromFile () {");
		sw.WriteLine ("\tMesh m\t\t= new Mesh();");
		sw.WriteLine ("\tm.name\t\t= \"Generated BakedMesh\";");
		sw.WriteLine ("\tm.vertices\t= vertices;");
		sw.WriteLine ("\tm.triangles\t= triangles;");
		sw.WriteLine ("\tm.uv\t\t= UV0;");

		if (WriteUV2)
			sw.WriteLine ("\tm.uv2\t\t= UV2;");

		if (WriteTangents)
			sw.WriteLine ("\tm.tangents\t= tangents;");

		if (WriteNormals) 
			sw.WriteLine ("\tm.normals\t= normals;");
		else
			sw.WriteLine ("\tm.RecalculateNormals();");

		sw.WriteLine ("\tm.bounds\t= new Bounds ();");
//		sw.WriteLine ("\tm.bounds\t= new Bounds (Vector3.zero, Vector3.one * 2e9f);");	// overide to huge Bounds
		sw.WriteLine ("\tm.hideFlags\t= HideFlags.DontSave;");
		sw.WriteLine ("\treturn m;");
		sw.WriteLine ("}");
		sw.WriteLine ("");
	}
}
