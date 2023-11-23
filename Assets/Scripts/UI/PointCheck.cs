using UnityEngine;
using UnityEngine.EventSystems;

public class PointCheck : MonoBehaviour, IPointerDownHandler
{
    //当鼠标点击，即鼠标按下与松开均在该物体上时，触发以下函数
    public void OnPointerClick(PointerEventData eventData)
    {
        //你要触发的代码
    }
    
    //当检测到鼠标在该物体上有“按下”操作时，触发以下函数
    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}





    



