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
