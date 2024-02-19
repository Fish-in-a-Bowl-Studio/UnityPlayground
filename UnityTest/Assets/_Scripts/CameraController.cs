using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    public float cameraSpeed = 10f;
    public float scrollSpeed = 10f;
    public Camera camera;

    private Vector3 cameraPanStartPos;
    [SerializeField]
    private Vector3 difference;

    private bool drag = false;


    // Start is called before the first frame update
    void Start()
    {
    }
    void handleZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize += (3f * Time.deltaTime) * scrollSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camera.orthographicSize -= (3f * Time.deltaTime) * scrollSpeed;

        }
    }
    // Update is called once per frame
    void Update()
    {
        handleZoom();
        if (Input.GetMouseButton(0) )
        {
            if (!drag)
            {
                cameraPanStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                drag = true;
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            difference = cameraPanStartPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.Translate(difference);
        }

        
    }
}
