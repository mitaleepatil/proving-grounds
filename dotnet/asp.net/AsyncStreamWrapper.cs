namespace asp.net;

public class AsyncStreamWrapper : Stream
{
    public Stream _stream { get; set; }

    public AsyncStreamWrapper(Stream stream)
    {
        _stream = stream;
    }

    public override bool CanRead => _stream.CanRead;

    public override bool CanSeek => _stream.CanSeek;

    public override bool CanWrite => _stream.CanWrite;

    public override long Length => _stream.Length;

    public override long Position
    {
        get => _stream.Position;
        set => _stream.Position = value;
    }

    // called async method from sync method
    public override void Flush() => _stream.FlushAsync();

    public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

    public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

    public override void SetLength(long value) => _stream.SetLength(value);

    // called async method from sync method
    public override void Write(byte[] buffer, int offset, int count) => _stream.WriteAsync(buffer, offset, count);
}

