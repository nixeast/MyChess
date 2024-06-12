using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePoint : MonoBehaviour
{
    public GameObject CurrentGameManagerObject;
    GameManager CurrentGameManager;
    bool isMovable = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameManagerObject = GameObject.Find("GameManager");
        CurrentGameManager = CurrentGameManagerObject.GetComponent<GameManager>();
        this.GetComponent<Button>().onClick.AddListener(() => CurrentGameManager.MovePieceToPoint(this.gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
