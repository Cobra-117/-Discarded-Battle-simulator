using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime_player : MonoBehaviour
{
    public Animation anim;
    public bool demo_walk;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (demo_walk == true)
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        if (anim.isPlaying)
        {
            Debug.Log("IS PLAYING");
            return;
        }
        //this.gameObject.transform.position = new Vector3(transform.position.x, -1.22f, transform.position.z);
        anim.Play("Armature|Walk03");

    }
}
