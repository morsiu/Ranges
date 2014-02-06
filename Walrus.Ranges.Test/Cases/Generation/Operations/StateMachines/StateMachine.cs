﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;
using System.Linq;
using Walrus.Ranges.Text;

namespace Walrus.Ranges.Test.Cases.Generation.Operations.StateMachines
{
    internal static class StateMachine
    {
        public static IRange<int> Execute(IRange<int> rangeA, IRange<int> rangeB, IReadOnlyCollection<State> states)
        {
            var rangePair = new PointSequencePair(
                PointSequence.FromRange(rangeA),
                PointSequence.FromRange(rangeB));
            var output = rangePair.Zip((pointA, pointB) => Execute(pointA, pointB, states));
            return output.ToRange();
        }

        private static PointType Execute(PointType pointA, PointType pointB, IReadOnlyCollection<State> states)
        {
            // TODO: Use StateCollection to do (inputA, intputB) => output
            var matchingState = states.First(state => state.Matches(pointA, pointB));
            return matchingState.Output;
        }
    }
}