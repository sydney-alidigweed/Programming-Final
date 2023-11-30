using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] GameObject diamond;

    private Vector3 _moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ControlManager.init(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * _moveDir);
    }
    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Destroy(diamond);
        }
    }
}
