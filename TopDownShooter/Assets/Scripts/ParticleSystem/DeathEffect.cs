using System;
using System.Collections;
using System.Collections.Generic;
using EnemyCore.EnemyHealth;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private GameObject blow;
    [SerializeField] private EnemyHealthController healthController;

    private void OnEnable()
    {
        healthController.Explosion += Explosion;
    }

    private void OnDisable()
    {
        healthController.Explosion -= Explosion;
    }

    void Explosion(Transform enemy)
    {
        GameObject exp = Instantiate(blow, enemy.position, enemy.rotation);
        Destroy(exp, 0.75f);
    }
}
