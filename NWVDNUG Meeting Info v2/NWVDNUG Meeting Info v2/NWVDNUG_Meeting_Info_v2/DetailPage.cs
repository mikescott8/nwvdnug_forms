using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin;
using Xamarin.Forms;
//using Xamarin.Forms.Maps;

namespace NWVDNUG_Meeting_Info_v2
{
    public class DetailPage
    {
        public static Page GetDetailPage(MeetingInfo meetingInfo)
        {
            var whoSection = new TableSection("Who")
            {
                new TextCell
                {
                    Text = string.Format("TextCell : {0}", meetingInfo.SpeakerName),
                },
                new EntryCell
                {
                    Label = "EntryCell",
                    Text = meetingInfo.SpeakerName,
                    IsEnabled = false
                },
                new EntryCell
                {
                    Text = "",
                    Placeholder="EntryCell",
                    IsEnabled = false
                },
            };
            var whatSection = new TableSection("What")
            {
                new TextCell
                {
                    Text = meetingInfo.Title + "TextCell",
                    Detail = meetingInfo.Location
                },
                new ImageCell()
                {
                    ImageSource = ImageSource.FromFile("icon.png"),
                    Text = meetingInfo.Title,
                    Detail = meetingInfo.Location
                },
                new ImageCell()
                {
                    ImageSource = ImageSource.FromFile("icon.png"),
                    Text = meetingInfo.Title,
                    Detail = meetingInfo.Location
                },
            };

            var whenSection = new TableSection("When")
            {
                new ImageCell()
                {
                    ImageSource = ImageSource.FromFile("icon.png"),
                    Text = meetingInfo.Title,
                    Detail = meetingInfo.Location
                },
            };
            //FormsMaps.Init();
            //var coder = new Geocoder();
            //var locCode = coder.GetPositionsForAddressAsync("5600 West Union Hills Rd, Glendale, AZ").Result;
            //Position locPos = new Position(locCode.First().Latitude, locCode.First().Longitude);
            //var mapCell = new ViewCell()
            //{
            //    View = new Map(new MapSpan(locPos, 5.0, 5.0))
            //    {
            //        HeightRequest = 100,
            //        HorizontalOptions = LayoutOptions.FillAndExpand,
            //        MapType = MapType.Hybrid,
            //        IsShowingUser = true,
            //    }
            //};
            var whereSection = new TableSection("Where");

            var tableRoot = new TableRoot("NWVDNUG Meeting Info")
            {
                whoSection,
                whatSection,
                whenSection,
                whereSection
            };

            return new ContentPage
            {
                Content = new TableView
                {
                    Intent = TableIntent.Form,
                    BindingContext=meetingInfo,
                    Root = tableRoot
                }
            };
        }
    }
}
