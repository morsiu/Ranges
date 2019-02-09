﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mors.Ranges.Generation
{
    public sealed class PairsOfOpenRangesOfAllPossibleRelations<TRange, TRangePair, TRanges, TRangePairs> : IEnumerable<TRangePair>
        where TRanges : IOpenRanges<TRange>
        where TRangePairs : IPairs<TRange, TRange, TRangePair>
    {
        public IEnumerator<TRangePair> GetEnumerator()
        {
            return new PairsOfClosedRangesOfAllPossibleRelations<IEnumerable<TRange>, IEnumerable<TRangePair>, Ranges, RangePairs>()
                .SelectMany(x => x)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private readonly struct Ranges : IClosedRanges<IEnumerable<TRange>>
        {
            public IEnumerable<TRange> Empty()
            {
                yield return default(TRanges).Empty();
            }

            public IEnumerable<TRange> Range(int start, int end)
            {
                var x = default(TRanges);
                yield return x.Range(start, end, isStartOpen: true, isEndOpen: true);
                yield return x.Range(start, end, isStartOpen: true, isEndOpen: false);
                yield return x.Range(start, end, isStartOpen: false, isEndOpen: true);
                yield return x.Range(start, end, isStartOpen: false, isEndOpen: false);
            }
        }
        
        private readonly struct RangePairs : IPairs<IEnumerable<TRange>, IEnumerable<TRange>, IEnumerable<TRangePair>>
        {
            public IEnumerable<TRangePair> Pair(IEnumerable<TRange> first, IEnumerable<TRange> second)
            {
                return first.SelectMany(x => second, (x, y) => default(TRangePairs).Pair(x, y));
            }
        }
    }
}
