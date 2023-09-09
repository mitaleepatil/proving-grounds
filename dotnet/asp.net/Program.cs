using asp.net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/download/{filesCount}/test.zip", async (int filesCount, HttpContext context, CancellationToken cancellationToken) =>
{
    context.Response.Headers.ContentDisposition = "attachment; filename=\"test.zip\"";
    // Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead
    // var stream = context.Response.Body;
    var stream = new AsyncStreamWrapper(context.Response.Body);
    await Zip.Write(stream, filesCount, cancellationToken);
});

app.Run();
