using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class PhotoResizer
{
    public void ResizedAnImage(string path)
    {
        var filename = path.Split("/").Last().Split(".").First();
        var extension = path.Split("/").Last().Split(".").Last();

        using (Image image = Image.Load(path))
        {
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
            image.Save($"./resized_imgs/{filename}_resized.{extension}");
        }
    }
}
