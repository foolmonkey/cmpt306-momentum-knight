using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Animator anim;
    private bool activated;
    private float elapsedTime;
    private bool animating;
    public int HitDamage = 10;
    public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        animating = false;
        activated = false;
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // spike activated
        if (elapsedTime - 2 > 1 && !animating)
        {
            anim.Play("SpikeAnim", 0, 1.0f);
            elapsedTime = 0;
            animating = true;
            activated = true;
        }

        if (animating && elapsedTime > 0.3f)
        {
            anim.Play("Full", 0, 1.0f);
            if (elapsedTime > 2f)
            {
                anim.Play("Static", 0, 1.0f);
                elapsedTime = 0;
                activated = false;
                animating = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag == "Player" && activated)
        {
            Debug.Log("hit");
            playerManager.healthDown(HitDamage);
        }

    }
}
