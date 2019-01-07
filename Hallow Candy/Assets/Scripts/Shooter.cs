using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    Gun gun;

    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
    }
    public void Fire(float speed)
    {
        var proj = Instantiate(projectile, gun.transform.position, new Quaternion(0f, 0f, -90f, 90f));        
    }
}
