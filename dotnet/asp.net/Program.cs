using asp.net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();



app.MapGet("/download/{filesCount}/test.zip", async (int filesCount, HttpContext context, CancellationToken cancellationToken) =>
{
    context.Response.Headers.ContentDisposition = "attachment; filename=\"test.zip\"";
    context.Response.Headers.ContentType = "application/octet-stream";
    // Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead
    var stream = context.Response.Body;
    //var stream = new AsyncStreamWrapper(context.Response.Body);

    await Zip.Write(stream, filesCount, cancellationToken);

});

app.Run();
