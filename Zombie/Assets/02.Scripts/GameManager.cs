using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴 할당 전역변수

    public bool isGameover = false; // 게임오버

    void Awake() {
        // 싱글턴 변수 instance 비었는지
        if(instance == null) {
            // instance가 비어 있다면(null) 자신 할당
            instance = this;
        } else {
            // instance에 이미 다른 GameManager 오브젝트가 할당되었으면
            // 씬에 두 개 이상의 GameManager가 존재
            // 싱글턴 오브젝트는 하나만 있어야함. 자신 파괴
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
