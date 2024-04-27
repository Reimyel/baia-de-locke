using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    // Spawn dos tiros
    public GameObject bulletPrefab;
    public Transform pontoDeTiro;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject tiro = Instantiate(bulletPrefab, pontoDeTiro.position, pontoDeTiro.rotation);
        tiro.GetComponent<Rigidbody2D>().AddForce(pontoDeTiro.up * fireForce, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
