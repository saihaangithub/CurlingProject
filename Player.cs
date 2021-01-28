  
using Godot;
using System;

public class Player : RigidBody2D
{
    public float MaxDistance = 1200;
    public float Impulse = 200;
    public float Life = 30;

    private Timer timer;
    private Vector2 originalPosition;


    public void LaunchRock(){
        originalPosition = this.Position;
        this.ApplyCentralImpulse(new Vector2(this.Transform.x.Normalized() * Impulse));

        timer = new Timer();
        this.AddChild(timer);
        timer.WaitTime = this.Life;
        timer.OneShot = true;
        timer.Connect("timeout",this,nameof(OnTimeToDie));
        timer.Start();
    }

    public override void _PhysicsProcess(float delta){
        float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
        if (distanceTravelled > this.MaxDistance)
            this.QueueFree();
        this.AppliedForce = (new Vector2(0,(float)(-1*this.LinearVelocity.y)));
    }

    public void OnTimeToDie(){
        this.QueueFree();
    }

}