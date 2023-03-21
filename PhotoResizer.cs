using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class PhotoResizer
{
    public void ResizeFromFolder(string folderPath)
    {
        this.ResizeSomeImages(System.IO.Directory.EnumerateFiles(folderPath, "*.*").ToArray());
    }

    public void ResizeSomeImages(string[] paths, bool parallel = true)
    {
        Console.WriteLine($"Image to process: {paths.Length}");
        var watch = new System.Diagnostics.Stopwatch();

        if (!parallel)
        {
            watch.Start();
            foreach (var path in paths)
            {
                this.ResizeAnImage(path);
            }
            watch.Stop();
            Console.WriteLine($"Sequential execution Time: {watch.ElapsedMilliseconds} ms");
        }
        else
        {
            watch.Start();
            Parallel.ForEach(
                paths,
                path =>
                {
                    this.ResizeAnImage(path);
                }
            );
            watch.Stop();
            Console.WriteLine($"Parallel execution Time: {watch.ElapsedMilliseconds} ms");
        }
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

    public void Resize(string path, string filename, string extension, int factor = 2)
    {
        using (Image image = Image.Load(path))
        {
            image.Mutate(x => x.Resize(image.Width / factor, image.Height / factor));
            image.Save($"./resized_imgs/{filename}_resized.{extension}");
        }
    }
}
