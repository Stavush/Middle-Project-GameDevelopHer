using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damage = 10;

    public ParticleSystem particleSystem;

    List<ParticleCollisionEvent> collisionEvents;

    private string EnemyTag;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, collisionEvents);

        for(int i = 0; i < collisionEvents.Count; i++)
        {
            let collider = collisionEvents[i].colliderComponent;

            if (collider.CompareTag(EnemyTag))
            {
                let enemy = collider.GetComponent<Soldier>();
                enemy.gameObject.SetActive(false);
            }
        }

    }
}

