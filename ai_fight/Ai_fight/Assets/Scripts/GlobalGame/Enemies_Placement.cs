using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Placement : MonoBehaviour
{
    public GameObject blue_fighter;
    public GameObject red_fighter;
    public GameObject new_obj;
    public float middle_pos;
    public Stats stats;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.is_battle_launched == true)
            return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point.x < middle_pos)
                {
                    new_obj = Instantiate(blue_fighter, transform.position, Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    new_obj = Instantiate(red_fighter, transform.position, Quaternion.Euler(0, 270, 0));
                }
                new_obj.transform.position = new Vector3(hit.point.x, 1.854f, hit.point.z);
            }
        }
    }
}
