using System.IO.Compression;

public static class Zip
{
    // Write a zip file with specified number of files of 1MiB each with random content.
    public static async Task Write(Stream stream, int files, CancellationToken cancellationToken = default)
    {
        var seed = 123;
        var rnd = new Random(seed);
        // set leaveOpen to true to not close stream on disposing ZipArchive
        using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true))
        {
            var buffer = new byte[0x100000];
            for (var i = 0; i < files; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                rnd.NextBytes(buffer);
                var name = i.ToString();
                var entry = archive.CreateEntry(name);
                using (var entryStream = entry.Open())
                {
                    await entryStream.WriteAsync(buffer);
                }
                Console.WriteLine($"added zip entry {i}");
                // added delay to test request cancellation
                await Task.Delay(1000);
            }
        }
    }
}
