using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject lamps;
    [SerializeField] private GameObject BLACK;
    private Transform lamps_transform;
    private GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lamps_transform = lamps.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            HideShowLamps(lamps, false);
            spriteRenderer.enabled = true;
            //BLACK.SetActive(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            HideShowLamps(lamps, true);
            spriteRenderer.enabled = false;
            //BLACK.SetActive(false);
        }    
    }

    private void HideShowLamps(GameObject lamps, bool hide){
        foreach(Transform lamp in lamps_transform){
            lamp.Find("Light").gameObject.SetActive(hide);
        }
    }
}
