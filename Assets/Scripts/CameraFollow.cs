using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 cameraPosition = player.position;
        transform.position = cameraPosition + new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
