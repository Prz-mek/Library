using Library.Core.Repisirories;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.ServiceInterfaces;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            services.AddScoped<IBorrowingService, BorrowingService>();

            services.AddScoped<IBranchLibraryRepository, BranchLibraryRepository>();
            services.AddScoped<IBranchLibraryService, BranchLibraryService>();

            services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            services.AddScoped<ILibrarianService, LibrarianService>();

            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IReaderService, ReaderService>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LibraryConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
