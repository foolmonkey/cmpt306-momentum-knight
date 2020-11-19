using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationController : MonoBehaviour
{
    public Animator anim;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerManager.currentMana > 20)
        {
            playerManager.manaDown(20);
            anim.Play("Swing", -1, 0f);
        }
    }
}
