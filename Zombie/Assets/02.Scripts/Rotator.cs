using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 초당 60도의 회전
    public float rotationSpeed = 60f;
    private void Update() {
        // 한 프레임당 0.017도
        // y축 기준으로 Rotate
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
