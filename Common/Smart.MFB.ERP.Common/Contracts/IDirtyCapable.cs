﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart.MFB.ERP.Common.Contracts
{
    public interface IDirtyCapable
    {
        bool IsDirty { get; }

        bool IsAnythingDirty();

        List<IDirtyCapable> GetDirtyObjects();

        void CleanAll();
    }
}
