﻿#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Tests
{
  [TestFixture]
  public abstract class TestFixtureBase
  {
    [SetUp]
    protected void TestSetup()
    {
      //CultureInfo turkey = CultureInfo.CreateSpecificCulture("tr");
      //Thread.CurrentThread.CurrentCulture = turkey;
      //Thread.CurrentThread.CurrentUICulture = turkey;
    }

    protected void WriteEscapedJson(string json)
    {
      Console.WriteLine(EscapeJson(json));
    }

    protected string EscapeJson(string json)
    {
      return @"@""" + json.Replace(@"""", @"""""") + @"""";
    }

    protected string GetOffset(DateTime d, DateFormatHandling dateFormatHandling)
    {
      StringWriter sw = new StringWriter();
      JsonConvert.WriteDateTimeOffset(sw, DateTime.SpecifyKind(d, DateTimeKind.Local).GetUtcOffset(), dateFormatHandling);
      sw.Flush();

      return sw.ToString();
    }
  }
}
