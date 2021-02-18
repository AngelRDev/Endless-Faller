using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private InitialSpeed speed;
    private float lowestPositionY = -11.85f; // handpicked value from scene.
    private float startPosY;

    private float timeCounter = 0f;
    private float increment = 0.005f;

    void Start()
    {
        // randomize the start position and save its initial Y value for reseting the levels later.
        float randX = Random.Range(-6f, 0.5f); // handpicked values from the limits of the level
        startPosY = transform.position.y;
        transform.position = new Vector3(randX, startPosY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (speed.value + (increment* timeCounter)) * Time.deltaTime;
        timeCounter += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TopLimit"))
        {
            float randX = Random.Range(-6f, 1f);
            transform.position = new Vector3(randX, lowestPositionY, 0f);
        }
    }

    public void Init()
    {
        float randX = Random.Range(-6f, 0.5f);
        transform.position = new Vector3(randX, startPosY, 0f);
        timeCounter = 0f;
    }
}