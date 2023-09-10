# To run locally

```shell
# Run server in seperate terminal
dotnet run

# On Windows, wget is available in Powershell
wget http://localhost:8080/download/10/test.zip

# To simualte different download speeds, use rate limit on client side
wget --limit-rate=1M http://localhost:8080/download/10/test.zip
```

# HTTP Request Abort

By client: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/use-http-context?view=aspnetcore-7.0#requestaborted

By server: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/use-http-context?view=aspnetcore-7.0#abort

# HTTP Response Compression

Ref: https://learn.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-7.0#response-compression

# Performance Testing

Ref: https://learn.microsoft.com/en-us/aspnet/core/test/load-tests?view=aspnetcore-7.0#third-party-tools
