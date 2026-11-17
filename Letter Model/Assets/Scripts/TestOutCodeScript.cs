using UnityEngine;

public class TestOutCodeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OutCode o1 = new OutCode(new Vector2(2f,2f));//1001
        print(o1.ToString());

        OutCode o2 = new OutCode(new Vector2(-2f,-2f));//0110
        print(o2.ToString());


        OutCode o3 = new OutCode(new Vector2(2f,-2f));//0101
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
