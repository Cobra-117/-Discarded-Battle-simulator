using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Stats Globabl_stats;
    public AI_calc_angle anglescript;
    public AI_movements move_script;
    public AI_Check_Collision collision_script;
    public Obj_values enemy_values;
    public Obj_values local_values;

    public GameObject closest_enemy;
    public GameObject Stat;

    public string local_tag;
    public float angle_offset = 0;
    public bool enemy_col = false;
    public bool projectil_col = false;
    public float t1 = 0;

    public BoxCollider body_collider;
    public BoxCollider Fight_collider;

    // Start is called before the first frame update
    void Start()
    {
        local_tag = this.tag;
        GameObject[] stat_array = GameObject.FindGameObjectsWithTag("Stat");
        foreach (GameObject obj in stat_array)
        {
            Stat = obj;
        }
        Globabl_stats = Stat.GetComponent<Stats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angle;
        Vector3 pos;

        if (Globabl_stats.is_battle_launched == false)
            return;
        if (local_values.cur_health <= 0)
            Destroy(this.gameObject);
        closest_enemy = find_closest_enemy();
        if (closest_enemy == null)
        {
            return;
        }
        pos = closest_enemy.transform.position - transform.position;
        angle = anglescript.calc_angle(closest_enemy);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
        collision_script.check_collisions();
        enemy_values = closest_enemy.GetComponent<Obj_values>();
        if (enemy_col == false && projectil_col == false)
            move_script.movements();
        else
            move_script.attack(enemy_values, local_values);
        
    }

    public GameObject find_closest_enemy()
    {
        GameObject closest = null;
        GameObject[] obj_array = null;
        Vector3 local_pos = transform.position;
        float bs_dist = Mathf.Infinity;
        float cur_dist = 0;

        if (local_tag == "Blue")
            obj_array = GameObject.FindGameObjectsWithTag("Red");
        else if (local_tag == "Red")
            obj_array = GameObject.FindGameObjectsWithTag("Blue");
        foreach (GameObject obj in obj_array)
        {
            cur_dist = calc_dist(obj);
            if (cur_dist < bs_dist)
            {
                bs_dist = cur_dist;
                closest = obj;
            }
        }
            return (closest);
    }

    public float calc_dist(GameObject obj)
    {
        float dist = 0;
        float dist_x = 0;
        float dist_z = 0;

        dist_x = transform.position.x - obj.transform.position.x;
        dist_z = transform.position.z - obj.transform.position.z;
        if (dist_x < 0)
            dist_x = dist_x * (-1);
        if (dist_z < 0)
            dist_z = dist_z * (-1);
        dist = (dist_x + dist_z);
        return (dist);
    }
}
