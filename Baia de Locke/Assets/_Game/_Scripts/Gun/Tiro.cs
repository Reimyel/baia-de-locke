using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float damage;
    public NpcStats npcSats;

    private void Start()
    {
        npcSats = FindObjectOfType<NpcStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        npcSats.TakeDamage(damage);
        Destroy(gameObject);
    }

    void Update()
    {
        Object.Destroy(gameObject, 1.5f);
    }
}
