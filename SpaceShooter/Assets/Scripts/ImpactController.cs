using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        // check if is in the screen
        if(transform.position.y > -4.5f && transform.position.y < 4.5f){
            AudioSource.PlayClipAtPoint(sound, Vector3.zero);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyImpact()
    {
        Destroy(gameObject);
    }
}
