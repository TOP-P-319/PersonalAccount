using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

// Client -> Https -> Server -> Router(FS[Page.cshtml]) -> Page -> PageModel{OnGet/OnPost}
//                    Server -> Page.html + CSS + JS -> Client

// Client -> Https -> Server -> Router(FS[Controller.cs]) -> Controller -> Model
//                                                           Controller -> View
//                    Server -> View + CSS + JS -> Client

// Client -> Https -> Backend -> Controller -> Service -> Repository 
//                               Controller -> JSON -> Client
// Client -> Https -> Frontend
//                    Frontend -> HTML + CSS + JS -> Client