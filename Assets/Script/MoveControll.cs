using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveControll : MonoBehaviour
{
    // Start is called before the first frame update
    public EventTrigger triggerEventL;
    public EventTrigger triggerEventR;
    public EventTrigger triggerEventD;
    public EventTrigger triggerEventU;

    void Start()
    {
        GameObject playerObj= GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        { 
            Move move= playerObj.GetComponent<Move>();
            AddEventTriggerListener(triggerEventD, EventTriggerType.PointerDown, move.MoveDown);
            AddEventTriggerListener(triggerEventU, EventTriggerType.PointerDown, move.MoveUp);
            AddEventTriggerListener(triggerEventL, EventTriggerType.PointerDown, move.Moveleft);
            AddEventTriggerListener(triggerEventR, EventTriggerType.PointerDown, move.MoveRight);
            AddEventTriggerListener(triggerEventD, EventTriggerType.PointerUp, move.StopMoving);
            AddEventTriggerListener(triggerEventU, EventTriggerType.PointerUp, move.StopMoving);
            AddEventTriggerListener(triggerEventL, EventTriggerType.PointerUp, move.StopMoving);
            AddEventTriggerListener(triggerEventR, EventTriggerType.PointerUp, move.StopMoving);
            Debug.Log("AddEventTriggerListener done");
        }
    }
    private void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction action)
    {
        // Kiểm tra xem loại sự kiện này đã có trong danh sách chưa
        EventTrigger.Entry entry = trigger.triggers.Find(x => x.eventID == eventType);

        if (entry == null)
        {
            entry = new EventTrigger.Entry();
            entry.eventID = eventType;
            trigger.triggers.Add(entry);
        }

        // Xóa các listener cũ để tránh bị trùng lặp
        entry.callback.RemoveAllListeners();

        // Thêm hàm thực thi vào sự kiện
        entry.callback.AddListener((data) => { action.Invoke(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
