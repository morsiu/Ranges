﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using Mors.Ranges.Test.Support.RangeGeneration.Options;

namespace Mors.Ranges.Test.Support.RangeGeneration
{
    public sealed class PairsOfRangesOfKinds : IEnumerable<RangePair>
    {
        private readonly IEnumerable<Tuple<RangeKind, RangeKind>> _pairsOfRangeKinds;

        public PairsOfRangesOfKinds(IEnumerable<Tuple<RangeKind, RangeKind>> pairsOfRangeKinds)
        {
            _pairsOfRangeKinds = pairsOfRangeKinds;
        }

        public IEnumerator<RangePair> GetEnumerator()
        {
            foreach (var pairOfRangeKinds in _pairsOfRangeKinds)
            {
                var rangeAKind = pairOfRangeKinds.Item1;
                var rangeBKind = pairOfRangeKinds.Item2;
                foreach (var pair in GeneratePairs(rangeAKind, rangeBKind))
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static IEnumerable<RangePair> GeneratePairs(IEnumerable<Tuple<RangeKind, RangeKind>> pairsOfRangeKinds)
        {
            return new PairsOfRangesOfKinds(pairsOfRangeKinds);
        }

        private static IEnumerable<RangePair> GeneratePairs(RangeKind rangeAKind, RangeKind rangeBKind)
        {
            if (rangeAKind == RangeKind.NonEmpty && rangeBKind == RangeKind.NonEmpty)
                return new PairsOfNonEmptyRanges();
            return GenerateMixedPairs(rangeAKind, rangeBKind);
        }

        private static IEnumerable<RangePair> GenerateMixedPairs(RangeKind rangeAKind, RangeKind rangeBKind)
        {
            var aRanges = new RangesOfAKind(rangeAKind);
            foreach (var rangeA in aRanges)
            {
                var bRanges = new RangesOfAKind(rangeBKind);
                foreach (var rangeB in bRanges)
                {
                    yield return new RangePair(rangeA, rangeB);
                }
            }
        }
    }
}
