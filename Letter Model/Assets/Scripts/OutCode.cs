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

    /*public static OutCode operator ==(OutCode a, OutCode b)
    {
        return new OutCode(a.up || b.up, a.down || b.down, a.left || b.left, a.right || b.right);
    }

    public static OutCode operator !=(OutCode a, OutCode b)
    {
        return !(a == b);
    }*/

    public override string ToString()
    {
        return base.ToString();
    }
  
  

}
