using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_calc_angle : MonoBehaviour
{
    public AI Mainscript;

    public float calc_angle(GameObject closest_enemy)
    {
        float quarter = 0;
        float angle = 0;

        //pos finding
        float dist_x = transform.position.x - closest_enemy.transform.position.x;
        float dist_z = transform.position.z - closest_enemy.transform.position.z;
        float posi_x = transform.position.x - closest_enemy.transform.position.x;
        float posi_z = transform.position.z - closest_enemy.transform.position.z;

        //quarter finding
        if (posi_x < 0)
            posi_x = posi_x * (-1);
        if (posi_z < 0)
            posi_z = posi_z * (-1);
        float dist = (posi_x + posi_z);

        if (dist_x > 0 && dist_z > 0)
            quarter = 0;
        else if (dist_x > 0 && dist_z < 0)
            quarter = 1;
        else if (dist_x < 0 && dist_z < 0)
            quarter = 2;
        else if (dist_x < 0 && dist_z > 0)
            quarter = 3;
        else
            quarter = -1;

        //angle finding
        if (quarter == 0 || quarter == 2)
            angle = 90 * (posi_x / dist) - Mainscript.angle_offset + (90 * quarter);
        else if (quarter == 1 || quarter == 3)
            angle = 90 * (posi_z / dist) - Mainscript.angle_offset + (90 * quarter);
        return (angle);

    }
}
