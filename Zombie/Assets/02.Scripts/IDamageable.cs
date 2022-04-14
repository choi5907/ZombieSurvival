using UnityEngine;

public interface IDamageable {
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
    // 데미지 크기, 공격당한 위치, 공격당한 표면의 방향
}