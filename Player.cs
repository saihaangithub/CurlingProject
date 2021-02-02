  
using Godot;
using System;

public class Player : RigidBody2D
{
    public float MaxDistance = 3000;
    public int Impulse = 200;

    public int Impulsey=100;
    public float Life = 30;

    private Timer timer;
    private Vector2 originalPosition;


    public void LaunchRock(){
        originalPosition = this.Position;
        this.ApplyCentralImpulse(new Vector2(this.Transform.x.Normalized() * Impulse));
        //this.ApplyTorqueImpulse(new Vector2(this.Transform.x.Normalized() * Impulse,this.Transform.y.Normalized() * Impulse));

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
        //this.AppliedForce = (new Vector2 ((float)(-2*this.AngularVelocity),0));
    }

    public void OnTimeToDie(){
        this.QueueFree();
    }

}