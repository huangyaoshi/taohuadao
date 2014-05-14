using WMPLib;

namespace ConsoleApplication1
{
    public static class MediaHelper
    {
        public static void Play(string file)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            wmp.currentMedia = wmp.newMedia(file);
            wmp.controls.currentPosition = 600;
            wmp.controls.play();
        }
    }
}
