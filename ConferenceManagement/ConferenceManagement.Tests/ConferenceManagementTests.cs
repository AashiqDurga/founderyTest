using System;
using System.Collections.Generic;
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

            var result = talksParser.Parse(@"C:\src\FounderyTest\founderyTest\ConferenceManagement\ConferenceManagement\input.txt");

            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GivenAListOfTalks_WhenCreatingTheMorningSession_ThenCreateASessionFor180Minutes()
        {
            var listOfTalks = new List<Talk>()
            {
                new Talk("Writing Fast Tests Against Enterprise Rails", 60),
                new Talk("Overdoing it in Python", 60),
                new Talk("Lua for the Masses", 60),
                new Talk("Ruby Errors from Mismatched Gem Versions", 60),
                new Talk("Common Ruby Errors", 60),
                new Talk("Rails for Python Developers", 60),
                new Talk("Communicating Over Distance", 60),
                new Talk("Accounting-Driven Development", 60),
                new Talk("Woah", 60),
                new Talk("Sit Down and Write", 60),
                new Talk("Pair Programming vs Noise", 60),
                new Talk("Rails Magic", 60),
                new Talk("Ruby on Rails: Why We Should Move On", 60),
                new Talk("Clojure Ate Scala (on my project)", 60),
                new Talk("Programming in the Boondocks of Seattle", 60),
                new Talk("Ruby vs. Clojure for Back-End Development", 60),
                new Talk("Ruby on Rails Legacy App Maintenance", 60),
                new Talk("A World Without HackerNews", 60),
                new Talk("User Interface CSS in Rails Apps ", 60),
            };
        }
    }
}
