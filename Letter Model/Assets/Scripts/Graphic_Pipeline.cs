using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.AI.Navigation.LowLevel;
using Unity.VisualScripting;
using UnityEngine;

public class Graphic_Pipeline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Model myModel = new Model();
        myModel.CreateUnityGameObject();

        List<Vector4> verts = Homog(myModel.vertices);

        Display(verts);

        //SingleAterMOT


        // First Transformation

        // Rotation by - 25 degrees about (-2,1,1).normalized

        Vector3 axis = (new Vector3(-2, 1, 1)).normalized;

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.AngleAxis(-25, axis),
            Vector3.one);

        Display(rotationMatrix);

        List<Vector4> imageAfterRotation = MatrixTransform(rotationMatrix, verts);

        Display(imageAfterRotation);


        // 2nd Transformation Scale be (4,1,1)

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(
            Vector3.zero, Quaternion.identity,
            new Vector3(4, 1, 1));


        Display(scaleMatrix);

        List<Vector4> imageAftertheScale =
            MatrixTransform(scaleMatrix, imageAfterRotation);

        Display(imageAftertheScale);


        Matrix4x4 traslationMatrix = Matrix4x4.TRS(
            new Vector3(0, -3, 2),
            Quaternion.identity,
            Vector3.one);

        Display(traslationMatrix);

        List<Vector4> imageAfterTranslation = MatrixTransform(traslationMatrix, imageAftertheScale);

        Display(imageAfterTranslation);

        //Single Matix

        Matrix4x4 singleMOT = traslationMatrix * scaleMatrix * rotationMatrix;

        Display(singleMOT);
        List<Vector4> singleAfterMOT = MatrixTransform(singleMOT, verts);

        Display(singleAfterMOT);


        //Test OutCode class
        OutCode o1 = new OutCode(new Vector2(2f, 2f));//1001
        print(o1.ToString());

        OutCode o2 = new OutCode(new Vector2(-2f, -2f));//0110
        print(o2.ToString());


        OutCode o3 = new OutCode(new Vector2(2f, -2f));//0101
        print(o3.ToString());

        OutCode o4 = new OutCode(new Vector2(-2f, 2f));//1010
        print(o4.ToString());

        OutCode o5 = new OutCode(new Vector2(0.2f, 0.2f));//0000
        print(o5.ToString());

        OutCode o6 = new OutCode(new Vector2(-0.2f, -0.2f));//0000
        print(o6.ToString());

        //With different values

        //Test Logical OR
        OutCode o7 = o2 + o3;//0101 + 0110 = 0111 got = 0111
        print(o7.ToString());

        //Test Logical AND
        OutCode o8 = o1 * o2;//1001 * 0110 = 0000 got = 0000
        print(o8.ToString());

        //Test Logical EQUALITY
        bool isEqual = o5 == o6;//0000 == 0000 = true got = true
        print(isEqual);

        //Test Logical NOT
        bool o9 = o1 != o2;//1001 == 0110 = true got = true
        print(o9.ToString());

        //With same values

        //Test Logical OR
        OutCode o10 = o3 + o3;//0101 + 0101 = 0111 got = 0101
        print(o10.ToString());

        //Test Logical AND
        OutCode o11 = o3 * o3;//0101 * 0101 = 0000 got = 0101
        print(o11.ToString());

        //Test Logical EQUALITY
        bool Equal = o3 == o3;//0101 == 0101 = true got = true
        print(Equal);

        //Test Logical NOT
        bool o12 = o3 != o3;//0101 == 0101 = false got = false
        print(o12.ToString());


        //print(LineClipping(ref Vector2 start, ref Vector2 end));

        //Vector2 start = new Vector2(0F, 0F), end = new Vector2(1F, 1F);  // Tested correct
        //Vector2 start = new Vector2(-2.4f, 0F), end = new Vector2(-1.7F, 1F);  // Tested correct

        //Vector2 start = new Vector2(2.4f, 2F), end = new Vector2(-0.9F, -1.5F);// Tested correct


        Vector2 start = new Vector2(2.4f, 2F), end = new Vector2(-0.9F, -14.5F);// Tested correct

        print("Start point " + start.ToString() + " to end point " + end.ToString());

        if (LineClipping(ref start, ref end))
        {

            print("Accepted clipped line is Start point " + start.ToString() + " to end point " + end.ToString());

        }
        else print("Rejected");

    }

    private List<Vector4> Homog(List<Vector3> vertices)
    {
        List<Vector4> result = new List<Vector4>();

        foreach (Vector3 v in vertices)
        { result.Add(new Vector4(v.x, v.y, v.z, 1f)); }

        return result;
    }

    private List<Vector4> MatrixTransform(Matrix4x4 matrix, List<Vector4> verts)
    {
        List<Vector4> hold = new List<Vector4>();
        foreach (Vector4 v in verts)
            hold.Add(matrix * v);

        return hold;
    }

    private void Display(Matrix4x4 matrix)
    {
        for (int i = 0; i < 4; i++)
            print(matrix.GetRow(i));
    }

    void Display(List<Vector4> verts)
    {
        foreach (Vector4 v in verts) { print(v); }
    }


    public bool LineClipping(ref Vector2 start, ref Vector2 end)
    {
        OutCode start_o = new OutCode(start);
        OutCode end_o = new OutCode(end);

        OutCode inScreen_o = new OutCode(new Vector2(0, 0));

        if (start_o + end_o == inScreen_o)
        {
            return true;
        }

        if (start_o * end_o != inScreen_o)
        {
            return false;
        }

        if (start_o == inScreen_o)
        {
            return LineClipping(ref end, ref start);
        }



        //Start must be outside the view port

        if (start_o.up)
        {
            if (end.y == start.y)
                return false;

            float n = (end.x - start.x) / (end.y - start.y);//This is 1/m where m is the slope

            start = new Vector2(start.x + n * (1 - start.y), 1);

            return LineClipping(ref start, ref end);


        }

        if (start_o.down)
        {
            if (end.y == start.y)
                return false;

            float n = (end.x - start.x) / (end.y - start.y);//This is 1/m where m is the slope

            start = new Vector2(start.x + n * (-1 - start.y), -1);

            return LineClipping(ref start, ref end);


        }

        if (start_o.left)
        {
            if (end.x == start.x)
                return false;

            float m = (end.y - start.y) / (end.x - start.x);

            start = new Vector2(-1, start.y + m * (-1 - start.x));

            return LineClipping(ref start, ref end);


        }

        if (start_o.right)
        {
            if (end.x == start.x)
                return false;

            float m = (end.y - start.y) / (end.x - start.x);

            start = new Vector2(1, start.y + m * (1 - start.x));

            return LineClipping(ref start, ref end);


        }

        return false;

    }

    //This is what am working on for rasterization of lines using Bresenham's algorithm
    /*List<Vector2Int> bresh(Vector2Int start, Vector2Int end)
    {
        
        List<Vector2Int> result = new List<Vector2Int>();
        int dx = end.x - start.x; int dy = end.y - start.y;

        if(dx < 0)
        {
            return bresh(end, start);
        }

        if(dy < 0)
        {
            return nvey(bresh(nvey(start), nvey(end)));
        }

        if(dy > dx)
        {
            return SwapXY(bresh(SwapXY(start), SwapXY(end)));
        }





        return result;
    }

    private List<Vector2Int> SwapXY(List<Vector2Int> vector2Ints)
    {
        throw new NotImplementedException();
    }

    private Vector2Int nvey(Vector2Int start)
    {
        throw new NotImplementedException();
    }*/


    //This is a duplicate with previous work
    /*List<Vector2Int> bresh(Vector2Int start, Vector2Int end)
    {
        int x = start.x;
        int y = start.y;

        List<Vector2Int> result = new List<Vector2Int>();
        int dx = end.x - start.x; int dy = end.y - start.y;
        int nve = 2 * (dy - dx);
        int pve = 2 * dy;
        int p0 = 2 * dy - dx;

        for (int i = 0; i <= dx; i++)
        {
            result.Add(new Vector2Int(x, y));

            x++;

            if (p0 < 0)
            {
                p0 += 2 * dy;
            }
            else
            {
                y++;
                p0 += 2 * (dy - dx);
            }
        }


        return result;
    }*/

    // Update is called once per frame
    void Update()
    {

    }


}


