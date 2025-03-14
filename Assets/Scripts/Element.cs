using UnityEngine;
    public class Element : MonoBehaviour
    {
        private static TopShooterApplication _topShooterApplication;
        protected static TopShooterApplication TopShooterApplication
        {
            get
            {
                if (_topShooterApplication == null)
                {
                    _topShooterApplication = FindFirstObjectByType<TopShooterApplication>();
                }
                return _topShooterApplication;
            }
        }
    }