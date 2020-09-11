using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Domain.Interfaces;
using System;

namespace OnlineShop.Infrastructure.Utilities
{
    public class SessionSettings : ISessionSettings
    {
        public SessionSettings(IHttpContextAccessor http)//wymagane wstrzykniecie obiektu w Service
        {
            _http = http;
        }
        public const string SessionKeyName = "_Cart";
        public const string SessionKeyAge = "773";
        private readonly IHttpContextAccessor _http;

        public string OnGet()
        {
            if (string.IsNullOrEmpty(_http.HttpContext.Session.GetString(SessionKeyName)))
            {
                _http.HttpContext.Session.SetString(SessionKeyName, Guid.NewGuid().ToString());
                _http.HttpContext.Session.SetInt32(SessionKeyAge, 773);
            }
            return _http.HttpContext.Session.GetString(SessionKeyName);
        }
    }
}