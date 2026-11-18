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
        /*Model myModel = new Model();
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
    }*/

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

        /*//Test Outodes
        OutCode o1 = new OutCode(new Vector2(0, 2));
        OutCode o2 = new OutCode(new Vector2(0, -2));
        OutCode o3 = new OutCode(new Vector2(2, 2));
        OutCode o4 = new OutCode(new Vector2(-2, -2));
        OutCode o5 = new OutCode(new Vector2(2, -2));
        OutCode o6 = new OutCode(new Vector2(-2, 2));

        print(o1.ToString());
        print(o2.ToString());
        print(o3.ToString());
        print(o4.ToString());*/
        /*string test5 = o5.ToString();
        string test6 = o6.ToString();*/



        /*Vector2 p1 = new Vector2(0f, -2f);
        Vector2 p2 = new Vector2(0f, 2f);
        Vector2 p3 = new Vector2(2f, -2f);
        Vector2 p4 = new Vector2(-2f, 2f);
        Vector2 p5 = new Vector2(-2f, -2f);
        Vector2 p6 = new Vector2(2f, 2f);*/

        //print(LineClipping(ref Vector2 start, ref Vector2 end));




        //Vector2 start = new Vector2(0F, 0F), end = new Vector2(1F, 1F);  // Tested correct
        // Vector2 start = new Vector2(-2.4f, 0F), end = new Vector2(-1.7F, 1F);  // Tested correct

        //   Vector2 start = new Vector2(2.4f, 2F), end = new Vector2(-0.9F, -1.5F);


        Vector2 start = new Vector2(2.4f, 2F), end = new Vector2(-0.9F, -14.5F);
        print("Start point " + start.ToString() + " to end point " + end.ToString());

        if (LineClipping(ref start, ref end))
        {

            print("Accepted clipped line is Start point " + start.ToString() + " to end point " + end.ToString());

        }
        else print("Rejected");

    }

    // Update is called once per frame
    void Update()
    {

    }



    //private Vector2 Intersect(ref Vector2 start, ref Vector2 end)
    //{
    //    //throw new NotImplementedException();

    //    OutCode O_Start = new OutCode(start);
    //    OutCode O_End = new OutCode(end);

    //    if (start.x == end.x)
    //    {
    //        if (O_Start.ToString() == "1000")
    //        {
    //            return new Vector2(start.x, 1);
    //        }

    //        else if (O_End.ToString() == "1000")
    //        {
    //            return new Vector2(start.x, 1);
    //        }

    //        if (O_Start.ToString() == "0100")
    //        {
    //            return new Vector2(start.x, -1);
    //        }

    //        else if (O_End.ToString() == "0100")
    //        {
    //            return new Vector2(start.x, -1);
    //        }
    //    }

    //    if (start.y == end.y)
    //    {
    //        if (O_Start.ToString() == "0010")
    //        {
    //            return new Vector2(-1, start.y);
    //        }

    //        else if (O_End.ToString() == "0010")
    //        {
    //            return new Vector2(-1, start.y);
    //        }

    //        if (O_Start.ToString() == "0001")
    //        {
    //            return new Vector2(1, start.y);
    //        }

    //        else if (O_End.ToString() == "0001")
    //        {
    //            return new Vector2(1, start.y);
    //        }
    //    }
    //    return new Vector2(float.NaN, float.NaN);
    //}

    private Vector2 Intersect(Vector2 start, Vector2 end, int v)
    {
        throw new NotImplementedException();

        /*// int edge 0 = up, 1 = down, 2 = left, 3 = right

        // Check for vertical line
        if (end.x == start.x)
        {
            return edge switch
            {
                0 => new Vector2(start.x, 1), // Up edge
                1 => new Vector2(start.x, -1), // Down edge
                2 => new Vector2(-1, start.y), // Left edge
                3 => new Vector2(1, start.y),  // Right edge
                _ => new Vector2(float.NaN, float.NaN) // No intersection with up or down edges
            };
        }

        // Check for horizontal line
        if (end.y == start.y)
        {
            return edge switch
            {
                0 => new Vector2(float.NaN, float.NaN), // Up edge (no valid x)
                1 => new Vector2(float.NaN, float.NaN), // Down edge (no valid x)
                _ => new Vector2(float.NaN, float.NaN) // No intersection with left or right edges
            };
        }

        // Regular case: calculate slope and intercept
        float m = (end.y - start.y) / (end.x - start.x);

        // y = mx+c  or  x = y-c/m
        float c = start.y - m * start.x;

        switch (edge)
        {
            case 0: // up
                return new Vector2((1 - c) / m, 1); // y = 1
            case 1: // down
                return new Vector2((-1 - c) / m, -1); // y = -1
            case 2: // left
                return new Vector2(-1, c - m); // left x = -1
            case 3: // right
                return new Vector2(1, m + c); // right x = 1
            default:
                return new Vector2(float.NaN, float.NaN); // Invalid edge
        }*/
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

            float n =(end.x - start.x) / (end.y - start.y);//This is 1/m where m is the slope

            start = new Vector2(start.x + n*(1 - start.y), 1);

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

            start = new Vector2(-1,start.y + m * (-1 - start.x));

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

        //Vector2 intersection = Intersect(ref start, ref end);

        //if (float.IsNaN(intersection.x) || float.IsNaN(intersection.y))
        //{
        //    if (start_o.up)
        //    {
        //        start = Intersect(start, end, 0);
        //        return LineClipping(ref start, ref end);

        //    }

        //    if (start_o.down)
        //    {
        //        start = Intersect(start, end, 1);
        //        return LineClipping(ref start, ref end);

        //    }

        //    if (start_o.left)
        //    {
        //        start = Intersect(start, end, 2);
        //        return LineClipping(ref start, ref end);

        //    }

        //    if (start_o.right)
        //    {
        //        start = Intersect(start, end, 3);
        //        return LineClipping(ref start, ref end);

        //    }
    }

    List<Vector2Int> bresh(Vector2Int start, Vector2Int end)
    {
        int x = start.x;
        int y = start.y;

        List<Vector2Int> result = new List<Vector2Int>();
        int dx = end.x - start.x; int dy = end.y - start.y;
        int nve = 2*(dy -dx);
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
    }

    
    }


