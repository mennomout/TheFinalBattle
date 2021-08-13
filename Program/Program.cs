using System;
using System.Collections.Generic;
using FinalBattle;

try
{
    Skeleton skeleton = new();
    Skeleton skeleton1 = new();

    Party party = new(skeleton1);

    BoneCrush boneCrush = new();
    boneCrush.Execute(skeleton, Input.SingleTarget(party));

    Console.WriteLine(skeleton1.Health);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
