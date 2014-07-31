using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NWVDNUG_Meeting_Info_v2
{
    public class App
    {
        public static Page GetMainPage()
        {
            return DetailPage.GetDetailPage(new MeetingInfo
            {
                SpeakerName = "Mike Hamilton",
                SpeakerBioLink = "http://www.mikescott8.me",
                Title = "Testing the various cells",
                Location="5600 West Union HIlls Rd, Glendale, AZ"
            });
            var vm = new AppViewModel();
            vm.LoadMeetingsCommand.Execute(null);

            var refresh = new Button
            {
                Text = "Refresh Data..."
            };
            refresh.SetBinding(Button.CommandProperty, "LoadMeetingsCommand");

            var countLabel = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "No Data"
            };
            countLabel.SetBinding(Label.TextProperty, "Meetings.Count");

            return new ContentPage
            {
                BindingContext= vm,
                Content = new StackLayout
                {
                    Padding = 3,
                    Spacing = 4,
                    Children =
                    {
                        new Label
                        {
                            Text = "Hello, Forms !",
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        },
                        refresh,
                        countLabel
                    }
                }
            };
        }
    }
}
