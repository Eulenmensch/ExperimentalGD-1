using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSegmentController : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private float MoveToForce;
    [SerializeField] private float DesiredDistance;
    [SerializeField] private float RotationSpeed;

    [Header( "PID" )]
    [SerializeField] private float ProportionalGain;
    [SerializeField] private float IntegralGain;
    [SerializeField] private float DerivativeGain;

    private PID TailPID;
    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        TailPID = new PID( ProportionalGain, IntegralGain, DerivativeGain );
    }

    void FixedUpdate()
    {
        MoveToTarget();
        RotateToVelocity();
        TailPID.Kp = ProportionalGain;
        TailPID.Ki = IntegralGain;
        TailPID.Kd = DerivativeGain;
    }

    void MoveToTarget()
    {
        Vector2 distance = Target.transform.position - transform.position;
        distance = -distance;
        Vector2 direction = distance.normalized;

        float forcePercent = TailPID.Control( DesiredDistance, distance.magnitude );

        Vector2 adjustedForce = MoveToForce * forcePercent * direction;

        RB.AddForce( adjustedForce );
    }
    void RotateToVelocity()
    {
        if ( RB.velocity.magnitude >= 0.3f )
        {
            var dir = RB.velocity;
            var angle = Mathf.Atan2( dir.y, dir.x ) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis( angle - 90, Vector3.forward );
            // /transform.rotation = q;

            transform.rotation = Quaternion.RotateTowards( transform.rotation, q, Time.deltaTime * RotationSpeed );
        }
    }
}
