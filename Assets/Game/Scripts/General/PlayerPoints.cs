using UnityEngine;

namespace StalinKilledMelons.General
{
    public class PlayerPoints : MonoBehaviour
    {
        private float totalPlayerPoints = 0;

        public float PotalPlayerPoints { get { return totalPlayerPoints; } }

        public void AddPoints(float points)
        {
            totalPlayerPoints += points;

            if (totalPlayerPoints < 0) { totalPlayerPoints = 0; }
        }
    }
}
