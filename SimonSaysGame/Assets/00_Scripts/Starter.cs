using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Starter : MonoBehaviour {

    public GameObject firstParticle;
    public GameObject treeParticles;
    public Transform[] treeParticlesPosition;

    public void StageSpawned() {
        StartCoroutine(StageSpawnedRoutine());
       // gameObject.GetComponent<Stage>().SendCharacterAnimators();
    }

    IEnumerator StageSpawnedRoutine() {
        InitialSetup();
        yield return null;
        for (int i = 0; i < 3; i++)
        {
            GameObject particle = Instantiate(firstParticle, transform.position, Quaternion.identity) as GameObject;
            particle.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        transform.DOScale(1, 1);
    }

    void InitialSetup() {
        transform.localScale = Vector3.zero;
        firstParticle.SetActive(false);
        SpawnTreeParticles();
    }

    void SpawnTreeParticles() {
        for (int i = 0; i < treeParticlesPosition.Length; i++)
        {
            GameObject leaves = Instantiate(treeParticles, treeParticlesPosition[i].transform.position, Quaternion.identity) as GameObject;
            leaves.transform.SetParent(treeParticlesPosition[i].transform);
            leaves.transform.localPosition = Vector3.zero;
            leaves.SetActive(false);
        }
    }
}
