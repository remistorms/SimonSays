using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTester : MonoBehaviour {

    public void CubeClicked()
    {
        Color random = new Color(Random.value, Random.value, Random.value);
        gameObject.GetComponent<MeshRenderer>().material.color = random;
        gameObject.transform.DOPunchRotation(Vector3.up, 0.5f);
    }
}
