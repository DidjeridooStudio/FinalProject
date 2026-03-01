using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class DesktopInput : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
            }
        }

        public Vector3 MousePosition
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                //return Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return Input.mousePosition;
            }
        }

        public bool LeftMouseButtonClicked
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                    return true;

                return false;
            }
        }

        public bool StartButtonClicked
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                if (Input.GetKeyDown(KeyCode.S))
                    return true;

                return false;
            }
        }

        public bool QuitButtonClicked
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                if (Input.GetKeyDown(KeyCode.Q))
                    return true;

                return false;
            }
        }
    }
}
