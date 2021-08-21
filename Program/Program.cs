using System;
using System.Threading;
using FinalBattle;

try
{
    Thread music = new(BGMusic.BackGroundMusic2);
    music.Start();

    MainMenu mainMenu = new();
    while (mainMenu.Play())
    {
        DifficultyMenu difficultyMenu = new();
        int difficulty = difficultyMenu.LevelDificulty();

        GameModeMenu gameModeMenu = new();
        (Player, Player) players = gameModeMenu.CreatePlayers();

        Player heroPlayer = players.Item1;
        Player monsterPlayer = players.Item2;

        Party heroes = new(
            new Programmer(),
            new VinFletcher());

        Party monsters1 = new(
            new UncodedOne(),
            new Skeleton("child skeleton", 2),
            new Skeleton("limping skeleton", 3),
            new Skeleton("armored skeleton", 6));

        Party monsters2 = new(
            new UncodedOne(),
            new Skeleton("child skeleton", 2),
            new Skeleton("limping skeleton", 3),
            new Skeleton("armored skeleton", 6));

        Party monsters3 = new(
            new UncodedOne(),
            new Skeleton("child skeleton", 2),
            new Skeleton("limping skeleton", 3),
            new Skeleton("armored skeleton", 6));

        Battle battle1 = new(new() { heroes }, new() { monsters1 });
        Battle battle2 = new(new() { heroes }, new() { monsters2 });
        Battle battle3 = new(new() { heroes }, new() { monsters3 });

        Level levelOne = new(heroPlayer, monsterPlayer, battle1);
        if (difficulty == 2) levelOne = new(heroPlayer, monsterPlayer, battle1, battle2);
        if (difficulty == 3) levelOne = new(heroPlayer, monsterPlayer, battle1, battle2, battle3);

        levelOne.Play();
    }
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}