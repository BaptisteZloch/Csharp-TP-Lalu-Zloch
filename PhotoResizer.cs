using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class PhotoResizer
{
    public int TargetWidth { get; set; } = 1024;
    public int TargetHeight { get; set; } = 1024;

    public void ResizeFromFolder(string folderPath)
    {
        this.ResizeSomeImages(System.IO.Directory.EnumerateFiles(folderPath, "*.*").ToArray());
    }

    public void ResizeSomeImages(string[] paths, bool parallel = true)
    {
        Console.WriteLine($"Image to process: {paths.Length}");
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        if (!parallel)
        {
            foreach (var path in paths)
            {
                this.ResizeAnImage(path);
            }
        }
        else
        {
            Parallel.ForEach(
                paths,
                path =>
                {
                    this.ResizeAnImage(path);
                }
            );
        }
        watch.Stop();
        Console.WriteLine($"Sequential execution Time: {watch.ElapsedMilliseconds} ms");
    }

    public void ResizeAnImage(string path)
    {
        var filename = path.Split("/").Last().Split(".").First();
        var extension = path.Split("/").Last().Split(".").Last();
        if (extension == "png" || extension == "jpg")
        {
            this.Resize(path, filename, extension);
        }
    }

    public void Resize(string path, string filename, string extension)
    {
        using (Image image = Image.Load(path))
        {
            image.Mutate(x => x.Resize(this.TargetWidth, this.TargetHeight));
            image.Save($"./resized_imgs/{filename}_resized.{extension}");
        }
    }
}
