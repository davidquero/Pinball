using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {
    // Ángulo de posición en descanso
    public float restPosition = 0f;
    // Ángulo de posición presionado
    public float pressedPostion = 45f;
    // Fuerza del golpe de impacto
    public float hitStrength = 10000f;
    // Velocidad del flipper
    public float flipperDamper = 150f;
    // Nombre de la entrada
    public string inputName;

    HingeJoint hingeJoint;

	// Use this for initialization
	void Start () {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

		if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPostion;
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;
	}
}
