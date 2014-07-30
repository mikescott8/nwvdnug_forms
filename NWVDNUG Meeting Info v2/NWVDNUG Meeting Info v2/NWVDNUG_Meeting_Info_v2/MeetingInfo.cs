using System;
using System.Collections.Generic;
using System.Linq;

namespace NWVDNUG_Meeting_Info_v2
{
    public class MeetingInfo : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, "Title"); }
        }
        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value, "Notes"); }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value, "Location"); }
        }
        private string _speakerName;
        public string SpeakerName
        {
            get { return _speakerName; }
            set { SetProperty(ref _speakerName, value, "SpeakerName"); }
        }
        private string _speakerBioLink;
        public string SpeakerBioLink
        {
            get { return _speakerBioLink; }
            set { SetProperty(ref _speakerBioLink, value, "SpeakerBioLink"); }
        }
        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set { SetProperty(ref _startTime, value, "StartTime"); }
        }
        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set { SetProperty(ref _endTime, value, "EndTime"); }
        }
     }
}
