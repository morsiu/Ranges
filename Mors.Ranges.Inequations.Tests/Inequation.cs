﻿using System;
using System.Collections.Generic;

namespace Mors.Ranges.Inequations.Tests
{
    using Implementation = Inequations.Inequation;

    public readonly struct Inequation
    {
        private readonly Inequation<Point> _inequation;

        public Inequation(Inequation<Point> inequation) => _inequation = inequation;

        public static Inequation And(in Inequation first, in Inequation second) =>
            new Inequation(Implementation.And(first._inequation, second._inequation));

        public static Inequation Closure(in Inequation value) =>
            new Inequation(Implementation.Closure(value._inequation));

        public static Inequation Not(in Inequation value) =>
            new Inequation(Implementation.Not(value._inequation));

        public static Inequation Or(in Inequation first, in Inequation second) =>
            new Inequation(Implementation.Or(first._inequation, second._inequation));

        public static Inequation Equal(in Point value) =>
            new Inequation(Implementation.Equal(value));

        public static Inequation False() =>
            new Inequation(Implementation.False<Point>());

        public static Inequation LessThan(in Point value) =>
            new Inequation(Implementation.LessThan(value));

        public static Inequation LessThanOrEqualTo(in Point value) =>
            new Inequation(Implementation.LessThanOrEqualTo(value));

        public static Inequation GreaterThan(in Point value) =>
            new Inequation(Implementation.GreaterThan(value));

        public static Inequation GreaterThanOrEqualTo(in Point value) =>
            new Inequation(Implementation.GreaterThanOrEqualTo(value));

        public RangeUnion ToRangeUnion() => RangeUnion.FromInequation(_inequation);

        public override bool Equals(object obj) =>
            obj is Inequation inequation
            && EqualityComparer<Inequation<Point>>.Default.Equals(_inequation, inequation._inequation);

        public override int GetHashCode() =>
            HashCode.Combine(_inequation);

        public override string ToString() => _inequation.ToString();
    }
}