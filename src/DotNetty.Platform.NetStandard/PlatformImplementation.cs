﻿using DotNetty.Common.Internal;
using DotNetty.Common.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

// .NET Standard assembly
namespace DotNetty.Platform
{
    public class PlatformImplementation : IPlatform
    {
        int IPlatform.GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id;
        }

        byte[] IPlatform.GetDefaultDeviceID()
        {
            return MacAddressUtil.GetBestAvailableMac();
        }
    }
}