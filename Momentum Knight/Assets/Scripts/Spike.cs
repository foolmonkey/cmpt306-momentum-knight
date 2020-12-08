using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Animator anim;
    private bool activated;
    private float elapsedTime;

    public float activationDuration;
    private float hitTime;
    private bool animating;
    public int HitDamage = 10;
    public PlayerManager playerManager;

    public bool alwaysActivated;

    // Start is called before the first frame update
    void Start()
    {
        if (!alwaysActivated)
        {
            alwaysActivated = false;
        }
        if (activationDuration == 0f)
        {
            activationDuration = 2f;
        }
        animating = false;
        activated = false;
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        hitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alwaysActivated)
        {
            elapsedTime += Time.deltaTime;

            // spike activated
            if (elapsedTime - activationDuration > 1 && !animating)
            {
                anim.Play("SpikeAnim", 0, 1.0f);
                elapsedTime = 0;
                animating = true;
                activated = true;
            }

            if (animating && elapsedTime > 0.3f)
            {
                anim.Play("Full", 0, 1.0f);
                if (elapsedTime > activationDuration)
                {
                    anim.Play("Static", 0, 1.0f);
                    elapsedTime = 0;
                    activated = false;
                    animating = false;
                }
            }
        }
        else
        {
            anim.Play("Full", 0, 1.0f);
            activated = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (hitTime == 0 && other.gameObject.tag == "Player" && activated)
        {
            hitTime += 0.01f;
            playerManager.healthDown(HitDamage);
        }
        else
        {
            hitTime += Time.deltaTime;
            if (hitTime > 0.5f)
            {
                hitTime = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hitTime = 0;
    }
}
