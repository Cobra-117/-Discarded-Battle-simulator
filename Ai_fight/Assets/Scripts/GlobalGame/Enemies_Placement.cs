using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Placement : MonoBehaviour
{
    public GameObject fighter;
    public GameObject new_obj;
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
            new_obj = Instantiate(fighter, transform.position, transform.rotation);
            if (Physics.Raycast(ray, out hit))
            {
                new_obj.transform.position = new Vector3(hit.point.x, 1.01f, hit.point.z);
            }
        }
    }
}
