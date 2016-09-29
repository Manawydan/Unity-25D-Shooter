using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    // Camera Refrence
    private Transform playerTarget;

    // Camera Atributes
    public float cameraSmoothAmount;

    // Relative Position
    private Vector3 offset;

    void Awake()
    {
        // Setup References
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        // Calculate the offset between player and camera
        offset = transform.position - playerTarget.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = playerTarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, cameraSmoothAmount * Time.deltaTime);
    }
}
