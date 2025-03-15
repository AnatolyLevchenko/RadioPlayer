using NAudio.Wave;
using Polly.Retry;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer.Services;

public class AudioPlayer(AsyncRetryPolicy retryPolicy) : IAudioPlayer
{
    private WaveOutEvent? _waveOut;
    private MediaFoundationReader? _mediaReader;

    public async Task PlayStreamAsync(string streamUrl)
    {
        try
        {
            StopStream();
            await retryPolicy.ExecuteAsync(async () =>
            {
                await Task.Run(() =>
                {
                    StopStream();
                    _mediaReader = new MediaFoundationReader(streamUrl);
                    _waveOut = new WaveOutEvent();
                    _waveOut.Init(_mediaReader);
                    _waveOut.Play();
                });
            });

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while trying to play the audio stream.", ex);
        }
    }

    public void StopStream()
    {
        _waveOut?.Stop();
        _waveOut?.Dispose();
        _mediaReader?.Dispose();
    }

    public void SetVolume(float volume)
    {
        if (_waveOut != null)
        {
            _waveOut.Volume = Math.Max(0.0f, Math.Min(1.0f, volume));
        }
    }
}