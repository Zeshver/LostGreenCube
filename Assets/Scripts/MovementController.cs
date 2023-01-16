using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class MovementController : SingletonBase<MovementController>
    {
        [SerializeField] private PointerClickHold m_MobileUp;
        [SerializeField] private PointerClickHold m_MobileDown;
        [SerializeField] private PointerClickHold m_MobileLeft;
        [SerializeField] private PointerClickHold m_MobileRight;

        [SerializeField] private GameObject m_PCControllPanel;
        [SerializeField] private GameObject m_MobileControllPanel;

        [SerializeField] private Vector3 m_MobileMoveDirectionUpDown;
        [SerializeField] private Vector3 m_MobileMoveDirectionLeftRight;

        [SerializeField] private Vector3 m_KeyboardMoveDirectionUpDown;
        [SerializeField] private Vector3 m_KeyboardMoveDirectionLeftRight;

        [SerializeField] private Vector3 m_DefaultDirection;

        [SerializeField] private List<CubeController> m_AllCubeControllers;
        public List<CubeController> AllCubeControllers => m_AllCubeControllers;

        private void Update()
        {
            if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileControllPanel.SetActive(false);
                m_PCControllPanel.SetActive(true);
            }
            else
            {
                m_MobileControllPanel.SetActive(true);
                m_PCControllPanel.SetActive(false);
            }
        }

        private void FixedUpdate()
        {
            if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard)
            {
                ControlKeyboard();
            }

            if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile)
            {
                ControlMobile();
            }
        }

        private void ControlMobile()
        {
            if (m_MobileUp.IsHold == true)
            {
                SetPlayerInput.Instance.m_ControlMode = ControlMode.Mobile;

                foreach (var cube in AllCubeControllers)
                {
                    if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile && SetPlayerInput.Instance.m_ControlMode != ControlMode.Keyboard)
                    {
                        if (cube.PlayerCubeMode == CubeController.CubeMode.Main && AllCubeControllers != null)
                        {
                            cube.GetComponent<Rigidbody>().velocity -= m_MobileMoveDirectionUpDown;
                        }
                    }
                }
            }

            if (m_MobileDown.IsHold == true)
            {
                SetPlayerInput.Instance.m_ControlMode = ControlMode.Mobile;

                foreach (var cube in AllCubeControllers)
                {
                    if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile && SetPlayerInput.Instance.m_ControlMode != ControlMode.Keyboard)
                    {
                        if (cube.PlayerCubeMode == CubeController.CubeMode.Main && AllCubeControllers != null)
                        {
                            cube.GetComponent<Rigidbody>().velocity += m_MobileMoveDirectionUpDown;
                        }
                    }
                }
            }

            if (m_MobileLeft.IsHold == true)
            {
                SetPlayerInput.Instance.m_ControlMode = ControlMode.Mobile;

                foreach (var cube in AllCubeControllers)
                {
                    if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile && SetPlayerInput.Instance.m_ControlMode != ControlMode.Keyboard)
                    {
                        if (cube.PlayerCubeMode == CubeController.CubeMode.Other && AllCubeControllers != null)
                        {
                            cube.GetComponent<Rigidbody>().velocity -= m_MobileMoveDirectionLeftRight;
                        }
                    }
                }
            }

            if (m_MobileRight.IsHold == true)
            {
                SetPlayerInput.Instance.m_ControlMode = ControlMode.Mobile;

                foreach (var cube in AllCubeControllers)
                {
                    if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Mobile && SetPlayerInput.Instance.m_ControlMode != ControlMode.Keyboard)
                    {
                        if (cube.PlayerCubeMode == CubeController.CubeMode.Other && AllCubeControllers != null)
                        {
                            cube.GetComponent<Rigidbody>().velocity += m_MobileMoveDirectionLeftRight;
                        }
                    }
                }
            }
        }

        private void ControlKeyboard()
        {
            foreach (var cube in AllCubeControllers)
            {
                if (cube.PlayerCubeMode == CubeController.CubeMode.Main && AllCubeControllers != null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        SetPlayerInput.Instance.m_ControlMode = ControlMode.Keyboard;

                        if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard && SetPlayerInput.Instance.m_ControlMode != ControlMode.Mobile)
                        {
                            cube.GetComponent<Rigidbody>().velocity -= m_KeyboardMoveDirectionUpDown;
                        }
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        SetPlayerInput.Instance.m_ControlMode = ControlMode.Keyboard;

                        if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard && SetPlayerInput.Instance.m_ControlMode != ControlMode.Mobile)
                        {
                            cube.GetComponent<Rigidbody>().velocity += m_KeyboardMoveDirectionUpDown;
                        }
                    }
                }

                if (cube.PlayerCubeMode == CubeController.CubeMode.Other && AllCubeControllers != null)
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        SetPlayerInput.Instance.m_ControlMode = ControlMode.Keyboard;

                        if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard && SetPlayerInput.Instance.m_ControlMode != ControlMode.Mobile)
                        {
                            cube.GetComponent<Rigidbody>().velocity -= m_KeyboardMoveDirectionLeftRight;
                        }
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        SetPlayerInput.Instance.m_ControlMode = ControlMode.Keyboard;

                        if (SetPlayerInput.Instance.m_ControlMode == ControlMode.Keyboard && SetPlayerInput.Instance.m_ControlMode != ControlMode.Mobile)
                        {
                            cube.GetComponent<Rigidbody>().velocity += m_KeyboardMoveDirectionLeftRight;
                        }
                    }
                }
            }
        }

        public void AddListCubeController(CubeController cube)
        {
            if (m_AllCubeControllers == null)
            {
                m_AllCubeControllers = new List<CubeController>();
            }

            m_AllCubeControllers.Add(cube);
        }
    }
}