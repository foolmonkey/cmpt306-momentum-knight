using UnityEngine;
using System.Collections;

public class EnemyKnock : MonoBehaviour
{
    public int HitDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        PlayerManager health = hit.GetComponent<PlayerManager>();
        if (health != null)
        {
            health.healthDown(HitDamage);
        }
        Destroy(this.gameObject);
    }
}




