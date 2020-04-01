using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPos : MonoBehaviour
{
    // Start is called before the first frame update
    public static int zAxisPos = 0; //Static because other scripts may need to get this.
    private float yAxisPos = 0f;
    public float xAxisBoundry = 7.5f;
    public float speed = 10f;

    void Update()
    {

        Vector3 mouse = new Vector3(Input.mousePosition.x, 0.0f, zAxisPos + Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        this.transform.position = new Vector3(mouse.x, yAxisPos, zAxisPos);
    }
}
    
