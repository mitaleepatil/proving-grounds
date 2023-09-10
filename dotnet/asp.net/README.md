This challenge requires some basic understanding of ASP.NET and [minimal apis](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0).
It focuses primarily on scalability and performance.

- Create a minimal ASP.NET project using `dotnet new web` using dotnet 7.
- Add a new GET endpoint `app.MapGet("/{files}", ...)` to serve a zip file using the `Zip.Write()` function from the `zip.cs` file in this repo.
You may edit this file to your liking.
Make sure you pass on the `files` argument to `Zip.Write()` function.
- Set response content-type to "`application/octet-stream`" and the file download name to "`test.zip`".

The `Zip.Write()` function has some issues that aren't ideal in a server environment.
The error you will get at runtime gives you a hint at one of them.

- Correct the error so that the program will actually work.
- Improve the scalability of the solution by e.g.:
  - Enable request cancellation.
  - Ensure threads are not blocked/held up needlessly.
  - Ensure memory consumption per request is low.
- Put your code in a githib repo and share with us.

Be prepared to discuss the reasoning behind your approach and choices.
Also, discuss any issues and weakness that remain and how they could be addressed.
We're also interested in how you have or would have tested and benchmarked this solution to tease out problems, particularly those that pertain to scalability and performance.
