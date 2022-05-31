using UnityEngine;
using UnityEngine.AI; // 내비메시 관련 코드

// 주기적으로 아이템을 플레이어 근처에 생성하는 스크립트
public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items; // 생성할 아이템
    public Transform playerTransform; // 플레이어의 트랜스폼

    public float maxDistance = 5f; // 플레이어 위치에서 아이템이 배치될 최대 반경

    public float timeBetSpawnMax = 7f; // 최대 시간 간격
    public float timeBetSpawnMin = 2f; // 최소 시간 간격
    private float timeBetSpawn; // 생성 간격

    private float lastSpawnTime; // 마지막 생성 시점

    private void Start(){
        // 생성 간격과 마지막 생성 시점 초기화
        // timeBetSpawn은 2f~7f사이의 랜덤 시간대
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    // 주기적으로 아이템 생성 처리 실행
    // 현재시간이 마지막생성시간+랜덤생성시간 지남 > 마지막생성시간 갱신 > 랜덤생성주기 > 생성 > 반복
    private void Update(){
        // 현재 시점이 마지막 생성 시점에서 생성 주기 이상 지남
        // && 플레이어 캐릭터가 존재함
        if(Time.time >= lastSpawnTime + timeBetSpawn && playerTransform != null){
            // 마지막 생성 시간 갱신
            lastSpawnTime = Time.time;
            // 생성 주기를 랜덤으로 변경
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // 아이템 생성 실행
            Spawn();
        }
    }

    // 실제 아이템 생성 처리
    // 1) spawnPosition에 플레이어 위치+maxDistance 반경값을 넣고 0.5f 위로 이동
    // 2) 지역변수 selectItem에 items배열 안에 등록된 오브젝트중 랜덤으로 부여
    // 3) Instantiate ??
    private void Spawn(){
        // 플레이어 근처에서 내비메시 위의 랜덤 위치 가져오기
        Vector3 spawnPosition = GetRandomPointOnNavMesh(playerTransform.position, maxDistance);
        // 바닥에서 0.5만큼 위로 올리기
        spawnPosition += Vector3.up *0.5f;

        // 아이템 중 하나를 무작위로 골라 랜덤 위치에 생성
        // Quaternion.identity : 0,0,0 반환 (x,y,z 축이 겹치지 않고 회전이 0인 오일러각을 표현)
        GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        // 생성된 아이템을 5초 뒤에 파괴
        Destroy(item, 5f);
    }

    // 내비메시 위의 랜덤한 위치를 반환하는 메서드
    // center를 중심으로 distance 반경 안에서의 랜덤한 위치를 찾음
    // center : playerTransform.position, distance : maxDistance                                                                  
    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance){
        // center를 중심으로 반지름이 maxDistance인 구 안에서의 랜덤한 위치 하나를 저장
        // Random.insideUnitSpher는 반지름이 1인 구 안에서의 랜덤한 한 점을 반환하는 프로퍼티
        // player Vector3값 자리에 반지름이 1*5f인 구 안에서 무작위 점 반환
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        // 내비메시 샘플링의 결과 정보를 저장하는 변수
        NavMeshHit hit;
        // maxDistance 반경 안에서 randomPos에 가장 가까운 내비메시 위의 한 점을 찾음
        // NavMesh.AllAreas 와 distance 반경내에서 randomPos와 가장 가까운 점을 hit에 out
        // out 키워드 : 출력 전용 매개변수
        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);

        // 찾은 점 반환
        return hit.position;
    }
}
