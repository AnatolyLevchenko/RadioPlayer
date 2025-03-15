using NAudio.Wave;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer.Services;

public class AudioPlayer : IAudioPlayer
{
    private WaveOutEvent? _waveOut;
    private MediaFoundationReader? _mediaReader;

    public void PlayStream(string streamUrl)
    {
        StopStream();
        _mediaReader = new MediaFoundationReader(streamUrl);
        _waveOut = new WaveOutEvent();
        _waveOut.Init(_mediaReader);
        _waveOut.Play();
    }

    public void StopStream()
    {
        _waveOut?.Stop();
        _waveOut?.Dispose();
        _mediaReader?.Dispose();
    }
}