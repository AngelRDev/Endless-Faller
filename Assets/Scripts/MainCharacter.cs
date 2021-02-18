using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameManager GM;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DangerZone"))
        {
            GM.Lose();
        }
        else if(other.CompareTag("AddScore"))
        {
            GM.GetLevelManager().IncrementScore();
        }

    }
}
