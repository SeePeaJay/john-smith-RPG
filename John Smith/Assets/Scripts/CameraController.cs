using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //0.0.24N1; 0.0.24I1

public class CameraController : MonoBehaviour
{
    private Transform playerTransform; //0.0.20N1; 0.0.20I1, 0.0.20I2
    public Tilemap map; //0.0.24N1

    public Vector3 bottomLeftCoordLimit; //0.0.24N2
    public Vector3 topRightCoordLimit; //0.0.24N2end

    public float halfCameraHeight; //0.0.25N1
    public float halfCameraWidth; //0.0.25N1end

    // Start is called before the first frame update //0.0.20I3
    void Start()
    {
        playerTransform = PlayerController.PCInstance.transform; //0.0.20N2, //0.0.20I4

        halfCameraHeight = Camera.main.orthographicSize; //0.0.25N2
        halfCameraWidth = halfCameraHeight * Camera.main.aspect; //0.0.25N3

        bottomLeftCoordLimit = map.localBounds.min + new Vector3(halfCameraWidth, halfCameraHeight, 0f); //0.0.24N2; 0.0.25N4
        topRightCoordLimit = map.localBounds.max + new Vector3(-halfCameraWidth, -halfCameraHeight, 0f);//0.0.24N2end; 0.0.25N4end

        PlayerController.PCInstance.SetBounds(map.localBounds.min, map.localBounds.max); //0.0.26N3
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z); //0.0.20N3; 0.0.20I2

        //keeps camera inbound
        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, bottomLeftCoordLimit.x, topRightCoordLimit.x), Mathf.Clamp(playerTransform.position.y, bottomLeftCoordLimit.y, topRightCoordLimit.y), transform.position.z); //0.0.24N3
    }
}
