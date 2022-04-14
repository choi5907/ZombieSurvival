using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱��� �Ҵ� ��������

    public bool isGameover = false; // ���ӿ���

    void Awake() {
        // �̱��� ���� instance �������
        if(instance == null) {
            // instance�� ��� �ִٸ�(null) �ڽ� �Ҵ�
            instance = this;
        } else {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ�����
            // ���� �� �� �̻��� GameManager�� ����
            // �̱��� ������Ʈ�� �ϳ��� �־����. �ڽ� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");
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
