using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIzzaMore.Utility
{
    public interface ICookieCollection : IEnumerable<Cookie>
    {
        void AddCookie(Cookie cookie);

        void RemoveCookie(string cookieName);

        bool ContainsCookie(string key);

        int Count { get; }

        Cookie this[string key] { get; set; }
    }
}
