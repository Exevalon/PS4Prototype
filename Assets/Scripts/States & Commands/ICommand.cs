using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    int Countdown { get; set; }
    string Name { get; set; }
    Actor Owner { get; set;}
    int TimePoints(CommandQueue queue);
    void Execute(CommandQueue queue);
    void UpdateCommand();
    bool IsFinished();
}
