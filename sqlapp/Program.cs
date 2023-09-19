using sqlapp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://appconfig213.azconfig.io;Id=t+p0;Secret=coqHojPjjfA8+nYGAqINNTa4/F+M3Fn/F62h5BTXJbM=";
builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(connectionString);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
