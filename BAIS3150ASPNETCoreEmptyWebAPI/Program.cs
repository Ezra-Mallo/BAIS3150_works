namespace BAIS3150ASPNETCoreEmptyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add services ti the container
            builder.Services.AddControllers();


            var app = builder.Build();

            //confirgure he HTTP request pipelin
            app.UseRouting();   
            app.MapControllers();

           


            app.Run();
        }
    }
}