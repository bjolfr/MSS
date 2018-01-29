﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.WebService
{
    public interface IScenario
    {
        bool Run(object source, out object destination);
        Task<bool> RunAsync();
    }
}
