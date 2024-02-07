namespace BAIS3150_UI_Razor_Pages_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapRazorPages();

            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}