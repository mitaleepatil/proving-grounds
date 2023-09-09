var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/download/{filesCount}/test.zip", (int filesCount) =>
{
    var ms = new MemoryStream();
    Zip.Write(ms, filesCount);
    ms.Seek(0, SeekOrigin.Begin);
    return Results.Stream(ms, "application/octet-stream", "test.zip");
});

app.Run();