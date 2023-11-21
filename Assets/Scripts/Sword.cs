using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Animator anim;
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
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1h1"))
            {
                collectedExp += 1;
                Destroy(objectName.gameObject);
            }
            
        }
    }
}
