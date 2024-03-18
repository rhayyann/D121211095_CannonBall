using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    private CannonAmmo cannonAmmo;
    public GameObject cannonBallPrefab;
    public Transform cannonShotPoint, cannonBody;
    public float shootForce;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private void Awake()
    {
        cannonAmmo = GetComponent<CannonAmmo>();
    }

    void Shoot()
    {
        if (cannonAmmo.CurrentAmmo <= 0) return;
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonShotPoint.position, cannonShotPoint.rotation);
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);
        cannonAmmo.CurrentAmmo--;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }
}
