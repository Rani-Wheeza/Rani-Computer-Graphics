using UnityEngine;

public class TestOutCodeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OutCode o = new OutCode(new Vector2(2,2));
        print(o.ToString());

        OutCode o2 = new OutCode(new Vector2(-2,-2));
        print(o2.ToString());


        OutCode o3 = new OutCode(new Vector2(2,-2));
        print(o3.ToString());

        OutCode o4 = new OutCode(new Vector2(-2, 2));
        print(o4.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
