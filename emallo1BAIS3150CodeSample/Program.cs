namespace emallo1BAIS3150CodeSample
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