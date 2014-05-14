﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;

namespace Walrus.Ranges.Test.Support.RangeGeneration.Options
{
    [Flags]
    internal enum RangeRelations
    {
        None = 0,
        ABeforeB = 1,
        ABeforeBTouching = 2,
        ABeforeBIntersecting = 4,
        ASpanningB = 8,
        AAfterBIntersecting = 16,
        AAfterBTouching = 32,
        AAfterB = 64,
        ACoversBTouchingLeft = 128,
        ACoversB = 256,
        ACoversBTouchingRight = 512,
        AInsideBTouchingLeft = 1024,
        AInsideB = 2048,
        AInsideBTouchingRight = 4096,
        All = 8191
    }
}