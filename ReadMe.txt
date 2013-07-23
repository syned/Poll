Description and thoughts:
Used Entity Framework Code First instead plain SQL
Didn't optimize queries from lazy loading and n+1 queries
Separate object model from Web and use View Models
Didn't use any DI container
Client side load all questions and them display them one by one, if questions are heavyweight (e.g. include images) need to implement other approach, when every step is loading by clicking next button.