
using System.Collections.Generic;
using UnityEngine;

public class gunShot : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public Transform fpsCam;
    private AudioSource source;
    public ParticleSystem gunFlare;//particulas
    public List<AudioClip> audios; 
    public float shotvolume = 0.2f;
    public float enemyHitVolume = 0.7f;
    public float materialHitVolume = 0.6f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Fire1")) {
            Shot();
             
        }
		
	}

    void Shot() {
        source.Play();
        //gunFlare.Play();
        source.volume =shotvolume;
        
        source.PlayOneShot(audios[0]);


        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.tag);
            enemyHealth target = hit.transform.GetComponent<enemyHealth>();
            if (target)
            {
                source.volume = enemyHitVolume;
                source.PlayOneShot(audios[1]);
                target.TakeDamage(damage);

            }

            else if (hit.transform.tag == "materialVidrio") {
                source.volume = materialHitVolume;
                source.PlayOneShot(audios[2]);
                
            }

            else if (hit.transform.tag == "materialPiedra")
            {
                source.volume = materialHitVolume;
                source.PlayOneShot(audios[3]);

            }

            else if (hit.transform.tag == "materialMetal")
            {
                source.volume = materialHitVolume;
                source.PlayOneShot(audios[4]);

            }
        }

    }
}
