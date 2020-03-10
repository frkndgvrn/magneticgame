using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
	public static int sifirlama=1;
float ZPosition;
Vector3 OffSet;
public Camera MainCamera;
[Space]
bool Dragging;
[SerializeField]
public UnityEvent OnBeginDrag;
[SerializeField]
public UnityEvent OnEndDrag;
void Start()
{

	ZPosition=MainCamera.WorldToScreenPoint(transform.position).z;
	
}
void Update()
{
	if(Dragging)
	{
		Vector3 position=new Vector3(Input.mousePosition.x,Input.mousePosition.y,ZPosition);
		transform.position=MainCamera.ScreenToWorldPoint(position+new Vector3(OffSet.x,OffSet.y));
	}
	
}
void OnMouseDown()
{
	if(!Dragging)
	{	
	BeginDrag();
    sifirlama=1;
	}
}
void OnMouseUp()
{
	EndDrag();
	Debug.Log("Elini kaldırdın!");
}
public void BeginDrag()
{
	OnBeginDrag.Invoke();
Dragging=true;
OffSet=MainCamera.WorldToScreenPoint(transform.position)-Input.mousePosition;	
}
public void EndDrag()
{
	sifirlama=0;
	transform.position = Vector3.zero;
	OnEndDrag.Invoke();
	Dragging=false;
}
}
