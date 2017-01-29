using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ConferenceManagement.Entities;
using ConferenceManagement.Factories;
using ConferenceManagement.Helpers;
using ConferenceManagement.Services;
using NUnit.Framework;

namespace ConferenceManagement.Tests
{
    [TestFixture]
    public class ConferenceManagementTests
    {
        [Test]
        public void GivenALineContaining_lighning_WhenParsing_ReturnTheTopicIfLightningIsTheDuration()
        {
            var line = "Rails for Python Developers lightning";
            var topic = TalkAnalizer.GetTopic(line);

            Assert.That(topic, Is.EqualTo("Rails for Python Developers"));
        }

        [Test]
        public void GivenALineNOtContaining_lighning_WhenParsing_ReturnTheTopic()
        {
            var line = "Writing Fast Tests Against Enterprise Rails 60min";
            var topic = TalkAnalizer.GetTopic(line);

            Assert.That(topic, Is.EqualTo("Writing Fast Tests Against Enterprise Rails"));
        }

        [Test]
        public void GivenAnInputTextFileWithTopicsAndDuration_ThenCreateAListOfTalks()
        {

            var talksParser = new TalkParser();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            var localPath = new Uri(path).LocalPath;
            var result = talksParser.Parse(localPath + @"\input.txt");

            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GivenAListOfTalks_WhenCreatingTheMorningSession_ThenCreateASessionFor180Minutes()
        {
            var listOfTalks = getListOfTalks();
            var factory = new SessionFactory();

            var morningSession = factory.CreateMorningSession(listOfTalks);

            Assert.That(morningSession.Sum(x => x.Duration), Is.LessThanOrEqualTo(180));
        }

        [Test]
        public void GivenAListOfTalks_WhenCreatingTheAfternoon_ThenCreateASessionLessThanOrEqualTo240Minutes()
        {
            var listOfTalks = getListOfTalks();
            var factory = new SessionFactory();

            var afternoonSession = factory.CreateAfternoonSession(listOfTalks);

            Assert.That(afternoonSession.Sum(x => x.Duration), Is.LessThanOrEqualTo(240));
        }

        [Test]
        public void IfTrackHasReachedCapacity_ThenCreateNewTrack()
        {
            var trackService = new TrackService();
            var traks = trackService.CreateTracks(getListOfTalks());

            Assert.That(traks.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void WhenCreatingATrack_MakeSureEachSessionHasNoDuplicates()
        {
            var trackService = new TrackService();
            var track = trackService.CreateTracks(getListOfTalks());

            Assert.That(track.First().MorningSesion, Is.Unique);
            Assert.That(track.First().AfternoonSession, Is.Unique);
        }

        private List<Talk> getListOfTalks()
        {
            return new List<Talk>()
            {
                new Talk("Writing Fast Tests Against Enterprise Rails", 60),
                new Talk("Overdoing it in Python", 45),
                new Talk("Lua for the Masses", 30),
                new Talk("Ruby Errors from Mismatched Gem Versions", 45),
                new Talk("Common Ruby Errors", 45),
                new Talk("Rails for Python Developers", 5),
                new Talk("Communicating Over Distance", 60),
                new Talk("Accounting-Driven Development", 45),
                new Talk("Woah", 30),
                new Talk("Sit Down and Write", 45),
                new Talk("Pair Programming vs Noise", 60),
                new Talk("Rails Magic", 60),
                new Talk("Ruby on Rails: Why We Should Move On", 60),
                new Talk("Clojure Ate Scala (on my project)", 45),
                new Talk("Programming in the Boondocks of Seattle", 30),
                new Talk("Ruby vs. Clojure for Back-End Development", 30),
                new Talk("Ruby on Rails Legacy App Maintenance", 60),
                new Talk("A World Without HackerNews", 30),
                new Talk("User Interface CSS in Rails Apps ", 30),
            };
        }
    }
}
