using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class PhotoResizer
{
    public void ResizeAnImage(string path)
    {
        var filename = path.Split("/").Last().Split(".").First();
        var extension = path.Split("/").Last().Split(".").Last();

        this.Resize(path, filename, extension);
    }

    public void ResizeSomeImages(string[] paths)
    {
        Parallel.ForEach(
            paths,
            path =>
            {
                var filename = path.Split("/").Last().Split(".").First();
                var extension = path.Split("/").Last().Split(".").Last();

                this.Resize(path, filename, extension);
            }
        );
    }

    public void Resize(string path, string filename, string extension)
    {
        using (Image image = Image.Load(path))
        {
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
            image.Save($"./resized_imgs/{filename}_resized.{extension}");
        }
    }
}
