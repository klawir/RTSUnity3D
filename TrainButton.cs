using Unit.CoreType;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Building
{
    namespace Training
    {
        namespace Units
        {
            public class TrainButton : GraphicalUserInterface.Production.Button
            {
                private Sprite effigy;
                private Production.Training trainingBuilding;
                public int index;

                protected override void Start()
                {
                    base.Start();
                    trainingBuilding = GetComponent<Owner>().owner.GetComponent<Production.Training>();
                    trainingBuilding.InitTrainButton(this);
                    effigy = GetComponent<Image>().sprite;
                }
                public override void OnPointerEnter(PointerEventData eventData)
                {
                    base.OnPointerEnter(eventData);
                    trainingBuilding.Identify(effigy);
                }

                public override void OnPointerExit(PointerEventData eventData)
                {
                    base.OnPointerExit(eventData);
                }

                public override void OnPointerClick(PointerEventData eventData)
                {
                    base.OnPointerClick(eventData);
                    trainingBuilding.Order();
                    SoundManagment.instance.PlayDefaultButtonClick();
                }
            }
        }
    }
}