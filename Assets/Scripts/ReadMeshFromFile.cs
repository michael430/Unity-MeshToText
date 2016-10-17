using UnityEngine;

public class ReadMeshFromFile : MonoBehaviour 
{
	public Mesh GeneratedMesh = null;

	void Start () {

		// Make sure use the same class name (file name) here!
		BakedMeshData readMesh = new BakedMeshData ();
		GeneratedMesh = readMesh.GenerateMeshFromFile ();

		// apply
		MeshFilter mf = GetComponent<MeshFilter> ();
		if (mf)
			mf.mesh = GeneratedMesh;
	}


}
