using UnityEngine;

public class RDForBoxGloves : MonoBehaviour
{
    [SerializeField] RagdollOnOff current;
    //TODO
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        var rdof = collision.gameObject.GetComponent<RagdollOnOff>();
        if (rdof != null && rdof != current)
        {
            print("test");
            //�ALI�MIYOR B�R T�RL�: (
            //Vector3 direction = new Vector3(0, current.transform.eulerAngles.y, 0);
            //print(direction);
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 800f);
            //print(collision.gameObject.GetComponent<Rigidbody>());

            rdof.RagDollOn();
        }
    }
}
