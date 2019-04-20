using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ViajaNetFullStackSr.Domain;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;

namespace ViajaNetFullStackSr.Infra
{
    public class CouchBaseRepository : ICouchBaseRepository
    {
        #region Fields

        private readonly ClientConfiguration _config;
        private readonly IConfiguration _configuration;

        #endregion

        #region Builder

        public CouchBaseRepository(IConfiguration configuration)
        {

            _configuration = configuration;

            _config = new ClientConfiguration() {
                Servers = new List<Uri>() {
                    new Uri(_configuration["UriCauchBase"])
                }
            };
        }

        #endregion

        #region Methods

        public List<Log> GetByFilter(string ip, string pageName)
        {
            IAuthenticator authenticator = new PasswordAuthenticator(
                _configuration["UserCauchbase"], 
                _configuration["PasswordCauchbase"]
            );

            _config.SetAuthenticator(authenticator);

            var cluster = new Cluster(_config);
            var bucket = cluster.OpenBucket("beer-sample2");
            var response = bucket.Query<Log>("SELECT id, ip, pageName, browserName, parameters FROM `beer-sample2` WHERE ip ='"+ip+"' and pageName = '"+pageName+"'");// WHERE brewery_id =\"Polar\"");//Get<Log>("21st_amendment_brewery_cafe");

            return response.Rows;
        }

        #endregion
    }
}
