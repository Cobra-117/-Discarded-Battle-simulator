using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Check_Collision : MonoBehaviour
{
    public AI mother_script;

    public void check_collisions()
    {
        if (mother_script.calc_dist(mother_script.closest_enemy) < 2)
            mother_script.enemy_col = true;
        else
            mother_script.enemy_col = false;

    }
}
