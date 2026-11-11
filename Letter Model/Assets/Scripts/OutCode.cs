using System;
using Unity.VisualScripting;
using UnityEngine;

public class OutCode
{
    //4 bool up, down, left, right

    public bool up;
    public bool down;
    public bool left;
    public bool right;

  public OutCode(Vector2 v)
    {
        up = v.y > 1; 
        down = v.y < -1;
        left = v.x < -1;
        right = v.x > 1;
    }

    public OutCode() // produces the 0000 ie in viewport OutCode
    {
        up =false;
        down =false;
        left =false;
        right =false;
    } 
    public OutCode(OutCode oc) // a copy of given OutCode
    {
        up =oc.up;
        down = oc.down;
        left =oc.left;
        right =oc.right;
    }
  public OutCode(bool up, bool down, bool left, bool right)
    {
        this.up = up;
        this.down = down;
        this.left =left;
        this.right =right;
    }

    //Logical OR
    public static OutCode operator +(OutCode a, OutCode b)
    {
        return new OutCode(a.up || b.up, a.down || b.down, a.left || b.left, a.right || b.right);
    }

    public static OutCode operator *(OutCode a, OutCode b)
    {
        return new OutCode(a.up && b.up, a.down && b.down, a.left && b.left, a.right && b.right);
    }

    public static bool operator ==(OutCode a, OutCode b)
    {
        return (a.up == b.up) && (a.down == b.down) && (a.left == b.left) && (a.right == b.right);
    }

    public static bool operator !=(OutCode a, OutCode b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return (up ? "1" : "0") + (down ? "1" : "0") + (left ? "1" : "0") + (right ? "1" : "0");
    }

    public bool LineClipping(ref Vector2 start, ref Vector2 end)
    {
        OutCode start_o = new OutCode(start);
        OutCode end_o = new OutCode(end);

        OutCode inScreen_o = new OutCode(new Vector2(0, 0));

        if(start_o + end_o == inScreen_o)
        {
            return true;
        }

        if (start_o * end_o != inScreen_o)
        {
            return false;
        }

        if(start_o == inScreen_o)
        {
            return LineClipping(ref end, ref start);
        }

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

        return false;
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
}
