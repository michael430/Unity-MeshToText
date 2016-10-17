## Unity MeshToText Project

### Features
This unity will write any static or procedural generated mesh with unity standard variables format into a text or C# file.
Variables array: 
* Vector3[] vertices = { new Vector3(.... };
* Vector3[] normals = { new Vector3(.... };
* Vector4[] tangents = { new Vector4(.... };
* Vector2[] uv0 = { new Vector2(.... };
* Vector2[] uv2 = { new Vector2(.... };
* int[] triangles = { .... };
* .......

Include example script to load the mesh from text file back to the scene.


![Unity MeshToText Screen Shot](./Unity MeshToText Screen Shot.jpg)

### How it works:

- Launch the scene.

Write mesh to file:
- Select the **Mesh Write** game object.
- Click the **Export File** button to write the mesh to a file.

Read mesh from the file
- Click the **PLAY** button. You will see the **Mesh Read** game object will generate a mesh from the exported file.
