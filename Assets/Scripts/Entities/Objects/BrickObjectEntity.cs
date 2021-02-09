using System.Collections;
using UnityEngine;

namespace Entities.Objects
{
    public class BrickObjectEntity : ObjectEntity
    {
        protected override void OnStart()
        {
            StartCoroutine(IMoveDown());
        }
        
        private IEnumerator IMoveDown()
        {
            yield return new WaitForSeconds(1);
            transform.position -= Vector3.up;
            StartCoroutine(IMoveDown());
        }
    }
}