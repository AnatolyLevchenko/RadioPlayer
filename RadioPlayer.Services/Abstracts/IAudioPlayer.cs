namespace RadioPlayer.Services.Abstracts;

public interface IAudioPlayer
{
    Task PlayStreamAsync(string streamUrl);
    void StopStream();
    void SetVolume(float volume);
}