using System.Collections.ObjectModel;
using System.Data.Entity;
using PollProject.Domain;

namespace PollProject.DAL.EF
{
    /// <summary>
    /// Initialize database with data
    /// </summary>
    public class PollDataSeedInitializer : CreateDatabaseIfNotExists<CodeFirstRepository>
    {
        protected override void Seed(CodeFirstRepository context)
        {
            var poll1 = new Poll
                            {
                                Title = "Place for living",
                                Questions = new Collection<Question>
                                                {
                                                    new SingleSelectionQuestion
                                                        {
                                                            Title = "What part of the world would you like to live?",
                                                            Answers = new Collection<Answer>
                                                                          {
                                                                              new Answer { Title = "Europe" },
                                                                              new Answer { Title = "Asia" },
                                                                              new Answer { Title = "North America"},
                                                                              new Answer {Title = "South America"},
                                                                              new Answer {Title = "Africa"},
                                                                              new Answer {Title = "Australia"},
                                                                              new Answer {Title = "Antarctica"},
                                                                              new Answer {Title = "Outside Earth"}
                                                                          }
                                                        },
                                                    new MultiSelectionQuestion
                                                        {
                                                            Title = "When choosing a place, what are the most important aspects you take into account?",
                                                            Answers = new Collection<Answer>
                                                                          {
                                                                              new Answer {Title = "Living conditions"},
                                                                              new Answer {Title = "People's behaviour"},
                                                                              new Answer {Title = "Career opportunities"},
                                                                              new Answer {Title = "Ability to travel"},
                                                                              new Answer {Title = "Absence of people around you"},
                                                                              new Answer {Title = "Ability to have gun"}
                                                                          }
                                                        },
                                                    new TextQuestion
                                                        {
                                                            Title = "Please provide additional comments if any"
                                                        }
                                                }
                            };

            var poll2 = new Poll
                            {
                                Title = "Football",
                                Questions = new Collection<Question>
                                                {
                                                    new TextQuestion
                                                        {
                                                            Title = "What is your favorite football team?"
                                                        },
                                                    new SingleSelectionQuestion
                                                        {
                                                            Title = "Which team will win Champions League this year?",
                                                            Answers = new Collection<Answer>
                                                                          {
                                                                              new Answer {Title = "Barcelona"},
                                                                              new Answer {Title = "Real Madrid"},
                                                                              new Answer {Title = "Malaga"},
                                                                              new Answer {Title = "Bayern Munchen"},
                                                                              new Answer {Title = "Galatasaray"},
                                                                              new Answer {Title = "Juventus"},
                                                                              new Answer {Title = "PSG"},
                                                                              new Answer {Title = "Borussia Dortmund"}
                                                                          }
                                                        },
                                                    new MultiSelectionQuestion
                                                        {
                                                            Title = "Where would you like to see next Euro?",
                                                            Answers = new Collection<Answer>
                                                                          {
                                                                              new Answer {Title = "Netherlands"},
                                                                              new Answer {Title = "France"},
                                                                              new Answer {Title = "Englang"},
                                                                              new Answer {Title = "Germany"},
                                                                              new Answer {Title = "Italy"}
                                                                          }
                                                        },
                                                    new SingleSelectionQuestion
                                                        {
                                                            Title = "What is your gender?",
                                                            Answers = new Collection<Answer>
                                                                          {
                                                                              new Answer {Title = "Female"},
                                                                              new Answer {Title = "Male"},
                                                                              new Answer {Title = "I don't know"},
                                                                              new Answer {Title = "Other"}
                                                                          }
                                                        }
                                                }
                            };

            context.Add(poll1);
            context.Add(poll2);
            context.SaveChanges();
        }
    }
}