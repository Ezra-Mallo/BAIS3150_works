namespace BAIST3150ASPNETCoreEmpty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Services to the container
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // commented out app.MapGet("/", () => "Hello World!");

            // Configure the HTTP request pipeline
            app.UseStaticFiles();  //  add for wwroot
            app.UseRouting();
            app.MapRazorPages();



            app.Run();
        }
    }
}