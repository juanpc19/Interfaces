using ServidorSignalIR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();//añade el servicio de SignalR

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");
app.MapHub<ChatHub>("/chatHub2");
app.MapHub<ChatHub>("/chatHub3");
app.MapHub<ChatHub>("/chatHub4");//añade el chathub al mapahub de la aplicacion, para que se pueda acceder a el mediante endpoint

app.Run();
