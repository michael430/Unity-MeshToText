using UnityEngine;

public class BakedMeshData {

public Mesh GenerateMeshFromFile () {
	Mesh m		= new Mesh();
	m.name		= "Generated BakedMesh";
	m.vertices	= vertices;
	m.triangles	= triangles;
	m.uv		= UV0;
	m.uv2		= UV2;
	m.tangents	= tangents;
	m.normals	= normals;
	m.bounds	= new Bounds ();
	m.hideFlags	= HideFlags.DontSave;
	return m;
}

// Mesh Vertices #24
Vector3[] vertices = {
	new Vector3(0.5f,-0.5f,0.5f),
	new Vector3(-0.5f,-0.5f,0.5f),
	new Vector3(0.5f,0.5f,0.5f),
	new Vector3(-0.5f,0.5f,0.5f),
	new Vector3(0.5f,0.5f,-0.5f),
	new Vector3(-0.5f,0.5f,-0.5f),
	new Vector3(0.5f,-0.5f,-0.5f),
	new Vector3(-0.5f,-0.5f,-0.5f),
	new Vector3(0.5f,0.5f,0.5f),
	new Vector3(-0.5f,0.5f,0.5f),
	new Vector3(0.5f,0.5f,-0.5f),
	new Vector3(-0.5f,0.5f,-0.5f),
	new Vector3(0.5f,-0.5f,-0.5f),
	new Vector3(-0.5f,-0.5f,0.5f),
	new Vector3(-0.5f,-0.5f,-0.5f),
	new Vector3(0.5f,-0.5f,0.5f),
	new Vector3(-0.5f,-0.5f,0.5f),
	new Vector3(-0.5f,0.5f,-0.5f),
	new Vector3(-0.5f,-0.5f,-0.5f),
	new Vector3(-0.5f,0.5f,0.5f),
	new Vector3(0.5f,-0.5f,-0.5f),
	new Vector3(0.5f,0.5f,0.5f),
	new Vector3(0.5f,-0.5f,0.5f),
	new Vector3(0.5f,0.5f,-0.5f)
};

// UV0 #24
Vector2[] UV0 = {
	new Vector2(0f,0f),
	new Vector2(1f,0f),
	new Vector2(0f,1f),
	new Vector2(1f,1f),
	new Vector2(0f,1f),
	new Vector2(1f,1f),
	new Vector2(0f,1f),
	new Vector2(1f,1f),
	new Vector2(0f,0f),
	new Vector2(1f,0f),
	new Vector2(0f,0f),
	new Vector2(1f,0f),
	new Vector2(0f,0f),
	new Vector2(1f,1f),
	new Vector2(1f,0f),
	new Vector2(0f,1f),
	new Vector2(0f,0f),
	new Vector2(1f,1f),
	new Vector2(1f,0f),
	new Vector2(0f,1f),
	new Vector2(0f,0f),
	new Vector2(1f,1f),
	new Vector2(1f,0f),
	new Vector2(0f,1f)
};

// UV2 #24
Vector2[] UV2 = {
	new Vector2(0.6909865f,0.3471644f),
	new Vector2(0.9966581f,0.3471644f),
	new Vector2(0.6909865f,0.6528358f),
	new Vector2(0.9966581f,0.6528358f),
	new Vector2(0.3097273f,0.3471642f),
	new Vector2(0.004055766f,0.3471642f),
	new Vector2(0.3471642f,0.6528358f),
	new Vector2(0.6528358f,0.6528358f),
	new Vector2(0.3097273f,0.6528358f),
	new Vector2(0.004055766f,0.6528358f),
	new Vector2(0.3471642f,0.3471642f),
	new Vector2(0.6528358f,0.3471642f),
	new Vector2(0.3471642f,0.004055766f),
	new Vector2(0.6528358f,0.3097273f),
	new Vector2(0.6528358f,0.004055766f),
	new Vector2(0.3471642f,0.3097273f),
	new Vector2(0.6902728f,0.3097273f),
	new Vector2(0.9959443f,0.004055766f),
	new Vector2(0.6902728f,0.004055766f),
	new Vector2(0.9959443f,0.3097273f),
	new Vector2(0.3097273f,0.004055766f),
	new Vector2(0.004055766f,0.3097273f),
	new Vector2(0.3097273f,0.3097273f),
	new Vector2(0.004055766f,0.004055766f)
};

// Triangles #36
int[] triangles = {
	0,3,1,
	0,2,3,
	8,5,9,
	8,4,5,
	10,7,11,
	10,6,7,
	12,13,14,
	12,15,13,
	16,17,18,
	16,19,17,
	20,21,22,
	20,23,21
};

// Normals #24
Vector3[] normals = {
	new Vector3(0f,0f,1f),
	new Vector3(0f,0f,1f),
	new Vector3(0f,0f,1f),
	new Vector3(0f,0f,1f),
	new Vector3(0f,1f,0f),
	new Vector3(0f,1f,0f),
	new Vector3(0f,0f,-1f),
	new Vector3(0f,0f,-1f),
	new Vector3(0f,1f,0f),
	new Vector3(0f,1f,0f),
	new Vector3(0f,0f,-1f),
	new Vector3(0f,0f,-1f),
	new Vector3(0f,-1f,0f),
	new Vector3(0f,-1f,0f),
	new Vector3(0f,-1f,0f),
	new Vector3(0f,-1f,0f),
	new Vector3(-1f,0f,0f),
	new Vector3(-1f,0f,0f),
	new Vector3(-1f,0f,0f),
	new Vector3(-1f,0f,0f),
	new Vector3(1f,0f,0f),
	new Vector3(1f,0f,0f),
	new Vector3(1f,0f,0f),
	new Vector3(1f,0f,0f)
};

// Tangents #24
Vector4[] tangents = {
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(-1f,0f,0f,-1),
	new Vector4(0f,0f,-1f,-1),
	new Vector4(0f,0f,-1f,-1),
	new Vector4(0f,0f,-1f,-1),
	new Vector4(0f,0f,-1f,-1),
	new Vector4(0f,0f,1f,-1),
	new Vector4(0f,0f,1f,-1),
	new Vector4(0f,0f,1f,-1),
	new Vector4(0f,0f,1f,-1)
};
}
