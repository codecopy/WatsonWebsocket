﻿using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;

namespace WatsonWebsocket
{
    internal class ClientMetadata
    { 
        internal string IpPort
        {
            get
            {
                return Ip + ":" + Port;
            }
        }

        internal string Ip;
        internal int Port;
        internal HttpListenerContext HttpContext;
        internal WebSocket Ws;
        internal WebSocketContext WsContext;
        internal readonly CancellationTokenSource TokenSource;
        internal readonly SemaphoreSlim SendLock = new SemaphoreSlim(1);
         
        internal ClientMetadata(HttpListenerContext httpContext, WebSocket ws, WebSocketContext wsContext, CancellationTokenSource tokenSource)
        {
            HttpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            Ws = ws ?? throw new ArgumentNullException(nameof(ws));
            WsContext = wsContext ?? throw new ArgumentNullException(nameof(wsContext));
            TokenSource = tokenSource ?? throw new ArgumentNullException(nameof(tokenSource)); 
            Ip = HttpContext.Request.RemoteEndPoint.Address.ToString();
            Port = HttpContext.Request.RemoteEndPoint.Port;
        } 
    }
}
