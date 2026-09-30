using System;
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

        texture_coordinates = new List<Vector2>();
        addTextureVertices();

        texture_coordinates = convertToUV(1024);

    }

    private List<Vector2> convertToUV(float s)
    {
        List<Vector2> hold = new List<Vector2>();
        foreach(Vector2 v in texture_coordinates) { hold.Add(new Vector2(v.x / s, 1 - v.y / s)); }
        return hold;
    }

    private void addTextureVertices()
    {
        texture_coordinates.Add(new Vector2(98, 106));//0
        texture_coordinates.Add(new Vector2(349, 106));//1
        texture_coordinates.Add(new Vector2(554, 105));//2
        texture_coordinates.Add(new Vector2(804, 105));//3
        texture_coordinates.Add(new Vector2(207, 166));//4
        texture_coordinates.Add(new Vector2(297, 166));//5
        texture_coordinates.Add(new Vector2(507, 163));//6
        texture_coordinates.Add(new Vector2(699, 163));//7
        texture_coordinates.Add(new Vector2(150, 318));//8
        texture_coordinates.Add(new Vector2(294, 318));//9
        texture_coordinates.Add(new Vector2(608, 318));//10
        texture_coordinates.Add(new Vector2(754, 318));//11
        texture_coordinates.Add(new Vector2(100, 375));//12
        texture_coordinates.Add(new Vector2(396, 375));//13
        texture_coordinates.Add(new Vector2(507, 375));//14
        texture_coordinates.Add(new Vector2(804, 375));//15
        texture_coordinates.Add(new Vector2(116, 472));//16
        texture_coordinates.Add(new Vector2(413, 472));//17
        texture_coordinates.Add(new Vector2(117, 530));//18
        texture_coordinates.Add(new Vector2(413, 530));//19
        texture_coordinates.Add(new Vector2(101, 553));//20
        texture_coordinates.Add(new Vector2(412, 553));//21
        texture_coordinates.Add(new Vector2(101, 618));//22
        texture_coordinates.Add(new Vector2(412, 618));//23
        texture_coordinates.Add(new Vector2(272, 635));//24
        texture_coordinates.Add(new Vector2(409, 635));//25
        texture_coordinates.Add(new Vector2(272, 679));//26
        texture_coordinates.Add(new Vector2(409, 679));//27
    }

    private void addfaces()
    {
        //Front faces
       faces.Add(new Vector3Int(0, 2, 3)); texture_index_list.Add(new Vector3Int(2, 6, 7));// 0
       faces.Add(new Vector3Int(0, 3, 1)); texture_index_list.Add(new Vector3Int(2, 7, 3));// 1
       faces.Add(new Vector3Int(1, 3, 4));  texture_index_list.Add(new Vector3Int(3, 7, 10));// 2
       faces.Add(new Vector3Int(3, 6, 4)); texture_index_list.Add(new Vector3Int(7, 14, 10));// 3
        faces.Add(new Vector3Int(4, 6, 7)); texture_index_list.Add(new Vector3Int(10, 14, 15));// 4
        faces.Add(new Vector3Int(4, 7, 5)); texture_index_list.Add(new Vector3Int(10, 15, 11));// 5

        //Back Faces
        faces.Add(new Vector3Int(8, 11, 10)); texture_index_list.Add(new Vector3Int(1, 4, 5));// 6
        faces.Add(new Vector3Int(8, 9, 11)); texture_index_list.Add(new Vector3Int(1, 0, 4));// 7
        faces.Add(new Vector3Int(9, 12, 11)); texture_index_list.Add(new Vector3Int(0, 9, 4));// 8
        faces.Add(new Vector3Int(11, 12, 14)); texture_index_list.Add(new Vector3Int(4, 9, 13)); // 9
        faces.Add(new Vector3Int(12, 15, 14)); texture_index_list.Add(new Vector3Int(9, 12, 13));// 10
        faces.Add(new Vector3Int(12, 13, 15)); texture_index_list.Add(new Vector3Int(9, 8, 12));// 11

        //Bottom Faces
        faces.Add(new Vector3Int(6, 14, 15)); texture_index_list.Add(new Vector3Int());// 12
        faces.Add(new Vector3Int(6, 15, 7)); texture_index_list.Add(new Vector3Int());// 13

        //Top Faces
        faces.Add(new Vector3Int(0, 1, 8)); texture_index_list.Add(new Vector3Int()); // 14
        faces.Add(new Vector3Int(8, 1, 9)); texture_index_list.Add(new Vector3Int());// 15

        //Side Back Face
        faces.Add(new Vector3Int(1, 4, 12)); texture_index_list.Add(new Vector3Int());//16
        faces.Add(new Vector3Int(1, 12, 9)); texture_index_list.Add(new Vector3Int());//17

        //Side Front Face
        faces.Add(new Vector3Int(11, 14, 6)); texture_index_list.Add(new Vector3Int());//18
        faces.Add(new Vector3Int(11, 6, 3)); texture_index_list.Add(new Vector3Int());//19

        //Bottom cover Face
        faces.Add(new Vector3Int(2, 10, 11)); texture_index_list.Add(new Vector3Int());//20
        faces.Add(new Vector3Int(2, 11, 3)); texture_index_list.Add(new Vector3Int());//21

        //Top cover Face
        faces.Add(new Vector3Int(12, 4, 5)); texture_index_list.Add(new Vector3Int());//22
        faces.Add(new Vector3Int(12, 5, 13)); texture_index_list.Add(new Vector3Int());//23

        //Top Front Face
        faces.Add(new Vector3Int(8, 10, 2)); texture_index_list.Add(new Vector3Int());//24
        faces.Add(new Vector3Int(8, 2, 0)); texture_index_list.Add(new Vector3Int());//25

        //Bottom Front Face
        faces.Add(new Vector3Int(5, 7, 15)); texture_index_list.Add(new Vector3Int());//26
        faces.Add(new Vector3Int(5, 15, 13)); texture_index_list.Add(new Vector3Int());//27
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
