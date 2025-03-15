namespace RadioPlayer.Services.Abstracts;

public interface IAudioPlayer
{
    void PlayStream(string streamUrl);
    void StopStream();
}