using Microsoft.AspNetCore.SpaServices.AngularCli; // Додайте цей using

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Додайте підтримку контролерів для вашого API (якщо ви використовуєте контролери).
            builder.Services.AddControllersWithViews();

            // *** КЛЮЧОВІ РЯДКИ ДЛЯ SPA ***
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });
            // ****************************

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseSpaStaticFiles(); // У продакшн-середовищі, обслуговуйте зібрані статичні файли SPA.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Дозволяє подавати файли з wwwroot, наприклад, favicon.ico

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            // *** КЛЮЧОВИЙ РЯДОК ДЛЯ SPA З ВИПРАВЛЕНИМ ШЛЯХОМ ***
            app.UseSpa(spa =>
            {
                // Вказує, де знаходяться вихідні файли вашого Angular-проекту (там, де package.json).
                // ПОТРІБНО ВИПРАВИТИ ЦЕЙ ШЛЯХ ЗГІДНО З ВАШОЮ СТРУКТУРОЮ ПАПОК.
                // Припустимо, що структура така:
                // E:\Films\
                //   backend\
                //     WebApplication2\
                //       WebApplication2\ (це ваш поточний Content root path)
                //   fronend\ (це ваш Angular-проект)
                spa.Options.SourcePath = "../../../fronend"; // <--- ЦЕЙ РЯДОК МАЄ БУТИ ЗМІНЕНИМ!


                if (app.Environment.IsDevelopment())
                {
                    // Закоментуйте або видаліть цей рядок, оскільки він намагається запустити npm:
                    // spa.UseAngularCliServer(npmScript: "start");

                    // ДОДАЙТЕ ЦЕЙ РЯДОК, вказавши URL, на якому слухає ваш вручну запущений Angular-сервер:
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // Переконайтеся, що порт (4200) співпадає з тим, що показує npm start
                }
            });
            // ****************************

            app.Run();
        }
    }
}