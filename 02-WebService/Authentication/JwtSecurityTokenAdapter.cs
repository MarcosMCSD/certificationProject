﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

namespace _02_WebService.Authentication
{
    public class JwtSecurityTokenAdapter
    {
        private readonly JwtSecurityToken _inner;

        public JwtSecurityTokenAdapter(string tokenData)
        {
            _inner = new JwtSecurityToken(tokenData);
        }

        public string SignatureAlgorithm
        {
            get { return _inner.SignatureAlgorithm; }
        }

        public string RawData
        {
            get { return _inner.RawData; }
        }
    }
}