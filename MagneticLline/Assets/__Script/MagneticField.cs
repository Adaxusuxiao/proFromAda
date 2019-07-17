using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour {

    public GameObject NP;      //N极
    public GameObject SP;      //S极
    private static float mu0 = 10.0f;       //磁常数项；
    public float strength;                 //磁场强度
    private Rigidbody rb;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Range of magnetic field
    void OnTriggerStay(Collider other)
    {

        Rigidbody other_rb = other.gameObject.GetComponent<Rigidbody>();   //同该磁铁相互作用的目标物体的rigidbody

        if (other.gameObject.tag == "Magnetic")
        {
            MagneticField other_script = other.gameObject.GetComponent<MagneticField>();
            GameObject other_NP = other_script.NP;
            GameObject other_SP = other_script.SP;
            Vector3 r_n_n = other_NP.transform.position - NP.transform.position; // from this(N) to that(N)
            Vector3 r_s_s = other_SP.transform.position - SP.transform.position; // from this(S) to that(S)
            Vector3 r_n_s = other_SP.transform.position - NP.transform.position; // from this(N) to that(S)
            Vector3 r_s_n = other_NP.transform.position - SP.transform.position; // from this(S) to that(N)
            float other_strength = other_script.strength;

            // Calculate Force towards magnetic poles
            float mu = Time.fixedDeltaTime * strength * other_strength;
            Vector3 f_n_n = // from this(N) to that(N)
                        (r_n_n.normalized) * mu / (Mathf.Pow(Mathf.Max(r_n_n.magnitude, 0.2f), 3));
            Vector3 f_s_s = // from this(S) to that(S)
                        (r_s_s.normalized) * mu / (Mathf.Pow(Mathf.Max(r_s_s.magnitude, 0.2f), 3));
            Vector3 f_n_s = // from this(N) to that(S)
                        (r_n_s.normalized) * mu / (Mathf.Pow(Mathf.Max(r_n_s.magnitude, 0.2f), 3));
            Vector3 f_s_n = // from this(S) to that(N)
                        (r_s_n.normalized) * mu / (Mathf.Pow(Mathf.Max(r_s_n.magnitude, 0.2f), 3));
            //Debug.Log ( f_n_n.magnitude + ", " + f_n_n.magnitude);

            // Apply Rejecting Force
            other_rb.AddForceAtPosition(
                        1f * f_n_n, other_NP.transform.position);
            other_rb.AddForceAtPosition(
                        1f * f_s_s, other_SP.transform.position);

            // Apply Attracting Force
            other_rb.AddForceAtPosition(-1f * f_n_s, other_SP.transform.position);
            other_rb.AddForceAtPosition(-1f * f_s_n, other_NP.transform.position);

        }
        else if (other.gameObject.tag == "Paramagnetic")
        {
            Vector3 r_n = other.gameObject.transform.position - NP.transform.position; // displacement vector
            Vector3 r_s = other.gameObject.transform.position - SP.transform.position; // displacement vector
            float mu = Time.fixedDeltaTime * strength * mu0 * other_rb.mass;
            // Calculate Force towards magnetic poles
            Vector3 f_n = (r_n.normalized) * mu / (Mathf.Pow(Mathf.Max(r_n.magnitude, 0.2f), 3));
            Vector3 f_s = (r_s.normalized) * mu / (Mathf.Pow(Mathf.Max(r_s.magnitude, 0.2f), 3));
            //Debug.Log ( nf.magnitude + ", " + sf.magnitude);

            // Apply attracting force to other object
            other_rb.AddForce(-1f * f_n);
            other_rb.AddForce(-1f * f_s);
            // Apply attracting force to magnetic object
            rb.AddForceAtPosition(1f * f_n, NP.transform.position);
            rb.AddForceAtPosition(1f * f_s, SP.transform.position);
        }
    }


}
