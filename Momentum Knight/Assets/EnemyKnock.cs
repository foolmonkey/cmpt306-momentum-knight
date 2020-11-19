using UnityEngine;
using System.Collections;

public class EnemyKnock : MonoBehaviour
{
    public int HitDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        PlayerManager healthDown = hit.GetComponent<PlayerManager>();
        if (healthDown != null)
        {
            healthDown.healthDown(HitDamage);
        }
        Destroy(this.gameObject);
    }
}




