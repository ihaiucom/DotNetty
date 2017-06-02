﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DotNetty.Codecs.Http
{
    using DotNetty.Buffers;

    public interface IFullHttpResponse : IHttpResponse, IFullHttpMessage
    {
        IFullHttpResponse Replace(IByteBuffer content);
    }
}