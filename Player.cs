
using Godot;
using System;

public class Player : RigidBody2D
{
    public float MaxDistance = 3000;
    [Export] public int Impulse = 100;

    [Export] public int friction = -1;

    [Export] public int Torque = 4;

    [Export] public int Direction = -1;

    public float Life = 30;

    private Timer timer;
    private Vector2 originalPosition;

    public override void _Ready()
    {
        this.Impulse = (int)GlobalVars.Impulse;
        this.friction = (int)GlobalVars.friction;
        this.Torque = (int)GlobalVars.Torque;
        this.Direction = (int)GlobalVars.Direction;
    }
    public void LaunchRock()
    {
        originalPosition = this.Position;
        //this.ApplyCentralImpulse(new Vector2(this.Transform.x.Normalized() * Impulse));
        this.ApplyTorqueImpulse((float)200);
        this.ApplyImpulse(new Vector2((float)-16.5, 0), this.Transform.x.Normalized() * Impulse);

        timer = new Timer();
        this.AddChild(timer);
        timer.WaitTime = this.Life;
        timer.OneShot = true;
        timer.Connect("timeout", this, nameof(OnTimeToDie));
        timer.Start();
    }

    public override void _PhysicsProcess(float delta)
    {
        float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
        if (distanceTravelled > this.MaxDistance)
            this.QueueFree();
        //this.AppliedForce = (new Vector2(0, (float)(friction * this.LinearVelocity.y)));
        this.AppliedForce = (new Vector2((float)(Direction * Torque * this.AngularVelocity), 1));
    }

    public void OnTimeToDie()
    {
        this.QueueFree();
    }

}