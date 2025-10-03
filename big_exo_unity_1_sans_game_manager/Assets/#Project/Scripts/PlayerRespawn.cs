using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class PlayerRespawn : MonoBehaviour
{
    private Collider collider;
    private Vector3 startPosition;

    void Awake()
    {
        collider = GetComponent<Collider>();
    }
    void Start()
    {
        startPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }
}
