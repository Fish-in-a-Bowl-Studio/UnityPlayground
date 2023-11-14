using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    public int cameraSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector2.up * Time.deltaTime * cameraSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector2.down * Time.deltaTime * cameraSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * Time.deltaTime * cameraSpeed);
        }
        if( Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left * Time.deltaTime * cameraSpeed);
        }
    }
}
