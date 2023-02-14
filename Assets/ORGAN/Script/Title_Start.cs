using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Start : MonoBehaviour
{

    public GameObject Interface_start;
    public GameObject Interface_menu;
    public AudioSource source;
    public AudioClip SoundEffect;
    // Update is called once per frame
    void Update()
    {
        if (Interface_start.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                source.PlayOneShot(SoundEffect);
                Interface_start.SetActive(false);
                
                if (!Interface_menu.activeSelf)
                {
                    Interface_menu.SetActive(true);

                }

            }
        }
    }


}
