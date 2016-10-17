# Unity MeshToText Project

##Features
**Save Mesh to text or CS file, and load the Mesh from file.**

This unity project will write any mesh with unity standard variables format into a plain text or C# file.

Variables array: 
> Vector3[] vertices = { new Vector3(.... };

> Vector3[] normals = { new Vector3(.... };

> Vector4[] tangents = { new Vector4(.... };

> Vector2[] uv0 = { new Vector2(.... };

> Vector2[] uv2 = { new Vector2(.... };

> int[] triangles = { .... };

Check out the unity default cube primitive mesh to a csharp file [here](https://github.com/michael430/Unity_MeshToText/blob/master/Assets/BakedMeshData.cs).
(You can apply any custom mesh to Mesh Filter component to write as a file.)

Include example script to load the mesh from text file back to the scene in runtime.


![Unity MeshToText Screen Shot](./Unity MeshToText Screen Shot.jpg)

## How it works:

- Launch the **MeshToText** scene.

**Write mesh to file:**
- Select the **Mesh Write** game object.
- Click the **Export File** button to write the mesh to a file.

**Read mesh from the file:**
- Click the **PLAY** button. 
  
  You will see the **Mesh Read** game object will generate a mesh from the exported file.
