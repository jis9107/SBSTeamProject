using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    public Animator anim;

    PlayerController enterPlayer;


    // Start is called before the first frame update
    void Enter(PlayerController player)
    {
        enterPlayer = player;
    }

    // Update is called once per frame
    void Exit()
    {
        
    }
}
