using System.Collections;
using System.Collections.Generic;
using Building.Production.Progress;
using GraphicalUserInterface.Player.Resources;
using GraphicalUserInterface.Production.Info;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GraphicalUserInterface
{
    namespace Production
    {
        public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
        {
            protected Item obj;

            protected virtual void Start()
            {
                obj = GetComponent<Item>();
            }

            public virtual void OnPointerClick(PointerEventData eventData)
            {
                Window.instance.Delete();
                if (GameObjectDetector.instance.IsAnyPreBuildingExistsOnMap)
                    PreInstantiateManager.instance.DeleteIfAnyExist();
            }

            public virtual void OnPointerEnter(PointerEventData eventData)
            {
                Window.instance.Render(obj);
            }

            public virtual void OnPointerExit(PointerEventData eventData)
            {
                Window.instance.Delete();
            }

            public Item Obj
            {
                get { return obj; }
            }
        }
    }
}