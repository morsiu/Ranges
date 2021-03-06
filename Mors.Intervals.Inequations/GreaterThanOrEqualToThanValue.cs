﻿using System;
using System.Collections.Generic;

namespace Mors.Intervals.Inequations
{
    internal sealed class GreaterThanOrEqualToValue<T> : IInequation<T>
        where T : IComparable<T>
    {
        private readonly T _value;

        public GreaterThanOrEqualToValue(in T value) => _value = value;

        public IEnumerable<T> Boundaries() => new SingleBoundary<T>(_value);

        public override bool Equals(object obj) =>
            obj is GreaterThanOrEqualToValue<T> value
            && EqualityComparer<T>.Default.Equals(_value, value._value);

        public override int GetHashCode() =>
            -1939223833 + EqualityComparer<T>.Default.GetHashCode(_value);

        public bool IsSatisfiedBy(in T value) => value.CompareTo(_value) >= 0;

        public override string ToString() => $"x ≥ {_value}";
    }
}
