using System.Collections;
using System.Collections.Generic;
using SkeletonEditor;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sword swordWeapon;
    [SerializeField] private PlayerController playerHero;
    
    [Header("UI")]
    [SerializeField] private TMP_Text labelExpCounter;

    [SerializeField] private TMP_Text labelHealthCounter;
    
    

    // private int expCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        labelExpCounter.SetText(swordWeapon.CollectedExp.ToString());
        labelHealthCounter.SetText(playerHero.HealthPoints.ToString());
    }
}
