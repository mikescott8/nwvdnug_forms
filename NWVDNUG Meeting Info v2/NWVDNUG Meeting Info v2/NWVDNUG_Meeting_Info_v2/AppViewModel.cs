using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace NWVDNUG_Meeting_Info_v2
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<MeetingInfo> Meetings { get; set; }
        public AppViewModel()
        {
            Meetings = new ObservableCollection<MeetingInfo>();
            SelectedMeeting = new MeetingInfo();
        }

        public AppViewModel(ObservableCollection<MeetingInfo> meetings, MeetingInfo selectedMeeting)
        {
            Meetings = meetings;
            _selectedMeeting = selectedMeeting;
        }

        private MeetingInfo _selectedMeeting;
        public MeetingInfo SelectedMeeting
        {
            get { return _selectedMeeting; }
            set { SetProperty(ref _selectedMeeting, value, "SelectedMeeting"); }
        }

        private Command _loadMeetingsCommand;
        public Command LoadMeetingsCommand
        {
            get { return _loadMeetingsCommand ?? (_loadMeetingsCommand = new Command(ExecuteLoadMeetingsCommand)); }
        }

        private const string MeetingsUrl = "http://nwvdnug.org/api/upcomingmeetings/";
        private async void ExecuteLoadMeetingsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Meetings.Clear();

                var client = new HttpClient();
                var json = await client.GetStringAsync(MeetingsUrl);

                var results = JsonConvert.DeserializeObject<List<MeetingInfo>>(json);
                foreach (var meeting in results)
                {
                    Meetings.Add(meeting);
                }
            }
            catch (Exception ex)
            {
                var page = new ContentPage();
                page.DisplayAlert("Error", "Unable to load Meetings.", "OK");
            }

            IsBusy = false;
        }
    }
}
