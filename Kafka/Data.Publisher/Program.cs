using Confluent.Kafka;
using Data.Publisher;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};
builder.Services.AddSingleton<IProducer<Null, string>>( x => new ProducerBuilder<Null, string>(config).Build());
builder.Services.AddSingleton<IPublisher, Publisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
