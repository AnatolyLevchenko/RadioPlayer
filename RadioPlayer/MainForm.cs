using RadioPlayer.Domain;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer;

public partial class MainForm : Form
{
    private readonly IRadioService _radioService;
    private readonly IAudioPlayer _audioPlayer;

    public MainForm(IRadioService radioService, IAudioPlayer audioPlayer)
    {
        _radioService = radioService;
        _audioPlayer = audioPlayer;
        InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        cbCountries.DataSource = await _radioService.GetCountriesAsync();
    }

    private async void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbCountries.SelectedItem is Country selectedCountry)
        {
            var stations = await _radioService.GetStationsByCountryAsync(selectedCountry.Name);
            lbStations.DataSource = stations;
        }
    }

    private async void btnPlay_Click(object sender, EventArgs e)
    {
        if (lbStations.SelectedItem is not RadioStation selectedStation) return;

        try
        {
            await _audioPlayer.PlayStreamAsync(selectedStation.Url);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"Cannot play the strem {selectedStation.Url}. {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    private void btnStop_Click(object sender, EventArgs e)
    {
        _audioPlayer.StopStream();
    }

    private void cbVolumeSlider_VolumeChanged(object sender, EventArgs e)
    {
        _audioPlayer.SetVolume(cbVolumeSlider.Volume);
 
    }
}