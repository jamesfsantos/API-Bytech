using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Services;
using Microsoft.EntityFrameworkCore; // Ou o nome exato do namespace onde está seu AppDbContext

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IPedidoVendaService, PedidoVendaService>();
builder.Services.AddScoped<IServicoManutencaoService, ServicoManutencaoService>();
builder.Services.AddScoped<IItemVendaService, ItemVendaService>();
builder.Services.AddScoped<ICampanhaEmailService, CampanhaEmailService>();
builder.Services.AddScoped<IMensagensContatoService, MensagensContatoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("PoliticaCors", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

var app = builder.Build();

app.UseCors("PoliticaCors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
    
app.UseAuthorization();

app.MapControllers();

app.Run();
