using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public float speedRotation;
    public float xDegrees, yDegrees;

    public Transform canonBody;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        CanonMovement();
    }

    void CanonMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        xDegrees += horizontalInput * speedRotation * Time.deltaTime;
        yDegrees += verticalInput * speedRotation * Time.deltaTime;

        xDegrees = Mathf.Clamp(xDegrees, -40, 40);
        yDegrees = Mathf.Clamp(yDegrees, -35, 8);

        canonBody.eulerAngles = new Vector3(yDegrees, xDegrees, 0);
    }
}
