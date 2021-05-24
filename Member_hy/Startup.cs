using Member_hy.Biz.ConsumptionView;
using Member_hy.Biz.MemberM;
using Member_hy.Biz.Users;
using Member_hy.Dao.ConsumptionView;
using Member_hy.Dao.IdCard;
using Member_hy.Dao.MemberM;
using Member_hy.Dao.Users;
using Member_hy.Entitys;
using Member_hy.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace member_hy
{
    public class Startup
    {
        private readonly IHostingEnvironment env;
        public Startup(IConfiguration configuration, IHostingEnvironment _env) 
        {
            env = _env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {




            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            /************************数据库配置开始***************************************/
            DbConfigurator.emrConnection = Configuration.GetConnectionString("EMR");
            string defConnection = Configuration.GetConnectionString("defConnection");
            DbConfigurator.SetConnection(defConnection);
            services.AddDbContext<MemberContext>(
              options => options.UseSqlServer(defConnection, opt => { opt.UseRowNumberForPaging(); })
            );
            /************************数据库配置结束***************************************/
            /************************业务服务注册开始***************************************/
            services.AddScoped<ICluberDao, CluberDaolmpl>();
            services.AddScoped<ICluberDaoService, CluberDaoServicelmpl>();
            services.AddScoped<ILoginDao, LoginDaolmpl>();
            services.AddScoped<ILoginDaoService, LoginDaoServiceImpl>();

            services.AddScoped<IdCardDao, IdCardDaoImpl>();
            services.AddScoped<IdCardDaoService, IdCardDaoServiceImpl>();

            services.AddScoped<IConsumptionViewDao, ConsumptionViewDaoImpl>();
            services.AddScoped<IConsumptionViewDaoService, ConsumptionViewDaoServiceImpl>();


            //session服务
            //services.AddSession();
            services.AddSession(options =>
            {
                //设置Session过期时间
                options.IdleTimeout = TimeSpan.FromHours(8);
                //options.Cookie.HttpOnly = true;
            });

            /************************业务服务注册结束***************************************/
            ServiceUtils.services = services;
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            //Session服务
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
