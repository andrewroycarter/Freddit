namespace Freddit

open System
open FSharp.Data

type RedditPage = JsonProvider<"""
{
    "kind": "Listing",
    "data": {
        "children": [
            {
                "kind": "t3",
                "data": {
                    "subreddit_name_prefixed": "r/science",
                    "subreddit": "science",
                    "selftext": "Hello everyone,\n\nEarlier today [President Trump announced his intention to exit the Paris Climate Agreement](https://www.washingtonpost.com/politics/trump-to-announce-us-will-exit-paris-climate-deal/2017/06/01/fbcb0196-46da-11e7-bcde-624ad94170ab_story.html?). While r/science does not take a stance on political issues, we feel the need to reaffirm our commitment to solid science, and in that regard we strongly disagree with these actions. [Climate change is real](https://climate.nasa.gov/) and it's happening right now. [There is still time left to do something about it](https://www.nature.org/ourinitiatives/urgentissues/global-warming-climate-change/index.htm), but this requires the actions of all people of the world. \n\nWe decided to create this thread to welcome discussion and questions from the users about climate change and the Paris Agreement. We will be moderating this thread [less heavily than we normally do](https://www.reddit.com/r/science/wiki/rules), but we still ask that you be civil and respectful in the comments.  Comments that go against established science must include **peer-reviewed** citations, and egregious dismissals may result in bans.",
                    "author": "rseasmith",
                    "score": 5492,
                    "downs": 0,
                    "permalink": "/r/science/comments/6erjjd/rscience_stands_with_the_paris_climate_agreement/",
                    "url": "https://www.reddit.com/r/science/comments/6erjjd/rscience_stands_with_the_paris_climate_agreement/",
                    "title": "r/science Stands with the Paris Climate Agreement",
                    "created_utc": 1496369189.0,
                    "num_comments": 580,
                    "ups": 5492
                }
            }
        ],
        "after": "t3_6eo5tn",
        "before": null
    }
}
""">