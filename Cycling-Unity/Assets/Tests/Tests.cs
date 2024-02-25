using System;
using System.Collections.Generic;
using System.Numerics;
using Cycling.Game;
using NUnit.Framework;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Tests
{

    [Test]
    public void OneCyclistIsPlacedAtStartingLine()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(1);
        var cyclist = raceSettings.Cyclists[0];
        var race = new Race(raceSettings);
        race.Init();
        
        Assert.IsTrue(IsSamePosition(cyclist.Position.Value,raceSettings.Course.Lanes[0][0]));
    }
    
    [Test]
    public void LanesAreCreated()
    {
        var course = CreateSimpleCourse(2);
        var direction = course.Lanes[0][1] - course.Lanes[0][0];
        var perpendicular = new Vector2(-direction.Y, direction.X);
        perpendicular = Vector2.Normalize(perpendicular);
        Assert.IsTrue(Math.Abs(Vector2.Distance(course.Lanes[0][0], course.Lanes[0][1]) - 1) < .01f);
        Assert.IsTrue(Vector2.Dot(direction, perpendicular) == 0);
    }

    [Test]
    public void TwoCyclistsArePlacedAtStartingLine()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(2);
        var race = new Race(raceSettings);
        race.Init();
        Assert.IsTrue(false);
        //todo: need to implement this in cyclist.init...
    }
    
    [Test]
    public void TestPlayerCanReachEndOfStraightLine()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(1);
        var cyclist = raceSettings.Cyclists[0];
        InitRaceAndRun(raceSettings, cyclist);
        Assert.IsTrue(IsSamePosition(cyclist.Position.Value, raceSettings.Course.Lanes[0][1]));
    }

    

    [Test]
    public void EnduranceIsReducedWhenCyclistMoves()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(1);
        var cyclist = raceSettings.Cyclists[0];
        var startingEndurance = cyclist.Endurance.Value;
       
        InitRaceAndRun(raceSettings,cyclist);
        var endEndurance = cyclist.Endurance.Value;
        
        Assert.IsTrue(startingEndurance > endEndurance);
    }
    
    [Test]
    public void MoreEnduranceIsUsedToGoFaster()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(1);
        var cyclist = raceSettings.Cyclists[0];
        var startingEndurance = cyclist.Endurance.Value;
        
        InitRaceAndRun(raceSettings,cyclist);
        
        var endEndurance = cyclist.Endurance.Value;
        
        Assert.IsTrue(startingEndurance > endEndurance);
    }

    [Test]
    public void CyclistsDontOverlap()
    {
        var raceSettings = CreateRaceSettingsWithCyclistsAndSimpleCourse(1);
        var cyclist1 = raceSettings.Cyclists[0];
        var cyclist2 = raceSettings.Cyclists[1];
        //todo: should slow down the second one if it can't overtake
        Assert.IsTrue(false);

    }

    private static void InitRaceAndRun(RaceSettings raceSettings, Cyclist cyclist)
    {
        var race = new Race(raceSettings);
        race.Init();
        
        for (int i = 0; i < 1000; i++)
        {
            race.Tick();    
        }
    }

    private RaceSettings CreateRaceSettingsWithCyclistsAndSimpleCourse(int numCyclists)
    {
        var raceSettings = new RaceSettings();
        raceSettings.Course = CreateSimpleCourse(1);
        for (int i = 0; i < numCyclists; i++)
        {
            var cyclist = new Cyclist(raceSettings);
            raceSettings.Cyclists.Add(cyclist);
        }

        raceSettings.Course = CreateSimpleCourse(1);
        return raceSettings;

    }

    private RaceCourse CreateSimpleCourse(int numLanes)
    {
        var nodes = new List<Vector2>();
        nodes.Add(new Vector2(0,0));
        nodes.Add(new Vector2(0,1));
        var course = new RaceCourse(nodes,1);
        return course;
    }
    

    private bool IsSamePosition(Vector2 a, Vector2 b)
    {
        return Mathf.Approximately(a.X, b.X) && Mathf.Approximately(a.Y, b.Y);
    }

    
}
