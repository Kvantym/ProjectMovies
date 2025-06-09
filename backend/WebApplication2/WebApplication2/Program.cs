using Microsoft.AspNetCore.SpaServices.AngularCli; // ������� ��� using

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ������� �������� ���������� ��� ������ API (���� �� ������������� ����������).
            builder.Services.AddControllersWithViews();

            // *** �����² ����� ��� SPA ***
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
                app.UseSpaStaticFiles(); // � ��������-����������, ������������ ����� ������� ����� SPA.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // �������� �������� ����� � wwwroot, ���������, favicon.ico

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            // *** �������� ����� ��� SPA � ����������� ������ ***
            app.UseSpa(spa =>
            {
                // �����, �� ����������� ������ ����� ������ Angular-������� (���, �� package.json).
                // ���в��� ��������� ��� ���� �ò��� � ����� ���������� �����.
                // ����������, �� ��������� ����:
                // E:\Films\
                //   backend\
                //     WebApplication2\
                //       WebApplication2\ (�� ��� �������� Content root path)
                //   fronend\ (�� ��� Angular-������)
                spa.Options.SourcePath = "../../../fronend"; // <--- ��� ����� ��� ���� �̲�����!


                if (app.Environment.IsDevelopment())
                {
                    // ������������ ��� ������� ��� �����, ������� �� ���������� ��������� npm:
                    // spa.UseAngularCliServer(npmScript: "start");

                    // ������� ��� �����, �������� URL, �� ����� ����� ��� ������ ��������� Angular-������:
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // �������������, �� ���� (4200) ������� � ���, �� ������ npm start
                }
            });
            // ****************************

            app.Run();
        }
    }
}