using UnityEngine;

public class HealthPack : MonoBehaviour, IItem
{
   public float health = 50;    // 회복할 체력 수치

   public void Use(GameObject target){
        // 전달받은 게임 오브젝트로부터 LivingEntity 컴포넌트 가져오기
        // 컴포넌트명 지역변수 = 게임오브젝트명.GetComponent<컴포넌트명>();
        LivingEntity life = target.GetComponent<LivingEntity>();

        if(life != null){
            life.RestoreHealth(health);
        }
        Destroy(gameObject);
    }
}
