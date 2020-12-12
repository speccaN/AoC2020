﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day12
{
    public class Day12 : BaseDay
    {
        internal record State(int Facing, (double x, double y) Coordinates, Waypoint Waypoint);
        internal record Waypoint(double X, double Y);
        internal record Instruction(string Operation, int Value);

        internal class Boat
        {
            private readonly string[] _input;
            private readonly bool _partTwo;
            private State State { get; set; } = new(90, (0, 0), new Waypoint(10, -1));
            
            public Boat(string[] input, bool partTwo = false)
            {
                _input = input;
                _partTwo = partTwo;
            }

            State ExecuteInstruction(State state, Instruction instruction) => instruction switch
            {
                { Operation: "N" } when _partTwo => 
                    state with { Coordinates = state.Coordinates, 
                        Facing = state.Facing, 
                        Waypoint = new Waypoint(state.Waypoint.X, state.Waypoint.Y-instruction.Value) },
                { Operation: "S" } when _partTwo =>
                    state with
                        {
                        Coordinates = state.Coordinates,
                        Facing = state.Facing,
                        Waypoint = new Waypoint(state.Waypoint.X, state.Waypoint.Y + instruction.Value)
                        },
                { Operation: "E" } when _partTwo => 
                    state with { 
                        Coordinates = state.Coordinates,
                        Facing = state.Facing,
                        Waypoint = new Waypoint(state.Waypoint.X + instruction.Value, state.Waypoint.Y)
                        },
                { Operation: "W" } when _partTwo => 
                    state with {
                        Coordinates = state.Coordinates,
                        Facing = state.Facing,
                        Waypoint = new Waypoint(state.Waypoint.X - instruction.Value, state.Waypoint.Y)
                        },
                { Operation: "L" } when _partTwo => 
                    state with {
                        Coordinates = state.Coordinates,
                        Facing = state.Facing,
                        Waypoint = RotateWaypoint(state.Waypoint, instruction)
                        },
                { Operation: "R" } when _partTwo => state with 
                    {
                    Coordinates = state.Coordinates,
                    Facing = state.Facing,
                    Waypoint = RotateWaypoint(state.Waypoint, instruction)
                    },
                { Operation: "F" } when _partTwo => state with 
                    {
                    Coordinates = (state.Coordinates.x + state.Waypoint.X * instruction.Value, state.Coordinates.y + state.Waypoint.Y * instruction.Value),
                    Facing = state.Facing,
                    Waypoint = state.Waypoint
                    },


                { Operation: "N" } => state with { Coordinates = (state.Coordinates.x, state.Coordinates.y - instruction.Value) },
                { Operation: "S" } => state with { Coordinates = (state.Coordinates.x, state.Coordinates.y + instruction.Value) },
                { Operation: "E" } => state with { Coordinates = (state.Coordinates.x + instruction.Value, state.Coordinates.y) },
                { Operation: "W" } => state with { Coordinates = (state.Coordinates.x - instruction.Value, state.Coordinates.y) },
                { Operation: "L" } => state with { Facing = CalcAngle(state.Facing, instruction.Value*-1) },
                { Operation: "R" } => state with { Facing = CalcAngle(state.Facing, instruction.Value) },
                { Operation: "F" } => state with { Coordinates = MoveWithAngle(state.Facing, state.Coordinates.x, state.Coordinates.y, instruction.Value) },
                _ => throw new ArgumentOutOfRangeException(nameof(instruction))
            };

            private int CalcAngle(int currentAngle, int turn)
            {
                var newAngle = (currentAngle + turn) % 360;
                return newAngle < 0 ? newAngle + 360 : newAngle;
            }

            private (double x, double y) MoveWithAngle(int angle, double x, double y, double val) => angle switch
            {
                0 => (x, y - val),
                90 => (x + val, y),
                180 => (x, y + val),
                270 => (x - val, y),
                _ => throw new ArgumentOutOfRangeException(nameof(angle), angle, null)
            };

            private Waypoint RotateWaypoint(Waypoint waypoint, Instruction instruction) => instruction switch
            {
                {Operation: "L" } => instruction.Value switch
                {
                    90 => waypoint with { X = waypoint.Y, Y = waypoint.X * -1 },
                    180 => waypoint with { X = waypoint.X * -1, Y = waypoint.Y * -1 },
                    270 => waypoint with { X = waypoint.Y, Y = waypoint.X },
                    _ => throw new ArgumentOutOfRangeException()
                },
                {Operation: "R" } => instruction.Value switch
                {
                    90 => waypoint with { X = waypoint.Y * -1, Y = waypoint.X },
                    180 => waypoint with { X = waypoint.Y * -1, Y = waypoint.X * -1 },
                    270 => waypoint with { X = waypoint.Y, Y = waypoint.X },
                    _ => throw new ArgumentOutOfRangeException()
                }
            };

            private double Manhattan(double a, double b) => Math.Abs(a) + Math.Abs(b);

            public double Move()
            {
                foreach (var instruction in _input.Select(s => new Instruction(s.Substring(0,1), int.Parse(s.Substring(1)))))
                {
                    State = ExecuteInstruction(State, instruction);
                }

                return Manhattan(State.Coordinates.x, State.Coordinates.y);
            }
            
        }
        
        public override string SolvePartOne()
        {
            var b = new Boat(Input);

            return b.Move().ToString();
        }

        public override string SolvePartTwo()
        {
            var b = new Boat(Input, true);
            return b.Move().ToString();
        }
    }
}