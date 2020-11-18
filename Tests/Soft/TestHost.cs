﻿//(c) - https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1

using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Context;
using Soft.Data;
using Util;

namespace Tests.Soft {

    public class TestHost<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class {

        private readonly Type[] dbContexts = new[] {
            typeof(ApplicationDbContext),
            typeof(StoreDbContext),
        };


        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            builder.ConfigureServices(s => {

                removeCurrentDb<ApplicationDbContext>(s);
                removeCurrentDb<StoreDbContext>(s);
                
                s.AddEntityFrameworkInMemoryDatabase();

                addInMemoryDb<ApplicationDbContext>(s);
                addInMemoryDb<StoreDbContext>(s);
               


                var sp = s.BuildServiceProvider();

                using (var scope = sp.CreateScope()) {

                    var scopedServices = scope.ServiceProvider;
                    ensureDbsAreCreated(scopedServices, dbContexts);
                }

                GetRepository.SetServiceProvider(sp);

            });
        }
        private static void ensureDbsAreCreated(IServiceProvider s, Type[] types) {
            foreach (var t in types) ensureDbIsCreated(s, t);
        }

        private static void ensureDbIsCreated(IServiceProvider s, Type t) {
            if (!(s.GetRequiredService(t) is DbContext db))
                throw new ApplicationException($"DBContext {t} not found");
            db.Database.EnsureCreated();

            if (!db.Database.IsInMemory())
                throw new ApplicationException($"DBContext {t} is not in memory");
        }

        private static void addInMemoryDb<T>(IServiceCollection s) where T : DbContext {
            s.AddDbContext<T>(o => { o.UseInMemoryDatabase("Tests"); });
        }

        private static void removeCurrentDb<T>(IServiceCollection s) where T : DbContext {
            var descriptor = s.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<T>));

            if (descriptor != null) { s.Remove(descriptor); }
        }


        public T GetContext<T>() where T : DbContext {
            var scope = Services.CreateScope();
            var s = scope.ServiceProvider;

            return s.GetRequiredService<T>();
        }

    }

}