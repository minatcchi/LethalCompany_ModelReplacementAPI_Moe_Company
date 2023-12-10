using System.Collections;
using UnityEngine;

namespace ModelReplacement
{
    public class PlayerDeathTracker : MonoBehaviour
    {
        private  bool _died;

        public  bool Died
        {
            get => _died;
            set => _died = value;
        }
    }
}
