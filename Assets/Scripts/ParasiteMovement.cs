using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteMovement : MonoBehaviour
{
    [SerializeField] float power = 10f;

    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower;

    private Rigidbody2D rb;
    private Camera camera;
    private SlingshotLine slingshotLine;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        slingshotLine = GetComponent<SlingshotLine>();
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            startPoint = camera.ScreenToWorldPoint( Input.mousePosition );
            startPoint.z = 0;
        }

        if ( Input.GetMouseButton( 0 ) )
        {
            Vector3 currentPoint = camera.ScreenToWorldPoint( Input.mousePosition );
            currentPoint.z = 0;

            slingshotLine.RenderLine( startPoint, currentPoint );
        }

        if ( Input.GetMouseButtonUp( 0 ) )
        {
            endPoint = camera.ScreenToWorldPoint( Input.mousePosition );
            endPoint.z = 0;

            force = new Vector2( Mathf.Clamp( startPoint.x - endPoint.x, minPower.x, maxPower.x ),
                                Mathf.Clamp( startPoint.y - endPoint.y, minPower.y, maxPower.y ) );

            rb.AddForce( force * power, ForceMode2D.Impulse );
            slingshotLine.EndLine();
        }

        if ( rb.velocity.magnitude >= 0.1f )
        {
            var dir = rb.velocity;
            var angle = Mathf.Atan2( dir.y, dir.x ) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis( angle - 90, Vector3.forward );
            transform.rotation = q;
        }
    }
}
