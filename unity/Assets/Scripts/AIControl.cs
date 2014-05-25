using UnityEngine;
using System.Collections;

public class AIControl : Photon.MonoBehaviour
{

    private Animator anim;							// a reference to the animator on the character
    private AnimatorStateInfo state;
    private GUINameOfAvatar textUnderAI;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        textUnderAI = this.GetComponent<GUINameOfAvatar>();
	}
	
	// Update is called once per frame
	void Update () {
        state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Idle"))
            textUnderAI.textUnderAvatar = "Я экскурсовод,\n кликни по мне,\n чтобы активировать";
        if (state.IsName("HelloWalk"))
            textUnderAI.textUnderAvatar = "Экскурсовод";
        if (state.IsName("IdleNearStand"))
            textUnderAI.textUnderAvatar = "Тут можно изучить\n стенды с информацией о\n факультетах университета";
        if (state.IsName("TurnRight180"))
            textUnderAI.textUnderAvatar = "Экскурсовод";
        if (state.IsName("IdleNearInfo"))
            textUnderAI.textUnderAvatar = "На данных стендах\n можно почитать историю\n создания кафедры ПС";
        if (state.IsName("TurnRightToTeachers"))
            textUnderAI.textUnderAvatar = "Экскурсовод";
        if (state.IsName("IdleNearTeachers"))
            textUnderAI.textUnderAvatar = "Всю информацию о преподавателях\n можно получить со стенда,\n представленного перед вами";
        if (state.IsName("Turn180ToTerminal"))
            textUnderAI.textUnderAvatar = "Экскурсовод";
        if (state.IsName("IdleNearTerminal"))
            textUnderAI.textUnderAvatar = "Для начала обучения,\n необходимо на терминале выбрать курс";
        if (state.IsName("Turn90Back"))
            textUnderAI.textUnderAvatar = "Экскурсовод";

        if (state.IsName("Finish"))
        {
            this.transform.position = GameObject.Find("RobotSpawnPlace").transform.position;
            this.transform.rotation = GameObject.Find("RobotSpawnPlace").transform.rotation;
            anim.SetBool("Excursion", false);
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Excursion", true);
        }        
    }
}
