using RadioPlayer.Domain;
using RadioPlayer.Services.Abstracts;

namespace RadioPlayer;

public partial class MainForm : Form
{
    private const string DefaultTitle = "Audio Player";
    private readonly IRadioService _radioService;
    private readonly IAudioPlayer _audioPlayer;

    private const string FailedToLoadCountries = "Failed to load countries.Click on me to reload...";
    private const string FailedToLoadStationList = "Failed to loading station list.Click on me to reload...";

    public MainForm(IRadioService radioService, IAudioPlayer audioPlayer)
    {
        _radioService = radioService;
        _audioPlayer = audioPlayer;
        InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        await LoadCountries();
    }

    private async Task LoadCountries()
    {
        cbCountries.Items.Add("Loading...");
        cbCountries.SelectedIndex = 0;

        try
        {

            var countries = await _radioService.GetCountriesAsync();
            cbCountries.Items.Clear();
            cbCountries.DataSource = countries;
        }
        catch (Exception)
        {
            cbCountries.Items.Clear();
            cbCountries.Items.Add(FailedToLoadCountries);
        }
    }

    private async void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbCountries.SelectedItem is FailedToLoadCountries)
        {
            await LoadCountries();
            return;
        }

        await LoadStations();
    }

    private async Task LoadStations()
    {

        if (cbCountries.SelectedItem is Country selectedCountry)
        {
            lbStations.DataSource = new List<string> { "Loading Stations..." };

            try
            {
                var stations = await _radioService.GetStationsByCountryAsync(selectedCountry.Name);
                lbStations.DataSource = stations;
                lbStations.DisplayMember = "Name";
            }
            catch (Exception)
            {
                lbStations.DataSource = new List<string> { FailedToLoadStationList };
            }
        }
    }


    private async void btnPlay_Click(object sender, EventArgs e)
    {
        await PlayStation();
    }

    private async Task PlayStation()
    {
        if (lbStations.SelectedItem is not RadioStation selectedStation) return;

        try
        {
            await _audioPlayer.PlayStreamAsync(selectedStation.Url);
            var country = cbCountries.SelectedItem as Country;
            SetTitle($"{selectedStation.Name} | {country?.Name}");
            await SetTitleStation(selectedStation);
        }
        catch (Exception exception)
        {
            ErrorHelper.ShowError($"Cannot play the stream {selectedStation.Url}. {exception.Message}");
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        _audioPlayer.StopStream();
        SetTitle(DefaultTitle);
    }

    private void cbVolumeSlider_VolumeChanged(object sender, EventArgs e)
    {
        _audioPlayer.SetVolume(cbVolumeSlider.Volume);

    }

    private void SetTitle(string data)
    {
        lbTitle.Text = $"Playing: {data}";
    }

    private async Task SetTitleStation(RadioStation radioStation)
    {
        try
        {
            if (pbLogo.Image != null)
            {
                var oldImage = pbLogo.Image;
                pbLogo.Image = null;
                oldImage.Dispose();
            }

            var imageBytes = await _radioService.DownloadIconFromUrlAsync(radioStation.Favicon);
            if (imageBytes is { Length: > 0 })
            {
                using var stream = new MemoryStream(imageBytes);
                using var tempImage = Image.FromStream(stream);
                pbLogo.Image = new Bitmap(tempImage); // Clone image to avoid GDI+ errors
                lblNoLogo.Visible = false;
            }
            else
            {
                pbLogo.Image = null;
                lblNoLogo.Visible = true;
            }
        }
        catch (Exception)
        {
            pbLogo.Image = null;
            lblNoLogo.Visible = true;
        }
    }

    private async void lbStations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lbStations.SelectedItem is FailedToLoadStationList)
        {
            await LoadStations();
        }

    }

    private async void lbStations_DoubleClick(object sender, EventArgs e)
    {
        if (lbStations.SelectedItem != null)
        {
            await PlayStation();
        }
    }
}