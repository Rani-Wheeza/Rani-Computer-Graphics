using System;
using UnityEngine;

public class TestOutCodeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    }



        private Vector2 Intersect(ref Vector2 start, ref Vector2 end)
        {
        //throw new NotImplementedException();

        OutCode O_Start = new OutCode(start);
        OutCode O_End = new OutCode(end);

        if (start.x == end.x)
        {
            if (O_Start.ToString() == "1000")
            {
                return new Vector2(start.x, 1);
            }

            else if (O_End.ToString() == "1000")
            {
                return new Vector2(start.x, 1);
            }

            if (O_Start.ToString() == "0100")
            {
                return new Vector2(start.x, -1);
            }

            else if (O_End.ToString() == "0100")
            {
                return new Vector2(start.x, -1);
            }
        }

        if (start.y == end.y)
        {
            if (O_Start.ToString() == "0010")
            {
                return new Vector2(-1, start.y);
            }

            else if (O_End.ToString() == "0010")
            {
                return new Vector2(-1, start.y);
            }

            if (O_Start.ToString() == "0001")
            {
                return new Vector2(1, start.y);
            }

            else if (O_End.ToString() == "0001")
            {
                return new Vector2(1, start.y);
            }
        }
        return new Vector2(float.NaN, float.NaN);
    }

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

        Vector2 intersection = Intersect(ref start, ref end);

        if (float.IsNaN(intersection.x) || float.IsNaN(intersection.y))
        {
            if (start_o.up)
            {
                start = Intersect(start, end, 0);
                return LineClipping(ref start, ref end);

            }

            if (start_o.down)
            {
                start = Intersect(start, end, 1);
                return LineClipping(ref start, ref end);

            }

            if (start_o.left)
            {
                start = Intersect(start, end, 2);
                return LineClipping(ref start, ref end);

            }

            if (start_o.right)
            {
                start = Intersect(start, end, 3);
                return LineClipping(ref start, ref end);

            }
        }



        return false;



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
