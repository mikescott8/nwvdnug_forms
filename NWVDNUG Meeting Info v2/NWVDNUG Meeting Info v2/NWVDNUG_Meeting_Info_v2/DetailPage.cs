using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NWVDNUG_Meeting_Info_v2
{
    public class DetailPage
    {
        public static Page GetDetailPage(MeetingInfo meetingInfo)
        {
            return new ContentPage
            {
                Content = new TableView
                {
                    Intent = TableIntent.Form,
                    BindingContext=meetingInfo,
                    Root = new TableRoot("NWVDNUG Meeting Info")
                    {
                        new TableSection("Who")
                        {
                            new TextCell
                            {
                                Text = "Speaker",
                            },
                            new EntryCell
                            {
                                Label = "Speaker Name",
                                Text = meetingInfo.SpeakerName,
                                IsEnabled = false,
                            }
                        }
                    }
                }
            };
        }
    }
}
