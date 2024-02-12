using Cycling.Game;
using NUnit.Framework;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Tests
{

    public void PlayerIsPlacedAtStartingLine()
    {
        
    }

    public void TwoPlayersArePlacedAtStartingLine()
    {
        
    }
    
    [Test]
    public void TestPlayerCanReachEndOfStraightLine()
    {
        var raceSettings = new RaceSettings();
        raceSettings.Course = CreateSimpleCourse();
        var cyclist = new Cyclist(raceSettings);
        raceSettings.Cyclists.Add(cyclist);

        var race = new Race(raceSettings);
        race.Init();
        cyclist.Speed.Value = .1f;
        for (int i = 0; i < 1000; i++)
        {
            race.Tick();    
        }
        
        Assert.IsTrue(Mathf.Approximately(cyclist.Position.Value.X, raceSettings.Course.Nodes[1].X));
        Assert.IsTrue(Mathf.Approximately(cyclist.Position.Value.Y, raceSettings.Course.Nodes[1].Y));
        
    }

    private RaceCourse CreateSimpleCourse()
    {
        var course = new RaceCourse();
        course.Nodes.Add(new Vector2(0,0));
        course.Nodes.Add(new Vector2(0,1));
        return course;
    }

    
}
