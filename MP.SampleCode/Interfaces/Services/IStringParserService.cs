﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.SampleCode.StringCalculator.Interfaces.Services
{
    public interface IStringParserService
    {
        int[] ParseAsArrayOfNumbers(string? input);
    }
}