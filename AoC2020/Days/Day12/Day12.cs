using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day12
{
    public class Day12 : BaseDay
    {
        internal record State(double Facing, (double x, double y) Coordinates, Waypoint Waypoint);
        internal record Waypoint(double X, double Y);
        internal record Instruction(string Operation, int Value);

        internal class Boat
        {
            private readonly Dictionary<string, double> _degreesToRads = new()
            {
                {"L", Math.PI / -180},
                {"R", Math.PI / 180}
            };
            private readonly string[] _input;
            private readonly bool _partTwo;
            private State State { get; set; } = new(0, (0, 0), new Waypoint(10, -1));
            
            public Boat(string[] input, bool partTwo = false)
            {
                _input = input;
                _partTwo = partTwo;
            }

            State ExecuteInstruction(State state, Instruction instruction) => _partTwo switch
            {
                false => instruction switch
                {
                    { Operation: "N" } => state with { Coordinates = MoveInDirection(Math.PI / -2d, instruction.Value) },
                    { Operation: "S" } => state with { Coordinates = MoveInDirection(Math.PI / 2d, instruction.Value) },
                    { Operation: "E" } => state with { Coordinates = MoveInDirection(0, instruction.Value) },
                    { Operation: "W" } => state with { Coordinates = MoveInDirection(Math.PI, instruction.Value) },
                    { Operation: "F" } => state with { Coordinates = MoveInDirection(state.Facing, instruction.Value) },
                    var x when x.Operation is "L" || x.Operation is "R" => state with { Facing = RotateBoat(state.Facing, instruction.Value, _degreesToRads[instruction.Operation]) },
                    _ => throw new ArgumentOutOfRangeException(nameof(instruction))
                },
                true => instruction switch
                {
                    { Operation: "N" } => state with { Waypoint = state.Waypoint with { X = state.Waypoint.X, Y = state.Waypoint.Y - instruction.Value } },
                    { Operation: "S" } => state with { Waypoint = state.Waypoint with { X = state.Waypoint.X, Y = state.Waypoint.Y + instruction.Value } },
                    { Operation: "E" } => state with { Waypoint = state.Waypoint with { X = state.Waypoint.X + instruction.Value, Y = state.Waypoint.Y } },
                    { Operation: "W" } => state with { Waypoint = state.Waypoint with { X = state.Waypoint.X - instruction.Value, Y = state.Waypoint.Y } },
                    { Operation: "F" } => state with { Coordinates = (state.Coordinates.x + state.Waypoint.X * instruction.Value, state.Coordinates.y + state.Waypoint.Y * instruction.Value) },
                    var x when x.Operation is "L" || x.Operation is "R" => state with { Waypoint = RotateWaypoint(state.Waypoint, instruction.Value * _degreesToRads[instruction.Operation]) },
                    _ => throw new ArgumentOutOfRangeException(nameof(instruction))
                }
            };


            private (double x, double y) MoveInDirection(double angle, double val) => 
                (val * Math.Cos(angle) + State.Coordinates.x, val * Math.Sin(angle) + State.Coordinates.y);

            private double RotateBoat(double currentAngle, int val, double angle) => currentAngle + val * angle;

            private Waypoint RotateWaypoint(Waypoint waypoint, double angle) => waypoint with
            { X = Math.Cos(angle) * waypoint.X - Math.Sin(angle) * waypoint.Y, Y = (Math.Sin(angle) * waypoint.X + Math.Cos(angle) * waypoint.Y) };

            private double Manhattan(double a, double b) => Math.Abs((int)Math.Round(a, 0)) + Math.Abs((int)Math.Round(b, 0));

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
