using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitter : MonoBehaviour {

    public GameObject[] waves;
    private int currentWave;
    private manager manager;

	// Use this for initialization
	IEnumerator Start () {

        if (waves.Length == 0) yield break;

        manager = FindObjectOfType<manager>();

        while (true)
        {

            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, transform.rotation);
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            Destroy(wave);
            currentWave++;
            while (waves.Length <= currentWave)
            {
                currentWave = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
