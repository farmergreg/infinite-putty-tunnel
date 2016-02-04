/**
 * Copyright (c) 2009, Joeri Bekker
 * Copyright (c) 2016, Gregory L. Dietsche
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;

namespace Infinite.PuTTY.Tunnel.Putty
{
    public class Tunnel
    {
        public Tunnel(string data)
        {
            switch (data[0])
            {
                case '6':
                    IpVersion = IpVersion.IPv6;
                    data = data.Substring(1);
                    break;
                case '4':
                    IpVersion = IpVersion.IPv4;
                    data = data.Substring(1);
                    break;
                default:
                    IpVersion = IpVersion.Auto;
                    break;
            }

            switch (data.Substring(0, 1))
            {
                case "L":
                    Type = TunnelType.Local;
                    break;
                case "R":
                    Type = TunnelType.Remote;
                    break;
                case "D":
                    Type = TunnelType.Dynamic;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var parts = data.Substring(1).Split('=');
            SourcePort = int.Parse(parts[0]);

            var dest = parts[1].Split(':');
            Destination = dest[0];
            if(Type != TunnelType.Dynamic)
                DestinationPort = int.Parse(dest[1]);
        }

        public IpVersion IpVersion { get; }

        public int SourcePort { get; }

        public string Destination { get; }
        public int DestinationPort { get; }

        public TunnelType Type { get; }

        public override string ToString()
        {
            switch (Type)
            {
                case TunnelType.Local:
                    return $"{IpVersion} {SourcePort:D4} ==> {Destination}:{DestinationPort:D4}";

                case TunnelType.Remote:
                    return $"{IpVersion} {SourcePort:D4} <== {Destination}:{DestinationPort:D4}";

                case TunnelType.Dynamic:
                    return $"{IpVersion} {SourcePort:D4} <==> *:*";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}