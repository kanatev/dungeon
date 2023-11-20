using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int collectedExp = 0;

    public int CollectedExp => collectedExp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider objectName)
    {
        // Debug.Log("Entered collision with " + objectName.tag);
        if (objectName.CompareTag("enemy_tag"))
        {
            collectedExp += 1;
            Destroy(objectName.gameObject);
        }
    }
}
