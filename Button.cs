using Godot;
using System;

public class Button : Godot.Button
{
    
    public override void _Ready()
    {
        
    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://Rink.tscn");
    }

}
