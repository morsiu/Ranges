﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Mors.Intervals.Inequations.Tests.Inequation;
using static Mors.Intervals.Inequations.Tests.OpenInterval;

namespace Mors.Intervals.Inequations.Tests
{
    public class Intervals_and_inequations
    {
        private static IEnumerable<(OpenIntervalUnion IntervalUnion, Inequation Inequation)> EquivalentIntervalsAndInequations()
        {
            yield return (
                Closed(1, 1),
                Equal(1));
            yield return (
                Closed(1, 3),
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(3)));
            yield return (
                Open(1, 3),
                And(
                    GreaterThan(1),
                    LessThan(3)));
            yield return (
                LeftOpen(1, 3),
                And(
                    GreaterThan(1),
                    LessThanOrEqualTo(3)));
            yield return (
                RightOpen(1, 3),
                And(
                    GreaterThanOrEqualTo(1),
                    LessThan(3)));
            yield return (
                Empty(),
                False());
            yield return (
                Union(
                    Closed(1, 3),
                    Closed(5, 7)),
                Or(
                    And(
                        GreaterThanOrEqualTo(1),
                        LessThanOrEqualTo(3)),
                    And(
                        GreaterThanOrEqualTo(5),
                        LessThanOrEqualTo(7))));
            yield return (
                Union(
                    RightOpen(1, 3),
                    LeftOpen(3, 5)),
                Or(
                    And(
                        GreaterThanOrEqualTo(1),
                        LessThan(3)),
                    And(
                        GreaterThan(3),
                        LessThanOrEqualTo(5))));
        }

        public static IEnumerable<(Inequation Inequation, OpenIntervalUnion IntervalUnion)> InequationsEquivalentToIntervals()
        {
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(1)),
                Closed(1, 1));
            yield return (
                And(
                    GreaterThan(1),
                    LessThan(1)),
                Empty());
            yield return (
                And(
                    GreaterThan(1),
                    LessThanOrEqualTo(1)),
                Empty());
            yield return (
                And(
                    LessThan(1),
                    GreaterThanOrEqualTo(1)),
                Empty());
            yield return (
                And(
                    GreaterThan(1),
                    LessThan(2)),
                Empty());
            yield return (
                Not(
                    LessThanOrEqualTo(1)),
                LeftOpen(1, Point.Maximum));
            yield return (
                Not(
                    LessThan(1)),
                Closed(1, Point.Maximum));
            yield return (
                Not(
                    GreaterThanOrEqualTo(1)),
                RightOpen(Point.Minimum, 1));
            yield return (
                Not(
                    GreaterThan(1)),
                Closed(Point.Minimum, 1));
            yield return (
                Not(
                    False()),
                Closed(Point.Minimum, Point.Maximum));
            yield return (
                Not(
                    Equal(1)),
                Union(
                    RightOpen(Point.Minimum, 1),
                    LeftOpen(1, Point.Maximum)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(6)),
                Union(
                    Closed(1, 3),
                    Closed(4, 6)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(5)),
                Union(
                    Closed(1, 3),
                    Closed(3, 5)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(5)),
                Union(
                    RightOpen(1, 3),
                    Closed(3, 5)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(5)),
                Union(
                    Closed(1, 3),
                    LeftOpen(3, 5)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(5)),
                Union(
                    Closed(1, 4),
                    Closed(3, 5)));
            yield return (
                And(
                    GreaterThanOrEqualTo(1),
                    LessThanOrEqualTo(5)),
                Union(
                    Closed(1, 3),
                    Closed(4, 5)));
            yield return (
                Closure(
                    Equal(1)),
                Closed(1, 1));
            yield return (
                Closure(
                    Or(
                        And(
                            GreaterThanOrEqualTo(1),
                            LessThanOrEqualTo(3)),
                        And(
                            GreaterThanOrEqualTo(5),
                            LessThanOrEqualTo(7)))),
                Closed(1, 7));
            yield return (
                Closure(
                    And(
                        GreaterThanOrEqualTo(1),
                        LessThanOrEqualTo(3))),
                Closed(1, 3));
            yield return (
                Closure(
                    And(
                        GreaterThan(1),
                        LessThanOrEqualTo(3))),
                LeftOpen(1, 3));
            yield return (
                Closure(
                    And(
                        GreaterThanOrEqualTo(1),
                        LessThan(3))),
                RightOpen(1, 3));
            yield return (
                Closure(
                    And(
                        GreaterThan(1),
                        LessThan(3))),
                Open(1, 3));
            yield return (
                Closure(
                    False()),
                Empty());
            yield return (
                Closure(
                    Not(
                        False())),
                Closed(Point.Minimum, Point.Maximum));
       }

        [Theory]
        [MemberData(nameof(InequationsEquivalentToIntervalUnions))]
        public void Inequation_is_equivalent_to_interval_union(in Inequation inequation, in OpenIntervalUnion intervalUnion)
        {
            Assert.Equal(intervalUnion, inequation.ToOpenIntervalUnion());
        }

        public static IEnumerable<object[]> InequationsEquivalentToIntervalUnions()
        {
            return EquivalentIntervalsAndInequations().Select(a => new object[] { a.Inequation, a.IntervalUnion })
                .Concat(InequationsEquivalentToIntervals().Select(a => new object[] { a.Inequation, a.IntervalUnion }));
        }

        [Theory]
        [MemberData(nameof(IntervalsUnionsEquivalentToInequations))]
        public void Interval_union_is_equivalent_to_inequation(in OpenIntervalUnion intervalUnion, in Inequation inequation)
        {
            Assert.Equal(inequation, intervalUnion.ToInequation());
        }

        public static IEnumerable<object[]> IntervalsUnionsEquivalentToInequations()
        {
            return EquivalentIntervalsAndInequations().Select(a => new object[] { a.IntervalUnion, a.Inequation });
        }
    }
}