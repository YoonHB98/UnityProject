using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public Collider[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        // 스캔 범위 내의 모든 타겟을 가져옴
        targets = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float currentDistance = Vector3.Distance(myPos, targetPos);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                result = target.transform;
            }
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        // 스캔 범위를 시각적으로 확인하기 위한 코드
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRange);
    }
}
