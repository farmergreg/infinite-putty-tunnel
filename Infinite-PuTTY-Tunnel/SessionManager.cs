/**
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

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Infinite.PuTTY.Tunnel.Properties;
using Infinite.PuTTY.Tunnel.Putty;

namespace Infinite.PuTTY.Tunnel
{
    internal class SessionManager
    {
        private IList<PlinkSession> _sessions = new List<PlinkSession>();

        internal IEnumerable<PlinkSession> Sessions
        {
            get
            {
                //We keep the active session objects and merge that list with the list of all available sessions.
                //This way we don't loose our active sessions and we are able to show the user the most up-to-date
                //list of sessions available in putty.
                var enabled = _sessions.Where(s => s.IsEnabled).ToList();
                var inactive = Putty.Putty.AvaiableSessions.Where(avail => enabled.All(a => a.Name != avail.Name));
                _sessions = enabled.Union(inactive).ToList();
                return _sessions;
            }
        }

        internal void SaveEnabledTunnels()
        {
            Settings.Default.ActiveTunnels = new StringCollection();
            foreach (var curTunnel in Sessions.Where(s => s.IsEnabled).Select(s => s.Name).ToList())
            {
                Settings.Default.ActiveTunnels.Add(curTunnel);
            }
            Settings.Default.Save();
        }
    }
}