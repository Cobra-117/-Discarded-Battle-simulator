using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_movements : MonoBehaviour
{
    public AI mother_script;
    public Anime_player anim_script;
    public float Speed;
    public Rigidbody rb;
    public float t0;

    public void movements()
    {
        transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
    }

    public void attack(Obj_values enemy_values, Obj_values local_values)
    {
        t0 = Time.time;
        if (t0 >= mother_script.t1 + 0.5)
        {
            anim_script.anim.Play("Armature|Hit");
            mother_script.t1 = t0;
            enemy_values.cur_health -= local_values.attack;
            Debug.Log(this.tag);
        }
    }
}
