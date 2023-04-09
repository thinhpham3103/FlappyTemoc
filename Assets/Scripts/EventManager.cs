using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;
    public delegate void VoidNoParams();
    public static event VoidNoParams moveLeft;
    public static event VoidNoParams moveRight;
    public static event VoidNoParams jump;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            if (instance != this){
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            jump?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            moveLeft?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            moveRight?.Invoke();
        }
    }
}
