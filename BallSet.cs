using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BallSet : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager; //RaycastManager변수 설정
    public List<ARRaycastHit> hits= new List<ARRaycastHit>();//Hit리스트 변수 설정 

    void Update()
    {
     if(Input.touchCount>0)// 터치가 발생했을 때
     {
        Vector2 touchPoint = Input.GetTouch(0).position;//평면에 객체를 생성함. 따라서 Vector2를 사용해도됨. Input.GetTouch(0)은 첫 번쨰 터치값을 반환해줌. 
        if(aRRaycastManager.Raycast(touchPoint,hits,TrackableType.PlaneWithinPolygon));
        //ARRaycastManager의 Raycast메서드(bool Type)호출. 레이캐스트 성공여부 판단  
        var hitPose=hits[0].pose;//hits의 첫 위치 값을 hitPose에 대입
        Instantiate(aRRaycastManager.raycastPrefab,hitPose.position,hitPose.rotation);


     }   
    }
}
