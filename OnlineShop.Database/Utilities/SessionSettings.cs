using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            if (_http.HttpContext.Session.GetString(SessionKeyName) == null)
            {
                if (!string.IsNullOrWhiteSpace(_http.HttpContext.User.Identity.Name))
                {
                    _http.HttpContext.Session.SetString(SessionKeyName, _http.HttpContext.User.Identity.Name);
                }
                else
                {
                    _http.HttpContext.Session.SetString(SessionKeyName, Guid.NewGuid().ToString());
                }
            }

            _http.HttpContext.Session.SetInt32(SessionKeyAge, 773);
            return _http.HttpContext.Session.GetString(SessionKeyName);


        }
    }
}
//    if (_http.HttpContext.User.Identity.IsAuthenticated)
//    {
//        string id = SessionKeyName+"_"+_http.HttpContext.User.Identity.Name;
//        _http.HttpContext.Session.SetString(SessionKeyName, id);
//        _http.HttpContext.Session.SetInt32(SessionKeyAge, 773);

//        return _http.HttpContext.Session.GetString(SessionKeyName);
//    }
//    else
//    {
//        _http.HttpContext.Session.SetString(SessionKeyName, Guid.NewGuid().ToString());
//        _http.HttpContext.Session.SetInt32(SessionKeyAge, 773);

//        return _http.HttpContext.Session.GetString(SessionKeyName);
//    }
