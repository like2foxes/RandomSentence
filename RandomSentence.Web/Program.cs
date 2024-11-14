using Microsoft.EntityFrameworkCore;
using RandomSentence.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/sentence", GetRandomSentence).WithOpenApi();

app.MapPost("/sentence", (string sentence, AppDbContext ctx) =>
{
    var s = new Sentence(sentence);
    ctx.Add(s);
    ctx.SaveChanges();
    return TypedResults.Created();
}).WithOpenApi();
app.Run();

static async Task<IResult>GetRandomSentence(AppDbContext ctx)
{
    int count = await ctx.Sentences.CountAsync();
    Random random = new Random();
    int num = random.Next(0, count);
    var sentence = await ctx.Sentences.ElementAtAsync(num);
    if (sentence is not null)
    {
        return TypedResults.Ok(sentence);
    }
    return TypedResults.NoContent();
};
