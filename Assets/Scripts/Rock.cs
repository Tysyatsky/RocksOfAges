using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    GameObject[] rocks;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 0.5f;
        const float MaxImpulseForce = 1f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rocks = GameObject.FindGameObjectsWithTag("Rock");
        if(rocks.Length > 10) Destroy(rocks[0]);
    }
}
