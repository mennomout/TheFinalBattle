using System;
using FinalBattle;

//----------Hero party-----------//
TrueProgrammer heroProgrammer = new();
Party party1 = new(heroProgrammer);

//----------Monster party-----------//
Skeleton monsterSkeleton = new();
Party party2 = new(monsterSkeleton);

//----------Initialize and Start game-----------//
Battle TheFinalBattle = new(party1, party2);
TheFinalBattle.Start();
