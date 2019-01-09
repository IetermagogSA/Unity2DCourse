using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderResource : MonoBehaviour
{
    [SerializeField] GameObject currencyCandy;
    
    public void CreateCandy()
    {
        Instantiate(currencyCandy, transform.position, Quaternion.identity);
    }
}
