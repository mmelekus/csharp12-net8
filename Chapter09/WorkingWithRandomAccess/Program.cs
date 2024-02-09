﻿using Microsoft.Win32.SafeHandles; // To use SafeFileHandle.
using System.Text; // To use Encoding.

// Write to random access file using SafeFileHandle.
using SafeFileHandle handle = File.OpenHandle(path: "coffee.txt", mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite);
string message = "Café £4.39";
ReadOnlyMemory<byte> buffer = new(Encoding.UTF8.GetBytes(message));
await RandomAccess.WriteAsync(handle, buffer, fileOffset: 0);

// Read from random access file using SafeFileHandle.
long length = RandomAccess.GetLength(handle);
Memory<byte> contentBytes = new(new byte[length]);
await RandomAccess.ReadAsync(handle, contentBytes, fileOffset: 0);
string content = Encoding.UTF8.GetString(contentBytes.ToArray());
Console.WriteLine($"Content of file: {content}");