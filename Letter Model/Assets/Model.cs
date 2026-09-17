using System.Collections.Generic;
using UnityEngine;

public class Model
{
    internal List<Vector3Int> faces;
    List<Vector3Int> texture_index_list;
    internal List<Vector3> vertices;
    List<Vector2> texture_coordinates;
    List<Vector3> normals;



    public Model()
    {
        vertices = new List<Vector3>();
        addvertices();
        faces = new List<Vector3Int>();
        addfaces();

    }

    private void addfaces()
    {
        //Front faces
       faces.Add(new Vector3Int(0, 2, 3)); // 0
       faces.Add(new Vector3Int(0, 3, 1)); // 1
       faces.Add(new Vector3Int(1, 3, 4)); // 2
       faces.Add(new Vector3Int(3, 6, 4)); // 3
       faces.Add(new Vector3Int(4, 6, 7)); // 4
       faces.Add(new Vector3Int(4, 7, 5)); // 5

        //Back Faces
       faces.Add(new Vector3Int(8, 11, 10)); // 6
       faces.Add(new Vector3Int(8, 9, 11)); // 7
        faces.Add(new Vector3Int(9, 12, 11)); // 8
        faces.Add(new Vector3Int(11, 12, 14)); // 9
        faces.Add(new Vector3Int(12, 15, 14)); // 10
        faces.Add(new Vector3Int(12, 13, 15)); // 11

        //Bottom Faces
        faces.Add(new Vector3Int(6, 14, 15));
        faces.Add(new Vector3Int(6, 15, 7));

        //Top Faces
        faces.Add(new Vector3Int(9, 0, 1));
        faces.Add(new Vector3Int(9, 1, 8));

        //Side Back Face
        faces.Add(new Vector3Int());
        faces.Add(new Vector3Int());

        //Side Front Face
        faces.Add(new Vector3Int());
        faces.Add(new Vector3Int());
    }

    private void addvertices()
    {
        vertices.Add(new Vector3(-2, 3, -1)); // 0

        vertices.Add(new Vector3(3, 3, -1)); // 1

        vertices.Add(new Vector3(-3, 2, -1)); // 2

        vertices.Add(new Vector3(1, 2, -1)); // 3

        vertices.Add(new Vector3(-1, -2, -1)); // 4

        vertices.Add(new Vector3(2, -2, -1)); // 5

        vertices.Add(new Vector3(-3, -3, -1)); // 6

        vertices.Add(new Vector3(3, -3, -1)); // 7

        vertices.Add(new Vector3(-2, 3, 1)); // 8

        vertices.Add(new Vector3(3, 3, 1)); // 9

        vertices.Add(new Vector3(-3, 2, 1)); // 10

        vertices.Add(new Vector3(1, 2, 1)); // 11

        vertices.Add(new Vector3(-1, -2,1)); // 12

        vertices.Add(new Vector3(2, -2, 1)); // 13

        vertices.Add(new Vector3(-3, -3, 1)); // 14

        vertices.Add(new Vector3(3, -3, 1)); // 15

       

    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        /*List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();*/

        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); //text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        /*mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();*/
        mesh_filter.mesh = mesh;

        return newGO;
    }
}
