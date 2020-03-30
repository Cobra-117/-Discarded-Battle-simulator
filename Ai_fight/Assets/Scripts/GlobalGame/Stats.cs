using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public bool is_battle_launched = false;
    public bool has_game_ended = false;
    public KeyCode LaucheGameKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(LaucheGameKey))
        {
            is_battle_launched = true;
        }
        has_game_ended = Has_game_ended();
    }

    bool Has_game_ended()
    {
        int count = 0;
        GameObject[] go_array;

        go_array = GameObject.FindGameObjectsWithTag("Red");
        foreach (GameObject obj in go_array)
            count++;
        if (count == 0)
            return (true);
        go_array = GameObject.FindGameObjectsWithTag("Blue");
        foreach (GameObject obj in go_array)
            count++;
        if (count == 0)
            return (true);
        return (false);
    }
}
